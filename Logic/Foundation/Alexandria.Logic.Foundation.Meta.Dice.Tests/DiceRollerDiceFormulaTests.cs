using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Fateblade.Alexandria.Logic.Foundation.Meta.DiceGeneration.DiceRollerNuget;

namespace Alexandria.Logic.Foundation.Meta.DiceGeneration.Tests
{
    [TestFixture]
    public class DiceRollerDiceFormulaTests
    {
        

        [SetUp]
        public void Setup()
        {
            var optionsManger = new DiceOptionsManager();
        }

        [Test]
        public void Parse_SimplestDiceRepresentationD_CorrectDiceFormula()
        {
            const string formulaString = "1d6";
            var numberOfRolls = 1000;
            var rollResults = new List<int>(numberOfRolls);
            var formula = new SimpleDiceRollerDiceFormula(new DiceOptionsManager(), formulaString);

            while (rollResults.Count < numberOfRolls)
            {
                rollResults.Add(formula.Roll());
            }

            rollResults.Should().OnlyContain(t=>t>0 && t<7);
            rollResults.Min().Should().Be(1);
            rollResults.Max().Should().Be(6);
        }


        [Test]
        public void Parse_MultiplicationFormulaD_CorrectResults()
        {
            const string formulaString = "2d6*3";
            var numberOfRolls = 1000;
            var rollResults = new List<int>(numberOfRolls);
            var formula = new SimpleDiceRollerDiceFormula(new DiceOptionsManager(), formulaString);

            while (rollResults.Count < numberOfRolls)
            {
                rollResults.Add(formula.Roll());
            }

            rollResults.Should().OnlyContain(t => t > 5 && t < 37);
            rollResults.Min().Should().Be(6);
            rollResults.Max().Should().Be(36);
        }

        [Test]
        public void Parse_AdditionFormulaD_CorrectResults()
        {
            const string formulaString = "2d8+8";
            var numberOfRolls = 1000;
            var rollResults = new List<int>(numberOfRolls);
            var formula = new SimpleDiceRollerDiceFormula(new DiceOptionsManager(), formulaString);

            while (rollResults.Count < numberOfRolls)
            {
                rollResults.Add(formula.Roll());
            }

            rollResults.Should().OnlyContain(t => t > 9 && t < 25);
            rollResults.Min().Should().Be(10);
            rollResults.Max().Should().Be(24);
        }

        [Test]
        public void Parse_MixedFormulaD_CorrectResults()
        {
            const string formulaString = "(2d4+4)*3";
            var numberOfRolls = 1000;
            var rollResults = new List<int>(numberOfRolls);
            var formula = new SimpleDiceRollerDiceFormula(new DiceOptionsManager(), formulaString);

            while (rollResults.Count < numberOfRolls)
            {
                rollResults.Add(formula.Roll());
            }

            rollResults.Should().OnlyContain(t => t > 17 && t < 37);
            rollResults.Min().Should().Be(18);
            rollResults.Max().Should().Be(36);
        }

        [Test]
        public void Parse_MixedFormulaWithoutBracketD_CorrectResults()
        {
            const string formulaString = "2d4+4*3";
            var numberOfRolls = 10000;
            var rollResults = new List<int>(numberOfRolls);
            var formula = new SimpleDiceRollerDiceFormula(new DiceOptionsManager(), formulaString);

            while (rollResults.Count < numberOfRolls)
            {
                rollResults.Add(formula.Roll());
            }

            rollResults.Should().OnlyContain(t => t > 13 && t < 21);
            rollResults.Min().Should().Be(14);
            rollResults.Max().Should().Be(20);
        }
    }
}