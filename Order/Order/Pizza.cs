using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order
{
    internal class Pizza
    {


        public Dictionary<string, int> Sausage()
        {

            Dictionary<string, int> sausage = new Dictionary<string, int>()
            {
                { "Много колбасок", 700},
                { "5 колбасок", 500 },
                { "3 колбасок", 300 },
                { "Без колбасок", 100}
            }; 
            return sausage;
        }
        public Dictionary<string, int> Sous()
        {

            Dictionary<string, int> sous = new Dictionary<string, int>()
            {
                { "Кетчуп", 200},
                { "Майонез", 200 },
                { "Горчица", 200 },
                { "Соевый", 100},
                { "Чесночный", 150 },
                { "Сырный", 150 }
            };
            return sous;
        }
        public Dictionary<string, int> Size()
        {

            Dictionary<string, int> size = new Dictionary<string, int>()
            {
                { "Большая", 600},
                { "Средняя", 400 },
                { "Маленькая", 200 }
            };
            return size;
        }

        public Dictionary<string, int> Cheese()
        {

            Dictionary<string, int> cheese = new Dictionary<string, int>()
            {
                { "Пармезан", 600},
                { "Адыгейский", 100 },
                { "Чеддер", 400 },
                { "Российский", 300},
                { "Эмменталь", 400 },
                { "Моцарелла", 200 }
            };
            return cheese;
        }

        public Dictionary<string, int> Additives()
        {

            Dictionary<string, int> additives = new Dictionary<string, int>()
            {
                { "Ананасы", 750},
                { "Грибы", 210 },
                { "Помидоры", 270 },
                { "Перцы", 340},
                { "Огурецы", 200 },
                { "Бекон", 590 }
            };
            return additives;
        }

        public void ShowPizza(Dictionary<string, int> piz, int PosAdd)
        {
            PosAdd = 2;
            Console.Clear();
            Console.WriteLine("Выберите парамтер пиццы.");
            Console.WriteLine("___________________________________________");
            foreach (var (name, price) in piz)
            {
                Console.SetCursorPosition(2, PosAdd);
                Console.WriteLine(name + " - " + price);
                PosAdd++;
            }
           
        }

        public void Order(int basket, Dictionary<string, int> Basket)
        {
            string path1 = @"C:\Users\denol\Desktop\Заказ.txt";
            string price = "Цена заказа: ";
            string korz = "Параметры пиццы:  ";
            DateTime date = DateTime.Now;
            File.AppendAllText(path1, "Дата заказа: " + date.ToString("d") + "\n");
            File.AppendAllText(path1, "\n" + price + Convert.ToString(basket) + "\n");
            File.AppendAllText(path1, korz + "\n");
            foreach (var (ke, val) in Basket)
            {
                File.AppendAllText(path1, ke + " - " + Convert.ToString(val) + "\n");
            }
        }

        public bool OrderPiz(int position, int PosAdd, Pizza piz, Menu m, ConsoleKeyInfo key, int basket, Dictionary<string, int> Basket)
        {

            if (position == 101)
            {
                Console.SetCursorPosition(0, 20);
                return true;
            }
            if (position == 2)
            {
                piz.ShowPizza(piz.Sausage(), PosAdd);
                position = m.MenuStr(2, 7, 2, key);
                if (position == 101) { return false; }
                Basket.Add((piz.Sausage().ElementAt(position - 2).Key), (piz.Sausage().ElementAt(position - 2).Value));
                return true;
            } 
            else if (position == 3)
            {
                piz.ShowPizza(piz.Sous(), PosAdd);
                position = m.MenuStr(2, 7, 2, key);
                if (position == 101) { return false; }
                Basket.Add((piz.Sous().ElementAt(position - 2).Key), (piz.Sous().ElementAt(position - 2).Value));
                return true;
            }
            else if (position == 4)
            {
                piz.ShowPizza(piz.Size(), PosAdd);
                position = m.MenuStr(2, 4, 2, key);
                if (position == 101) { return false; }
                Basket.Add((piz.Size().ElementAt(position - 2).Key), (piz.Size().ElementAt(position - 2).Value));
                return true;
            }
            else if (position == 5)
            {
                piz.ShowPizza(piz.Cheese(), PosAdd);
                position = m.MenuStr(2, 7, 2, key);
                if (position == 101) { return false; }
                Basket.Add((piz.Cheese().ElementAt(position - 2).Key), (piz.Cheese().ElementAt(position - 2).Value));
                return true;
            }
            else if (position == 6)
            {
                piz.ShowPizza(piz.Additives(), PosAdd);
                position = m.MenuStr(2, 7, 2, key);
                if (position == 101) { return false; }
                Basket.Add((piz.Additives().ElementAt(position - 2).Key), (piz.Additives().ElementAt(position - 2).Value));
                return true;
            }
            else if (position == 7)
            {
                piz.Order(basket, Basket);
                Basket.Clear();
                return false;
            }

            return false;


        }
    }
}
