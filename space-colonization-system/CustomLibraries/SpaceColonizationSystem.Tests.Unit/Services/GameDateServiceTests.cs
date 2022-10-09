using FluentAssertions;
using SpaceColonizationSystem.Services;
using Xunit;

namespace SpaceColonizationSystem.Tests.Unit.Services
{

    public class GameDateServiceTests
    {
        private const int StartingDay = 1;
        private const int StartingYear = 1;

        private readonly GameDateConfig _config;
        private readonly GameDateService _subject;

        public GameDateServiceTests()
        {
            _config = new GameDateConfig(new GameDate(StartingDay, 0.0f, StartingYear), 5, 5, 5);
            _subject = new GameDateService(_config);
        }

        [Fact]
        private void InitializesDate()
        {
            _subject.Date.DayOfYear.Should().Be(StartingDay);
            _subject.Date.Year.Should().Be(StartingYear);
        }

        [Theory]
        [InlineData(1.5f, 2, 1)]
        [InlineData(-1.0f, 1, 1)]
        [InlineData(1000.3f, 1, 9)]
        private void AddingDaysIncrementsDay(float daysToAdd, int expectedDayOfYear, int expectedYear)
        {
            _subject.Date.DayOfYear.Should().Be(StartingDay);
            
            _subject.Add(daysToAdd);

            var result = _subject.Date;
            result.CurrentDayProgress.Should().Be(daysToAdd - (int) daysToAdd);
            result.DayOfYear.Should().Be(expectedDayOfYear);
            result.Year.Should().Be(expectedYear);
        }
    }
}