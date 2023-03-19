using OnlineStore.Application.Common.Interfaces;

namespace OnlineStore.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
