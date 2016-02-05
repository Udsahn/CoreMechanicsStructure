#region Liscense
/*

The MIT License (MIT)

Copyright (c) 2016 Udsahn

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

*/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace Udsahn.Framework
{
    /// <summary>
    /// Overly simplification of the MonoGame GameClock object. Not at all accurate, but enough for testing.
    /// </summary>
    class GameClock
    {
        // Used to simulate random fluctuations in time.
        Random r = new Random();

        int totalIntervals = 0;
        int baseTimePerInterval = 5;

        TimeSpan totalTime;
        TimeSpan elapsedTime;

        /// <summary>
        /// Represents a multiplier to simulate faster time every interval.
        /// </summary>
        public double TimeMultiplier { get { return _timeMultiplier; } set { _timeMultiplier = CheckMultiplier(value); } }
        double _timeMultiplier = 2.5;

        /// <summary>
        /// Represents the total number of times updated.
        /// </summary>
        public TimeSpan TotalGameIntervals { get { return new TimeSpan(0, 0, 0, 0, totalIntervals); } }

        /// <summary>
        /// Represents time elapsed between updates.
        /// </summary>
        public TimeSpan ElapsedGameIntervals { get { return elapsedTime; } }

        /// <summary>
        /// Snapshot of time.
        /// </summary>
        public GameTime GameTime { get; protected set; }

        public GameClock()
        {
            GameTime = new GameTime(TimeSpan.Zero, TimeSpan.Zero);
        }

        /// <summary>
        /// Updates GameTime.
        /// </summary>
        public void Tick()
        {
            // Simulates fluctuations in minute timing.
            double variance = (r.Next((int)(100d * TimeMultiplier)) / 100d) - (r.Next((int)(100d * TimeMultiplier)) / 100d);

            int timeDelta = (int)Math.Round(baseTimePerInterval * Math.Abs((TimeMultiplier + variance)));

            // at least 1 ms passed.
            if (timeDelta == 0)
                timeDelta = 1;

            totalIntervals += timeDelta;

            totalTime = new TimeSpan(0, 0, 0, 0, totalIntervals);
            elapsedTime = new TimeSpan(0, 0, 0, 0, timeDelta);

            this.GameTime = new GameTime(elapsedTime, totalTime);
        }

        /// <summary>
        /// Ensures value is not less than 1.
        /// </summary>
        private double CheckMultiplier(double value)
        {
            if (value < 1)
            {
                return 1;
            }
            else
                return value;
        }
    }
}
