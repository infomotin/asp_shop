using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;
// this class are using for data insert with json formate 
namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        
        public static async Task SeedAsync(StoreContext context,ILoggerFactory iloggerFactory){
            try
            {
                if(!context.ProductBrand.Any()){
                    var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData); 
                    foreach (var item in brands)
                    {
                        context.ProductBrand.Add(item);
                        
                    }
                    await context.SaveChangesAsync();
                }

                if(!context.ProductType.Any()){
                    var typesData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData); 
                    foreach (var item in types)
                    {
                        context.ProductType.Add(item);
                        
                    }
                    await context.SaveChangesAsync();
                }
                if(!context.Products.Any()){
                    var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                    var types = JsonSerializer.Deserialize<List<Product>>(productsData); 
                    foreach (var item in types)
                    {
                        context.Products.Add(item);
                        
                    }
                    await context.SaveChangesAsync();
                }


            }
            catch(Exception ex){
                var logger = iloggerFactory.CreateLogger<StoreContextSeed>();
                    logger.LogError(ex.Message);
            }
            
        }
    }
}