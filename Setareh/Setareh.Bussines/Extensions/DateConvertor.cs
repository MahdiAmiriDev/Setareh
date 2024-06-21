using System.Globalization;

namespace Setareh.Bussines.Extensions
{
    public static class DateConvertor
    {
        public static string ToShamsi(this DateOnly value)
        {
            PersianCalendar pc = new();

            DateTime dateTime = new DateTime(value.Year, value.Month, value.Day, 0, 0, 0, 0);

            return pc.GetYear(dateTime) + "/" +
                pc.GetMonth(dateTime).ToString("00") + "/" +
                pc.GetDayOfMonth(dateTime).ToString("00");

        }
    }
}
