using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DevEduEducationSystemQAA.WEB.Tests.Support
{
    public class IOHelper
    {
        private static string tokenAdmin;
        public static void CheckAuthNegative(IWebDriver driver, string email, string password)
        {
            driver.Navigate().GoToUrl(UrlStorage.EnterWindow);
            Thread.Sleep(200);
            var inputEmail = driver.FindElement(Enter_WindowXPaths.InputLogin);
            inputEmail.SendKeys(email);
            var inputPassword = driver.FindElement(Enter_WindowXPaths.InputPassword);
            inputPassword.Clear();
            inputPassword.SendKeys(password);
            var buttonEnterWinLogin = driver.FindElement(Enter_WindowXPaths.ButtonEnter);
            buttonEnterWinLogin.Click();
            Thread.Sleep(500);
            driver.Navigate().GoToUrl(UrlStorage.BasePage);
            string actual = driver.Url;
            string expected = UrlStorage.EnterWindow;
            Assert.AreEqual(expected, actual);
        }

        public static void CheckAuth(IWebDriver driver, string email, string password)
        {
            driver.Navigate().GoToUrl(UrlStorage.EnterWindow);
            Thread.Sleep(200);
            var inputEmail = driver.FindElement(Enter_WindowXPaths.InputLogin);
            inputEmail.SendKeys(email);
            var inputPassword = driver.FindElement(Enter_WindowXPaths.InputPassword);
            inputPassword.Clear();
            inputPassword.SendKeys(password);
            var buttonEnterWinLogin = driver.FindElement(Enter_WindowXPaths.ButtonEnter);
            buttonEnterWinLogin.Click();
            Thread.Sleep(500);
            driver.Navigate().GoToUrl(UrlStorage.BasePage);
            string actual = driver.Url;
            string expected = UrlStorage.BasePage;
            Assert.AreEqual(expected, actual);
        }

        public static void EnterInSystem(string email, string password, IWebDriver driver)
        {
            var inputEmail = driver.FindElement(Enter_WindowXPaths.InputLogin);
            inputEmail.SendKeys(email);
            var inputPassword = driver.FindElement(Enter_WindowXPaths.InputPassword);
            inputPassword.Clear();
            inputPassword.SendKeys(password);
            var buttonEnterWinLogin = driver.FindElement(Enter_WindowXPaths.ButtonEnter);
            buttonEnterWinLogin.Click();
            Thread.Sleep(500);
            driver.Navigate().GoToUrl(UrlStorage.BasePage);
        }

        public static string AuthUser(string email, string password)
        {
            string urlAuth = @"https://piter-education.ru:7070/sign-in";
            string emailAdmin = "user@example.com";
            string passwordAdmin = "stringst";
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
                RequestUri = new Uri(urlAuth),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage response = client.Send(request);
            tokenAdmin = response.Content.ReadAsStringAsync().Result;
            HttpStatusCode expected = HttpStatusCode.OK;
            HttpStatusCode actual = response.StatusCode;
            Assert.AreEqual(expected, actual);
            return tokenAdmin;
        }

        public static UserModel GetUserByToken(string token)
        {
            string url = @"https://piter-education.ru:7070/api/Users/self";
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

            return JsonSerializer.Deserialize<UserModel>(s);
        }

        public static List<StudentHomework> GetAllStudenHomeworkById(int idUser, string token)
        {
            string url = $"https://piter-education.ru:7070/api/student-homeworks/by-user/{idUser}";
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
            return JsonSerializer.Deserialize<List<StudentHomework>>(s);
        }

        public static void DeleteUser(int id)
        {
            string connectionString = @"Data Source=80.78.240.16;Initial Catalog = DevEdu; Persist Security Info=True;User ID = student;Password=qwe!23;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();

                command.CommandText = $"delete from dbo.[User_Role] where UserId = {id}";
                command.Connection = connection;
                var i = command.ExecuteNonQuery();

                command.CommandText = $"delete from dbo.[User] where Id = {id}";
                command.ExecuteNonQuery();
            }
        }

        public static void DeleteStudentHomework(int id)
        {
            string connectionString = @"Data Source=80.78.240.16;Initial Catalog = DevEdu; Persist Security Info=True;User ID = student;Password=qwe!23;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandText = $"delete from dbo.[Student_Homework] where Id = {id}";
                command.Connection = connection;
                var i = command.ExecuteNonQuery();
            }
        }

    }

    public class UserModel
    {
        [JsonPropertyName("patronymic")]
        public string Patronymic { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("registrationDate")]
        public string RegistrationDate { get; set; }

        [JsonPropertyName("birthDate")]
        public string BirthDate { get; set; }

        [JsonPropertyName("gitHubAccount")]
        public string GitHubAccount { get; set; }

        [JsonPropertyName("exileDate")]
        public string ExileDate { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("groups")]
        public List<object> Groups { get; set; }

        [JsonPropertyName("roles")]
        public List<string> Roles { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("photo")]
        public string Photo { get; set; }

        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }
    }

    public class Homework
    {
        [JsonPropertyName("task")]
        public Task Task { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("startDate")]
        public string StartDate { get; set; }

        [JsonPropertyName("endDate")]
        public string EndDate { get; set; }
    }

    public class StudentHomework
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("answer")]
        public string Answer { get; set; }

        [JsonPropertyName("completedDate")]
        public object CompletedDate { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("homework")]
        public Homework Homework { get; set; }

        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }
    }

    public class Task
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("links")]
        public object Links { get; set; }

        [JsonPropertyName("isRequired")]
        public bool IsRequired { get; set; }

        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }
    }


}
