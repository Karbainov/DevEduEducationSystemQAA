using System.Text.Json.Serialization;

namespace DevEduEducationSystem.API.Tests.Support.Models.StudentModelClassesForModel
{
    public class Group
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("course")]
        public Course Course { get; set; }

        [JsonPropertyName("groupStatus")]
        public string GroupStatus { get; set; }

        [JsonPropertyName("startDate")]
        public string StartDate { get; set; }

        [JsonPropertyName("endDate")]
        public string EndDate { get; set; }

        [JsonPropertyName("timetable")]
        public string Timetable { get; set; }

        [JsonPropertyName("paymentPerMonth")]
        public int PaymentPerMonth { get; set; }

        public override bool Equals(object? obj)
        {
            var model = (Group)obj;
            return obj is Group group &&
                   Id == group.Id &&
                   Name == group.Name &&
                   Course.Equals(model.Course) &&
                   GroupStatus == group.GroupStatus &&
                   StartDate == group.StartDate &&
                   EndDate == group.EndDate &&
                   Timetable == group.Timetable &&
                   PaymentPerMonth == group.PaymentPerMonth;
        }
    }
}
