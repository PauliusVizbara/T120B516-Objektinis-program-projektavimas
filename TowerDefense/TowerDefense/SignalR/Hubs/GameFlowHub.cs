using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TowerDefense.Data.Repository.Abstraction;
using TowerDefense.GameManagerSingleton;
using TowerDefense.SignalR.GameFlowHelpers;
using TowerDefense.SignalR.Models;

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

            GameFlowOperations gameFlowHelper = new GameFlowOperations();

            var gameStatusModel = new GameStatusModel();

            await Clients.All.SendAsync("StartGame");
            while (gameManager.CurrentLevel() > 0)
            {
                gameFlowHelper.MoveMonstersPosition(gameStatusModel.MonsterList);
                await Clients.All.SendAsync("GameStatus", gameStatusModel);
                Thread.Sleep(1000);
            }
        }

        public async Task EndGame()
        {
            gameManager.GameOver();
            await Clients.All.SendAsync("GameOver");
        }
    }
}
