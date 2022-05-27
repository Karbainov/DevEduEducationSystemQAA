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
        public static List<RegistrationResponseModel> Registration(List<RegistrationRequestModel> userModel)
        {
            List<RegistrationResponseModel> userResponses = new List<RegistrationResponseModel>();
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
                userResponses.Add(JsonSerializer.Deserialize<RegistrationResponseModel>(s));
            }
            return userResponses;
        }

        public static RegistrationResponseModel RegistrationReturnModel (RegistrationRequestModel userModel)
        {
            string url = "https://piter-education.ru:7072/register";
            string json = JsonSerializer.Serialize(userModel);
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
            return JsonSerializer.Deserialize<RegistrationResponseModel>(s);
        }

        public HttpResponseMessage Registration(RegistrationRequestModel userModel)
        {
            List<RegistrationResponseModel> userResponses = new List<RegistrationResponseModel>();
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
            HttpStatusCode expected = HttpStatusCode.Forbidden;
            HttpStatusCode actual = response.StatusCode;
            Assert.AreEqual(expected, actual);           
        }
    }
}
