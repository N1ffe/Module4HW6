using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Module4HW6.Converters
{
    public class TimeOnlyConverter : ValueConverter<TimeOnly, TimeSpan>
    {
        public TimeOnlyConverter()
            : base(
                  t => t.ToTimeSpan(),
                  t => TimeOnly.FromTimeSpan(t))
        {
        }
    }
}
