using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;

namespace Fateblade.Alexandria.Logic.Foundation.Meta.Dice.Contract
{
    public interface IDiceFactory
    {
        IDice CreateDice(DiceType diceType);
        IDice CreateCustomDice(uint sides);
        IDiceCollection CreateDices(int amount, DiceType diceType);
        IDiceCollection CreateCustomDices(int amount, uint sides);
        IDiceFormula CreateDiceFormula(DiceType diceType, int diceAmount, int modifier, bool isModifierPerDice, bool isNegativeModifierResultPerDiceAllowed);
        IDiceFormula CreateDiceFormula(uint diceSides, int diceAmount, int modifier, bool isModifierPerDice, bool isNegativeModifierResultPerDiceAllowed);
        IDiceFormula CreateDiceFormula(IDiceCollection dice, int modifier, bool isModifierPerDice, bool isNegativeModifierResultPerDiceAllowed);
    }
}
