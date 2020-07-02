using GenericsDemo.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsDemo.WithoutGenerics
{
    public class OriginalTextFileProcessor
    {
        public static List<Person> LoadPeople(string filePath)
        {
            List<Person> output = new List<Person>();
            Person p;
            dynamic lines = File.ReadAllLines(filePath).ToList();

            // Remove the header row
            lines.RemoveAt(0);
            foreach (var line in lines)
            {
                dynamic values = line.Split(',');
                p = new Person();
                p.FirstName = values[0];
                p.IsAlive = values[1];
                p.LastName = values[2];
                output.Add(p);
            }
            return output;
        }

        public static void SavePepole(List<Person> people, string filePath)
        {
            List<string> lines = new List<string>();
            // Add a header row
            lines.Add("FirstName, IsAlive, LastName");
            foreach (var p in people)
            {
                lines.Add($"{p.FirstName}, {p.IsAlive},{p.LastName}");
            }
            File.WriteAllLines(filePath,lines);
        }
    }
}
