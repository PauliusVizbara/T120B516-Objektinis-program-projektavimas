using System;
using System.Collections.Generic;
using System.Text;
using TowerDefense.Models.Monster;
using TowerDefense.Models.Strategies.Movement;
using Xunit;

namespace UnitsTests.GameFlowOperations
{
    public class MovementTests
    {
        [Fact]
        public void TestGroundMovement()
        {
            var movement = new GroundMovement();
            var monster = new Monster { MonsterIndex = 1, Position = 1 };

            movement.Move(monster);

            Assert.True(monster.Position == 2 && monster.MonsterIndex == 1);
        }

        [Fact]
        public void TestAirMovement()
        {
            var movement = new AirMovement();
            var monster = new Monster { MonsterIndex = 1, Position = 1 };

            movement.Move(monster);

            Assert.True(monster.Position == 3 && monster.MonsterIndex == 1);
        }

        [Fact]
        public void TestUnderGroundMovement()
        {
            var movement = new GroundMovement();
            var monster = new Monster { MonsterIndex = 1, Position = 1 };

            movement.Move(monster);

            Assert.True(monster.Position == 2 && monster.MonsterIndex == 1);
        }
    }
}
