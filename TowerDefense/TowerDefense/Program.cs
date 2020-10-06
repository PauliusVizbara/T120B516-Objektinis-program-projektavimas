using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TowerDefense.Models.MapFactory;
using TowerDefense.Models.TowerFactory;

namespace TowerDefense
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

            TowerCreator towerCreator = new TowerCreator();

            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("ID", 1);
            BomberTower bomberTower = towerCreator.Get(TowerType.BomberTower, data) as BomberTower;
            GunerTower gunerTower = towerCreator.Get(TowerType.GunerTower, data) as GunerTower;
            FreezerTower freezerTower = towerCreator.Get(TowerType.FreezerTower, data) as FreezerTower;
            BankTower bankTower = towerCreator.Get(TowerType.BankTower, data) as BankTower;

            Console.WriteLine(bomberTower.getInfo());
            Console.WriteLine(gunerTower.getInfo());
            Console.WriteLine(freezerTower.getInfo());
            Console.WriteLine(bankTower.getInfo());
            Console.ReadLine();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        
    }
}
