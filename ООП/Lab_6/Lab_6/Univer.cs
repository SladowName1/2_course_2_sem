using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    [Serializable]
    public class Student
    {
        public  string Name { get; set; }
        public int Age { get; set; }
        public string Profession { get; set; }
        public DateTime DateTime { get; set; }
        public int Course { get; set; }
        public  int Group { get; set; }
        public double Average { get; set; }
        public string Gender { get; set; }
        public Adress Adress { get; set; }
        public Student()
        {  }
        public Student(string name, int age, string profession, DateTime dateTime, int course,int group, double avg, string gender, Adress adress)
        {
            Name = name;
            Age = age;
            Profession = profession;
            DateTime = dateTime;
            Course = course;
            Group = group;
            Average = avg;
            Gender = gender;
            Adress = adress;
        }
        public override string ToString()
        {
            return $"Name:{Name}\n Age: {Age} \n Professiion: {Profession}\n Birthdau:{DateTime}\n Course:{Course}\n Group:{Group}\n Average mark:{Average}\n Gender:{Gender}\n Adress:{Adress.City} {Adress.Streat}\n";
        }

    }
    [Serializable]
    public class Adress
    {
       public string City { get; set; }
        public int Index { get; set; }
        public string Streat { get; set; }
        public  int House { get; set; }
        public  int Flat { get; set; }
        public Adress()
        { }
        public Adress(string city,int index,string streat, int house, int flat)
        {
            City = city;
            Index = index;
            Streat = streat;
            House = house;
            Flat = flat;
        }
    }
}
