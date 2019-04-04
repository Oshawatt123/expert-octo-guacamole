using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionaryAI
{
    public class RandomHelper
    {
        private static Random rand = new Random();

        /// <summary>
        /// Generates and returns a random number between min and max
        /// </summary>
        /// <param name="min">Inclusive</param>
        /// <param name="max">Exclusive</param>
        /// <returns></returns>
        public static float Range(float min, float max)
        {
            float returnValue = min + ((float)rand.NextDouble() * (max-min));
            return returnValue;
        }

        /// <summary>
        /// Gemnerates and return a random integer.
        /// </summary>
        /// <param name="min">Inclusive</param>
        /// <param name="max">Exclusive</param>
        /// <returns></returns>
        public static int RandInt(int min, int max)
        {
            return rand.Next(min, max);
        }
    }
}
