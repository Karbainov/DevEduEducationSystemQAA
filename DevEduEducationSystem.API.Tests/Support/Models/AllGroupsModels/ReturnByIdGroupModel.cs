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
        public List<TeacherModel> Teachers { get; set; }

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

        public override bool Equals(object? obj)
        {
            return obj is ReturnByIdGroupModel model &&
                   EqualityComparer<List<StudentModel>>.Default.Equals(Students, model.Students) &&
                   EqualityComparer<List<TeacherModel>>.Default.Equals(Teachers, model.Teachers) &&
                   EqualityComparer<List<TutorModel>>.Default.Equals(Tutors, model.Tutors) &&
                   Id == model.Id &&
                   Name == model.Name &&
                   EqualityComparer<Course>.Default.Equals(Course, model.Course) &&
                   GroupStatus == model.GroupStatus &&
                   StartDate == model.StartDate &&
                   EndDate == model.EndDate &&
                   Timetable == model.Timetable &&
                   PaymentPerMonth == model.PaymentPerMonth;
        }

    }
}
