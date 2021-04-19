using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Hotel.Auth.Api.Manager
{
    public static class AppHelper
    {
        public static O ConvertToObject<I, O>(this I input)
        {
            O resp = default(O);
            var convertedInputJson = JsonConvert.SerializeObject(input);
            if (!string.IsNullOrEmpty(convertedInputJson))
            {
                resp = JsonConvert.DeserializeObject<O>(convertedInputJson);
            }
            return resp;
        }
    }
}
