

using System.Globalization;

namespace Setareh.Bussines.Extensions
{
    public static class DateExtensions
    {
        public static string ToShamsi(this DateTime date)
        {
            PersianCalendar pc = new();

            var year = pc.GetYear(date);
            var month = pc.GetMonth(date);
            var day = pc.GetDayOfMonth(date);

            return $"{year}/{month.ToString("00")}/{day.ToString("00")}";

        }
    }
}
