using DevEduEducationSystem.API.Tests.Support.Models;
using DevEduEducationSystem.API.Tests.Support.Models.RequestModels;
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
    public class AddEntitysClients
    {

       static HttpResponseMessage _statusCodeCreateGroup;
        public static CourseResponseModel CreateCourse(string token, CourseRequestModel course)
        {
            string url = "https://piter-education.ru:7072/api/Courses";
            string json = JsonSerializer.Serialize<CourseRequestModel>(course);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
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
            return JsonSerializer.Deserialize<CourseResponseModel>(s);
        }

        public static GroupResponseModel CreateGroupe(string token, GroupRequestModel group)
        {
            string url = "https://piter-education.ru:7072/api/Groups";
            string json = JsonSerializer.Serialize<GroupRequestModel>(group);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
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
            _statusCodeCreateGroup = response;
            Assert.AreEqual(expected, actual);
            return JsonSerializer.Deserialize<GroupResponseModel>(s); 
        }

         public static HttpResponseMessage CreateGroupe()
        {
            return _statusCodeCreateGroup;
        }

        public static void AddUserInGroup(int groupId, int userId, string roleId, string token)
        {
            // сделать проверку на id 
            string url = $"https://piter-education.ru:7072/api/Groups/{groupId}/user/{userId}/role/{roleId}";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpRequestMessage request = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(url),
            };
            HttpResponseMessage response = client.Send(request);
            string s = response.Content.ReadAsStringAsync().Result;
            HttpStatusCode expected = HttpStatusCode.NoContent;
            HttpStatusCode actual = response.StatusCode;
            Assert.AreEqual(expected, actual);
        }

        public static TopicResponseModel CreateTopic (string token, TopicRequestModel topic)
        {
            string url = "https://piter-education.ru:7072/api/Topics";
            string json = JsonSerializer.Serialize<TopicRequestModel>(topic);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
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

            return JsonSerializer.Deserialize<TopicResponseModel>(s);
        }


    }
}
