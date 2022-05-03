using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DevEduEducationSystem.API.Tests.Support.Models.ResponseModels
{
    public class CourseResponseModelWithPosition
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("position")]
        public int Position { get; set; }

        [JsonPropertyName("topic")]
        public TopicResponseModel Topic { get; set; }

        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is CourseResponseModelWithPosition position &&
                   Id == position.Id &&
                   Position == position.Position &&
                   (Topic != null ? Topic.Equals(position.Topic): position.Topic == null) &&
                   IsDeleted == position.IsDeleted;
        }
    }
}
