using System;

namespace PaymentDateCheck
{
    public class Bill
    {
        public Bill(IHolidayService mockService)
        { }

        private IHolidayService _holidayService = new HolidayService();

        public DateTime CheckDate (DateTime dueDate)
        {
            DateTime fakeDate = new DateTime(2019, 12, 20);

            if (dueDate.DayOfWeek == DayOfWeek.Saturday)
            {
                // return fakeDate;
                return dueDate.AddDays(2);
            }
            if (dueDate.DayOfWeek == DayOfWeek.Sunday)
            {
                // return fakeDate;
                return dueDate.AddDays(1);
            }
            if (_holidayService.isHoliday(dueDate) == true && dueDate.DayOfWeek == DayOfWeek.Friday) 
            {
                return dueDate.AddDays(3);
            }
            else if (_holidayService.isHoliday(dueDate) == true)
            {
                return dueDate.AddDays(1);
            }

            // the duedate falls on a business day, m-f, return the due date AS ISurn dueDate;
                return dueDate;
        }
    }

}

