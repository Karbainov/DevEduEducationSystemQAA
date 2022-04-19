using System.Text.Json.Serialization;

namespace DevEduEducationSystem.API.Tests.Support.Models.StudentModelClassesForModel
{
    public class Course
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Course course &&
                   Id == course.Id &&
                   Name == course.Name &&
                   IsDeleted == course.IsDeleted;
        }
    }
}
