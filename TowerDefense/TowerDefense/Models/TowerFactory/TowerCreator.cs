using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TowerDefense.Models.MapFactory;

namespace TowerDefense.Models.TowerFactory
{

    enum TowerType
    {
        BomberTower,
        GunerTower,
        FreezerTower,
        BankTower,
    }
    class TowerCreator : Creator
    {
        private TowerType _type;
        private Dictionary<string, object> _data;


        public GameTower Get(TowerType type, Dictionary<string, object> data)
        {
            _type = type;
            _data = data;
            return GetTower();
        }

        public override GameTower GetTower()
        {
            GameTower tow = null;

            Int32 id = Convert.ToInt32(_data["ID"]);

            //fetch object information

            switch(_type)
            {
                case TowerType.BomberTower:
                    if (id == 1)
                    {
                        tow = new BomberTower() { Id = 1, Range = 1, Damage = 50, Type = "Offensive" };
                    }
                    
                    break;
                case TowerType.GunerTower:
                    if (id == 1)
                    {
                        tow = new GunerTower() { Id = 1, Range = 2, Damage = 20, Type = "Offensive" };
                    }

                    break;
                case TowerType.FreezerTower:
                    if (id == 1)
                    {
                        tow = new FreezerTower() { Id = 1, Range = 2, Damage = 10, Type = "Support" };
                    }

                    break;
                case TowerType.BankTower:
                    if (id == 1)
                    {
                        tow = new BankTower() { Id = 1, Money = 12, Type = "Support" };
                    }

                    break;
                default:
                    tow = null;
                    break;

            }

            return tow;
        }

    }
}
