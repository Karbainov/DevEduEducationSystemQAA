using DevEduEducationSystem.API.Tests.Support.Models.StudentModelClassesForModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DevEduEducationSystem.API.Tests.Support.Models
{
    public class GroupResponseModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("course")]
        public Course Course { get; set; }

        //TODO: как будет починина бага исправить тип данных 
        //[JsonIgnore]
        [JsonPropertyName("groupStatus")]
        public object GroupStatus { get; set; }

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
            return obj is GroupResponseModel model &&
                   Id == model.Id &&
                   Name == model.Name &&
                   Course.Equals(model.Course) &&
                   GroupStatus == model.GroupStatus &&
                   StartDate == model.StartDate &&
                   EndDate == model.EndDate &&
                   Timetable == model.Timetable &&
                   PaymentsCount == model.PaymentsCount &&
                   PaymentPerMonth == model.PaymentPerMonth;
        }
    }
    
}
