using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            God god = new God();
            Person person = new Person();
            god.SetCommand(new PersonCommand(person));
            god.GoKill();
            god.GoFire();
            god.GoRun();
            god.GoJump();
            god.GoRun();
            god.GoHide();

            Hero hero = new Hero(new LiveHeroState());
            hero.Die();
            hero.Die();
            hero.Respawn();
            hero.Respawn();
            hero.Respawn();

            Killer killer = new Killer();
            killer.Shoot();
            GameHistory game = new GameHistory();
            game.History.Push(killer.SaveState());
            killer.Shoot();
            killer.Shoot();
            killer.RestoreStore(game.History.Pop());
            killer.Shoot();

            Stock stock = new Stock();
            Bank bank = new Bank("ЮнитБанк", stock);
            Broker broker = new Broker("Иван Иваныч", stock);
            stock.Market();
            stock.Market();
            stock.Market();
            broker.StopTrade();

            Console.ReadLine();
        }
    }
    
}
