using DevEduEducationSystem.API.Tests.Support.Models;
using DevEduEducationSystem.API.Tests.Support.Models.AllGroupsModels;
using DevEduEducationSystem.API.Tests.Support.Models.StudentModelClassesForModel;
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
            ;
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
        public static List<GetAllUsersResponseModel> GetAllClients(string token)
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
            List< GetAllUsersResponseModel> allUsers = JsonSerializer.Deserialize<List<GetAllUsersResponseModel>>(s);
            return allUsers;
        }
    }
}
