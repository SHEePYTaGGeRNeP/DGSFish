using System.Collections.Generic;
using System.Linq;
using Assets.Scripts;
using NUnit.Framework;

namespace Assets.Unit_Tests
{
    public class DieTests
    {
        [Test]
        public void Can_Create()
        {
            Die d = new Die(6);
            Assert.NotNull(d);
        }

        [Test]
        public void Can_Roll()
        {
            const uint sides = 6;
            const uint nrOfDice = 1;
            Die d = new Die(sides);
            for (int i = 0; i < 100; i++)
            {
                uint result = d.Roll();
                Assert.True(result > nrOfDice - 1 && result <= sides);
            }
        }

        [Test]
        public void Can_Roll_Static()
        {
            const uint sides = 6;
            const uint nrOfDice = 1;
            for (int i = 0; i < 100; i++)
            {
                uint result = Die.Roll(nrOfDice, sides);
                Assert.True(result > nrOfDice - 1 && result <= sides);
            }
        }

        [Test]
        public void Can_Roll_Two_Static()
        {
            const uint sides = 6;
            const uint nrOfDice = 2;
            for (int i = 0; i < 100; i++)
            {
                uint result = Die.Roll(nrOfDice, sides);
                Assert.True(result > nrOfDice - 1 && result <= sides * nrOfDice);
            }
        }

        [Test]
        public void Can_Roll_Dice()
        {
            KeyValuePair<Die, uint> die1 = new KeyValuePair<Die, uint>(new Die(8), 1);
            KeyValuePair<Die, uint> die2 = new KeyValuePair<Die, uint>(new Die(8), 1);
            KeyValuePair<Die, uint>[] dice = new KeyValuePair<Die, uint>[] { die1, die2 };
            for (int i = 0; i < 100; i++)
            {
                uint result = Die.Roll(dice);
                Assert.True(result > dice.Sum(x => x.Value) - 1
                    && result <= dice.Sum(x => x.Value * x.Key.NrOfSides));
            }
        }
    }
}
