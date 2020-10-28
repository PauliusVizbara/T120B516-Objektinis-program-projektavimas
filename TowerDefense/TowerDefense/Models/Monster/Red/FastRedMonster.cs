using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TowerDefense.Models.Strategies;

namespace TowerDefense.Models.Monster.Red
{
    public class FastRedMonster : RedMonster
    {

        public int MonsterIndex { get; set; }
        public double CurrentHealth { get; set; }
        public int Loot { get; set; }
        public int Position { get; set; }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public string MonsterType { get; set; }
        public MovementStrategy MovementMethod { get; set; }

        public FastRedMonster(int index, int health, int loot)
        {
            this.SetMonsterIndex(index);
            this.SetCurrentHealth(health);
            this.SetLoot(loot);
            this.SetMonsterType("Red Fast Monster");
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
