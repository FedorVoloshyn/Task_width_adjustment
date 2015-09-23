using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task_width_adjustment
{
    class Program
    {
        static void Main(string[] args)
        {
            if (File.Exists(@"C:\Users\ФЁДОР\Documents\Visual Studio 2013\Projects\Task_width_adjustment\Task_width_adjustment\in.txt"))
            {
                string[] lines = File.ReadAllLines(@"C:\Users\ФЁДОР\Documents\Visual Studio 2013\Projects\Task_width_adjustment\Task_width_adjustment\in.txt", Encoding.Default);
                if (lines.Length == 2)
                {
                    // Show text from file 'in.txt'
                    Console.WriteLine("File 'in.txt' contains: ");
                    foreach(string x in lines)
                        Console.WriteLine(x);
                    Console.WriteLine("\n");
                    
                    int width = Convert.ToInt32(lines[0]);
                    string text = lines[1];
                    char[] separators = {' '};
                    string[] words = text.Split(separators);

                    // Show words
                    foreach (string x in words)
                        Console.WriteLine(x);

                    
                }
                else
                    Console.WriteLine("Incorrect number of lines in 'in.txt'!");
            }
        }
    }
}
