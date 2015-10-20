using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Practices.Unity;

namespace Task_width_adjustment
{
    class Program
    {
        static void Main(string[] args)
        {
            if (File.Exists(@"..\..\in.txt"))
            {
                string[] lines = File.ReadAllLines(@"..\..\in.txt", Encoding.Default);
                if (lines.Length == 2)
                {
                    // Show text from file 'in.txt'
                    Console.WriteLine("File 'in.txt' contains: ");
                    foreach (string x in lines)
                        Console.WriteLine(x);
                    Console.WriteLine("\n");

                    int width = 0;
                    if(lines[0].Length>0)
                        width = Convert.ToInt32(lines[0]);
                    string text = lines[1];

                    MyLittleMSWord myMSWord = new MyLittleMSWord();
                    string strToList = myMSWord.MakeSomeStringMagic(text, width);
                    string[] finalStrings = strToList.Split('\n');

                    File.WriteAllLines(@"..\..\out.txt", finalStrings);
                }
                else
                    Console.WriteLine("Incorrect number of lines in 'in.txt'!");
            }
        }
    }
}
