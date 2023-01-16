﻿using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Module4HW6.Converters
{
    public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
    {
        public DateOnlyConverter()
            : base(
                  d => d.ToDateTime(TimeOnly.MinValue),
                  d => DateOnly.FromDateTime(d))
        {
        }
    }
}
