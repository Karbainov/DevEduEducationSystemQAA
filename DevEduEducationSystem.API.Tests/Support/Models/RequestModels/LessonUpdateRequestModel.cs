using System.Text.Json.Serialization;

namespace DevEduEducationSystem.API.Tests.Support.Models.RequestModels
{
    public class LessonUpdateRequestModel
    {

        [JsonPropertyName("additionalMaterials")]
        public string AdditionalMaterials { get; set; }

        [JsonPropertyName("linkToRecord")]
        public string LinkToRecord { get; set; }

        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("topicIds")]
        public List<int> TopicIds { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is LessonUpdateRequestModel model &&
                   Date == model.Date &&
                   AdditionalMaterials == model.AdditionalMaterials &&
                   LinkToRecord == model.LinkToRecord &&
                   EqualityComparer<List<int>>.Default.Equals(TopicIds, model.TopicIds);
        }
    }
}
