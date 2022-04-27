﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DevEduEducationSystem.API.Tests.Support.Models
{
    public class TeacherModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("photo")]
        public object Photo { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is TeacherModel model &&
                   Id == model.Id &&
                   FirstName == model.FirstName &&
                   LastName == model.LastName &&
                   Email == model.Email &&
                   EqualityComparer<object>.Default.Equals(Photo, model.Photo);
        }
    }
}
