using SpaceColonizationSystem.Services;
using UnityEngine;
using UnityEngine.UI;

namespace Time
{
    public class GameTimeBehaviour : MonoBehaviour
    {
        public static GameTimeBehaviour Instance { get; private set; }
        
        //todo:  Make this a nice visual date selector for designers.
        public float dayDurationInSeconds = 3.0f;
        public float gameTimeMultiplier = 0.0f;
        public bool isPaused = true;
        public int initialGameDay;
        public float initialDayProgress = 0.4f;
        public Text gameTimeUiTextElement;
        public int initialGameYear = 1;
        public int weeksPerMonth = 4;
        public string[] dayNames;
        public string[] monthNames;

        private GameDateService _gameDateService;

        public void SetSpeed(float speed)
        {
            isPaused = speed < float.Epsilon;
            gameTimeMultiplier = speed;
        }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }
    
        private void Start()
        {
            var startDate = new GameDate(initialGameDay, initialDayProgress, initialGameYear);
            _gameDateService = new GameDateService(new GameDateConfig(startDate, weeksPerMonth, dayNames, monthNames));
        }

        private void Update()
        {
            if (isPaused) return;
        
            _gameDateService.Add(UnityEngine.Time.deltaTime * gameTimeMultiplier / dayDurationInSeconds);
            gameTimeUiTextElement.text = GetFullDateString(_gameDateService.FullGameDate);
        }

        private static string GetFullDateString(FullGameDate date)
        {
            // future: add internationalization
            return $"{date.DayName} {date.DayOfMonth} {date.MonthName} {date.Year}";
        }
    }
}