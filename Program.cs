using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace WebAPIClient
{
    
    class TriviaQuestion
    {
        [JsonProperty("answer")]
        public string Answer { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("question")]
        public string Question { get; set; }

        
    }

    
    class Program
    {
        static async Task Main(string[] args)
        {
            await ProcessRepositories();
        }

        private static readonly HttpClient client = new HttpClient();
        
        private static async Task ProcessRepositories()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Press Enter to get a random trvia question");
                    var pokeName = Console.ReadLine();
                   
                    var result = await client.GetAsync("http://jservice.io/api/random");
                    var resultRead = await result.Content.ReadAsStringAsync();

                    var response = JsonConvert.DeserializeObject<List<TriviaQuestion>>(resultRead);
                    var a = response[0];

                    Console.WriteLine("---");
                    Console.WriteLine("#: " + a.Id);
                    
                    Console.WriteLine("Question: " + a.Question);
                    Console.WriteLine("Answer: " + a.Answer);
                    
                    Console.WriteLine("\n---");
                } catch(Exception e) {
                    Console.WriteLine("ERROR. API is down");
                    Console.WriteLine(e);
                
                }
                
            }
        }
    }

}



