using System;
namespace Common
{
    public  class Tools
    {
        public static int ConvertDateTimeToUnix(DateTime time)
        {
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds;
        }
    }
}
