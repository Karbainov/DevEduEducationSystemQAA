using DevEduEducationSystem.API.Tests.Support.Models;
using DevEduEducationSystem.API.Tests.Support.Models.CourseResponseModelForAdd;
using DevEduEducationSystem.API.Tests.Support.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEduEducationSystem.API.Tests.Support.MethodForTests
{
    public class Mapper
    {
        public RegistrationRequestModel MapRegistrationResponsesModelToRegisterRequestModel(RegistrationResponseModel model)
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

        public static List<TopicRequestModel> MapCourseRequestAndTopicRequestModelToCourseResponseModel(CourseResponseFullModel modelCourseRequest)
        {
            List<TopicRequestModel> listTopics = new List<TopicRequestModel>();
            
            foreach (TopicResponseModel a in modelCourseRequest.Topics)
            {

                listTopics.Add(new TopicRequestModel() { Duration = a.Duration, Name = a.Name });
            }
            return listTopics;
        }

        public static GroupRequestModel MapGroupResponseModelToGroupRequestModel(GroupResponseModel model)
        {
            //TODO
            if(model.GroupStatus == "0")
            {
                model.GroupStatus = "1";
            }
            return new GroupRequestModel()
            {
                Name = model.Name,
                CourseId = model.Course.Id,
                GroupStatusId = model.GroupStatus.ToString(),
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Timetable = model.Timetable,
                PaymentPerMonth = model.PaymentPerMonth,
            };
        }

        public static PaymentResponseModel MapPaymentRequestModelToPaymentResponseModel(PaymentRequestModel model)
        {
            return new PaymentResponseModel()
            {
                Date = model.Date,
                Sum = model.Sum,
                IsPaid = model.IsPaid,
                User = new User()
            };
        }

        public static PaymentRequestModel MapPaymentResponseModelToPaymentRequestModel(PaymentResponseModel model)
        {
            return new PaymentRequestModel()
            {
                Date = model.Date,
                Sum = model.Sum,
                IsPaid = model.IsPaid,
                UserId = model.User.Id
            };
        }
    }
}
