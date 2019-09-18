using NUnit.Framework;
using PaymentDateCheck;
using System;
using System.Collections.Generic;

namespace Tests
{    
    [TestFixture]
    public class BillShould
    {
        [Test]
        public void ifBussinessDay_ReturnDueDate()
        {
            DateTime input = new DateTime(2019, 9, 17);
            IHolidayService mockHolidayService = new HolidayService<IHolidayService>();
            Bill _bill = new Bill(mockHolidayService);

            var output = _bill.CheckDate(input);
            var expected = input;
            Assert.AreEqual(expected, output);
        }
    }
}