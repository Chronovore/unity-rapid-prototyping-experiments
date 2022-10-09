namespace SpaceColonizationSystem.Services
{
    public readonly struct GameDateConfig
    {
        public GameDate StartingDate { get; }
        public int DaysPerWeek { get; }
        public int WeeksPerMonth { get; }
        public int MonthsPerYear { get; }

        public int DaysPerYear { get; }

        public GameDateConfig(GameDate gameDate, int daysPerWeek, int weeksPerMonth, int monthsPerYear)
        {
            StartingDate = gameDate;
            DaysPerWeek = daysPerWeek;
            WeeksPerMonth = weeksPerMonth;
            MonthsPerYear = monthsPerYear;
            DaysPerYear = DaysPerWeek * WeeksPerMonth * MonthsPerYear;
        }
    }

    public class GameDateService
    {
        private readonly GameDateConfig _config;

        public GameDateService(GameDateConfig config)
        {
            _config = config;
            Date = config.StartingDate;
        }

        public GameDate Date { get; private set; }

        /// <summary>
        /// Increment the date by the number of days indicated.
        /// </summary>
        /// <param name="daysToAdd"></param>
        public void Add(float daysToAdd)
        {
            // future: Log and emit an error about negative time.
            if (daysToAdd < 0.0f) return;
            
            Date.CurrentDayProgress += daysToAdd;
            if (Date.CurrentDayProgress < 1.0f) return;
            
            var newDays = (int)Date.CurrentDayProgress;
            Date.CurrentDayProgress -= newDays;
            // future: Emit an event for daysPassing.
            Date.DayOfYear += newDays;
            if (Date.DayOfYear <= _config.DaysPerYear) return;
            
            var newYears = Date.DayOfYear / _config.DaysPerYear;
            Date.DayOfYear %= _config.DaysPerYear;
            Date.Year += newYears;
        }
    }
}