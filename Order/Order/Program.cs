using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Order
{
    internal class Program
    {

        static void Show(string[] Parts)
        {
            for (int i = 0; i < 6; i++)
            {
                Console.SetCursorPosition(3, i+2);
                Console.WriteLine( i+1 + ". "+ Parts[i]);
            }
        }

        static void Main() 
        {
            
            int PosAdd = 0;
            int position;
            Pizza piz = new Pizza();
            Menu m = new Menu();
            string[] Parts = {"Колбаска", "Соус", "Размер", "Сыр", "Добавки", "Конец заказа",};
            Dictionary<string, int> Basket = new Dictionary<string, int>();
            int basket = 0;
            ConsoleKeyInfo key;
           
            do
            {
                Console.Clear();
                Console.WriteLine("Привествуем вас в пиццерии Pizza Tower, заказывайте пиццу.");
                Console.WriteLine("___________________________________________________________");

                Show(Parts);

                int previousBasketTotal = basket;

                Console.SetCursorPosition(0, 10);

                basket = Basket.Sum(item => item.Value);

                Console.WriteLine("Итог: " + basket);

                Console.SetCursorPosition(0,12);
                Console.WriteLine("Корзина: ");
                foreach (var (ke, val) in Basket)
                {
                    Console.WriteLine(ke + " - " + val);
                }

                Console.SetCursorPosition(0, 2);
                key = Console.ReadKey();

                position = m.MenuStr(2, 7, 2, key);
               

                piz.OrderPiz(position, PosAdd, piz, m, key, basket, Basket);
                 
            } while (true);
        }

    }
}
