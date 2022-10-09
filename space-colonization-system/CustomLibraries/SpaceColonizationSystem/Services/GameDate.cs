
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
}