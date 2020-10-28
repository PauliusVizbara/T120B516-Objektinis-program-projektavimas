using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TowerDefense.Models.Strategies;
using TowerDefense.Models.Strategies.Movement;

namespace TowerDefense.Models.Monster.Red
{
    public class StrongRedMonster : RedMonster
    {

        public int MonsterIndex { get; set; }
        public double CurrentHealth { get; set; }
        public int Loot { get; set; }
        public int Position { get; set; }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public string MonsterType { get; set; }
        public MovementStrategy MovementMethod { get; set; }

        public StrongRedMonster(int index, int health, int loot)
        {
            this.SetMonsterIndex(index);
            this.SetCurrentHealth(health);
            this.SetLoot(loot);
            this.SetMonsterType("Red Strong Monster");
            this.SetMovementMethod(new GroundMovement());
        }
        public override int GetXCoordinate()
        {
            return XCoordinate;
        }

        public override void SetXCoordinate(int value)
        {
            XCoordinate = value;
        }

        public override int GetYCoordinate()
        {
            return YCoordinate;
        }

        public override void SetYCoordinate(int value)
        {
            YCoordinate = value;
        }

        public override int GetPosition()
        {
            return Position;
        }

        public override void SetPosition(int value)
        {
            Position = value;
        }

        public override MovementStrategy GetMovementMethod()
        {
            return MovementMethod;
        }

        public void SetMovementMethod(MovementStrategy value)
        {
            MovementMethod = value;
        }

        public override int GetMonsterIndex()
        {
            return MonsterIndex;
        }

        public void SetMonsterIndex(int value)
        {
            MonsterIndex = value;
        }

        public override double GetCurrentHealth()
        {
            return CurrentHealth;
        }

        public void SetCurrentHealth(double value)
        {
            CurrentHealth = value;
        }

        public override int GetLoot()
        {
            return Loot;
        }

        public void SetLoot(int value)
        {
            Loot = value;
        }

        public override string GetMonsterType()
        {
            return MonsterType;
        }

        public void SetMonsterType(string value)
        {
            MonsterType = value;
        }
    }
}
