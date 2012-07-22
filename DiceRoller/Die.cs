using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DiceRoller.Rollers;

namespace DiceRoller
{
    class Die : IRollable
    {
        private readonly int minValue;
        private readonly int maxValue;

        public Die(int maxValue, int minValue = 1)
        {
            this.maxValue = maxValue;
            this.minValue = minValue;
        }

        public int MinValue
        {
            get { return minValue; }
        }

        public int MaxValue
        {
            get { return maxValue; }
        }

        readonly static Random random = new Random();

        public int Roll()
        {
            return random.Next(minValue, maxValue+1);
        }

        public static implicit operator Die(int maxValue)
        {
            return new Die(maxValue);
        }
    }
}