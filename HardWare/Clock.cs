using System;


namespace HW
{

    public static class Clock
    {
        private static System.Timers.Timer clock;


        public delegate void ClockEventHendler();
        public static event ClockEventHendler ClockEvent;

        public static void Init()
        {

            clock = new System.Timers.Timer(1000);

            clock.Elapsed += OnTimedEvent;

            clock.AutoReset = true;
            clock.Enabled = true;

        }
        private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            if (ClockEvent != null)
                ClockEvent();
        }
    }
}