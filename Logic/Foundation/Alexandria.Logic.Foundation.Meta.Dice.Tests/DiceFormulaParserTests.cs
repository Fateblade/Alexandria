using Fateblade.Alexandria.Logic.Foundation.Meta.Dice;
using FluentAssertions;
using NUnit.Framework;

namespace Alexandria.Logic.Foundation.Meta.DiceGeneration.Tests
{
    [TestFixture]
    public class DiceFormulaParserTests
    {
        private DiceFormulaParser _target;
        // 5d4+4*3
        // 2d6*3
        // 2d8+8

        [SetUp]
        public void Setup()
        {
            var optionsManger = new TestRoundDownDiceOptionsManager();
            _target = new DiceFormulaParser(new DiceFactory(optionsManger), optionsManger);
        }

        [Test]
        public void Parse_SimplestDiceRepresentationD_CorrectDiceFormula()
        {
            const string simplestDiceRepresentationD = "1d6";


            var formula = _target.Parse(simplestDiceRepresentationD);


            formula.Should().NotBeNull();
            formula.Should().BeOfType<ComplexDiceFormula>();
            formula.As<ComplexDiceFormula>().Roll().Should().BeOneOf(1, 2, 3, 4, 5, 6);
        }
    }
}