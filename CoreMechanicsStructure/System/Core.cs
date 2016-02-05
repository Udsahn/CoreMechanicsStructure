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

using Udsahn.Framework;

namespace Udsahn
{
    class Core
    {
        static GameClock clock;
        int _intervalCount = 0;

        public void Begin()
        {
            // Initialize all required objects.
            Initialize();

            // Load all simulated assets.
            LoadContent();

            // Enters the game state loop.
            GameStateLoop(1000);

            Console.WriteLine();
        }

        /// <summary>
        /// Starts the game loop.
        /// </summary>
        /// <param name="lifespan">Amount of time to stay alive in milliseconds.</param>
        public void GameStateLoop(int lifespan)
        {
            // The game loop.
            while (lifespan > clock.GameTime.TotalGameInterval.TotalMilliseconds)
            {
                // Updates the clock.
                UpdateClock();

                // Updates all objects.
                Update(clock.GameTime);

                // Output simulated assets.
                Draw();
            }
        }

        protected void Initialize()
        {
            // Called once before all other methods.
            // Initialize all required objects.
            clock = new GameClock();
            clock.TimeMultiplier = 2.1;

            Console.WriteLine("\nSimulation Initialized. Clock time variance multiplier set to :: " + clock.TimeMultiplier);
        }

        protected void LoadContent()
        {
            // Called once after Initialize()
            // Load all simulated assets.

            Console.WriteLine("Content Loaded...\n");
        }

        protected void Update(GameTime gameTime)
        {
            _intervalCount++;

            // Update objects.

        }

        protected void Draw()
        {
            // Output simulated assets.
            Console.WriteLine("Interval - " + _intervalCount + " :: " + clock.ElapsedGameIntervals.TotalMilliseconds + "ms elapsed :: " + clock.TotalGameIntervals.TotalMilliseconds + "ms total time.");
        }

        protected void UpdateClock()
        {
            // Update GameTime
            clock.Tick();
        }
    }
}
