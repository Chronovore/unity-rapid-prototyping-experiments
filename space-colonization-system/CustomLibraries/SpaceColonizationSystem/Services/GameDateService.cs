namespace SpaceColonizationSystem.Services
{
    public readonly struct GameDateConfig
    {
        public GameDate StartingDate { get; }
        public int DaysPerWeek => DaysOfWeek.Length;
        public int WeeksPerMonth { get; }
        public int DaysPerMonth => DaysPerWeek * WeeksPerMonth;
        public int MonthsPerYear => MonthsOfYear.Length;
        public string[] DaysOfWeek { get; }
        public string[] MonthsOfYear { get; }

        public int DaysPerYear { get; }

        public GameDateConfig(GameDate gameDate, int weeksPerMonth, string[] daysOfWeek, string[] monthsOfYear)
        {
            StartingDate = gameDate;
            DaysOfWeek = daysOfWeek;
            MonthsOfYear = monthsOfYear;
            WeeksPerMonth = weeksPerMonth;
            DaysPerYear = daysOfWeek.Length * WeeksPerMonth * monthsOfYear.Length;
        }
    }

    public class GameDateService
    {
        public GameDate Date { get; }
        public FullGameDate FullGameDate { get; private set; }
        
        private readonly GameDateConfig _config;

        public GameDateService(GameDateConfig config)
        {
            _config = config;
            Date = config.StartingDate;
            UpdateFullGameDate();
        }

        /// <summary>
        /// Increment the date by the number of days indicated.
        /// </summary>
        /// <param name="daysToAdd"></param>
        public void Add(float daysToAdd)
        {
            // future: Log and emit an error about negative time.
            if (daysToAdd < 0.0f) return;
            
            Date.CurrentDayProgress += daysToAdd;
            if (Date.CurrentDayProgress > 1.0f)
            {
                var newDays = (int) Date.CurrentDayProgress;
                Date.CurrentDayProgress -= newDays;
                // future: Emit an event for daysPassing.
                Date.DayOfYear += newDays;
                if (Date.DayOfYear >= _config.DaysPerYear)
                {

                    var newYears = Date.DayOfYear / _config.DaysPerYear;
                    Date.DayOfYear %= _config.DaysPerYear;
                    Date.Year += newYears;
                }
            }

            UpdateFullGameDate();
        }

        private void UpdateFullGameDate()
        {
            var day = _config.DaysOfWeek[Date.DayOfYear % _config.DaysPerWeek];
            var dayOfMonth = Date.DayOfYear % _config.DaysPerMonth + 1;
            var month = _config.MonthsOfYear[Date.DayOfYear / _config.DaysPerMonth];
            
            FullGameDate = new FullGameDate(dayOfMonth, day, month, Date.Year);
        }
    }
}