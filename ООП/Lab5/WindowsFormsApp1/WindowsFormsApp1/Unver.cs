using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    [Serializable]
   public class Student
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Profession { get; set; }
       public DateTime Datetime { get; set; }
        public int Course { get; set; }
        public int Group { get; set; }
        public double Avg { get; set; }
        public string Gender { get; set; }
        public Adress Adres { get; set; }
        public Student()
        {

        }
        public Student(string name, string lastName, string profession, int course, int group, Adress adress, DateTime dateTime, int age, string gender, double avg)
        {
            Name = name;
            LastName = lastName;
            Age = age;
            Profession = profession;
            Datetime = dateTime;
            Course = course;
            Group = group;
            Avg = avg;
            Gender = gender;
            Adres = adress;
        }
        public override string ToString()
        {
            return $"Name: {Name}, {LastName} \n Age: {Age}\n Profession: {Profession}\n Birthday: {Datetime}\n Course: {Course}, group:{Group}\n Averag mark: {Avg}\n Gender: {Gender} Adress: {Adres.City} {Adres.Streat}, {Adres.NumberHouse}-{Adres.Flat}\n Index: {Adres.Index} ";
        }

    }

    [Serializable]
    public class Adress
    {
        public string City { get; set; }
        public int Index { get; set; }
        public string Streat { get; set; }
        public int NumberHouse { get; set; }
        public int Flat { get; set; }
        public Adress()
        {

        }
        public Adress(string city, int index, string streat, int numberHouse, int flat)
        {
            City = city;
            Index = index;
            Streat = streat;
            NumberHouse = numberHouse;
            Flat = flat; ;
        }

    }
}
