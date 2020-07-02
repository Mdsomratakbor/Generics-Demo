using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsDemo.WithGenerics
{
    public class GenericTextFileProcess
    {
        public static List<T> LoadFromTextFile<T>(string filePath) where T : class, new()
        {
            var lines = File.ReadAllLines(filePath).ToList();
            List<T> output = new List<T>();
            T entry = new T();
            var cols = entry.GetType().GetProperties();

            // Checks to be sure we have at least one header nrow and one data row
            if (lines.Count < 2)
            {
                throw new IndexOutOfRangeException("The file was either empty or missing.");
            }
            // Splits the header into one column header per entry
            var header = lines[0].Split(',');
            // Removes the header row from the lines so we don't 
            // have to worry about skipping over that first row.
            lines.RemoveAt(0);
            foreach (var row in lines)
            {
                entry = new T();
                var values = row.Split(',');
                for(var i=0; i<header.Length; i++)
                {
                    foreach (var col in cols)
                    {
                        col.SetValue(entry, Convert.ChangeType(values[i], col.PropertyType));
                    }
                }
                output.Add(entry);
            }
            return output;
        }

        public static void SaveToTextFile<T>(List<T> data, string filePathe) where T : class, new()
        {
            List<string> lines = new List<string>();
            StringBuilder line = new StringBuilder();
            if(data == null || data.Count == 0)
            {
                throw new ArgumentNullException("data", "you must populate the data parameter with least one");
            }
            var cols = data[0].GetType().GetProperties();
            foreach (var col in cols)
            {
                line.Append(col.Name);
                line.Append(",");
            }
            lines.Add(line.ToString().Substring(0, line.Length - 1));
            foreach (var row in data)
            {
                line = new StringBuilder();
                foreach(var col in cols)
                {
                    line.Append(col.GetValue(row));
                    line.Append(",");
                }
                lines.Add(line.ToString().Substring(0, line.Length-1));
            }
            File.WriteAllLines(filePathe, lines);
        }
    }
}
