using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TowerDefense.GameManagerSingleton
{
    /// <summary>

    /// The 'Singleton' class

    /// </summary>

    public class GameManager

    {
        private static GameManager _instance;
        private int _currentLevel = 0;
        private Random _random = new Random();

        private static object syncLock = new object();

        protected GameManager()
        {

        }

        public static GameManager GetGameManager()
        {
            if (_instance == null)
            {
                lock (syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new GameManager();
                    }
                }
            }

            return _instance;
        }
        public int CurrentLevel()
        {
            return _currentLevel;
        }

        public int LevelFinished()
        {
            return _currentLevel++;
        }

        public void GameOver()
        {
            _currentLevel = 0;
        }
    }
}
