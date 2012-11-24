﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Californium
{
    public static class Timer
    {
        public delegate bool RepeatingTimerEvent();
        public delegate void TimerEvent();

        class TimerInfo
        {
            public RepeatingTimerEvent Event;
            public float StartTime;
            public float Time;
        }

        private static List<TimerInfo> timers = new List<TimerInfo>();

        public static void NextFrame(TimerEvent callback)
        {
            timers.Add(new TimerInfo { Event = () => { callback(); return true; } });
        }

        public static void EveryFrame(RepeatingTimerEvent callback)
        {
            timers.Add(new TimerInfo { Event = callback });
        }

        public static void After(float time, TimerEvent callback)
        {
            timers.Add(new TimerInfo { Event = () => { callback(); return true; }, Time = time });
        }

        public static void Every(float time, RepeatingTimerEvent callback)
        {
            timers.Add(new TimerInfo { Event = callback, StartTime = time, Time = time });
        }

        public static void Update(float dt)
        {
            List<TimerInfo> timersCopy = new List<TimerInfo>(timers);
            List<TimerInfo> toRemove = new List<TimerInfo>();

            foreach (var timer in timersCopy)
            {
                timer.Time -= dt;
                if (timer.Time <= 0)
                {
                    if (timer.Event())
                        toRemove.Add(timer);
                    else
                        timer.Time = timer.StartTime;
                }
            }

            timers.RemoveAll(toRemove.Contains);
        }
    }
}