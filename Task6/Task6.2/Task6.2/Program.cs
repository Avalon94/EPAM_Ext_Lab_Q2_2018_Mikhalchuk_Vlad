using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6._2
{
    public delegate void Greeting(Person person, TimeSpan time);

    public delegate void Farewell(Person person);

    public class Program
    {
        public static void Main(string[] args)
        {
            Office office = new Office();
            Person alex = new Person("Alex");
            Person jack = new Person("Jack");
            Person mary = new Person("Mary");

            office.AppearenceOfAPerson(alex, new TimeSpan(10, 00, 00));
            office.AppearenceOfAPerson(jack, new TimeSpan(12, 00, 00));
            office.AppearenceOfAPerson(mary, new TimeSpan(17, 00, 00));

            office.OutAPerson(alex);
            office.OutAPerson(jack);
            office.OutAPerson(mary);

            Console.ReadLine();
        }
    }
}
