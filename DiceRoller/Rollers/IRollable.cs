using System.Collections.Generic;
namespace DiceRoller.Rollers
{
    interface IRollable
    {
        int Roll();
        int MaxValue { get;}
        int MinValue { get; }
    }

    static class IRollableExtensions
    {
        public static List<IRollable> And(this IRollable original, IRollable toAdd)
        {
            return new List<IRollable> {original, toAdd};
        }

        public static List<IRollable> And(this IEnumerable<IRollable> original, IRollable toAdd)
        {

            var rollables = new List<IRollable> {toAdd};
            rollables.AddRange(original);
            return rollables;
        }

        public static List<IRollable> And(this IEnumerable<IRollable> original, IEnumerable<IRollable> toAdd)
        {
            var rollables = new List<IRollable>();
            rollables.AddRange(original);
            rollables.AddRange(toAdd);
            return rollables;
            
        }

        public static Results Roll(this IEnumerable<IRollable> toRoll, int iterations)
        {
            var roller = new Roller();
            foreach (var rollable in toRoll)
            {
                roller.AddRollable(rollable);
            }
            return roller.Roll(iterations);
        }

        public static Results Roll(this IRollable rollable, int iterations)
        {
            var roller = new Roller();
            roller.AddRollable(rollable);
            return roller.Roll(iterations);
        }
        
        public static IEnumerable<IRollable> ToRollables(this IRollable singleton)
        {
            return new List<IRollable> { singleton };
        }
    }
}
