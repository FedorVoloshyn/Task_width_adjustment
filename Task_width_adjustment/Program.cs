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

                    // Produce final strings
                    List<string> finalStrings = new List<string>();
                    bool isEnd = false;
                    int countOfLettersInString = 0, i = 0, j, lastWordIndex = 0, avaluableSpaces = 0, startWord = 0;
                   
                    while(!isEnd)
                    {
                        while (countOfLettersInString <= width && countOfLettersInString + words[i].Length <= width)
                        {
                            foreach (char x in words[i])
                                countOfLettersInString++;
                            if (countOfLettersInString < width)
                            {
                                countOfLettersInString++;
                                if (countOfLettersInString == width)
                                    countOfLettersInString--;
                            }
                            else
                                lastWordIndex = i;
                            i++;
                            if (i == words.Length)
                                break;
                        } 

                        //for (j = startWord; j < i; j++ )
                        //{
                        //    if(j != i)
                        //        avaluableSpaces += words[j].Length + 1;
                        //    else
                        //        avaluableSpaces += words[j].Length;
                        //}
                        //avaluableSpaces -= countOfLettersInString;
                        avaluableSpaces = width - countOfLettersInString + 1;

                        while (avaluableSpaces != 0)
                        {
                            for (j = startWord; j < i; j++)
                            {
                                if (avaluableSpaces > 0)
                                {
                                    words[j] += ' ';
                                    avaluableSpaces--;
                                }
                            }
                        }

                        string tmp = "";
                        for (j = startWord; j < i; j++)
                        {
                            tmp += words[j];
                        }

                        finalStrings.Add(tmp);
                        startWord = i;
                        countOfLettersInString = 0;
                        avaluableSpaces = 0;
                        if (i == words.Length)
                            isEnd = true;
                    }

                    Console.WriteLine("\n");
                    foreach (string x in finalStrings)
                        Console.WriteLine(x);

                    File.WriteAllLines(@"C:\Users\ФЁДОР\Documents\Visual Studio 2013\Projects\Task_width_adjustment\Task_width_adjustment\out.txt", finalStrings);
                }
                else
                    Console.WriteLine("Incorrect number of lines in 'in.txt'!");
            }
        }
    }
}
