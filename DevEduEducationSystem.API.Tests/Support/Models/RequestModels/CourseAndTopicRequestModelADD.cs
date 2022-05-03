using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DevEduEducationSystem.API.Tests.Support.Models.RequestModels
{
    public class CourseAndTopicRequestModelADD
    {
        [JsonPropertyName("position")]
        public int Position { get; set; }

        [JsonPropertyName("topicId")]
        public int TopicID { get; set; }

    }
}
