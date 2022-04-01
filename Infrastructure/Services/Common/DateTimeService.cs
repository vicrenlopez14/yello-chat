using Application.Common.Interfaces;

namespace Infrastructure.Services.Common;

public class DateTimeService : IDateTime
{
    public static DateTime Now => DateTime.Now;
    
}