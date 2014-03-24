using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace RecipiesWebFormApp.Shared
{
    public static class StopwatchHelper
    {
        private static Dictionary<string, Stopwatch> stopwatches = new Dictionary<string, Stopwatch>();

        public static void StartNewMeasurement(string stopwatchName)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatches[stopwatchName] = stopwatch; 
        }

        public static long StopLastMeasurement(string stopwatchName)
        {
            Stopwatch stopwatch = stopwatches[stopwatchName];
            stopwatch.Stop();
            //stopwatches.Remove(stopwatchName);
            long milliseconds = stopwatch.ElapsedMilliseconds;
            return milliseconds;
        }
    }
}
