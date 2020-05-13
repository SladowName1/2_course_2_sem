using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Mider mider = new Mider("agressiv");
            Mid mid = new Mid();
            mider.goToMid(mid);
            Diff diff = new Diff();
            Motion motion = new MidderGoToBot(diff);
            mider.goToMid(motion);

            Mider mider1 = new AgressivMider();
            mider1 = new WithNuke(mider1);
            Console.WriteLine(mider1.typeOfMider);

            Mider mider2 = new PasivMider();
            mider2 = new WithOutNuke(mider2);
            Console.WriteLine(mider2.typeOfMider);

            var district = new Map { Title = "District" };
            district.AddComponent(new MapComponent { Title = "House 1" });
            district.AddComponent(new MapComponent { Title = "House 2" });

            var city = new Map { Title = "New city" };
            city.AddComponent(district);
            city.Draw();

            var house = city.Find("House 1");
            house.Draw();

            Console.Read();
        }
    }
   interface Motion
    {
        void Move();
    }
    class Mid:Motion
    {
        public void Move()
        {
            Console.WriteLine("Mider go to mid");
        }
    }
    class Mider
    {
        public string typeOfMider { get; protected set; }
        public Mider(string type)
        {
            this.typeOfMider = type;
        } 
        public void goToMid(Motion move)
        {
            move.Move();
        }
    }
     interface Differens
    {
        void Moves();
    }
    class Diff:Differens
    {
        public void Moves()
        {
            Console.WriteLine("Mider go to bot");
        }
    }
    class MidderGoToBot:Motion
    {
        Diff mider;
        public MidderGoToBot(Diff m)
        {
            mider = m;
        }
        public void Move()
        {
            mider.Moves();
        }

    }
    class AgressivMider:Mider
    {
        public AgressivMider() : base("agressiv mider")
        { }
    }
    class PasivMider : Mider
    {
        public PasivMider() : base("passiv mider")
        { }
    }
    abstract class DecoratorMider:Mider
    {
        protected Mider mider;
        public DecoratorMider(string n, Mider mider):base(n)
        {
            this.mider = mider;
        }

    }
    class WithNuke:DecoratorMider
    {
        public WithNuke(Mider m) : base(m.typeOfMider + " with nuke", m)
        { }
    }
    class WithOutNuke:DecoratorMider
    {
        public WithOutNuke(Mider m):base(m.typeOfMider+" with out nuke",m)
        { }
    }
    public interface IComponent
    {
        string Title { get; set; }
        void Draw();
        IComponent Find(string title);
    }
    public class MapComponent:IComponent
    {
        public string Title { get; set; }
        public void Draw()
        {
            Console.WriteLine(Title);
        }
        public IComponent Find(string title)
        {
            return Title == title ? this : null;
        }
    }
    public class Map:IComponent
    {
        private readonly List<IComponent> _map = new List<IComponent>();
        public string Title { get; set; }
        public void AddComponent(IComponent component)
        {
            _map.Add(component);
        }
        public void Draw()
        {
            Console.WriteLine(Title);
            foreach(var component in _map)
            {
                component.Draw();
            }
        }
        public IComponent Find(string title)
        {
            if (Title==title)
            {
                return this;
            }
            foreach (var component in _map)
            {
                var found = component.Find(title);
                if(found!=null)
                {
                    return found;
                }
            }
            return null;
        }
    }
}
