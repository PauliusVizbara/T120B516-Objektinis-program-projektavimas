﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TowerDefense.GameManagerSingleton;
using TowerDefense.Models.Factory;

namespace TowerDefense.Models.Proxy
{
    public class ProxyGameManager : IGameManager
    {
        private GameManager _realSubject;

        public ProxyGameManager(GameManager realSubject)
        {
            this._realSubject = realSubject;
        }

        public bool GameStart()
        {
            if (this.CheckAccess())
            {
                this._realSubject.GameStart();
                return true;
            }
            return false;
        }

        public bool CheckAccess()
        {
            if (_realSubject.CurrentLevel() != 0)
            {
                return false;
            }
            return true;
        }

    }
}
