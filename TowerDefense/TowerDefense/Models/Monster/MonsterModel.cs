using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TowerDefense.Models.Strategies;
using TowerDefense.Models.Strategies.Movement;

namespace TowerDefense.Models.Monster
{
    public class Monster
    {
        public MonsterState currentState = null;
        public int MonsterIndex { get; set; }
        public double CurrentHealth { get; set; }
        public int Loot { get; set; }
        public int Position { get; set; }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public int MonsterType { get; set; }
        public MovementStrategy MovementMethod { get; set; }

        public Monster(MonsterState state, int i, int randomMonsterType, MovementStrategy[] movementStrategies)
        {
            this.TransitionTo(state);
            this.MonsterIndex = i;
            this.CurrentHealth = 100;
            this.Loot = 5;
            this.Position = i * 2 - 20;
            this.MonsterType = randomMonsterType;
            this.MovementMethod = movementStrategies[randomMonsterType - 1];
        }
        public void TransitionTo(MonsterState state)
        {
            this.currentState = state;
            this.currentState.SetMonsterState(this);
        }

        public void KillMonster()
        {
            this.currentState.Kill();
        }

        public static List<Monster> GetMockedList()
        {
            Random rnd = new Random();
            var movementStrategies = new MovementStrategy[] { new GroundMovement(), new UnderGroundMovement(), new AirMovement()};
            var monsters = new List<Monster>();
            for (int i = 1; i <= 10; i++)
            {
                int randomMonsterType = rnd.Next(1, 4);
                monsters.Add(new Monster(new Alive(), i, randomMonsterType, movementStrategies));
            }
            return monsters;
        }

    }
}
