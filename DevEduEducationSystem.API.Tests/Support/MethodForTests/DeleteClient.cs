using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DevEduEducationSystem.API.Tests.Support.MethodForTests
{
    public class DeleteClient
    {
        public static void DeleteUserById(string token, int id)
        {
            string url = $"https://piter-education.ru:7072/api/Users/{id}"; 

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpRequestMessage request = new HttpRequestMessage()
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(url),
            };

            HttpResponseMessage response = client.Send(request);

            string s = response.Content.ReadAsStringAsync().Result;

            HttpStatusCode expected = HttpStatusCode.NoContent;
            HttpStatusCode actual = response.StatusCode;

            Assert.AreEqual(expected, actual);
        }

        public static void DeleteCourseById(string token, int id)
        {
            string url = $"https://piter-education.ru:7072/api/Courses/{id}";

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpRequestMessage request = new HttpRequestMessage()
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(url),
            };

            HttpResponseMessage response = client.Send(request);

            string s = response.Content.ReadAsStringAsync().Result;

            HttpStatusCode expected = HttpStatusCode.NoContent;
            HttpStatusCode actual = response.StatusCode;

            Assert.AreEqual(expected, actual);
        }

        public static void DeleteGroupeById(string token, int id)
        {
            string url = $"https://piter-education.ru:7072/api/Groups/{id}";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpRequestMessage request = new HttpRequestMessage()
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(url),
            };
            HttpResponseMessage response = client.Send(request);
            string s = response.Content.ReadAsStringAsync().Result;
            HttpStatusCode expected = HttpStatusCode.NoContent;
            HttpStatusCode actual = response.StatusCode;
            Assert.AreEqual(expected, actual);
        }

        public static void DeleteUserFromGroup(string token, int idGroup, int idUser)
        {
            string url = $"https://piter-education.ru:7072/api/Groups/{idGroup}/user/{idUser}";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpRequestMessage request = new HttpRequestMessage()
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(url),
            };
            HttpResponseMessage response = client.Send(request);
            string s = response.Content.ReadAsStringAsync().Result;
            HttpStatusCode expected = HttpStatusCode.NoContent;
            HttpStatusCode actual = response.StatusCode;
            Assert.AreEqual(expected, actual);
        }

        public static void DeleteTopicOfCourseById(string token, int idCourse,int idTopic)
        {
            string url = $"https://piter-education.ru:7072/api/Courses/{idCourse}/topic/{idTopic}";

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpRequestMessage request = new HttpRequestMessage()
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(url),
            };

            HttpResponseMessage response = client.Send(request);

            string s = response.Content.ReadAsStringAsync().Result;

            HttpStatusCode expected = HttpStatusCode.NoContent;
            HttpStatusCode actual = response.StatusCode;

            Assert.AreEqual(expected, actual);
        }

        public static void DeletePayment(string token, int idPayment)
        {
            string url = $"https://piter-education.ru:7072/api/Payments/{idPayment}";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpRequestMessage request = new HttpRequestMessage()
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(url),
            };
            HttpResponseMessage response = client.Send(request);
            string s = response.Content.ReadAsStringAsync().Result;
            HttpStatusCode expected = HttpStatusCode.NoContent;
            HttpStatusCode actual = response.StatusCode;
            Assert.AreEqual(expected, actual);
        }

        public static void DeleteHomework(string token, int idHomework)
        {
            string url = $"https://piter-education.ru:7072/api/Homeworks/{idHomework}";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpRequestMessage request = new HttpRequestMessage()
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(url),
            };
            HttpResponseMessage response = client.Send(request);
            string s = response.Content.ReadAsStringAsync().Result;
            HttpStatusCode expected = HttpStatusCode.NoContent;
            HttpStatusCode actual = response.StatusCode;
            Assert.AreEqual(expected, actual);
        }

        public static void DeleteRoleFromUser(string token, string role, int idUser)
        {
            string url = $"https://piter-education.ru:7072/api/Users/{idUser}/role/{role}";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpRequestMessage request = new HttpRequestMessage()
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(url),
            };
            HttpResponseMessage response = client.Send(request);
            string s = response.Content.ReadAsStringAsync().Result;
            HttpStatusCode expected = HttpStatusCode.NoContent;
            HttpStatusCode actual = response.StatusCode;
            Assert.AreEqual(expected, actual);
        }
    }
}
