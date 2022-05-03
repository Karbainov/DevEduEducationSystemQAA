using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DevEduEducationSystem.API.Tests.Support.Models.RequestModels
{
    public class CourseAndTopicRequestModel
    {
        [JsonPropertyName("position")]
        public string Name { get; set; }

        [JsonPropertyName("topicId")]
        public int Position { get; set; }

    }
}
