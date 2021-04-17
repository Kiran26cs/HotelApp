using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HotelWebApp.Models;
using Newtonsoft.Json;
namespace HotelWebApp.Services
{
    public static class ApiHelper
    {
        public static O GetFromApi<O, I>(string url)
        {
            O resp = default(O);
            using (var client = new HttpClient())
            {
                var resourcerul = url.Split("api")[0];
                client.BaseAddress = new Uri(resourcerul);
                //HTTP GET
                var responseTask = client.GetAsync(string.Format("api/{0}", url.Split("api/")[1]));
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<O>();
                    readTask.Wait();

                    resp = readTask.Result;                    
                }
            }
            return resp;
        }

        public static O PostToApi<O, I>(string url, I request)where O:Error
        {
            O resp = default(O);
            using (var client = new HttpClient())
            {
                var resourcerul = url.Split("api")[0];
                client.BaseAddress = new Uri(resourcerul);
                var response = client.PostAsJsonAsync(string.Format("api/{0}",url.Split("api/")[1]), request ).Result;
                var responseString = response.Content.ReadAsStringAsync().Result;
                if (response.IsSuccessStatusCode)
                {
                    resp = JsonConvert.DeserializeObject<O>(responseString);
                }
                resp.isError = !response.IsSuccessStatusCode;
            }
            return resp;
        }
    }
}
