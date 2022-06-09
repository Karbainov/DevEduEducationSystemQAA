using DevEduEducationSystem.API.Tests.Support.Models;
using DevEduEducationSystem.API.Tests.Support.Models.RequestModels;
using DevEduEducationSystem.API.Tests.Support.Models.ResponseModels;
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
    public class UpdateClient
    {
        public static void UpdateUser(RegistrationResponseModel newUserModel, int id, string token)
        {           
                string url = $"https://piter-education.ru:7072/api/Users/{id}";
                string json = JsonSerializer.Serialize(newUserModel);
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpRequestMessage request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Put,
                    RequestUri = new Uri(url),
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                };
                HttpResponseMessage response = client.Send(request);
                string s = response.Content.ReadAsStringAsync().Result;
                HttpStatusCode expected = HttpStatusCode.Created;
                HttpStatusCode actual = response.StatusCode;
                Assert.AreEqual(expected, actual);
        }

        public static void UpdateGroup(int idGroup, GroupRequestModel groupUpdate, string token)
        {
            groupUpdate.GroupStatusId = "1";
            string url = $"https://piter-education.ru:7072/api/Groups/{idGroup}";
            string json = JsonSerializer.Serialize(groupUpdate);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpRequestMessage request = new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri(url),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage response = client.Send(request);
            string s = response.Content.ReadAsStringAsync().Result;
            HttpStatusCode expected = HttpStatusCode.OK;
            HttpStatusCode actual = response.StatusCode;
            Assert.AreEqual(expected, actual);
        }

        public static CourseResponseModel UpdateCourse(CourseRequestModel newCourseModel, int id, string token)
        {
            string url = $"https://piter-education.ru:7072/api/Courses/{id}";
            string json = JsonSerializer.Serialize(newCourseModel);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpRequestMessage request = new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri(url),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage response = client.Send(request);
            string s = response.Content.ReadAsStringAsync().Result;
            HttpStatusCode expected = HttpStatusCode.OK;
            HttpStatusCode actual = response.StatusCode;
            Assert.AreEqual(expected, actual);
            return JsonSerializer.Deserialize<CourseResponseModel>(s);
        }

        public static List<CourseResponseModel> UpdateCourseAddTopic (List<CourseAndTopicRequestModelADD> modelTopicForCourse, int idCourse, string token)
        {
            string url = $"https://piter-education.ru:7072/api/Courses/{idCourse}/program";
            string json = JsonSerializer.Serialize(modelTopicForCourse);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpRequestMessage request = new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri(url),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage response = client.Send(request);
            string s = response.Content.ReadAsStringAsync().Result;
            HttpStatusCode expected = HttpStatusCode.OK;
            HttpStatusCode actual = response.StatusCode;
            Assert.AreEqual(expected, actual);
            return JsonSerializer.Deserialize<List<CourseResponseModel>>(s);
        }

        public static GroupResponseMiniModel UpdateGroupStatus(int idGroup, string statusId, string token)
        {
            string url = $"https://piter-education.ru:7072/api/Groups/{idGroup}/status/{statusId}";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpRequestMessage request = new HttpRequestMessage()
            {
                Method = HttpMethod.Patch,
                RequestUri = new Uri(url),
            };
            HttpResponseMessage response = client.Send(request);
            string s = response.Content.ReadAsStringAsync().Result;
            HttpStatusCode expected = HttpStatusCode.OK;
            HttpStatusCode actual = response.StatusCode;
            Assert.AreEqual(expected, actual);
            return JsonSerializer.Deserialize<GroupResponseMiniModel>(s);

        }

        public static PaymentResponseModel UpdatePayment(PaymentRequestModel changePayment, int idPayment, string token)
        {
            string url = $"https://piter-education.ru:7072/api/Payments/{idPayment}";
            string json = JsonSerializer.Serialize(changePayment);
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpRequestMessage request = new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri(url),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage response = client.Send(request);
            string s = response.Content.ReadAsStringAsync().Result;
            HttpStatusCode expected = HttpStatusCode.OK;
            HttpStatusCode actual = response.StatusCode;
            Assert.AreEqual(expected, actual);
            return JsonSerializer.Deserialize<PaymentResponseModel>(s);
        }

        public static HomeworkResponseModel UpdateHomework(string token, HomeworkRequestModel homeworkUpdate, int homeworkId)
        {
            string url = $"https://piter-education.ru:7072/api/Homeworks/{homeworkId}";
            string json = JsonSerializer.Serialize(homeworkUpdate);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpRequestMessage request = new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri(url),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage response = client.Send(request);
            string s = response.Content.ReadAsStringAsync().Result;
            HttpStatusCode expected = HttpStatusCode.OK;
            HttpStatusCode actual = response.StatusCode;
            Assert.AreEqual(expected, actual);
            return JsonSerializer.Deserialize<HomeworkResponseModel>(s);
        }

        public static void MarkAttendance (string AttendanceType,int idStudent, int idLesson, string token)
        {
            string url = $"https://piter-education.ru:7072/api/Lessons/{idLesson}/student/{idStudent}/attendance/{AttendanceType}";

            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpRequestMessage request = new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri(url),
            };
            HttpResponseMessage response = client.Send(request);
            string s = response.Content.ReadAsStringAsync().Result;
            HttpStatusCode expected = HttpStatusCode.NoContent;
            HttpStatusCode actual = response.StatusCode;
            Assert.AreEqual(expected, actual);
        }

        public static LessonResponseModel UpdateLesson(LessonUpdateRequestModel lesson, int id, string token)
        {
            string url = $"https://piter-education.ru:7072/api/Lessons/{id}";
            string json = JsonSerializer.Serialize(lesson);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpRequestMessage request = new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri(url),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage response = client.Send(request);
            string s = response.Content.ReadAsStringAsync().Result;
            HttpStatusCode expected = HttpStatusCode.OK;
            HttpStatusCode actual = response.StatusCode;
            Assert.AreEqual(expected, actual);
            return JsonSerializer.Deserialize<LessonResponseModel>(s);
        }
    }
}
