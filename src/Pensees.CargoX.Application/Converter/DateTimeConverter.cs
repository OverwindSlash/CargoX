using AutoMapper;
using System;

namespace Pensees.CargoX.Converter
{
    public class DateTimeConverter : IValueConverter<string, DateTime>
    {
        public DateTime Convert(string sourceMember, ResolutionContext context)
        {
            if (DateTimeParseHelper.ParseDateTime(sourceMember).HasValue)
            {
                return DateTimeParseHelper.ParseDateTime(sourceMember).Value;
            }

            return DateTime.MinValue;
        }
    }
}
