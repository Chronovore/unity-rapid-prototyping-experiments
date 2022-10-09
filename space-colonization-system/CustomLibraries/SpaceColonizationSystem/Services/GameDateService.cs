namespace SpaceColonizationSystem.Services
{
    public readonly struct GameDateConfig
    {
        public GameDate StartingDate { get; }
        public int DaysPerWeek { get; }
        public int WeeksPerMonth { get; }
        public int MonthsPerYear { get; }

        public GameDateConfig(GameDate gameDate, int daysPerWeek, int weeksPerMonth, int monthsPerYear)
        {
            StartingDate = gameDate;
            DaysPerWeek = daysPerWeek;
            WeeksPerMonth = weeksPerMonth;
            MonthsPerYear = monthsPerYear;
        }
    }

    public class GameDateService
    {
        private readonly GameDateConfig _config;

        public GameDateService(GameDateConfig config)
        {
            _config = config;
        }

        public GameDate Add(float daysToAdd)
        {
            throw new System.NotImplementedException();
        }
    }
}