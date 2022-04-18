using DevEduEducationSystem.API.Tests.Support.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DevEduEducationSystem.API.Tests.Support.MethodForTests
{
    public class Get
    {
        public List<RegistrationResponsesModel> GetUserById(string token, int id)
        {
            List<RegistrationResponsesModel> user = new List<RegistrationResponsesModel>();
            string url = $"https://piter-education.ru:7070/api/Users/{id}";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpRequestMessage request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url),
            };

            HttpResponseMessage response = client.Send(request);

            string s = response.Content.ReadAsStringAsync().Result;

            HttpStatusCode expected = HttpStatusCode.OK;
            HttpStatusCode actual = response.StatusCode;

            Assert.AreEqual(expected, actual);
            user.Add(JsonSerializer.Deserialize<RegistrationResponsesModel>(s));
            return user;
        }
    }
}
