using System;

namespace Lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Heros archer = new Heros(new Archer());
            archer.Hit();
            archer.Run();

            Heros swordsman = new Heros(new Swordsman());
            swordsman.Run();
            swordsman.Hit();

            Heros commander = new Heros(new Commenders());
            commander.Flex("My name is Alex");
            Console.WriteLine(commander.Commander.Name_commander);
            commander.Hit();
            commander.Run();

            Gods hero = new Gods();
            HerosBuilder builder = new SwordsmanGods();
            Heros swordsman_2 = hero.God_of_swordsman(builder);
            Console.WriteLine("////////////////////////////////////");
            IHeros hero1 = new Heros(new Archer());
            IHeros cloned_hero1 = hero1.Clone();
            hero1.GetInfo();
            cloned_hero1.GetInfo();

        }
    }
    abstract class Weapon
    {
        public abstract void Hit();
    }
    abstract class Motion
    {
        public abstract void Move();
    }
    class Bow:Weapon
    {
        public override void Hit()
        {
            Console.WriteLine("Shoot for bow");
        }
    }
    class Sword:Weapon
    {
        public override void Hit()
        {
            Console.WriteLine("Hit on sword");
        }
    }
    class Step:Motion
    {
        public override void Move()
        {
            Console.WriteLine("Movement");
        }
    }
    class Run:Motion
    {
        public override void Move()
        {
            Console.WriteLine("Run");
        }
    }
    class Axe:Weapon
    {
        public override void Hit()
        {
            Console.WriteLine("AXEEEEEE");
        }
    }
    class Say:Motion
    {
        public override void Move()
        {
            Console.WriteLine("Go fight baby");
        }
    }
    abstract class HerosFactory
    {
        public abstract Motion CreateMotion();
        public abstract Weapon CreateWeapon();
    }
    class Swordsman:HerosFactory
    {
        public override Motion CreateMotion()
        {
            return new Step();
        }
        public override Weapon CreateWeapon()
        {
            return new Sword();
        }
    }
    class Archer:HerosFactory
    {
        public override Motion CreateMotion()
        {
            return new Run();
        }
        public override Weapon CreateWeapon()
        {
            return new Bow();
        }

    }
    class Commenders:HerosFactory
    {
        public override Motion CreateMotion()
        {
            return new Say();
        }
        public override Weapon CreateWeapon()
        {
            return new Axe();
        }
    }
    class Heros : IHeros
    {
        private Weapon weapon;
        private Motion motion;
        public Commander Commander { get; set; }
        public void Flex(string commander_name)
        {
            Commander = Commander.getInstance(commander_name);
        }
        public Heros(HerosFactory factory)
        {
            weapon = factory.CreateWeapon();
            motion = factory.CreateMotion();
        }
        public Heros(Weapon weapon, Motion motion)
        {
            this.weapon =weapon;
            this.motion = motion;
        }
        public void Run()
        {
            motion.Move();
        }
        public void Hit()
        {
            weapon.Hit();
        }
        public IHeros Clone()
        {
            return new Heros(this.weapon, this.motion);
        }
        public void GetInfo()
        {
            Console.WriteLine("Heros",weapon,motion);
        }
    }
    class Commander
    {
        private static Commander instance;
        public string Name_commander { get; private set; }
        protected Commander(string name_commander)
        {
            this.Name_commander = name_commander;
        }
        public static Commander getInstance(string name_commander)
        {
            if (instance == null)
                instance = new Commander(name_commander);
            return instance;
        }
    }
    abstract class HerosBuilder
    {
        public Heros Heros { get; private set; }
        public void CreateSwordsman()
        {
            Heros = new Heros(new Swordsman());
        }
        public void CreateArcher()
        {
            Heros = new Heros(new Archer());
        }
        public abstract void SetWeapon();
        public abstract void SetMotion();
    }
    class Gods
    {
        public Heros God_of_swordsman(HerosBuilder swordsman_builder)
        {
            swordsman_builder.CreateSwordsman();
            swordsman_builder.SetMotion();
            swordsman_builder.SetWeapon();
            return swordsman_builder.Heros;
        }
        public Heros God_of_archer(HerosBuilder archer_builder)
        {
            archer_builder.CreateSwordsman();
            archer_builder.SetMotion();
            archer_builder.SetWeapon();
            return archer_builder.Heros;
        }
    }
    class SwordsmanGods : HerosBuilder
    {
        public override void SetMotion()
        {
            Console.WriteLine("Run");
        }
        public override void SetWeapon()
        {
            Console.WriteLine("Hit on sword");
        }
    }
    class ArcherGods : HerosBuilder
    {
        public override void SetMotion()
        {
            Console.WriteLine("Movement");
        }
        public override void SetWeapon()
        {
            Console.WriteLine("Shoot for bow");
        }
    }
    interface IHeros
    {
        IHeros Clone();
        void GetInfo();
    }
}
