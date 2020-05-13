using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
   public interface ICommand
    {
        void Jump();
        void Buy();
        void Fire();
        void Run();
        void Shift();
    }
    public class Person
    {
        public void PersonJump()
        {
            Console.WriteLine("Person jump");
        }
        public void PersonBuy()
        {
            Console.WriteLine("Person buy pistolet");
        }
        public void PersonFire()
        {
            Console.WriteLine("Perspm fire");
        }
        public void PerssonRun()
        {
            Console.WriteLine("Person run from Police");
        }
        public void PersonShift()
        {
            Console.WriteLine("Person hide");
        }

    }
    public class PersonCommand: ICommand
    {
        Person person;
        public PersonCommand(Person personSet)
        {
            person = personSet;
        }
        public void Jump()
        {
            person.PersonJump();
        }
        public void Buy()
        {
            person.PersonBuy();
        }
       public void Fire()
        {
            person.PersonFire(); 
        }
        public void Run()
        {
            person.PerssonRun();
        }
       public  void Shift()
        {
            person.PersonShift();
        }
    }
    public class God
    {
        ICommand command;
        public God() { }
        public void SetCommand(ICommand com) => command = com;
        public void GoKill()
        {
            command.Buy();
        }
        public void GoFire()
        {
            command.Fire();
        }
        public void GoJump()
        {
            command.Jump();
        }
        public void GoRun()
        {
            command.Run();
        }
        public void GoHide()
        {
            command.Shift();
        }
    }

}
