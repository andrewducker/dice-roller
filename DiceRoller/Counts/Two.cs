using System.Collections.Generic;
using DiceRoller.Rollers;

namespace DiceRoller.Counts
{
    static class Two
    {
        static public List<IRollable> D(int maxValue)
        {
            return new List<IRollable> {new Die(maxValue), new Die(maxValue)};
        }
    }
}
