using System.Collections.Generic;
using System.Linq;

namespace DiceRoller.Rollers
{
    class RollAndAdd : IRollable
    {
        readonly List<IRollable> rollables = new List<IRollable>();
        public RollAndAdd(params int[] maxValues)
        {
            MaxValue = 0;
            MinValue = 0;
            foreach (var value in maxValues)
            {
                MaxValue += value;
                MinValue++;
                rollables.Add((Die)value);
            }
        }

        public int Roll()
        {
            return rollables.Sum(rollable => rollable.Roll());
        }

        public int MaxValue { get; private set; }

        public int MinValue { get; private set; }
    }
}
