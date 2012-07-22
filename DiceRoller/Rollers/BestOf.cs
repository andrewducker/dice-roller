using System.Collections.Generic;
using System.Linq;

namespace DiceRoller.Rollers
{
    class BestOf : IRollable
    {
        readonly List<IRollable> rollables = new List<IRollable>();
        public BestOf(IRollable die, int numberOfDice)
        {
            for (var i = 0; i < numberOfDice; i++)
            {
                rollables.Add(die);
            }
            MaxValue = die.MinValue;
            MinValue = die.MaxValue;
        }
        public BestOf(){}

        public int Roll()
        {
            var value = MaxValue;
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
