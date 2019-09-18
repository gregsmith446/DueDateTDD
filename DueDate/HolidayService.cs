using System;
using System.Collections.Generic;

namespace PaymentDateCheck
{
    public class HolidayService : IHolidayService
    {
        public bool isHoliday (DateTime dueDate)
        {

            var holidays = new List<DateTime>
            {
                new DateTime(2019, 12, 25),
                new DateTime(2019, 9, 27),
            };

            if (holidays.Contains(dueDate))
                return true;

            return false;
        }
    }
}