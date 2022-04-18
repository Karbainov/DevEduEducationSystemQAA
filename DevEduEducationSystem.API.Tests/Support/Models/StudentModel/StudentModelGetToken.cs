using DevEduEducationSystem.API.Tests.Support.Models.StudentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DevEduEducationSystem.API.Tests.Support.Models
{
    public class StudentModelGetToken
    {
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

        [JsonPropertyName("roles")]
        public List<string> Roles { get; set; }

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

        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("exileDate")]
        public string ExileDate { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("groups")]
        public List<Group> Groups { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is StudentModelGetToken token &&
                   Id == token.Id &&
                   FirstName == token.FirstName &&
                   LastName == token.LastName &&
                   Email == token.Email &&
                   Photo == token.Photo &&
                   EqualityComparer<List<string>>.Default.Equals(Roles, token.Roles) &&
                   Patronymic == token.Patronymic &&
                   Username == token.Username &&
                   RegistrationDate == token.RegistrationDate &&
                   BirthDate == token.BirthDate &&
                   GitHubAccount == token.GitHubAccount &&
                   PhoneNumber == token.PhoneNumber &&
                   ExileDate == token.ExileDate &&
                   City == token.City &&
                   EqualityComparer<List<Group>>.Default.Equals(Groups, token.Groups);
        }
    }
}
