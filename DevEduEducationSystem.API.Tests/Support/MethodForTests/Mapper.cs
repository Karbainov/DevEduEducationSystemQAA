using DevEduEducationSystem.API.Tests.Support.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEduEducationSystem.API.Tests.Support.MethodForTests
{
    public class Mapper
    {
        public RegistrationRequestModel MapRegistrationResponseModelToRegisterRequestModel(RegistrationResponseModel model)
        {
            return new RegistrationRequestModel()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Patronymic = model.Patronymic,
                Email = model.Email,
                Username = model.Username,
                City = model.City,
                BirthDate = model.BirthDate,
                GitHubAccount = model.GitHubAccount,
                PhoneNumber = model.PhoneNumber
            };
        }

        public static CourseRequestModel MapCourseResponseModelToCourseRequestModel(CourseResponseModel model)
        {
            return new CourseRequestModel()
            {
                Name = model.Name,
                Description = model.Description
            };
        }
    }
}
