using DevEduEducationSystem.API.Tests.Support.Models.CourseResponseModelForAdd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DevEduEducationSystem.API.Tests.Support.Models.ResponseModels
{
    public class GetAllHomeworkByGroupResponseModel
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
            return obj is GetAllHomeworkByGroupResponseModel model &&
                   Id == model.Id &&
                   StartDate == model.StartDate &&
                   EndDate == model.EndDate &&
                   Task.Equals(model.Task);
        }
    }
}
