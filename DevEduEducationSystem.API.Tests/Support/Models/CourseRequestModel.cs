using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DevEduEducationSystem.API.Tests.Support.Models
{
    public class CourseRequestModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
        public override bool Equals(object? obj)
        {
            return obj is CourseRequestModel model &&
                   Name == model.Name &&
                   Description == model.Description;
        }
    }
}
