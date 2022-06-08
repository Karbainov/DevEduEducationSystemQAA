using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEduEducationSystemQAA.WEB.Tests.Support.MockListStudent
{
    public class JournalStudentMock
    {
        private static List<double> allTotal = new List<double>();

        public static List<double> GetAllTotal()
        {
            return allTotal;
        }

        public static List<GridJournalModel> GetStudent()
        {
            List<GridJournalModel> students = new List<GridJournalModel>()
            {
                new GridJournalModel()
                {
                   Name = "Абрикос Филя",
                   Ball = new List<string>()
                   {
                       "1","1","0","1","0.5","0","1","0.5","0.5","0.5","0.5","0.5","0.5"
                   },
                   DateEmployment = new List<string>()
                   {
                       "10.10.10" , "11.10.10","12.10.10","13.10.10","14.10.10","15.10.10","16.10.10",
                       "17.10.10","18.10.10", "19.10.10", "20.10.10", "21.10.10", "22.10.10"
                   },
                   Percent = "90%"
                },
                new GridJournalModel()
                {
                    Name = "Барабан Second",
                    Ball = new List<string>()
                    {
                        "0","1","1","0.5","0","0","0","0","0","0","0","0","0"
                    },
                    DateEmployment = new List<string>()
                   {
                       "10.10.10" , "11.10.10","12.10.10","13.10.10","14.10.10","15.10.10","16.10.10",
                       "17.10.10", "18.10.10", "19.10.10", "20.10.10", "21.10.10", "22.10.10"
                   },
                    Percent = "50%"
                },
                new GridJournalModel()
                {
                    Name = "Ворона Амеба",
                    Ball = new List<string>()
                    {
                        "1","1","0","0","0.5","0.5","0.5","0.5","0.5","0.5","0.5","0.5","0.5"
                    },
                    DateEmployment = new List<string>()
                   {
                       "10.10.10" , "11.10.10","12.10.10","13.10.10","14.10.10","15.10.10","16.10.10",
                       "17.10.10", "18.10.10", "19.10.10", "20.10.10", "21.10.10", "22.10.10"
                   },
                    Percent = "70%"
                }
            };
            

            for (int j = 0; j < students.Count; j++)
            {
                List<string> total = students[j].Ball;
                List<double> list = new List<double>();
                for (int i = 0; i < total.Count; i++)
                {
                    string a = total[i];
                    double aa = Convert.ToDouble(a);
                    list.Add(aa);
                }
                students[j].Total = list;
            }
            // тут я не могу додумать как на автомат поставить(
            for (int j = 0; j < students[0].Total.Count; j++)
            {
                double sum = 0;
                for (int i = 0; i < students.Count; i++)
                {
                    sum += students[i].Total[j];
                }
                allTotal.Add(sum);
            }
            return students;
        }
    }

    public class GridJournalModel
    {
        public string Name { get; set; }
        public List<string> Ball { get; set; }
        public List<string> DateEmployment { get; set; }
        public string Percent  { get; set; }
        public List<double> Total { get; set; }

        public override bool Equals(object? obj)
        {
            var model = (GridJournalModel)obj!;
            if (Ball.Count != model.Ball.Count)
            {
                return false;
            }

            for (int i = 0; i < Ball.Count; i++)
            {
                if (!Ball[i].Equals(model.Ball[i]))
                {
                    return false;
                }
            }

            if (DateEmployment.Count != model.DateEmployment.Count)
            {
                return false;
            }

            for (int i = 0; i < DateEmployment.Count; i++)
            {
                if (!DateEmployment[i].Equals(model.DateEmployment[i]))
                {
                    return false;
                }
            }
            return    Name == model.Name &&
                   Percent == model.Percent;
        }
    }
}
