using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DevEduEducationSystem.API.Tests.Support.Models.CourseResponseModelForAdd
{
    public class CourseResponseFullModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("topics")]
        public List<TopicResponseModel> Topics { get; set; }

        [JsonPropertyName("materials")]
        public List<MaterialResponseModel> Materials { get; set; }

        [JsonPropertyName("tasks")]
        public List<TaskResponseModel> Tasks { get; set; }

        [JsonPropertyName("groups")]
        public List<GroupResponseModel> Groups { get; set; }
    }
}
