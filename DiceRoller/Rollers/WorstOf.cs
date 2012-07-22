using System.Collections.Generic;
using System.Linq;

namespace DiceRoller.Rollers
{
    class WorstOf: IRollable
    {
        readonly List<IRollable> rollables = new List<IRollable>();
        public WorstOf(IRollable die, int numberOfDice)
        {
            for (var i = 0; i < numberOfDice; i++)
            {
                rollables.Add(die);
            }
            MaxValue = die.MaxValue;
            MinValue = die.MinValue;
        }

        public int Roll()
        {
            var value = MaxValue;
            foreach (var result in rollables.Select(rollable => rollable.Roll()).Where(result => result < value))
            {
                value = result;
            }
            return value;
        }

        public int MaxValue { get; private set; }

        public int MinValue { get; private set; }
    }
}
