using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace NameOfDateWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class DateNamer : INameOfDate
    {
        public string GetNameOfDate(DateTime date)
        {
            string nameOfDate = "";
            switch (date.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    nameOfDate = "Понеделник";
                    break;
                case DayOfWeek.Tuesday:
                    nameOfDate = "Вторник";
                    break;
                case DayOfWeek.Wednesday:
                    nameOfDate = "Сряда";
                    break;
                case DayOfWeek.Thursday:
                    nameOfDate = "Четвъртък";
                    break;
                case DayOfWeek.Friday:
                    nameOfDate = "Петък";
                    break;
                case DayOfWeek.Saturday:
                    nameOfDate = "Събота";
                    break;
                case DayOfWeek.Sunday:
                    nameOfDate = "Неделя";
                    break;
                default:
                    throw new InvalidOperationException("The day was not found!");
            }
            return nameOfDate;
        }

    }
}
