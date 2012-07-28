using DiceRoller.Rollers;

namespace DiceRoller.Counts
{
    static class One
    {
        static public IRollable D(int count)
        {
            return new Die(count);
        }
    }
}
