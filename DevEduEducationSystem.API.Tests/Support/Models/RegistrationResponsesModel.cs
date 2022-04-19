using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DevEduEducationSystem.API.Tests.Support.Models
{
    public class RegistrationResponsesModel
    {
        [JsonPropertyName("patronymic")]
        public string Patronymic { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("registrationDate")]
        public string RegistrationDate { get; set; } = $"{DateTime.Now.ToString("dd.MM.yyyy")}";

        [JsonPropertyName("birthDate")]
        public string BirthDate { get; set; }

        [JsonPropertyName("gitHubAccount")]
        public string GitHubAccount { get; set; }

        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("exileDate")]
        public string ExileDate { get; set; } = "01.01.0001";

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("groups")]
        public object Groups { get; set; } = null;

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("photo")]
        public object Photo { get; set; } = null;

        [JsonPropertyName("roles")]
        public List<string> Roles { get; set; } = new List<string>() { "Student" };

        public override bool Equals(object? obj)
        {
            return obj is RegistrationResponsesModel model &&
                   Patronymic == model.Patronymic &&
                   Username == model.Username &&
                   RegistrationDate == model.RegistrationDate &&
                   BirthDate == model.BirthDate &&
                   GitHubAccount == model.GitHubAccount &&
                   PhoneNumber == model.PhoneNumber &&
                   ExileDate == model.ExileDate &&
                   City == model.City &&
                   EqualityComparer<object>.Default.Equals(Groups, model.Groups) &&
                   Id == model.Id &&
                   FirstName == model.FirstName &&
                   LastName == model.LastName &&
                   Email == model.Email &&
                   EqualityComparer<object>.Default.Equals(Photo, model.Photo) &&
                   EqualityComparer<List<string>>.Default.Equals(Roles, model.Roles);
        }
    }
}
