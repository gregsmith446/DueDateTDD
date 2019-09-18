using NUnit.Framework;
using PaymentDateCheck;
using System;

[TestFixture]
public class TestCode
{
    // test 1 the way I think it should be
    [Test]
    public void IfDueDateIsASaturday_ReturnDateMonday()
    {
        // initialize the interface + the Bill calculator object
        IHolidayService mockHolidayService = new HolidayService();
        Bill _bill = new Bill(mockHolidayService);

        DateTime input = new DateTime(2019, 9, 21);
        var expected = input.AddDays(2);
        var output = _bill.CheckDate(input);
        Assert.AreEqual(expected, output);
    }

    // test 2 the way I think it should be
    [Test]
    public void IfDueDateIsASunday_ReturnMonday()
    {
        IHolidayService mockHolidayService = new HolidayService();
        Bill _bill = new Bill(mockHolidayService);

        DateTime input = new DateTime(2019, 9, 22);
        var expected = input.AddDays(1);
        var output = _bill.CheckDate(input);
        Assert.AreEqual(expected, output);
    }

    // test 3 the way I think it should be
    [Test]
    public void IfDueDateIsAFridayHoliday_ReturnMondayAfterWeekend()
    {
        IHolidayService mockHolidayService = new HolidayService();
        Bill _bill = new Bill(mockHolidayService);

        DateTime input = new DateTime(2019, 9, 27);
        var expected = input.AddDays(3);
        var output = _bill.CheckDate(input);
        Assert.AreEqual(expected, output);
    }

    // test 4 the way I think it should be
    [Test]
    public void IfDueDateIsAWeekdayHolidayNotFriday_ReturnNextDay()
    {
        IHolidayService mockHolidayService = new HolidayService();
        Bill _bill = new Bill(mockHolidayService);

        DateTime input = new DateTime(2019, 12, 25);
        var expected = input.AddDays(1);
        var output = _bill.CheckDate(input);
        Assert.AreEqual(expected, output);
    }

    // test 1
    [Test]
    public void IfSaturday_ReturnMonday()
    {
        DateTime input = new DateTime(2019, 9, 21);
        var output = input;

        DateTime actualDuedate = new DateTime(2019, 9, 23);

        if (input.DayOfWeek == DayOfWeek.Saturday)
        {
            output = input.AddDays(2);
        }

        var expected = actualDuedate;
        Assert.AreEqual(expected, output);
    }

    //test 2
    [Test]
    public void IfSunday_ReturnMonday()
    {
        DateTime input = new DateTime(2019, 9, 22);
        var output = input;

        DateTime actualDuedate = new DateTime(2019, 9, 23);

        if (input.DayOfWeek == DayOfWeek.Sunday)
        {
            output = input.AddDays(1);
        }

        var expected = actualDuedate;
        Assert.AreEqual(expected, output);
    }

    // test 3
    [Test]
    public void IfHoliday_ReturnNonHoliday()
    {
        DateTime input = new DateTime(2019, 12, 25);
        DateTime christmas = new DateTime(2019, 12, 25);
        var output = input;

        DateTime actualDuedate = new DateTime(2019, 12, 26);

        if (input == christmas)
        {
            output = input.AddDays(1);
        }

        var expected = actualDuedate;
        Assert.AreEqual(expected, output);
    }

    // test 4
    [Test]
    public void IfHoliday_ReturnWeekday()
    {
        DateTime input = new DateTime(2019, 1, 1);
        DateTime newYears = new DateTime(2019, 1, 1);
        var output = input;

        DateTime actualDuedate = new DateTime(2019, 1, 2);

        if (input == newYears)
        {
            output = input.AddDays(1);
        }

        var expected = actualDuedate;
        Assert.AreEqual(expected, output);
    }
}

