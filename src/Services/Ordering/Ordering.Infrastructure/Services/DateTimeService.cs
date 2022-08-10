using Ordering.Application.Common.Interfaces;

namespace Ordering.Infrastructure.Services
{
    internal class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
