using System;

namespace _Game.Source.Tools
{
    public static class DateUtility
    {
        /// <summary>
        /// Проверяет, прошло ли указанное количество времени с момента startTime.
        /// </summary>
        public static bool HasTimePassed(DateTime startTime, TimeSpan duration)
        {
            return DateTime.UtcNow >= startTime + duration;
        }

        public static bool IsAnotherDay(DateTime startTime, DateTime now)
        {
            return now.Date > startTime.Date;
        }
        /// <summary>
        /// Возвращает TimeSpan, прошедший с указанного времени.
        /// </summary>
        public static TimeSpan TimeSince(DateTime since)
        {
            return DateTime.UtcNow - since;
        }

        public static double SecondsSince(DateTime since)
        {
            return TimeSince(since).TotalSeconds;
        }

        public static double MinutesSince(DateTime since)
        {
            return TimeSince(since).TotalMinutes;
        }

        public static double HoursSince(DateTime since)
        {
            return TimeSince(since).TotalHours;
        }

        /// <summary>
        /// Возвращает оставшееся время до deadline (если уже прошло — вернет TimeSpan.Zero).
        /// </summary>
        public static TimeSpan GetRemainingTime(DateTime deadline)
        {
            var remaining = deadline - DateTime.UtcNow;
            return remaining > TimeSpan.Zero ? remaining : TimeSpan.Zero;
        }

        /// <summary>
        /// Проверяет, находится ли текущее время между start и end.
        /// </summary>
        public static bool IsNowBetween(DateTime start, DateTime end)
        {
            var now = DateTime.UtcNow;
            return now >= start && now <= end;
        }

        /// <summary>
        /// Возвращает true, если прошло менее указанного времени.
        /// </summary>
        public static bool IsWithin(DateTime since, TimeSpan timeWindow)
        {
            return TimeSince(since) < timeWindow;
        }
    }
}