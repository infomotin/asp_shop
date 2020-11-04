using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Core.Interfaces;
using AutoMapper;
using API.Helpers;
using API.Middleware;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using API.Errors;

namespace API
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {   
            //Adding this services for ProductRepository [interface,thenimplemeted class]
            services.AddScoped<IProductRepository,ProductRepository>();
            //Universal Repository To Adding on Services 
            services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            //this services are adding for AutoMapper 
            services.AddAutoMapper(typeof(MappingProfile));
            //for all controllers adding this services 
            services.AddControllers();
            //this services for database class 
            services.AddDbContext<StoreContext>(x => x.UseSqlite(_configuration.GetConnectionString("DefaultConnection")));
            // Error Exception hendeller With Options 
            services.Configure<ApiBehaviorOptions>(options =>{
                options.InvalidModelStateResponseFactory = actionContext => {
                    var error = actionContext.ModelState
                    .Where(e => e.Value.Errors.Count >0)
                    .SelectMany(x => x.Value.Errors)
                    .Select(x => x.ErrorMessage).ToArray();

                    var errorResponse = new ApiValidationsErrorRespons{
                        Error = error
                    };
                    return new BadRequestObjectResult(errorResponse);
                };
            });
            services.AddSwaggerGen(c => c.SwaggerDoc("V1", new Microsoft.OpenApi.Models.OpenApiInfo {Title = "Skinet API", Version ="V1"}));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // if (env.IsDevelopment())
            // {
            //     app.UseDeveloperExceptionPage();
            // }
            //adding middlware that are describe on Errors folder Class 
            app.UseMiddleware<ExceptionMiddleware>();
            // //using for Error Status Code place holder positions "/error/{0}" 
            // if any request come into api but dont any end poit asinge to them ,then request go error helldeler 
            app.UseStatusCodePagesWithReExecute("/error/{0}");
            app.UseHttpsRedirection();

            app.UseRouting();
            //For Using Static File As HTML Public Like Django 
            app.UseStaticFiles();

            app.UseAuthorization();
            //for pop up libray 
            app.UseSwagger();
            // which url are are Shoing pop up Message '
            app.UseSwaggerUI(c => {c.SwaggerEndpoint("/swagger/v1/swagger.json","Swagger API V1");});
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
