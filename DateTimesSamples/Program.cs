namespace DateTimesSamples;

class Program
{
    static void Main(string[] args)
    {
        var zoneId = TimeZoneInfo.Local.Id;
        // string zoneId = "Central Standard Time";
        TimeZoneInfo zone = TimeZoneInfo.FindSystemTimeZoneById(zoneId);
    }
    
}

public class CustomDateTime
{
    public static DateTime ToLocalTime(DateTime time)
    {
        if (time.Kind == DateTimeKind.Local)
        {
            return time;
        }
        else if (time.Kind == DateTimeKind.Utc)
        {
            DateTime returnTime = new DateTime(time.Ticks, DateTimeKind.Local);
            returnTime += GetUtcOffset(returnTime);
            if (TimeZoneInfo.Local.IsDaylightSavingTime(returnTime))
                returnTime -= new TimeSpan(1, 0, 0);
            return returnTime;
        }      
        else
        {
            throw new ArgumentException("The source time zone cannot be determined.");
        }      
    }
    
    private static TimeSpan GetUtcOffset(DateTime time)
    {
        return TimeZoneInfo.Local.GetUtcOffset(time);
    }
}


