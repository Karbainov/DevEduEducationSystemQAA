using DevEduEducationSystem.API.Tests.Support.Models;
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
    public class Update
    {
        public void UpdateUser(List<UpdateUserModel> updateUser, int id, string token)
        {
            foreach (var user in updateUser)
            {
                string url = $"https://piter-education.ru:7070/api/Users/{id}";
                //ChangeCustomerModel customerModel = new ChangeCustomerModel(customer);
                string json = JsonSerializer.Serialize(user);
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
        }
    }
}
