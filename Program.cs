using Newtonsoft.Json;
using System;
using System.Net.Http;
//using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace autosuggest
{
    class Program
    {
        
        static string host = "https://leela-autosuggest.cognitiveservices.azure.com";
        static string path = "/bing/v7.0/Suggestions";
        static string market = "en-US";
        static string key = "03c40bcea7fc47319d922cce10cd3380";

        static string query = "hi";

        
        async static void Autosuggest()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", key);

            
            string uri = host + path + "?mkt=" + market + "&query=" + System.Net.WebUtility.UrlEncode(query);

            HttpResponseMessage response = await client.GetAsync(uri);

            string contentString = await response.Content.ReadAsStringAsync();
            dynamic parsedJson = JsonConvert.DeserializeObject(contentString);
            Console.WriteLine(JsonConvert.SerializeObject(parsedJson, Formatting.Indented));
            
        }

        static void Main(string[] args)
        {
            Autosuggest();
            Console.ReadLine();
        }
    }
}