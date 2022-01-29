using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;

namespace Fateblade.Alexandria.Logic.Foundation.Meta.Dice.Contract
{
    public interface IComplexDiceFormulaBuilder
    {
        /// <summary>
        /// adds a single dice of the given type to the formula
        /// i.e.[previous steps] + 1d6
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        IComplexDiceFormulaBuilder AddDice(DiceType type);

        /// <summary>
        /// adds a given amount of the given dice type to the formula
        /// i.e. [previous steps] + 3d8
        /// </summary>
        /// <param name="type"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        IComplexDiceFormulaBuilder AddDice(DiceType type, int amount);

        /// <summary>
        /// adds a given amount of the given dice type to the formula with a flat modifier
        /// i.e. [previous steps] + 4d10+5
        /// </summary>
        /// <param name="type"></param>
        /// <param name="amount"></param>
        /// <param name="modifier"></param>
        /// <returns></returns>
        IComplexDiceFormulaBuilder AddDiceWithFlatModifier(DiceType type, int amount, int modifier);

        /// <summary>
        /// adds a given amount of the given dice type to the formula with a multiplicator
        /// i.e. [previous steps] + 2d12*3
        /// </summary>
        /// <param name="type"></param>
        /// <param name="amount"></param>
        /// <param name="multiplier"></param>
        /// <returns></returns>
        IComplexDiceFormulaBuilder AddDiceWithMultiplier(DiceType type, int amount, int multiplier);

        /// <summary>
        /// adds a given amount of the given dice type to the formula with a flat modifier multiplying the result by the given value
        /// [previous steps] + (8d4+8)*2
        /// </summary>
        /// <param name="type"></param>
        /// <param name="amount"></param>
        /// <param name="modifier"></param>
        /// <param name="multiplicator"></param>
        /// <returns></returns>
        IComplexDiceFormulaBuilder AddDiceWithFlatModifierAndMultiplier(DiceType type, int amount, int modifier, int multiplicator);

        /// <summary>
        /// adds a multiplication to the sum of all previous steps.
        /// i.e. ([previous steps]) * 9
        /// </summary>
        /// <param name="multiplicator"></param>
        /// <returns></returns>
        IComplexDiceFormulaBuilder AddMultiplicator(int multiplicator);

        /// <summary>
        /// adds a division to the sum of all previous steps.
        /// i.e. ([previous steps]) / 9
        /// </summary>
        /// <param name="divider"></param>
        /// <returns></returns>
        IComplexDiceFormulaBuilder AddDivider(int divider);

        /// <summary>
        /// adds a value to the sum of all previous steps.
        /// i.e. ([previous steps]) + 9
        /// </summary>
        /// <param name="modifier"></param>
        /// <returns></returns>
        IComplexDiceFormulaBuilder AddFlatModifier(int modifier);

        /// <summary>
        /// instead of adding to the total the next step will be multiplied with the sum of the previous steps
        /// i.e. ([previous steps] * [next step]) + [further steps]
        /// </summary>
        /// <returns></returns>
        IComplexDiceFormulaBuilder AddMultiplicatorStep();

        /// <summary>
        /// returns a cloned instance of the current builder state
        /// </summary>
        /// <returns></returns>
        IComplexDiceFormulaBuilder Clone();

        /// <summary>
        /// clears all steps from the builder
        /// </summary>
        void Clear();

        /// <summary>
        /// builds the formula
        /// </summary>
        /// <returns></returns>
        IDiceFormula Build();
    }
}
