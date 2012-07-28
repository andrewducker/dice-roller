using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DiceRoller.Rollers
{
    static class Sum
    {
        public static IRollable Of(IEnumerable<IRollable> rollables)
        {
            return new SumOf(rollables);
        }
        class SumOf : IRollable
        {
            readonly IEnumerable<IRollable> rollables;
            public SumOf(IEnumerable<IRollable> rollables)
            {
                this.rollables = rollables;
                MaxValue = 0;
                MinValue = 0;
                foreach (var die in rollables)
                {
                    MaxValue += die.MaxValue;
                    MinValue += die.MinValue;
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

}