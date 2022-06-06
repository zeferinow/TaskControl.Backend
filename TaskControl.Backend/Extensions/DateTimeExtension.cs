using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskControl.Backend.Models;

namespace TaskControl.Backend.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateOnly ToDateOnly(this DateTime value)
        {
            return new DateOnly { Value = value };
        }

        public static DateOnly ToDateOnly(this DateTime? nullableValue)
        {
            if (nullableValue != null)
            {
                return new DateOnly { Value = nullableValue.Value };
            }

            return null;
        }
        public static bool IsEmpty(this DateTime dateTime)
        {
            return dateTime == default;
        }

        public static DateTime? ToNullableDateTime(this DateTime dateTime)
        {
            if (dateTime == DateTime.MinValue)
            {
                return null;
            }

            return dateTime;
        }

        public static int TotalMonths(this DateTime initialDate, DateTime finalDate)
        {
            return (finalDate.Year * 12 + finalDate.Month) - (initialDate.Year * 12 + initialDate.Month);
        }

        public static DateTime AddWeeks(this DateTime date, int weeks)
        {
            return date.AddDays(7 * weeks);
        }
    }
}
