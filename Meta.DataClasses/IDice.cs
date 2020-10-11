namespace Fateblade.Alexandria.CrossCutting.Meta.DataClasses
{
    public interface IDice
    {
        DiceType DiceType { get; }
        int Roll();
        int LastRollResult { get; }
    }
}
