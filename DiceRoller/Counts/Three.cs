using System.Collections.Generic;
using DiceRoller.Rollers;

namespace DiceRoller.Counts
{
    class Three
    {
        static public List<IRollable> D(int maxValue)
        {
            return new List<IRollable> { new Die(maxValue), new Die(maxValue), new Die(maxValue) };
        }
    }
}
