using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DevEduEducationSystem.API.Tests.Support.Models.ResponseModels
{
    public class StudentHomeworkByTaskResponseModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("answer")]
        public string Answer { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("completedDate")]
        public string CompletedDate { get; set; }

        [JsonPropertyName("user")]
        public UserResponseModel User { get; set; }

        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is StudentHomeworkByTaskResponseModel model &&
                   Id == model.Id &&
                   Answer == model.Answer &&
                   Status == model.Status &&
                   CompletedDate == model.CompletedDate &&
                   User.Equals(model.User) &&
                   IsDeleted == model.IsDeleted;
        }
    }
}
