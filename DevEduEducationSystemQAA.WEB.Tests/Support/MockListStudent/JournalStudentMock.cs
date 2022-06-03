using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEduEducationSystemQAA.WEB.Tests.Support.MockListStudent
{
    public class JournalStudentMock
    {
       

        public static List<GridJournalModel> GetStudent()
        {
            List<GridJournalModel> students = new List<GridJournalModel>()
            {
                new GridJournalModel()
                {
                   Name = "Абрикос Филя",
                   Ball = 0,
                   DateEmployment = "10.10.10",
                   Percent = "90%"
                },
                new GridJournalModel()
                {
                    Name = "Барабан Second",
                    Ball = 0,
                    DateEmployment = "10.10.10",
                    Percent = "50%"
                },
                new GridJournalModel()
                {
                    Name = "Ворона Амеба",
                    Ball = 1,
                    DateEmployment = "10.10.10",
                    Percent = "70%"
                }

            };
            return students;
        }
    }

    public class GridJournalModel
    {
        public string Name { get; set; }
        public int Ball { get; set; }
        public string DateEmployment { get; set; }
        public string Percent  { get; set; } 
    }
}
