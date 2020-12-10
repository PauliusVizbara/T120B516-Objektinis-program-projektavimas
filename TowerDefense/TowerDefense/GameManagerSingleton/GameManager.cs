using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TowerDefense.Data;
using TowerDefense.Models.Observer;
using TowerDefense.Models.Factory;
using TowerDefense.Models.Tower;

namespace TowerDefense.GameManagerSingleton
{
    public class GameManager : IGameManager

    {
        private static GameManager _instance;
        private int _currentLevel = 0;
        public Score smallScore = new SmallScore();
        private Score midScore = new MidScore();
        private Score bigScore = new BigScore();
        //private List<MapPathCoordinate> _currentMap = new List<MapPathCoordinate>();
        private static object syncLock = new object();
        private List<MapPathCoordinate> Coordinates = new List<MapPathCoordinate>();
        public List<BuiltTower> Towers = new List<BuiltTower>();

        protected GameManager()
        {
            _currentLevel = 0;
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

        public void AddTower(int xCoordinate, int yCoordinate, string towerType, Tower tower)
        {
            Towers.Add(new BuiltTower
            {
                TowerType = towerType,
                xCoordinate = xCoordinate,
                yCoordinate = yCoordinate,
                Damage = tower.GetDamage(),
                Range = tower.GetRange(),
                Id = Towers.Count,
            });
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

        public bool GameStart()
        {
            smallScore.SetProccess(midScore);
            midScore.SetProccess(bigScore);

            _currentLevel = 1;

            return true;
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
