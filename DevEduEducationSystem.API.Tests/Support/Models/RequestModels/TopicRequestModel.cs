using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DevEduEducationSystem.API.Tests.Support.Models.RequestModels
{
    public class TopicRequestModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("duration")]
        public int Duration { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is TopicRequestModel model &&
                   Name == model.Name &&
                   Duration == model.Duration;
        }
    }
}
