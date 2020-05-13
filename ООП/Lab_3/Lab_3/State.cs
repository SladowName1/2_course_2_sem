using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    class Hero
    {
        public IHeroState State { get; set; }
        public Hero(IHeroState hero)
        {
            State = hero;
        }
        public void Respawn()
        {
            State.Respawn(this);
        }
        public void Die()
        {
            State.Die(this);
        }
    }
    interface IHeroState
    {
        void Respawn(Hero hero);
        void Die(Hero hero);
    }
    class DieHeroState:IHeroState
    {
        public void Respawn(Hero hero)
        {
            Console.WriteLine("Герой начал возрождение");
            hero.State = new RespawnHeroState();
        }
        public void Die(Hero hero)
        {
            Console.WriteLine("Герой умер");
        }
    }
    class LiveHeroState:IHeroState
    {
        public void Respawn(Hero hero)
        {
            Console.WriteLine("Герой возродился");
            hero.State = new DieHeroState();
        }
        public void Die(Hero hero)
        {
            Console.WriteLine("Герой на пороге смерти");
            hero.State = new DieHeroState();
        }
    }
    class RespawnHeroState:IHeroState
    {
        public void Respawn(Hero hero)
        {
            Console.WriteLine("Герой возраждается");
            hero.State = new LiveHeroState();
        }
        public void Die(Hero hero)
        {
            Console.WriteLine("Герой щас умрет");
            hero.State = new DieHeroState();
        }
    }
}
