﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DevEduEducationSystem.API.Tests.Support.MethodForTests
{
    public class AddRoleUsers
    {

        private static string AddParametersInUrl(string role, int id)
        {
            string longurl = "https://piter-education.ru:7070/api/Users/";
            var uriBuilder = new UriBuilder(longurl);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["id/"] = id.ToString();
            query["role/"] = role;
            uriBuilder.Query = query.ToString();
            longurl = uriBuilder.ToString();
            return longurl;
        }



        public static void AddRole(string role, int id, string token)
        {
            string url = $"https://piter-education.ru:7072/api/Users/{id}/role/{role}";
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
    }
}
