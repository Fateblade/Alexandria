using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;
using Fateblade.Alexandria.Logic.Foundation.Meta.Dice.Contract;
using Fateblade.Alexandria.Logic.Foundation.Meta.Dice.Contract.Exceptions;
using System;
using System.Text;
using Troschuetz.Random;

namespace Fateblade.Alexandria.Logic.Foundation.Meta.Dice
{
    public class DiceFactory :IDiceFactory
    {
        private readonly IDiceOptionsManager _optionsManager;
        private TRandom _currentGenerator;
        private DateTime _generatorInstancedAt;

        public DiceFactory(IDiceOptionsManager optionsManager)
        {
            _optionsManager = optionsManager;
            _currentGenerator = new TRandom(new TRandom().NextUInt(uint.MaxValue));
            _generatorInstancedAt = DateTime.UtcNow;
        }

        public IDice CreateDice(DiceType diceType)
        {
            handleGeneratorRecreation();
            return new Dice(_currentGenerator, diceType);
        }

        public IDice CreateCustomDice(uint sides)
        {
            handleGeneratorRecreation();
            return new CustomDice(_currentGenerator, sides);
        }

        public IDiceCollection CreateDices(int amount, DiceType diceType)
        {
            if (amount < 0)  { throw new ArgumentException($"negative Amount not allowed", nameof(amount));}

            handleGeneratorRecreation();
            DiceCollection dicePool = new DiceCollection();

            for (int i = 0; i < amount; i++)
            {
                dicePool.Add(new Dice(_currentGenerator, diceType));
            }

            return dicePool;
        }

        public IDiceCollection CreateCustomDices(int amount, uint sides)
        {
            if (amount < 0) { throw new ArgumentException($"negative Amount not allowed", nameof(amount)); }

            handleGeneratorRecreation();
            DiceCollection dicePool = new DiceCollection();

            for (int i = 0; i < amount; i++)
            {
                dicePool.Add(new CustomDice(_currentGenerator, sides));
            }

            return dicePool;
        }

        public IDiceFormula CreateDiceFormula(DiceType diceType, int diceAmount, int modifier, bool isModifierPerDice, bool isNegativeModifierResultPerDiceAllowed)
        {
            return new SimpleDiceFormula(this, diceType, diceAmount, modifier, isModifierPerDice, isNegativeModifierResultPerDiceAllowed);
        }

        public IDiceFormula CreateDiceFormula(uint diceSides, int diceAmount, int modifier, bool isModifierPerDice, bool isNegativeModifierResultPerDiceAllowed)
        {
            return new SimpleDiceFormula(this, diceSides, diceAmount, modifier, isModifierPerDice, isNegativeModifierResultPerDiceAllowed);
        }

        public IDiceFormula CreateDiceFormula(IDiceCollection diceCollection, int modifier, bool isModifierPerDice, bool isNegativeModifierResultPerDiceAllowed)
        {
            return new SimpleDiceFormula(this, diceCollection, modifier, isModifierPerDice, isNegativeModifierResultPerDiceAllowed);
        }

        public IDiceFormula FromString(string diceFormula)
        {
            if (string.IsNullOrWhiteSpace(diceFormula)) return null;
            DiceFormulaParser parser = new DiceFormulaParser(this, _optionsManager);

            return parser.Parse(diceFormula);
        }

        private void handleGeneratorRecreation()
        {
            if ((DateTime.Now - _generatorInstancedAt).Minutes > 30)
            {
                _currentGenerator = new TRandom(_currentGenerator.NextUInt(uint.MaxValue));
                _generatorInstancedAt = DateTime.Now;
            }
        }


    }


    internal class DiceFormulaParser
    {
        private readonly IDiceFactory _diceFactory;
        private readonly IDiceOptionsManager _optionsManager;

        public DiceFormulaParser(IDiceFactory diceFactory, IDiceOptionsManager optionsManager)
        {
            _diceFactory = diceFactory;
            _optionsManager = optionsManager;
        }

        public IDiceFormula Parse(string diceFormula)
        {
            ComplexDiceFormulaBuilder builder = new ComplexDiceFormulaBuilder(_diceFactory, _optionsManager);

            StringBuilder sb = new StringBuilder();

 

            IDiceCollection currentCollection = null;

            for (int i = 0; i < diceFormula.Length; i++)
            {
                if (IsModifierChar(diceFormula[i]))
                {
                    currentCollection = ParseDiceCollection(sb.ToString());
                }
                else if(i == diceFormula.Length - 1)
                {
                    sb.Append(diceFormula[i]);
                    currentCollection = ParseDiceCollection(sb.ToString());
                }
                else
                {
                    sb.Append(diceFormula[i]);
                }
            }

            if (currentCollection == null) return null;
            return new SimpleDiceFormula(_diceFactory, currentCollection, 0, false, false);
        }

        /// <summary>
        /// expected format [numbers]d[numbers] or [numbers]w[numbers]
        /// </summary>
        /// <param name="simpleDiceFormula"></param>
        /// <returns></returns>
        /// <exception cref="DiceParsingException"></exception>
        private IDiceCollection ParseDiceCollection(string simpleDiceFormula)
        {
            string[] splittedFormula =
                simpleDiceFormula.Split(new char[] { 'd', 'w' }, StringSplitOptions.RemoveEmptyEntries);

            
            if (splittedFormula.Length != 2)
            {
                throw new DiceParsingException($"Could not parse valid formula from '{simpleDiceFormula}'");
            }

            if (!int.TryParse(splittedFormula[0], out int amount))
            {
                throw new DiceParsingException($"Could not parse '{splittedFormula[0]}' to amount");
            }

            if (!uint.TryParse(splittedFormula[1], out uint sides))
            {
                throw new DiceParsingException($"Could not parse '{splittedFormula[1]}' to dice sides");
            }

            return _diceFactory.CreateCustomDices(amount, sides);
        }


        private bool IsModifierChar(char c)
        {
            return IsAddition(c)
                   || IsSubsctraction(c)
                   || IsMultiplication(c)
                   || IsDivision(c);
        }

        private bool IsAddition(char c) => c == '+';
        private bool IsSubsctraction(char c) => c == '-';
        private bool IsMultiplication(char c) => c == '*';
        private bool IsDivision(char c) => c == '/';
    }
}
