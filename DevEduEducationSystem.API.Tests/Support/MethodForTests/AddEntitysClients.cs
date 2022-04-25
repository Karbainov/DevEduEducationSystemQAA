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
        public static CourseResponsesModel CreateCourse(string token, CourseRequestModel course)
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
            return JsonSerializer.Deserialize<CourseResponsesModel>(s);
        }

        public static GroupResponsesModel CreateGroupe(string token, GroupRequestModel group)
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
            Assert.AreEqual(expected, actual);
            return JsonSerializer.Deserialize<GroupResponsesModel>(s); 
        }
    }
}
