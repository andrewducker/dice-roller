namespace DiceRoller.Rollers
{
    interface IRollable
    {
        int Roll();
        int MaxValue { get;}
        int MinValue { get; }
    }
}
