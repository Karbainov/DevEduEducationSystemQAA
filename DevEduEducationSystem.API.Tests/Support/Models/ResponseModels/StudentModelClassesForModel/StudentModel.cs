using System.Text.Json.Serialization;

namespace DevEduEducationSystem.API.Tests.Support.Models.StudentModelClassesForModel

{
    public class StudentModel
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

            var model = (StudentModel)obj!;
            if(Roles.Count != model.Roles.Count)
            {
                return false;
            }
            for (int i = 0; i < Roles.Count; i++)
            {
                if (!Roles[i].Equals(model.Roles[i]))
                {
                    return false;
                }
            }

            if(Groups.Count != model.Groups.Count)
            {
                return false;
            }
            for(int i = 0; i < Groups.Count; i++)
            {
                if (!Groups[i].Equals(model.Groups[i])) ;
            }


            return obj is StudentModel token &&
                   Id == token.Id &&
                   FirstName == token.FirstName &&
                   LastName == token.LastName &&
                   Email == token.Email &&
                   Photo == token.Photo &&
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
