using DevEduEducationSystem.API.Tests.Support.Models;
using DevEduEducationSystem.API.Tests.Support.Models.CourseResponseModelForAdd;
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
        public static List<RegistrationResponseModel> GetUserById(string token, int id)
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
            user.Add(JsonSerializer.Deserialize<RegistrationResponseModel>(s));
            return user;
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
    }
}
