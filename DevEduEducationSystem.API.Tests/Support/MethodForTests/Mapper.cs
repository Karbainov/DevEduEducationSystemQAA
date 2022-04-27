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
        public RegisterRequestModel MapRegistrationResponsesModelToRegisterRequestModel(RegistrationResponsesModel model)
        {
            return new RegisterRequestModel()
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
    }
}
