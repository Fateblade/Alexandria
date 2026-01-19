using System;
using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;
using Fateblade.Alexandria.Logic.Foundation.Meta.Dice.Contract;
using System.Collections.Generic;
using Fateblade.Alexandria.Logic.Foundation.Meta.Dice.Contract.DataClasses;

namespace Fateblade.Alexandria.Logic.Foundation.Meta.Dice
{
    class ComplexDiceFormula : IDiceFormula
    {
        private readonly IEnumerable<FormulaStep> _steps;
        private readonly IDiceOptionsManager _optionsManager;
        private readonly IDiceFactory _diceFactory;
        private bool _previousStepWasMultiplierStep;


        internal ComplexDiceFormula(IDiceFactory diceFactory, IDiceOptionsManager optionsManager, IEnumerable<FormulaStep> steps)
            : this(diceFactory, optionsManager)
        {
            _steps = steps;
        }

        private ComplexDiceFormula(IDiceFactory diceFactory, IDiceOptionsManager optionsManager)
        {
            _diceFactory = diceFactory;
            _optionsManager = optionsManager;
        }

        public int Roll()
        {
            int result = 0;

            foreach (var currentStep in _steps)
            {
                if (currentStep is DiceFormulaStep formulaStep)
                {
                    if (_previousStepWasMultiplierStep)
                    {
                        result *= CalculateFormulaStep(formulaStep);
                    }
                    else
                    {
                        result += CalculateFormulaStep(formulaStep);
                    }
                }
                else if (currentStep is MultiplicationStep multiplicationStep)
                {
                    result *= multiplicationStep.Multiplicator;
                }
                else if (currentStep is DivisionStep divisionStep)
                {
                    switch (_optionsManager.DiceFormulaRounding)
                    {
                        case RoundingOptions.AlwaysRoundDown:
                            result /= divisionStep.Divider;
                            break;
                        case RoundingOptions.AlwaysRoundUp:
                            var tempResult = result / divisionStep.Divider;
                            if (result % divisionStep.Divider != 0)
                            {
                                tempResult++;
                            }

                            result = tempResult;
                            break;
                        case RoundingOptions.RoundMathematically:
                            result = Convert.ToInt32(Math.Round((double)result / divisionStep.Divider, 0));
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(_optionsManager.DiceFormulaRounding), $"Unknown enum value '{_optionsManager.DiceFormulaRounding}'");
                    }
                }

                _previousStepWasMultiplierStep = currentStep is MultiplierStep;
            }

            return result;
        }

        private int CalculateFormulaStep(DiceFormulaStep formulaStep)
        {
            int result = 0;

            if (formulaStep.DiceType.HasValue && formulaStep.Amount.HasValue)
            {
                var diceCollection = _diceFactory.CreateDices(formulaStep.Amount.Value, formulaStep.DiceType.Value);
                result += diceCollection.RollAll();
            }

            if (formulaStep.Modifier.HasValue)
            {
                result *= formulaStep.Modifier.Value;
            }

            if (formulaStep.Multiplicator.HasValue)
            {
                result *= formulaStep.Multiplicator.Value;
            }

            return result;
        }
    }
}
