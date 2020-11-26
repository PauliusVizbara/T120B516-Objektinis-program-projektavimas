using System;
using System.Collections.Generic;
using System.Text;
using TowerDefense.Decorator;
using TowerDefense.Models.Factory;
using TowerDefense.Models.Factory.Creators;
using Xunit;

namespace UnitsTests.GameFlowOperations
{
    public class TowerCreationTest
    {
        private static TowerCreator _sut;
        private static CTower tower;

        [Fact]
        public void TowerCreateBomberTest()
        {
            _sut = new BomberCreator(1, 10, "Offensive");

            tower = _sut.createTower();

            Assert.Equal(10, tower.GetDamage());

        }

        [Fact]
        public void TowerCreateArcherTest()
        {
            _sut = new ArcherCreator(1, 10, "Offensive");

            tower = _sut.createTower();

            Assert.Equal(10, tower.GetDamage());

        }

        [Fact]
        public void TowerCreateBankTest()
        {
            _sut = new BankCreator(10, "Offensive");

            tower = _sut.createTower();

            Assert.Equal(10, tower.GetMoney());

        }

        [Fact]
        public void TowerCreateFreezeTest()
        {
            _sut = new FreezeCreator(1, 10, "Offensive");

            tower = _sut.createTower();

            Assert.Equal(10, tower.GetDamage());

        }

        [Fact]
        public void TowerCreateMageTest()
        {
            _sut = new MageCreator(1, 10, "Offensive");

            tower = _sut.createTower();

            Assert.Equal(10, tower.GetDamage());

        }
    }
}   
