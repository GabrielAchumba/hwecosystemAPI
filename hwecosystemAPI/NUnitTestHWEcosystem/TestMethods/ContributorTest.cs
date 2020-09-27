using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using hwecosystemAPI.Models;
using NUnit.Framework;

namespace NUnitTestHWEcosystem.TestMethods
{
    public class ContributorTest
    {
        HttpClient client;
        Guid id = Guid.NewGuid();
        string baseUrl;
        string controllerName = "contributors";

        [SetUp]
        public void Setup()
        {
            string baseUrl = "http://localhost:59275/";
            client = new HttpClient();
            client.BaseAddress = new System.Uri(baseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        [Test]
        public async Task Test1()
        {
            string requestUri = "api/contributors";
            var response = await client.GetAsync(requestUri);
            IEnumerable<Contributor> contributors = new List<Contributor>();

            if (response.IsSuccessStatusCode)
                contributors = await response.Content.ReadAsAsync<IEnumerable<Contributor>>();

            Assert.IsTrue(contributors != null);
        }
    }
}
