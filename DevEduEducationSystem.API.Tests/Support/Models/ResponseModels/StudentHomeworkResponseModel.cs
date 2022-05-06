using DevEduEducationSystem.API.Tests.Support.Models.CourseResponseModelForAdd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DevEduEducationSystem.API.Tests.Support.Models.ResponseModels
{
    public class StudentHomeworkResponseModel
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

        [JsonPropertyName("homework")]
        public Homework Homework { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is StudentHomeworkResponseModel model &&
                   Id == model.Id &&
                   Answer == model.Answer &&
                   Status == model.Status &&
                   CompletedDate == model.CompletedDate &&
                   User.Equals(model.User) &&
                   IsDeleted == model.IsDeleted &&
                   Homework.Equals(model.Homework);
        }
    }
    public class Homework
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("startDate")]
        public string StartDate { get; set; }

        [JsonPropertyName("endDate")]
        public string EndDate { get; set; }

        [JsonPropertyName("task")]
        public TaskResponseModel Task { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Homework homework &&
                   Id == homework.Id &&
                   StartDate == homework.StartDate &&
                   EndDate == homework.EndDate &&
                   Task.Equals(homework.Task);
        }
    }
}
