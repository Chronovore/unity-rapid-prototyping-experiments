using FluentAssertions;
using SpaceColonizationSystem.Services;
using Xunit;

namespace SpaceColonizationSystem.Tests.Unit.Services
{

    public class GameDateServiceTests
    {

        private readonly GameDateConfig _config;
        private readonly GameDateService _subject;

        public GameDateServiceTests()
        {
            _config = new GameDateConfig(new GameDate(1, 0.0f, 1), 5, 5, 5);
            _subject = new GameDateService(_config);
        }

        [Theory]
        [InlineData(1.5f, 2, 1)]
        [InlineData(-1.0f, 1, 1)]
        [InlineData(1000.3f, 1, 8)]
        private void AddingDaysIncrementsDay(float daysToAdd, int expectedDayOfYear, int expectedYear)
        {
            var result = _subject.Add(daysToAdd);

            result.CurrentDayProgress.Should().Be(daysToAdd - (int) daysToAdd);
            result.DayOfYear.Should().Be(expectedDayOfYear);
            result.Year.Should().Be(expectedYear);
        }
    }
}