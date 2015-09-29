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

                    int width = Convert.ToInt32(lines[0]);
                    string text = lines[1];
                    char[] separators = { ' ' };
                    string[] words = text.Split(separators);

                    // Show words
                    foreach (string x in words)
                        Console.WriteLine(x);

                    // Produce final strings
                    List<string> finalStrings = new List<string>();
                    bool isEnd = false;
                    int countOfLettersInString = 0, i = 0, j, avaluableSpaces = 0, startWord = 0, countOfWordsInLine = 0;
                    if (width >= 3)
                    {
                        while (!isEnd)
                        {
                            while (countOfLettersInString <= width && countOfLettersInString + words[i].Length <= width)
                            {
                                countOfLettersInString += words[i].Length + 1;
                                i++;
                                countOfWordsInLine++;
                                if (i == words.Length)
                                    break;
                            }
                            // Calculate spaces to enter after words
                            avaluableSpaces = width - countOfLettersInString + countOfWordsInLine;

                            // Adding spaces to words
                            while (avaluableSpaces != 0)
                            {
                                if (countOfWordsInLine == 1)
                                {
                                    j = startWord;
                                    while (avaluableSpaces != 0)
                                    {
                                        if (avaluableSpaces > 0)
                                        {
                                            words[j] += ' ';
                                            avaluableSpaces--;
                                        }
                                    }
                                }
                                else
                                {
                                    for (j = startWord; j < i - 1; j++)
                                    {
                                        if (avaluableSpaces > 0)
                                        {
                                            words[j] += ' ';
                                            avaluableSpaces--;
                                        }
                                    }
                                }
                            }

                            // Compiling strings
                            string tmp = "";
                            for (j = startWord; j < i; j++)
                            {
                                tmp += words[j];
                            }

                            finalStrings.Add(tmp);

                            // Reset variables
                            startWord = i;
                            countOfLettersInString = 0;
                            avaluableSpaces = 0;
                            countOfWordsInLine = 0;

                            // Check is finish
                            if (i == words.Length)
                                isEnd = true;
                        }

                        Console.WriteLine("\n");
                        foreach (string x in finalStrings)
                            Console.WriteLine(x);
                        File.WriteAllLines(@"..\..\out.txt", finalStrings);
                    }
                    else
                        Console.WriteLine("Incorrect width.");
                }
                else
                    Console.WriteLine("Incorrect number of lines in 'in.txt'!");
            }
        }
    }
}
