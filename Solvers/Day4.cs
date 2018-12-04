using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Solvers
{
    public static class Day4
    {
        public static int Part1Solver(string[] input)
        {
            var minutesAsleep = CalculateMinutesAsleep(input);
            var sleepiestGuard = minutesAsleep.MaxBy(m => m.Value.Sum()).Single().Key;
            var sleepiestMinute = minutesAsleep[sleepiestGuard]
                    .Select((sleepCount, index) => (sleepCount, index))
                    .MaxBy(x => x.sleepCount).Single().index;
            return sleepiestGuard * sleepiestMinute;
        }

        private static Dictionary<int, int[]> CalculateMinutesAsleep(string[] input)
        {
            int currentGuard = -1;
            DateTime sleepFrom = DateTime.MinValue;
            var minutesAsleep = new Dictionary<int, int[]>();
            foreach (var (t, g, e) in input.Select(ParseLine).OrderBy(x => x.t))
            {
                if (e == GuardEvent.BeginShift)
                {
                    currentGuard = g;
                }
                else if (e == GuardEvent.FallAsleep)
                {
                    sleepFrom = t;
                }
                else if (e == GuardEvent.WakeUp)
                {
                    if (!minutesAsleep.ContainsKey(currentGuard))
                    {
                        minutesAsleep[currentGuard] = new int[60];
                    }
                    if (t.Hour != 0) throw new InvalidOperationException("not expected");
                    for (var m = sleepFrom.Minute; m < t.Minute; m++)
                    {
                        minutesAsleep[currentGuard][m]++;
                    }
                }
            }

            return minutesAsleep;
        }

        public static int Part2Solver(string[] input)
        {
            var minutesAsleep = CalculateMinutesAsleep(input);
            var sleepiestMinute = minutesAsleep
                    .SelectMany(kvp => 
                        kvp.Value.Select((sleepCount, minute) => 
                        new { Guard = kvp.Key, sleepCount, minute }))
                    .MaxBy(x => x.sleepCount).Single(); 

            return sleepiestMinute.Guard * sleepiestMinute.minute;
        }

        private static (DateTime t, int g, GuardEvent e) ParseLine(string input)
        {
            var regex = new Regex(@"\[(.+)\] (Guard #(\d+) begins shift|wakes up|falls asleep)");
            var g = regex.Match(input).Groups;
            var time = DateTime.Parse(g[1].Value);
            var eventType = g[2].Value == "falls asleep" ? GuardEvent.FallAsleep:
                g[2].Value == "wakes up" ? GuardEvent.WakeUp : GuardEvent.BeginShift;
            var guard = (eventType == GuardEvent.BeginShift) ? int.Parse(g[3].Value) : 0;
            return (time, guard, eventType);
        }

        enum GuardEvent
        {
            BeginShift,
            WakeUp,
            FallAsleep
        }

    }
}
