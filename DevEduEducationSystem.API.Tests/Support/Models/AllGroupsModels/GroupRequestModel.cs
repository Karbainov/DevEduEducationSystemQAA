using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DevEduEducationSystem.API.Tests.Support.Models
{
    public class GroupRequestModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("courseId")]
        public int CourseId { get; set; }

        [JsonPropertyName("groupStatusId")]
        public string GroupStatusId { get; set; }

        [JsonPropertyName("startDate")]
        public string StartDate { get; set; }

        [JsonPropertyName("endDate")]
        public string EndDate { get; set; }

        [JsonPropertyName("timetable")]
        public string Timetable { get; set; }

        [JsonPropertyName("paymentPerMonth")]
        public decimal PaymentPerMonth { get; set; }

        [JsonPropertyName("paymentsCount")]
        public int PaymentsCount { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is GroupRequestModel model &&
                   Name == model.Name &&
                   CourseId == model.CourseId &&
                   GroupStatusId == model.GroupStatusId &&
                   StartDate == model.StartDate &&
                   EndDate == model.EndDate &&
                   Timetable == model.Timetable &&
                   PaymentsCount == model.PaymentsCount &&
                   PaymentPerMonth == model.PaymentPerMonth;

        }
    }
}
