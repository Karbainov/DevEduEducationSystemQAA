using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DevEduEducationSystem.API.Tests.Support.Models.RequestModels
{
    public class TaskMethodistRequestModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("links")]
        public string Links { get; set; }

        [JsonPropertyName("isRequired")]
        public bool IsRequired { get; set; }

        [JsonPropertyName("courseIds")]
        public List<int> CourseIds { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is TaskMethodistRequestModel model &&
                   Name == model.Name &&
                   Description == model.Description &&
                   Links == model.Links &&
                   IsRequired == model.IsRequired &&
                   EqualityComparer<List<int>>.Default.Equals(CourseIds, model.CourseIds);
        }
    }
}
