using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_width_adjustment
{
    class VoloshynTextJustifier : ITextJustifer
    {
        public string Justify(string text, int maxLineWidth)
        {
            char[] separators = { ' ' };
            string[] words = text.Split(separators);
            bool falseWidth = false;

            if (maxLineWidth < 100 && maxLineWidth > 0)
            {
                // Show words
                foreach (string x in words)
                {
                    if (x.Length < maxLineWidth)
                        Console.WriteLine(x);
                    else
                        return "Error: word`s length >= width.";
                }


                // Produce final strings
                if (!falseWidth)
                {
                    bool isEnd = false;
                    int countOfLettersInString = 0, i = 0, j, avaluableSpaces = 0, startWord = 0, countOfWordsInLine = 0;
                    if (maxLineWidth >= 3)
                    {
                        string rezult = "";
                        while (!isEnd)
                        {
                            while (countOfLettersInString <= maxLineWidth && countOfLettersInString + words[i].Length <= maxLineWidth)
                            {
                                countOfLettersInString += words[i].Length + 1;
                                i++;
                                countOfWordsInLine++;
                                if (i == words.Length)
                                    break;
                            }
                            // Calculate spaces to enter after words
                            avaluableSpaces = maxLineWidth - countOfLettersInString + countOfWordsInLine;

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
                                tmp += words[j];

                            rezult += tmp + '\n';

                            // Reset variables
                            startWord = i;
                            countOfLettersInString = 0;
                            avaluableSpaces = 0;
                            countOfWordsInLine = 0;

                            // Check is finish
                            if (i == words.Length)
                                isEnd = true;
                        }

                        Console.WriteLine("\n" + rezult);
                        return rezult;
                    }
                    else
                        return "Width is incorrect!";
                }
                else
                    return "Width is incorrect!";
            }
            else
                return "Width is incorrect! (width = [higher word length, 100])";
        }
    }
}
