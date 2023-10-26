using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order
{
    internal class Menu
    {

        public int pos;
        public ConsoleKeyInfo key;

        public int MenuStr(int pos, int max, int min, ConsoleKeyInfo key)
        {
             
             
            Console.SetCursorPosition(0, pos);
            Console.Write("->");
            
            do
            {
                Console.SetCursorPosition(0, pos);
                key = Console.ReadKey();
                Console.WriteLine("  ");
                if (key.Key == ConsoleKey.UpArrow)
                {
                    pos--;
                    if (pos < min)
                    {
                        pos = max;
                    }
                    
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    pos++;
                    if (pos > max)
                    {
                        pos = min;
                    }
                    
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    return 101;
                }
                Console.SetCursorPosition(0, pos);
                Console.Write("->");
            }while (key.Key != ConsoleKey.Enter);
            return pos;
        }
    }
}
