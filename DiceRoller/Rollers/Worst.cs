﻿using System.Collections.Generic;
using System.Linq;

namespace DiceRoller.Rollers
{
    static class Worst
    {
        public static IRollable Of(IEnumerable<IRollable> rollables)
        {
            return new WorstOf(rollables);
        }
        class WorstOf : IRollable
        {
            readonly IEnumerable<IRollable> rollables = new List<IRollable>();
            public WorstOf(IEnumerable<IRollable> rollables)
            {
                this.rollables = rollables;
                MaxValue = int.MinValue;
                MinValue = int.MaxValue;
                foreach (var rollable in rollables.Where(rollable => rollable.MinValue < MinValue))
                {
                    MinValue = rollable.MinValue;
                }
                foreach (var rollable in rollables.Where(rollable => rollable.MaxValue > MaxValue))
                {
                    MaxValue = rollable.MaxValue;
                }
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
}
