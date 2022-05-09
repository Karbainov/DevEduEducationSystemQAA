using DevEduEducationSystem.API.Tests.Support.Models;
using DevEduEducationSystem.API.Tests.Support.Models.CourseResponseModelForAdd;
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

      private static HttpResponseMessage _statusCodeCreateGroup;
      private static HttpResponseMessage _statusCodeCreatePayment;
      private static HttpResponseMessage _statusCodeCreateHomework;

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

        public static PaymentResponseModel CreateOnePayment(string token, PaymentRequestModel payment)
        {
            string url = "https://piter-education.ru:7072/api/Payments";
            string json = JsonSerializer.Serialize<PaymentRequestModel>(payment);
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
            _statusCodeCreatePayment = response;
            return JsonSerializer.Deserialize<PaymentResponseModel>(s);
        }

        public static HttpResponseMessage CreateOnePayment()
        {
            return _statusCodeCreatePayment;
        }

        public static List<PaymentResponseModel> CreatePayments(List<PaymentRequestModel> payments, string token)
        {
            string url = "https://piter-education.ru:7072/api/Payments/bulk";
            string json = JsonSerializer.Serialize<List<PaymentRequestModel>>(payments);
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

            HttpStatusCode expected = HttpStatusCode.OK;
            HttpStatusCode actual = response.StatusCode;
            Assert.AreEqual(expected, actual);
            _statusCodeCreatePayment = response;
            return JsonSerializer.Deserialize<List<PaymentResponseModel>>(s);
        }

        public static TaskResponseModel CreateTaskByMethodist(string token, TaskMethodistRequestModel taskMethodist)
        {
            string url = "https://piter-education.ru:7072/api/Tasks/methodist";
            string json = JsonSerializer.Serialize<TaskMethodistRequestModel>(taskMethodist);
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
            _statusCodeCreatePayment = response;
            return JsonSerializer.Deserialize<TaskResponseModel>(s);
        }

        public static HomeworkResponseModel CreateHomework(string token, int taskId, int groupeId,HomeworkRequestModel homework)
        {
            string url = $"https://piter-education.ru:7072/api/Homeworks/group/{groupeId}/task/{taskId}";
            string json = JsonSerializer.Serialize<HomeworkRequestModel>(homework);
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
            _statusCodeCreateHomework = response;
            HttpStatusCode expected = HttpStatusCode.Created;
            HttpStatusCode actual = response.StatusCode;
            Assert.AreEqual(expected, actual);
            _statusCodeCreatePayment = response;
            return JsonSerializer.Deserialize<HomeworkResponseModel>(s);
        }

        public static HttpResponseMessage CreateHomework()
        {
            return _statusCodeCreateHomework;
        }

        public static StudentHomeworkResponseModel CreateStudentHomework(StudentHomeworkRequestModel studentHomework,string token,int idHomework)
        {
            string url = $"https://piter-education.ru:7072/api/student-homeworks/{idHomework}";
            string json = JsonSerializer.Serialize<StudentHomeworkRequestModel>(studentHomework);
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
            _statusCodeCreateHomework = response;
            HttpStatusCode expected = HttpStatusCode.Created;
            HttpStatusCode actual = response.StatusCode;
            Assert.AreEqual(expected, actual);
            _statusCodeCreatePayment = response;
            return JsonSerializer.Deserialize<StudentHomeworkResponseModel>(s);
        }

        public static CommentResponeseModel CreateComment(string token,int idStudentHomework, CommentRequestModel comment)
        {
            string url = $"https://piter-education.ru:7072/api/Comments/to-student-answer/{idStudentHomework}";
            string json = JsonSerializer.Serialize<CommentRequestModel>(comment);
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
            _statusCodeCreateHomework = response;
            HttpStatusCode expected = HttpStatusCode.Created;
            HttpStatusCode actual = response.StatusCode;
            Assert.AreEqual(expected, actual);
            _statusCodeCreatePayment = response;
            return JsonSerializer.Deserialize<CommentResponeseModel>(s);
        }
        public static LessonResponseModel CreateLesson (string token, LessonRequestModel lesson)
        {
            string url = "https://piter-education.ru:7072/api/Lessons";

            string json = JsonSerializer.Serialize<LessonRequestModel>(lesson);
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

            return JsonSerializer.Deserialize<LessonResponseModel>(s);
        }

        public static void AddGroupLesson (string token, int groupId, int lessonId)
        {
            string url = $"https://piter-education.ru:7072/api/Groups/{groupId}/lesson/{lessonId}";

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
        public static StudentHomeworkResponseModel AddDeclineStudentHomework(string token, int idStudentHomework)
        {
            string url = $"https://piter-education.ru:7072/api/student-homeworks/{idStudentHomework}/decline";
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
            return JsonSerializer.Deserialize<StudentHomeworkResponseModel>(s);
        }

        public static StudentHomeworkResponseModel AddApproveStudentHomework(string token, int idStudentHomework)
        {
            string url = $"https://piter-education.ru:7072/api/student-homeworks/{idStudentHomework}/approve";
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
            return JsonSerializer.Deserialize<StudentHomeworkResponseModel>(s);
        }
    }
}
