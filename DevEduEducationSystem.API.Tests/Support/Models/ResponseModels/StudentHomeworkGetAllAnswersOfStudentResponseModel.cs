using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DevEduEducationSystem.API.Tests.Support.Models.ResponseModels
{
    public class StudentHomeworkGetAllAnswersOfStudentResponseModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("answer")]
        public string Answer { get; set; }

        [JsonPropertyName("completedDate")]
        public string CompletedDate { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("homework")]
        public Homework Homework { get; set; }

        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is StudentHomeworkGetAllAnswersOfStudentResponseModel model &&
                   Id == model.Id &&
                   Answer == model.Answer &&
                   CompletedDate == model.CompletedDate &&
                   Status == model.Status &&
                   Homework.Equals(model.Homework) &&
                   IsDeleted == model.IsDeleted;
        }
    }
}
