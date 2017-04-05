using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using RichardSzalay.MockHttp;
using Lib;

namespace Tests
{
    [TestClass]
    public class HttpClientWrapperTests
    {
        private const string JsonMediaType = "application/json";

        [TestMethod]
        public void TestGetUserAsyncJson()
        {
            var jObject = new JObject()
            {
                { "Test1", 1 },
                { "Test2", 2 },
                { "Test3",
                    new JArray
                    {
                        new JObject
                        {
                            { "Test4", "4" },
                        },
                    }
                },
            };

            var mockHttp = new MockHttpMessageHandler();

            string jsonResponse = jObject.ToString(Newtonsoft.Json.Formatting.None);

            // Setup a respond for the user api (including a wildcard in the URL)
            mockHttp.When("https://jsonplaceholder.typicode.com/users/*")
                    .Respond(JsonMediaType, jsonResponse); // Respond with JSON

            // Inject the handler into your application code
            HttpClientWrapper client = new HttpClientWrapper(mockHttp);

            var userJson = client.GetUserAsyncJson().Result;
            Assert.IsTrue(JToken.DeepEquals(jObject, userJson));
        }

        [TestMethod]
        public void TestGetUserAsync()
        {
            var jObject = new JObject()
            {
                { "Test1", 1 },
                { "Test2", 2 },
                { "Test3",
                    new JArray
                    {
                        new JObject
                        {
                            { "Test4", "4" },
                        },
                    }
                },
            };

            var mockHttp = new MockHttpMessageHandler();

            string jsonResponse = jObject.ToString(Newtonsoft.Json.Formatting.None);

            // Setup a respond for the user api (including a wildcard in the URL)
            mockHttp.When("https://jsonplaceholder.typicode.com/users/*")
                    .Respond(JsonMediaType, jsonResponse); // Respond with JSON

            // Inject the handler into your application code
            HttpClientWrapper client = new HttpClientWrapper(mockHttp);

            var userJson = client.GetUserAsync().Result;
            Assert.AreEqual(jObject.ToString(), userJson);
        }
    }
}
