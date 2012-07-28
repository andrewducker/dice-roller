using System.Collections.Generic;
using System.Linq;

namespace DiceRoller.Rollers
{
    static class Best
    {
        public static IRollable Of(IEnumerable<IRollable> rollables)
        {
            return new BestOf(rollables);
        }

        private class BestOf : IRollable
        {
        private readonly IEnumerable<IRollable> rollables;
        public BestOf(IEnumerable<IRollable> rollables)
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
            var value = MinValue;
            foreach (var result in rollables.Select(rollable => rollable.Roll()).Where(result => result > value))
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
