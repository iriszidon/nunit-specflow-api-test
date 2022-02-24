using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Net.Http;
using System.Text;
using TechTalk.SpecFlow;
using System.Threading.Tasks;

namespace SpecFlowWithApiTests
{
    [Binding]
    public class ApiExampleTestsStepDefinitions
    {
        private string platinuUserId;
        private string redultPlatinuUserId;
        private HttpResponseMessage response;
        private HttpContent content;
        private HttpClient client;

        private int sumResult;
        private int firstNumber;
        private int secondNumber;

        [BeforeScenario("sanity")] 
        public void Setup()
        {
            this.content = new StringContent(
                JsonConvert.SerializeObject(new { description = "Iris Test" }),
                Encoding.UTF8, "application/json");
            this.client = new HttpClient();
        }

        [AfterScenario("sanity")]
        public void TearDown()
        {
            Console.WriteLine("Done ;-) ");
        }

        [Given(@"a platinum user id ""([^""]*)""")]
        public void GivenAPlatinumUserId(string id)
        {
            this.platinuUserId = id;
        }

        [When(@"I call method with endpoint todos")]
        public async Task WhenICallMethodWithEndpointTodosAsync()
        {
            //Create request object
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri($"https://jsonplaceholder.typicode.com/todos/1"));
            request.Content = this.content;
            // Send the request to the server 
            response = await this.client.SendAsync(request);
            // Process the response to a readable type
            string serializerdRresultFromController = JsonConvert.SerializeObject(response, Formatting.Indented);
            var responseDataObject = response.Content.ReadAsStringAsync();
            var serializedData = responseDataObject.Result;
            PlatinumeUser platinumeUser = JsonConvert.DeserializeObject<PlatinumeUser>(serializedData);
            this.redultPlatinuUserId = platinumeUser.UserId;
        }

        [Then(@"the returned id is ""([^""]*)""")]
        public void ThenTheReturnedIdIs(string id)
        {
            Assert.AreEqual(this.redultPlatinuUserId, id, $"{platinuUserId} is not equal to {redultPlatinuUserId}");
        }

        [Given(@"two numbers with values '(.*)' and '(.*)'")]
        public void TwoNumbers(int x, int y)
        {
            firstNumber = x; 
            secondNumber = y;
        }

        [When(@"I add two numbers")]
        public void AddTwoNumbers()
        {
            sumResult = firstNumber + secondNumber;
        }

        [Then(@"the sum of the numbers is '(.*)'")]
        public void TheSumIs(int sum)
        {
            Console.WriteLine($"{firstNumber} + {secondNumber} = {sumResult}");
            Assert.IsTrue(sumResult == sum, $"{firstNumber} + {secondNumber} does not == {sumResult}");
        }
    }
}
