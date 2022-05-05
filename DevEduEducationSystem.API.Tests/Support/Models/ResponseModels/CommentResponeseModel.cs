using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DevEduEducationSystem.API.Tests.Support.Models.ResponseModels
{
    public class CommentResponeseModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("user")]
        public UserStudentHomework User { get; set; }

        [JsonPropertyName("studentHomework")]
        public StudentHomework StudentHomework { get; set; }

        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is CommentResponeseModel model &&
                   Id == model.Id &&
                   Text == model.Text &&
                   User.Equals(model.User) &&
                   EqualityComparer<StudentHomework>.Default.Equals(StudentHomework, model.StudentHomework) &&
                   Date == model.Date &&
                   IsDeleted == model.IsDeleted;
        }
    }

    public class StudentHomework
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("answer")]
        public string Answer { get; set; }

        [JsonPropertyName("completedDate")]
        public string CompletedDate { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is StudentHomework homework &&
                   Id == homework.Id &&
                   Answer == homework.Answer &&
                   CompletedDate == homework.CompletedDate;
        }
    }

    public class UserStudentHomework
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

        public override bool Equals(object? obj)
        {
            var model = (UserStudentHomework)obj!;

            if (Roles.Count != model.Roles.Count)
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
            return obj is UserStudentHomework homework &&
                   Id == homework.Id &&
                   FirstName == homework.FirstName &&
                   LastName == homework.LastName &&
                   Email == homework.Email &&
                   Photo == homework.Photo;
        }
    }
}
