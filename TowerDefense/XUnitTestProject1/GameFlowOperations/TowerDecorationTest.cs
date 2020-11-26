using System;
using System.Collections.Generic;
using System.Text;
using TowerDefense.Decorator;
using TowerDefense.Models.Decorator;
using TowerDefense.Models.Factory;
using TowerDefense.Models.Factory.Creators;
using Xunit;

namespace UnitsTests.GameFlowOperations
{
    public class TowerDecorationTest
    {
        private static TowerCreator _sut;
        private static CTower tower;

        [Fact]
        public void TowerDamageUpTest()
        {
            _sut = new BomberCreator(1, 10, "Offensive");

            tower = _sut.createTower();

            DamageUpgrade towerDmgUp = new DamageUpgrade(tower);

            Assert.Equal(120, towerDmgUp.GetDamage());

        }

        [Fact]
        public void TowerRangeUpTest()
        {
            _sut = new BomberCreator(1, 10, "Offensive");

            tower = _sut.createTower();

            RangeUpgrade towerRangeUp = new RangeUpgrade(tower);

            Assert.Equal(11, towerRangeUp.GetRange());

        }

        [Fact]
        public void TowerMoneyUpTest()
        {
            _sut = new BankCreator(10, "Offensive");

            tower = _sut.createTower();

            MoneyUpgrade towerMoneyUp = new MoneyUpgrade(tower);

            Assert.Equal(1010, towerMoneyUp.GetMoney());

        }
    }
}
