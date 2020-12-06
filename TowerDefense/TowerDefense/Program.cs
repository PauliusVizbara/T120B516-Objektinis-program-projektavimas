using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TowerDefense.Decorator;
using TowerDefense.Models.Factory;
using TowerDefense.Models.Factory.Creators;
using TowerDefense.Models.Observer;

namespace TowerDefense
{
    public class Program
    {

        private static TowerCreator factory;

        private static CTower tower;


        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

            Console.WriteLine("Please select: bo(mber), ba(nk), m(age), f(reze)");

            string input = Console.ReadLine();
            switch (input.ToLower())
            {
                case "bo":
                    factory = new BomberCreator(1, 50, "Offensive");
                    break;
                case "ba":
                    factory = new BankCreator(100, "Support");
                    break;
                case "m":
                    factory = new MageCreator(3, 25, "Offensive");
                    break;
                case "f":
                    factory = new FreezeCreator(2, 10, "Support");
                    break;
                default:
                    break;
            }

            tower = factory.createTower();

            
            Console.WriteLine("Tower details are below : ");
            Console.WriteLine("Tower damage: {0} Tower Range {1} \n", tower.GetDamage(), tower.GetRange());


            /*----Decorator------*/
            DamageUpgrade towerDmgUp = new DamageUpgrade(tower);

            Console.WriteLine("Tower details after damage decorator: ");
            Console.WriteLine("Tower damage: {0} Tower Range {1} \n", towerDmgUp.GetDamage(), towerDmgUp.GetRange());

            DamageUpgrade towerRngUp = new DamageUpgrade(towerDmgUp);


            Console.WriteLine("Tower details after range decorator: ");
            Console.WriteLine("Tower damage: {0} Tower Range {1} \n", towerRngUp.GetDamage(), towerRngUp.GetRange());




            Console.ReadKey();


        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        
    }
}
