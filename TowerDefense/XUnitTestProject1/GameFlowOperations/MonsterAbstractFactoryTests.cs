using System;
using System.Collections.Generic;
using System.Text;
using TowerDefense.Models.Monster;
using Xunit;

namespace UnitsTests.GameFlowOperations
{
    public class MonsterAbstractFactoryTests
    {

        [Fact]
        public void FastandRedMonsterCreateTest()
        {
            AbstractFactory fastFactory = new FastFactory();

            var fastRedMonster = fastFactory.CreateRedMonster(1);

            Assert.Equal(90, fastRedMonster.GetCurrentHealth());

        }

        [Fact]
        public void FastandBlackMonsterCreateTest()
        {
            AbstractFactory fastFactory = new FastFactory();

            var fastBlackMonster = fastFactory.CreateBlackMonster(1);

            Assert.Equal(120, fastBlackMonster.GetCurrentHealth());

        }

        [Fact]
        public void StrongandRedMonsterCreateTest()
        {
            AbstractFactory strongFactory = new StrongFactory();

            var strongRedMonster = strongFactory.CreateRedMonster(1);

            Assert.Equal(120, strongRedMonster.GetCurrentHealth());

        }

        [Fact]
        public void StrongandBlackMonsterCreateTest()
        {
            AbstractFactory strongFactory = new StrongFactory();

            var strongBlackMonster = strongFactory.CreateBlackMonster(1);

            Assert.Equal(150, strongBlackMonster.GetCurrentHealth());

        }

        [Fact]
        public void WeakandRedMonsterCreateTest()
        {
            AbstractFactory weakFactory = new WeakFactory();

            var weakRedMonster = weakFactory.CreateRedMonster(1);

            Assert.Equal(60, weakRedMonster.GetCurrentHealth());

        }

        [Fact]
        public void WeakandBlackMonsterCreateTest()
        {
            AbstractFactory weakFactory = new WeakFactory();

            var weakBlackMonster = weakFactory.CreateBlackMonster(1);

            Assert.Equal(90, weakBlackMonster.GetCurrentHealth());
        }


    }
}
