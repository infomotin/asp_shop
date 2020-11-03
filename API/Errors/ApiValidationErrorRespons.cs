using System.Collections.Generic;

namespace API.Errors
{
    public class ApiValidationsErrorRespons : ApiResponse
    {
        public ApiValidationsErrorRespons() : base(4000)
        {

        }
        public IEnumerable<string> Error {get;set;}
    }
}