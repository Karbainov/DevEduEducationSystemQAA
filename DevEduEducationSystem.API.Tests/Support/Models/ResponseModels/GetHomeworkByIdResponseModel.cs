using DevEduEducationSystem.API.Tests.Support.Models.CourseResponseModelForAdd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DevEduEducationSystem.API.Tests.Support.Models.ResponseModels
{
    public class GetHomeworkByIdResponseModel
    {
        
        [JsonPropertyName("task")]
        public TaskResponseModel Task { get; set; }

        [JsonPropertyName("group")]
        public GroupHomework Group { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("startDate")]
        public string StartDate { get; set; }

        [JsonPropertyName("endDate")]
        public string EndDate { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is GetHomeworkByIdResponseModel model &&
                   Task.Equals(model.Task) &&
                   Group.Equals(model.Group) &&
                   Id == model.Id &&
                   StartDate == model.StartDate &&
                   EndDate == model.EndDate;
        }
    }
    public class GroupHomework
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("groupStatus")]
        public string GroupStatus { get; set; }

        [JsonPropertyName("startDate")]
        public string StartDate { get; set; }

        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is GroupHomework homework &&
                   Id == homework.Id &&
                   Name == homework.Name &&
                   GroupStatus == homework.GroupStatus &&
                   StartDate == homework.StartDate &&
                   IsDeleted == homework.IsDeleted;
        }
    }
}

