
namespace SpaceColonizationSystem.Services
{
    public class GameDate
    {
        public int DayOfYear { get; set; }
        public int Year { get; set; }
        public float CurrentDayProgress { get; set; }

        public GameDate(int dayOfYear, float currentDayProgress, int year)
        {
            DayOfYear = dayOfYear;
            CurrentDayProgress = currentDayProgress;
            Year = year;
        }
    }

    public class FullGameDate
    {
        public int DayOfMonth { get; }
        public string DayName { get; } = string.Empty;
        public string MonthName { get; } = string.Empty;
        public int Year { get; }

        public FullGameDate()
        {
        }

        public FullGameDate(int dayOfMonth, string dayName, string monthName, int year)
        {
            DayOfMonth = dayOfMonth;
            DayName = dayName;
            MonthName = monthName;
            Year = year;
        }
    }
}