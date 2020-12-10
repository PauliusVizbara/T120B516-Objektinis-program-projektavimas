using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TowerDefense.Data.Repository.Abstraction;
using TowerDefense.GameManagerSingleton;
using TowerDefense.Models.Factory.Creators;
using TowerDefense.Models.Factory;
using TowerDefense.SignalR.GameFlowHelpers;
using TowerDefense.SignalR.Models;
using TowerDefense.Models.Observer;
using TowerDefense.Models.Proxy;

namespace TowerDefense.SignalR.Hubs
{
    public class GameFlowHub : Hub
    {
        private IHubContext<GameFlowHub> _hubContext;
        public GameFlowHub(IHubContext<GameFlowHub> hubContext)
        {
            _hubContext = hubContext;
        }
        GameManager gameManager = GameManager.GetGameManager();
        GameStatusModel gameStatusModel = new GameStatusModel();

        Observable<Score> scoreSubject = new Observable<Score>();
        ScoreObserver scoreObserver = new ScoreObserver();

        

        public async Task SendGameStatus()
        {
            await _hubContext.Clients.All.SendAsync("GameStatus");
        }

        public async Task StartGame()
        {
            ProxyGameManager proxyGameManager = new ProxyGameManager(gameManager);
            proxyGameManager.GameStart();

            Task.Factory.StartNew(() => GameFlow(_hubContext.Clients));

            await _hubContext.Clients.All.SendAsync("StartGame");
            
        }

        private async Task<bool> GameFlow(IHubClients clients)
        {
            GameFlowOperations gameFlowHelper = new GameFlowOperations();

            

            while (gameManager.CurrentLevel() > 0)
            {
                gameFlowHelper.GameTickOperations(gameStatusModel.MonsterList, gameStatusModel.DeadMonstersList, gameManager.Towers, gameManager.smallScore);
                //var TestMonster = gameStatusModel.MonsterList.FirstOrDefault();
                //TestMonster.KillMonster();
                await clients.All.SendAsync("GameStatus", gameStatusModel);
                Thread.Sleep(1000);
            }
            return true;
        }

        public async Task RequestBuildTower(int x, int y, string towerType)
        {
            System.Diagnostics.Debug.WriteLine(x);
            System.Diagnostics.Debug.WriteLine(y);
            System.Diagnostics.Debug.WriteLine(towerType);
            gameManager.AddTower(x, y, towerType);
            Tower tower = null;
            switch (towerType)
            {
                case "Archer":
                    tower = new ArcherCreator(10, 20, "physical").createTower();
                    await _hubContext.Clients.All.SendAsync("BuildTower", x, y, tower);
                    break;

                case "Bomber":
                    tower = new BomberCreator(10, 20, "physical").createTower();
                    await _hubContext.Clients.All.SendAsync("BuildTower", x, y, tower);
                    break;

                case "Freeze":
                    tower = new FreezeCreator(10, 20, "physical").createTower();
                    await _hubContext.Clients.All.SendAsync("BuildTower", x, y, tower);
                    break;

                case "Mage":
                     tower = new MageCreator(10, 20, "physical").createTower();
                    await _hubContext.Clients.All.SendAsync("BuildTower", x, y, tower);
                    break;

                case "Bank":
                    tower = new BankCreator(10, "physical").createTower();
                    await _hubContext.Clients.All.SendAsync("BuildTower", x, y, tower);
                    break;
                default:
                    System.Diagnostics.Debug.WriteLine("Didn't found the tower type");
                    break;
            }
        }

        public async Task EndGame()
        {
            gameManager.GameOver();
            await _hubContext.Clients.All.SendAsync("GameOver");
        }
    }
}
