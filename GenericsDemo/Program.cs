using GenericsDemo.Models;
using GenericsDemo.WithoutGenerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();

            Console.Write("Please Enter any key to exit the application.....");
            Console.Read();
        }
        private static void DemonStrateTextFileStorage()
        {
            List<Person> people = new List<Person>();
            List<LogEntry> logs = new List<LogEntry>();
            string pepoleFile = @"D:\New folder\pepole.csv";
            string logFile = @"D:\New folder\logs.csv";
            PopulateLists(people, logs);
            OriginalTextFileProcessor.SavePepole(people, pepoleFile);
            var newPeople = OriginalTextFileProcessor.LoadPeople(pepoleFile);
            foreach (var p in newPeople)
            {
                Console.WriteLine($"First Name: {p.FirstName }, Last Name: { p.LastName}, Is Alive: {p.IsAlive }");
            }
        }
        private static void PopulateLists(List<Person> people, List<LogEntry> logs)
        {
            people.Add(new Person { FirstName = "Md Somrat", LastName = "Akbor", IsAlive = true });
            people.Add(new Person { FirstName = "Md Rakib", LastName = "Hossain", IsAlive = true });
            people.Add(new Person { FirstName = "Md Raihan", LastName = "Khan", IsAlive = true });
            people.Add(new Person { FirstName = "Md Delwar", LastName = "Hossain", IsAlive = true });
            people.Add(new Person { FirstName = "Md Asif", LastName = "Khan", IsAlive = true });
            people.Add(new Person { FirstName = "Md Atiqur", LastName = "Rahman", IsAlive = true });

            logs.Add(new LogEntry { Message = "Hi How are you",  ErrorCode= 000121});
            logs.Add(new LogEntry { Message = "This is Nice", ErrorCode = 334021});
            logs.Add(new LogEntry { Message = "You are looking good", ErrorCode = 011424 });
            logs.Add(new LogEntry { Message = "which person are you like", ErrorCode = 0142424});

        }
    }
}
