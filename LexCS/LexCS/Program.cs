using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexCS
{
    class Program
    {
        static void Main(string[] args)
        {
            var rtrn = Lexer.mainloop(LexHandler);
            Console.WriteLine($"Returned {rtrn}");
        }

        static void LexHandler(int val, IntPtr type)
        {
            String str = Lexer.PtrToStringUtf8(type);
            switch (val)
            {
                case 0:
                    Console.WriteLine($"Detected Number, code {str}");
                    break;
                case 1:
                    Console.WriteLine($"Detected Text, code {str}");
                    break;
                default:
                    Console.WriteLine("Detected Unknown Character(s)");
                    break;
            }
        }
    }
}
