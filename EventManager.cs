using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CookieClicker
{
    internal class EventManager
    {
        private MainWindow mainWindow;

        public EventManager(MainWindow window)
        {
            mainWindow = window;
        }

        public void RunRandomEvent()
        {
            Random random = new();
            int eventsLength = Enum.GetValues(typeof(EventType)).Length;
            
            switch(random.Next(eventsLength))
            {
                case 0: RunCookieRain(); break;
                case 1: RunGoldenCookie(); break;
            }
        }

        private void RunCookieRain()
        {
            Random random = new();
            int duration = EventTypeHelper.GetDurationInSeconds(EventType.COOKIE_RAIN);

            Thread eventThread = new(() =>
            {
                DateTime threadEndTime = DateTime.Now.AddSeconds(duration);

                while(DateTime.Now < threadEndTime) {

                    // Dispatcher is used because i can't modify GUI on other thread than main
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        mainWindow.SummonRainCookie(EventTypeHelper.GetCookieMultiplier(EventType.COOKIE_RAIN));
                    });

                    Thread.Sleep(random.Next(100, 400));
                }
            });

            eventThread.Start();
        }

        private void RunGoldenCookie()
        {
            // Dispatcher is used because i can't modify GUI on other thread than main
            Application.Current.Dispatcher.Invoke(() =>
            {
                mainWindow.SummonGoldenCookie(EventTypeHelper.GetCookieMultiplier(EventType.GOLDEN_COOKIE));
            });
        }
    }

    internal enum EventType
    {
        COOKIE_RAIN,
        GOLDEN_COOKIE
    }

    internal class EventTypeHelper
    {
        public static int GetDurationInSeconds(EventType eventType)
        {
            Random random = new();

            switch (eventType)
            {
                case EventType.COOKIE_RAIN:
                    return random.Next(30, 60);
            
                default:
                    return -1;
            }
        }

        public static int GetCookieMultiplier(EventType eventType)
        {
            Random random = new();

            switch (eventType) {
                case EventType.COOKIE_RAIN:
                    return random.Next(1, 5);

                case EventType.GOLDEN_COOKIE:
                    return random.Next(20, 50);

                default:
                    return 1;
            }
        }
    }
}
