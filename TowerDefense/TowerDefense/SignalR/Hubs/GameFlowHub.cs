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
using TowerDefense.Models.Monster;

namespace TowerDefense.SignalR.Hubs
{
    public class GameFlowHub : Hub
    {
        GameManager gameManager = GameManager.GetGameManager();

        public async Task SendGameStatus()
        {
            await Clients.All.SendAsync("GameStatus");
        }

        public async Task StartGame()
        {
            gameManager.GameStart();

            Task.Factory.StartNew(() => GameFlow(Clients));

            await Clients.All.SendAsync("StartGame");
            
        }

        private async Task<bool> GameFlow(IHubCallerClients clients)
        {
            GameFlowOperations gameFlowHelper = new GameFlowOperations();
            var gameStatusModel = new GameStatusModel();
            //List<Monster> monsters = GetMockedList();


            while (gameManager.CurrentLevel() > 0)
            {
                gameFlowHelper.MoveMonstersPosition(gameStatusModel.MonsterList);
                await clients.All.SendAsync("GameStatus", gameStatusModel);
                Thread.Sleep(1000);
            }
            return true;
        }

        public List<Monster> GetMockedList()
        {
            AbstractFactory fastFactory = new FastFactory();
            AbstractFactory strongFactory = new StrongFactory();
            AbstractFactory weakFactory = new WeakFactory();
            var monsters = new List<Monster>();
            for (int i = 1; i < 10; i++)
            {
                var weakmonster = weakFactory.CreateRedMonster(i);
                weakmonster.SetPosition(i * 2 - 20);
                monsters.Add(weakmonster);
                i++;

                var fastmonster1 = fastFactory.CreateRedMonster(i);
                fastmonster1.SetPosition(i * 2 - 20);
                monsters.Add(fastmonster1);
                i++;

                var fastmonster2 = fastFactory.CreateRedMonster(i);
                fastmonster2.SetPosition(i * 2 - 20);
                monsters.Add(fastmonster2);
            }
            return monsters;
        }

        public async Task RequestBuildTower(int x, int y, string towerType)
        {
            System.Diagnostics.Debug.WriteLine(x);
            System.Diagnostics.Debug.WriteLine(y);
            System.Diagnostics.Debug.WriteLine(towerType);
            Tower tower = null;
            switch (towerType)
            {
                case "Archer":
                    tower = new ArcherCreator(10, 20, "physical").createTower();
                    await Clients.All.SendAsync("BuildTower", x, y, tower);
                    break;

                case "Bomber":
                    tower = new BomberCreator(10, 20, "physical").createTower();
                    await Clients.All.SendAsync("BuildTower", x, y, tower);
                    break;

                case "Freeze":
                    tower = new FreezeCreator(10, 20, "physical").createTower();
                    await Clients.All.SendAsync("BuildTower", x, y, tower);
                    break;

                case "Mage":
                     tower = new MageCreator(10, 20, "physical").createTower();
                    await Clients.All.SendAsync("BuildTower", x, y, tower);
                    break;

                case "Bank":
                    tower = new BankCreator(10, "physical").createTower();
                    await Clients.All.SendAsync("BuildTower", x, y, tower);
                    break;
                default:
                    System.Diagnostics.Debug.WriteLine("Didn't found the tower type");
                    break;
            }
        }

        public async Task EndGame()
        {
            gameManager.GameOver();
            await Clients.All.SendAsync("GameOver");
        }
    }
}
