using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_width_adjustment
{
    static class SetText
    {
        public static string[] SetStrings(string[] tmpMas, int width)
        {
            List<string> finalStrings;
            int i = 0, countOfSymbolsInWord = 0, possibleSpaces;
            string tmp = "";
            bool isFinish = false;
            while(!isFinish)
            {
                do // ИДЕЯ: к каждому слову, как к строке, добавлять пробелы.
                {

                    tmp += tmpMas[i] + " ";
                    countOfSymbolsInWord += tmpMas[i].Length;
                    i++;
                } while (tmp.Length < width);
                possibleSpaces = tmp.Length - countOfSymbolsInWord;

                i = 0;
            }
            return tmpMas;
        }
    }
}
