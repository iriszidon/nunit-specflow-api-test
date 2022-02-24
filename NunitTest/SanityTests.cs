using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;


namespace NunitTest
{
    public class SanityTests
    {
        private HttpResponseMessage response;
        //private string server = "http://dummy.restapiexample.com";

        [Test]
        public async Task GetApiResponse()
        {
            //Create request object
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri($"https://jsonplaceholder.typicode.com/todos/1"));
            //request.Headers.Add();
            request.Content = new StringContent(
                JsonConvert.SerializeObject(new { description = "Iris Test" }),
                Encoding.UTF8, "application/json");
            // Send the request to the server 
            HttpClient client = new HttpClient();
            response = await client.SendAsync(request);
            // Process the response to a readable type
            string serializerdRresultFromController = JsonConvert.SerializeObject(response, Formatting.Indented);
            var responseDataObject = response.Content.ReadAsStringAsync();
            string serializedData = JsonConvert.SerializeObject(responseDataObject);
            PlatinumeUser platinumeUser = JsonConvert.DeserializeObject<PlatinumeUser>(serializedData);
            // Assert
            Console.WriteLine(responseDataObject.Result);
            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK);
            Assert.IsTrue(platinumeUser.Id == 1);
            //Assert.IsTrue(platinumeUser.Title.Contains("delectus"));
            Assert.False(platinumeUser.completed);
        }
        [Test]
        public void ReturnMinimalValueInTree()
        {
            List<int> intList = new List<int>() { 91, -71, 1, 0, 2, 3, -3, 4, 80, 5, 7, 2, 8, 9, 90, 91, -2 };
            intList.Add(1);
            intList.Add(67);
            intList.Add(3);
            intList.Add(2);
            intList.Add(90);
            intList.Sort();
            Assert.True(intList.First() == -71, $"[{intList.First()}");
        }

        public class PlatinumeUser
        {
            public int Id { get; set; } 
            public string UserId { get; set; }
            public string Title { get; set; }
            public bool completed { get; set; }

        }
    }
}
