using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DevEduEducationSystem.API.Tests.Support.Models.ResponseModels
{
    public class LessonGroupeResponseModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("additionalMaterials")]
        public string AdditionalMaterials { get; set; }

        [JsonPropertyName("linkToRecord")]
        public string LinkToRecord { get; set; }

        [JsonPropertyName("number")]
        public int Number { get; set; }

        [JsonPropertyName("teacher")]
        public UserResponseModel Teacher { get; set; }    

        [JsonPropertyName("topics")]
        public List<TopicResponseModel> Topics { get; set; }

        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is LessonGroupeResponseModel model &&
                   Id == model.Id &&
                   Date == model.Date &&
                   Name == model.Name &&
                   AdditionalMaterials == model.AdditionalMaterials &&
                   LinkToRecord == model.LinkToRecord &&
                   //EqualityComparer<UserResponseModel>.Default.Equals(Teacher, model.Teacher) &&
                   //EqualityComparer<List<TopicResponseModel>>.Default.Equals(Topics, model.Topics) &&
                   IsDeleted == model.IsDeleted;
        }
    }
}
