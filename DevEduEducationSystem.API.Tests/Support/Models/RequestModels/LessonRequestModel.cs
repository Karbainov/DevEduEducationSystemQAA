using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DevEduEducationSystem.API.Tests.Support.Models.RequestModels
{
    public class LessonRequestModel
    {

        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("additionalMaterials")]
        public string AdditionalMaterials { get; set; }

        [JsonPropertyName("groupId")]
        public int GroupId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("linkToRecord")]
        public string LinkToRecord { get; set; }

        [JsonPropertyName("topicIds")]
        public List<int> TopicIds { get; set; }

        [JsonPropertyName("isPublished")]
        public bool IsPublished { get; set; }
        public override bool Equals(object? obj)
        {
            return obj is LessonRequestModel model &&
                   Date == model.Date &&
                   AdditionalMaterials == model.AdditionalMaterials &&
                   Name == model.Name &&
                   LinkToRecord == model.LinkToRecord;
        }
    }
}
