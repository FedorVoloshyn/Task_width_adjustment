using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_width_adjustment
{
    interface ITextJustifer
    {
        string Justify(string text, int maxLineWidth);
    }
}
