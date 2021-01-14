using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_4.Interfaces
{
    interface IDisk
    {
        string Read(); // повертає все що є в memory на диску

        void Write(string text); // записує переданий текст на диск
    }
}
