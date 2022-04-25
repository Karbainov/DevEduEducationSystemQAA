using DevEduEducationSystem.API.Tests.Support.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DevEduEducationSystem.API.Tests.Support.MethodForTests
{
    public class AuthClient
    {
        public List<RegistrationResponsesModel> Registration(List<RegisterRequestModel> userModel)
        {
            List<RegistrationResponsesModel> userResponses = new List<RegistrationResponsesModel>();
            foreach (var user in userModel)
            {
                string url = "https://piter-education.ru:7072/register";
                string json = JsonSerializer.Serialize(user);
                HttpClient client = new HttpClient();
                HttpRequestMessage request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(url),
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                };
                HttpResponseMessage response = client.Send(request);
                string s = response.Content.ReadAsStringAsync().Result;
                HttpStatusCode expected = HttpStatusCode.Created;
                HttpStatusCode actual = response.StatusCode;
                Assert.AreEqual(expected, actual);
                userResponses.Add(JsonSerializer.Deserialize<RegistrationResponsesModel>(s));
            }
            return userResponses;
        }

        public HttpResponseMessage Registration(RegisterRequestModel userModel)
        {
            List<RegistrationResponsesModel> userResponses = new List<RegistrationResponsesModel>();
                string url = "https://piter-education.ru:7072/register";
                string json = JsonSerializer.Serialize(userModel);
                HttpClient client = new HttpClient();
                HttpRequestMessage request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(url),
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                };
            
            return client.Send(request);
        }

        public static string AuthUser(string email, string password)
        {
            string url = "https://piter-education.ru:7072/sign-in";
            LoginRequestModel login = new LoginRequestModel()
            {
                Email = email,
                Password = password,
            };
            string json = JsonSerializer.Serialize<LoginRequestModel>(login);
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(url),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage response = client.Send(request);
            string s = response.Content.ReadAsStringAsync().Result;
            HttpStatusCode expected = HttpStatusCode.OK;
            HttpStatusCode actual = response.StatusCode;
            Assert.AreEqual(expected, actual);
            string token = s;//JsonSerializer.Deserialize<string>(s);
            return token;
        }
        public static void AuthUserErrorForNegativeTest(string email, string password)
        {
            string url = "https://piter-education.ru:7072/sign-in";
            LoginRequestModel login = new LoginRequestModel()
            {
                Email = email,
                Password = password,
            };
            string json = JsonSerializer.Serialize<LoginRequestModel>(login);
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(url),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage response = client.Send(request);
            string s = response.Content.ReadAsStringAsync().Result;
            HttpStatusCode expected = HttpStatusCode.NotFound;
            HttpStatusCode actual = response.StatusCode;
            Assert.AreEqual(expected, actual);           
        }
    }
}
