using DevEduEducationSystem.API.Tests.Support.Models;
using DevEduEducationSystem.API.Tests.Support.Models.AllGroupsModels;
using DevEduEducationSystem.API.Tests.Support.Models.StudentModelClassesForModel;
using DevEduEducationSystem.API.Tests.Support.Models.CourseResponseModelForAdd;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DevEduEducationSystem.API.Tests.Support.MethodForTests
{
    public class GetClient
    {
        public static RegistrationResponseModel GetUserById(string token, int id)
        {
            List<RegistrationResponseModel> user = new List<RegistrationResponseModel>();
            string url = $"https://piter-education.ru:7072/api/Users/{id}";
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
            
            return JsonSerializer.Deserialize<RegistrationResponseModel>(s);
        }

        public static StudentModel GetUserByIdReturnModel (string token, int id)
        {
            string url = $"https://piter-education.ru:7072/api/Users/{id}";
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

            return JsonSerializer.Deserialize<StudentModel>(s);
        }
        public static void GetUserByIdAfterDeleted(string token, int id)
        {
            string url = $"https://piter-education.ru:7072/api/Users/{id}";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpRequestMessage request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url),
            };

            HttpResponseMessage response = client.Send(request);
            string s = response.Content.ReadAsStringAsync().Result;
            HttpStatusCode expected = HttpStatusCode.NoContent;
            HttpStatusCode actual = response.StatusCode;
            Assert.AreEqual(expected, actual);
        }

        public static ReturnByIdGroupModel GetGroupById(int idGroup, string token) // должен возвращать модель большую группу
        {
            string url = $"https://piter-education.ru:7072/api/Groups/{idGroup}";
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
            return JsonSerializer.Deserialize<ReturnByIdGroupModel>(s);
        }

        public static CourseResponseFullModel GetCourseByIdCourseFullModel (string token, int id)
        {
            string url = $"https://piter-education.ru:7072/api/Courses/{id}/full";
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

            return JsonSerializer.Deserialize<CourseResponseFullModel>(s);
        }

        public static CourseResponseModel GetCourseByIdCourseSimpleModel(string token, int id)
        {
            string url = $"https://piter-education.ru:7072/api/Courses/{id}/simple";
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

            return JsonSerializer.Deserialize<CourseResponseModel>(s);
        }

        public static HttpResponseMessage GetClientByIdError (int id, string token)
        {            
            string url = $"https://piter-education.ru:7072/api/Courses/{id}/simple";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpRequestMessage request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url),               
            };  
            return client.Send(request);
        }
        public static List<AllUsersResponseModel> GetAllUsers (string token)
        {           
            string url = $"https://piter-education.ru:7072/api/Users";
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
            List< AllUsersResponseModel> allUsers = JsonSerializer.Deserialize<List<AllUsersResponseModel>>(s);
            return allUsers;
        }

        public static List<GroupResponseModel> GetAllGroups(string token)
        {
            string url = "https://piter-education.ru:7072/api/Groups";
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
            List<GroupResponseModel> allGroups = JsonSerializer.Deserialize<List<GroupResponseModel>>(s);
            return allGroups;
        }

        public static List<CourseResponseModel> GetAllCourses (string token)
        {
            string url = $"https://piter-education.ru:7072/api/Courses";
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
            List<CourseResponseModel> allCourses = JsonSerializer.Deserialize<List<CourseResponseModel>>(s);
            return allCourses;
        }

        public static List<CourseResponseModelWithPosition> GetAllTopicsOfCoursesById(string token, int id)
        {
            string url = $"https://piter-education.ru:7072/api/Courses/{id}/topics";
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
            List<CourseResponseModelWithPosition> allCourses = JsonSerializer.Deserialize<List<CourseResponseModelWithPosition>>(s);
            return allCourses;
        }

        public static PaymentResponseModel GetPaymentById(int id, string token)
        {
            string url = $"https://piter-education.ru:7072/api/Payments/{id}";
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
            return JsonSerializer.Deserialize<PaymentResponseModel>(s);
        }

        public static List<PaymentResponseModel> GetAllPaymentsByUserId(int userId,string token)
        {
            string url = $"https://piter-education.ru:7072/api/Payments/user/{userId}";
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
            return JsonSerializer.Deserialize<List<PaymentResponseModel>>(s);
        }

        public static GetHomeworkByIdResponseModel GetHomeworkById(string token,int homeworkId)
        {
            string url = $"https://piter-education.ru:7072/api/Homeworks/{homeworkId}";
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
            return JsonSerializer.Deserialize<GetHomeworkByIdResponseModel>(s);
        }

        public static List<GetAllHomeworkByGroupResponseModel> GetAllHomeworkByGroup(int idGroup,string token)
        {
            string url = $"https://piter-education.ru:7072/api/Homeworks/by-group/{idGroup}";
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
            return JsonSerializer.Deserialize<List<GetAllHomeworkByGroupResponseModel>>(s);
        }

        public static CommentResponeseModel GetCommentById(int idComment, string token)
        {
            string url = $"https://piter-education.ru:7072/api/Comments/{idComment}";
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
            return JsonSerializer.Deserialize<CommentResponeseModel>(s);
        }

        public static StudentHomeworkResponseModel GetStudentHomeworkById(string token,int idStudentHomework)
        {
            string url = $"https://piter-education.ru:7072/api/student-homeworks/{idStudentHomework}";
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
            return JsonSerializer.Deserialize<StudentHomeworkResponseModel>(s);
        }

        public static List<LessonTeacherResponseModel> GetAllLessonsTeachers (int teacherId, string token)
        {
            string url = $"https://piter-education.ru:7072/api/Lessons/by-teacherId/{teacherId}";
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
            return JsonSerializer.Deserialize<List<LessonTeacherResponseModel>>(s);
        }

        public static List<LessonGroupeResponseModel> GetAllLessonsGroup(int groupId, string token)
        {
            string url = $"https://piter-education.ru:7072/api/Lessons/by-groupId/{groupId}";
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
            return JsonSerializer.Deserialize<List<LessonGroupeResponseModel>>(s);
        }

        public static LessonResponseFullModelWithStudents GetLessonFullModel (string token, int idLesson)
        {
            string url = $"https://piter-education.ru:7072/api/Lessons/{idLesson}/full-info";
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

            return JsonSerializer.Deserialize<LessonResponseFullModelWithStudents>(s);
        }


        public static List<StudentHomeworkByTaskResponseModel> GetAllStudentHomeworkOnTaskByTask(int idTask, string token)
        {
            string url = $"https://piter-education.ru:7072/api/student-homeworks/task/{idTask}/answers";
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
            return JsonSerializer.Deserialize<List<StudentHomeworkByTaskResponseModel>>(s);
        }

        public static List<StudentHomeworkGetAllAnswersOfStudentResponseModel> GetAllAnswersOfStudent(string token, int idUser)
        {
            string url = $"https://piter-education.ru:7072/api/student-homeworks/by-user/{idUser}";
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
            return JsonSerializer.Deserialize<List<StudentHomeworkGetAllAnswersOfStudentResponseModel>>(s);
        }
    }
}
