using BlazorCA.Application.Common.Interfaces;

namespace BlazorCA.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
