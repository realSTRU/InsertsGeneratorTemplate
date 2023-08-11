using System;
using System.Text;

namespace InsertGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "45,CORTA UÑA MED,UND,17.08,768.6\r\n9,CORTA UÑA GDE,UND,23.32,209.88";
            string result = GenerateInserts(input);

            Console.WriteLine(result);
        }

        static string GenerateInserts(string input)
        {
            string[] lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            StringBuilder insertBuilder = new StringBuilder();

            foreach (string line in lines)
            {
                string[] values = line.Split(',');

                if (values.Length != 5)
                {
                    Console.WriteLine("Error: Invalid input format.");
                    return null;
                }

                int id = int.Parse(values[0]);
                string name = values[1];
                string unit = values[2];
                double value1 = double.Parse(values[3]);
                double value2 = double.Parse(values[4]);

                string insert = $"({id}, \"{name}\", \"{unit}\", {value1}, {value2})";
                insertBuilder.Append(insert).Append(", ");
            }

            string inserts = insertBuilder.ToString().TrimEnd(' ', ',');
            string finalInsert = $"INSERT INTO invColmado VALUES {inserts};";

            return finalInsert;
        }
    }
}
