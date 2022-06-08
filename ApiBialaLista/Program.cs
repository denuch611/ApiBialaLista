using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text;
using System.Text.Json;
using System.IO;

namespace ApiBialaLista
{
    class Program
    {
        static void Main(string[] args)
     
        {
            var url = "https://wl-api.mf.gov.pl";
            var nip = "9721290903";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync($"/api/search/nip/{nip}?date={DateTime.Now.ToString("yyyy-MM-dd")}").Result; 
            if (response.IsSuccessStatusCode)
            {
                string products = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(products);
            }
            Console.WriteLine(response);
         
        }

    }
}
