﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DevEduEducationSystem.API.Tests.Support.Models.ResponseModels
{
    public class LessonTeacherResponseModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("additionalMaterials")]
        public string AdditionalMaterials { get; set; }

        [JsonPropertyName("teacher")]
        public UserResponseModel Teacher { get; set; }

        [JsonPropertyName("linkToRecord")]
        public string LinkToRecord { get; set; }

        [JsonPropertyName("topics")]
        public List<TopicResponseModel> Topics { get; set; }

        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }

        [JsonPropertyName("course")]
        public CourseResponseModel Course { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is LessonTeacherResponseModel model &&
                   Id == model.Id &&
                   Date == model.Date &&
                   AdditionalMaterials == model.AdditionalMaterials &&
                   EqualityComparer<UserResponseModel>.Default.Equals(Teacher, model.Teacher) &&
                   LinkToRecord == model.LinkToRecord &&
                   EqualityComparer<List<TopicResponseModel>>.Default.Equals(Topics, model.Topics) &&
                   IsDeleted == model.IsDeleted &&
                   EqualityComparer<CourseResponseModel>.Default.Equals(Course, model.Course);
        }
    }
}
