using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    public class Killer
    {
        private int patnrons = 8;
        private int aim = 4;
        public void Shoot()
        {
            if (patnrons > 0)
            {
                patnrons--;
                Console.WriteLine("Выстерл сделан");
                if (patnrons % 2 == 0)
                {
                    Console.WriteLine("Попадание");
                }
                else
                    Console.WriteLine("Промох");
            }
            else
                Console.WriteLine("Закончились патроны");
        }
        public KillerMemento SaveState()
        {
            Console.WriteLine($"Сохранение игры. Осталось патронов {patnrons}, осталось целей {aim}");
            return new KillerMemento(patnrons, aim);
        }
        public void RestoreStore(KillerMemento memento)
        {
            this.patnrons = memento.Patrons;
            this.aim = memento.Aim;
            Console.WriteLine($"Возварт игры. Параметры: патроны {patnrons}, цели {aim}");
        }
    }

    public class KillerMemento
    {
        public int Patrons { get; private set; }
        public int Aim { get; private set; }
        public KillerMemento(int patrons, int aim)
        {
            this.Patrons = patrons;
            this.Aim = aim;
        }
    }
    
    public class GameHistory
    {
        public Stack<KillerMemento> History { get; private set; }
        public GameHistory()
        {
            History = new Stack<KillerMemento>();
        }
    }
}
