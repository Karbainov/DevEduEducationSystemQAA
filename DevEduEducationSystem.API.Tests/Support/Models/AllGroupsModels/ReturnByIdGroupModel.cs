using DevEduEducationSystem.API.Tests.Support.Models.StudentModelClassesForModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DevEduEducationSystem.API.Tests.Support.Models.AllGroupsModels
{
    public class ReturnByIdGroupModel
    {
        [JsonPropertyName("students")]
        public List<StudentModel> Students { get; set; }

        [JsonPropertyName("teachers")]
        public List<UserResponseModel> Teachers { get; set; }

        [JsonPropertyName("tutors")]
        public List<TutorModel> Tutors { get; set; }

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
        public decimal PaymentPerMonth { get; set; }

        [JsonPropertyName("paymentsCount")]
        public int PaymentsCount { get; set; }

        public override bool Equals(object? obj)
        {

            var model = (ReturnByIdGroupModel)obj!;

            //EqualityComparer<List<StudentModel>>.Default.Equals(Students, model.Students) &&
            if (Students.Count != model.Students.Count)
            {
                return false;
            }

            for (int i = 0; i < Students.Count; i++)
            {
                if (!Students[i].Equals(model.Students[i]))
                {
                    return false;
                }
            }
            if(Teachers.Count != model.Teachers.Count)
            {
                return false;
            }
            for(int i = 0; i < Teachers.Count; i++)
            {
                if(!Teachers[i].Equals(model.Teachers[i]))
                {
                    return false;
                }
            }
            
            if(Tutors.Count != model.Tutors.Count)
            {
                return false;
            }
            for(int i = 0; i < Tutors.Count; i++)
            {
                if(!Tutors[i].Equals(model.Tutors[i]))
                {
                    return false;
                }
            }
            return Id == model.Id &&
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
