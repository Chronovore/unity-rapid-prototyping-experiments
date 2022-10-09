using FluentAssertions;
using SpaceColonizationSystem.Services;
using Xunit;

namespace SpaceColonizationSystem.Tests.Unit.Services
{

    public class GameDateServiceTests
    {
        private const int StartingDay = 0;
        private const int StartingYear = 1;
        private readonly string[] _daysOfWeek = {"One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten"};
        private readonly string[] _monthsOfYear = {"First", "Second", "Third", "Fourth", "Fifth", "Sixth", "Seventh", "Eighth", "Ninth", "Tenth"};

        private readonly GameDateConfig _config;
        private readonly GameDateService _subject;

        public GameDateServiceTests()
        {
            _config = new GameDateConfig(new GameDate(StartingDay, 0.0f, StartingYear), 4, _daysOfWeek, _monthsOfYear);
            _subject = new GameDateService(_config);
        }

        [Fact]
        private void InitializesDate()
        {
            _subject.Date.DayOfYear.Should().Be(StartingDay);
            _subject.Date.Year.Should().Be(StartingYear);
        }

        [Theory]
        [InlineData(1.5f, 1, 1)]
        [InlineData(-1.0f, 0, 1)]
        [InlineData(1000.3f, 200, 3)]
        private void AddingDaysIncrementsDay(float daysToAdd, int expectedDayOfYear, int expectedYear)
        {
            _subject.Add(daysToAdd);

            var result = _subject.Date;
            result.CurrentDayProgress.Should().Be(daysToAdd - (int) daysToAdd);
            result.DayOfYear.Should().Be(expectedDayOfYear);
            result.Year.Should().Be(expectedYear);
        }
        
        [Theory]
        [InlineData(1.5f, "Two", "First", 2, 1)]
        [InlineData(-1.0f, "One", "First", 1, 1)]
        [InlineData(1000.3f, "One", "Sixth", 1, 3)]
        [InlineData(45.7f, "Six", "Second", 6, 1)]
        private void DayOfWeekIsCalculatedProperly(float daysToAdd, string expectedDay, string expectedMonth, int expectedMonthDay, int expectedYear)
        {
            _subject.Add(daysToAdd);
            
            var result = _subject.FullGameDate;
            result.DayName.Should().Be(expectedDay);
            result.MonthName.Should().Be(expectedMonth);
            result.DayOfMonth.Should().Be(expectedMonthDay);
            result.Year.Should().Be(expectedYear);
        }
        
    }
}