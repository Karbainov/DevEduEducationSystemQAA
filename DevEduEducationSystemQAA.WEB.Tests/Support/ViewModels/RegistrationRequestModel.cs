using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEduEducationSystemQAA.WEB.Tests.Support.ViewModels
{
    public class RegistrationRequestModel
    {
       public string Surname { get; set; }
       public string Name { get; set; }
       public string Patronymic { get; set; }
       public string BirthDate { get; set; }
       public string Password { get; set; }
       public string RepeatPassword { get; set; }
       public string Email { get; set; }
       public string Phone { get; set; }
       public string LinkByGitHub { get; set; }

    }
}
