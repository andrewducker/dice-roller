using System.Collections.Generic;
using DiceRoller.Rollers;

namespace DiceRoller
{
    class Roller
    {
        public static Results Roll(int iterations, params IRollable[] toAdd)
        {
            var roller = new Roller();
            foreach (var rollable in toAdd)
            {
                roller.AddRollable(rollable);
            }
            return roller.Roll(iterations);
        }


        private readonly List<IRollable> rollables = new List<IRollable>();
        private int maxValue = int.MinValue;
        private int minValue = int.MaxValue;

        public void AddRollable(IRollable toAdd)
        {
            if (toAdd.MaxValue > maxValue )
            {
                maxValue = toAdd.MaxValue;
            }
            if (toAdd.MinValue < minValue)
            {
                minValue = toAdd.MinValue;
            }
            rollables.Add(toAdd);
        }

        public Results Roll()
        {
            var results = new Results();
            foreach (var rollable in rollables)
            {
                results.AddResult(rollable.Roll());
            }
            return results;
        }
        public Results Roll(int times)
        {
            var results = new Results();
            for (int i = 0; i < times; i++)
            {
                foreach (var rollable in rollables)
                {
                    results.AddResult(rollable.Roll());
                }
            }
            return results;
        }

    }
}
