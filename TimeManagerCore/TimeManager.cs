using System.Globalization;

public interface ITimeManager
{
    public string GetTime();
    public bool SetTimeZone(string olsonTimeZone);
    public string ConvertDate(string dateTime);
}

public class TimeManager : ITimeManager
{
    private TimeZoneInfo timeZoneInfo = TimeZoneInfo.Utc;
    const string ResultDateTimeFormat = "dd.MM.yyyy HH:mm:ss zzzz";

    public string GetTime()
    {
        var dateTime = TimeZoneInfo.ConvertTime(DateTimeOffset.Now, timeZoneInfo);
        return dateTime.ToString(ResultDateTimeFormat);

    }

    public bool SetTimeZone(string olsonTimeZone)
    {
        var timeZone = TimeZoneConverter.OlsonTimeZoneToTimeZoneInfo(olsonTimeZone);
        if (timeZone == null)
            return false;
        timeZoneInfo = timeZone;
        return true;
    }

    public string ConvertDate(string dateTime)
    {
        var format1 = "dd.MM.yyyy HH:mm:ss zzzz";
        var format2 = "dd.MM.yyyy HH:mm";
        var format3 = "dd/MM/yyyy HH-mm-ss";
        var allFormats = new[] { format1, format2, format3 };
        foreach (var format in allFormats)
        {
            if (DateTimeOffset.TryParseExact(dateTime, format, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out var result))
            {
                return result.ToString(ResultDateTimeFormat);
            }
        }
        return string.Empty;
    }
}

