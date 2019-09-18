using System;

namespace PaymentDateCheck
{
    public class Bill
    {
        public Bill(IHolidayService mockService)
        { }

        //bring in holiday service to check for holidays
        //use dependency injection
        public DateTime CheckDate (DateTime dueDate)
        {
            DateTime fakeDate = new DateTime(2019, 12, 20);
            // if the duedate falls on a business day, m-f, return the due date AS IS
            if (dueDate.DayOfWeek != DayOfWeek.Saturday || dueDate.DayOfWeek != DayOfWeek.Sunday)
            {
                return dueDate;
            }
            else if (dueDate.DayOfWeek == DayOfWeek.Saturday)
            {
                return dueDate.AddDays(2);
            }
            else
            {
                return fakeDate;
            }
                
        }
    }

}

