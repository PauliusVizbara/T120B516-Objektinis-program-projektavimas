using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TowerDefense.Data;

namespace TowerDefense.GameManagerSingleton
{
    public class GameManager

    {
        private static GameManager _instance;
        private int _currentLevel = 0;
        //private List<MapPathCoordinate> _currentMap = new List<MapPathCoordinate>();
        private static object syncLock = new object();
        private List<MapPathCoordinate> Coordinates = new List<MapPathCoordinate>();

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

        public void GameStart()
        {
            _currentLevel = 1;
        }

        public void SetCoordinates(List<MapPathCoordinate> coordinates)
        {
            Coordinates = coordinates;
        }

        public List<MapPathCoordinate> GetCoordinates()
        {
            return Coordinates;
        }
    }
}
