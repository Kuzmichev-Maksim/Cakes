using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Linq;
using static Cakes.Cake;

namespace Cakes
{
    internal class Program
    {   
        private static int money = 0;
        private static string zakaz = "";
        static void Main()
        {
            PodpunktOfPart kvadrat = new PodpunktOfPart("квадратный", 100);
            PodpunktOfPart pramoug = new PodpunktOfPart("прямоугольный", 150);
            PodpunktOfPart krug = new PodpunktOfPart("круглый", 80);
            PartCake forma = new PartCake();
            forma.Name = "Форма";
            forma.Podpunkts = new List<PodpunktOfPart> {kvadrat, pramoug, krug};

            PodpunktOfPart kolvo1 = new PodpunktOfPart("1 корж", 100);
            PodpunktOfPart kolvo2 = new PodpunktOfPart("2 коржа", 200);
            PodpunktOfPart kolvo3 = new PodpunktOfPart("3 коржа", 300);
            PartCake kolichestvo = new PartCake();
            kolichestvo.Name = "Количество коржей";
            kolichestvo.Podpunkts = new List<PodpunktOfPart> {kolvo1, kolvo2, kolvo3};

            PodpunktOfPart small = new PodpunktOfPart("диаметор - 10 см", 300);
            PodpunktOfPart medium = new PodpunktOfPart("диаметор - 20 см", 500);
            PodpunktOfPart large = new PodpunktOfPart("диаметор - 30 см", 700);
            PartCake razmer = new PartCake();
            razmer.Name = "Размер торта";
            razmer.Podpunkts = new List<PodpunktOfPart> {small, medium, large};

            PodpunktOfPart sladkiy = new PodpunktOfPart("сладкий вкус", 100);
            PodpunktOfPart kisliy = new PodpunktOfPart("кислый вкус", 100);
            PodpunktOfPart solkaramel = new PodpunktOfPart("солено-карамельный вкус", 150);
            PartCake vkus = new PartCake();
            vkus.Name = "Вкусы";
            vkus.Podpunkts = new List<PodpunktOfPart> {sladkiy, kisliy, solkaramel};

            PodpunktOfPart sugar = new PodpunktOfPart("Сахарная глазурь", 100);
            PodpunktOfPart chocolate = new PodpunktOfPart("Шоколадная глазурь", 200);
            PodpunktOfPart milk = new PodpunktOfPart("Молочная глазурь", 150);
            PartCake glazur = new PartCake();
            glazur.Name = "Глазурь";
            glazur.Podpunkts = new List<PodpunktOfPart> {sugar, chocolate, milk};

            PodpunktOfPart posipca = new PodpunktOfPart("Посыпка", 150);
            PodpunktOfPart mastika = new PodpunktOfPart("Фигурки из мастики", 200);
            PodpunktOfPart berry = new PodpunktOfPart("Ягодки", 170);
            PartCake decor = new PartCake();
            decor.Name = "Декор";
            decor.Podpunkts = new List<PodpunktOfPart> {posipca, mastika, berry};

            int pos = 0;
            int pos1 = 0;
            List<PartCake> punkts = new List<PartCake> {forma, razmer, kolichestvo, vkus, glazur, decor };
            Menu(punkts, pos, pos1);
        }
        static void Menu(List<PartCake> punkts, int pos, int pos1)
        {
            foreach (PartCake i in punkts)
            {
                Console.WriteLine("  " + i.Name);
            }
            Console.WriteLine("  Чтобы сохранить заказ наведите стрелочку на этот пункт и нажмите кнопку (S)");
            Console.WriteLine("-----------------------------------------------------------------------------"); 
            Console.WriteLine("Итоговая цена: " + money);
            Console.WriteLine("Состав вашего заказа: " + zakaz);
            Arrow(punkts, pos, pos1);
        }
        static int Arrow(List<PartCake> punkts, int pos, int pos1)
        {
            Console.SetCursorPosition(0, pos);
            Console.WriteLine("->");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.S)
            {
                Console.Clear();
                Console.WriteLine("Ваш чек записан в отдельный файл");
                Save(money, zakaz);
            }
            else
            while (key.Key != ConsoleKey.Enter)
            {
                if (key.Key == ConsoleKey.UpArrow) 
                { 
                    pos--; 
                }
                if (key.Key == ConsoleKey.DownArrow) 
                { 
                    pos++; 
                }
                Console.Clear();
                Menu(punkts, pos, pos1);
                Console.WriteLine("->");
                key = Console.ReadKey();
            }
            Console.Clear();
            ZakazMenu(punkts, pos, pos1);
            return pos;
        }
        static void ZakazMenu(List<PartCake> punkts, int pos, int pos1)
        {
            foreach (PodpunktOfPart podpunkt in punkts[pos].Podpunkts)
            {
                Console.WriteLine("\t" + podpunkt.Name + ", " + podpunkt.Price + " Рублей");
            }
            ZakazArrow(punkts, pos, pos1);
            Menu(punkts, pos, pos1);
        }
        static int ZakazArrow(List<PartCake> punkts, int pos, int pos1)
        {
            ConsoleKeyInfo key = Console.ReadKey();
            while (key.Key != ConsoleKey.Enter)
            {
                if (key.Key == ConsoleKey.UpArrow)
                {
                    Console.Clear();
                    Console.SetCursorPosition(4, 0);
                    foreach (PodpunktOfPart podpunkt in punkts[pos].Podpunkts)
                    {
                        Console.WriteLine("\t" + podpunkt.Name + ", " + podpunkt.Price + " Рублей");
                    }
                    pos1--;
                    Console.SetCursorPosition(0, pos1);
                    Console.WriteLine("->");
                    key = Console.ReadKey();
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    Console.Clear();
                    Console.SetCursorPosition(4, 0);
                    foreach (PodpunktOfPart podpunkt in punkts[pos].Podpunkts)
                    {
                        Console.WriteLine("\t" + podpunkt.Name + ", " + podpunkt.Price + " Рублей");
                    }
                    pos1++;
                    Console.SetCursorPosition(0, pos1);
                    Console.WriteLine("->");
                    key = Console.ReadKey();
                }
                if (key.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    Main();
                }
            }
            Console.Clear();
            money += punkts[pos].Podpunkts[pos1].Price;
            zakaz += punkts[pos].Podpunkts[pos1].Name + ", ";
            return pos1;
        }
        static void Save(int money,string zakaz)
        {
            DateTime date = DateTime.Now;
            string sostav = zakaz;
            string cena = money.ToString();
            File.WriteAllText("C:\\Users\\maksi\\OneDrive\\Рабочий стол\\chek.txt", "Заказ от " + date);
            File.AppendAllText("C:\\Users\\maksi\\OneDrive\\Рабочий стол\\chek.txt", "\nЗаказ: " + sostav);
            File.AppendAllText("C:\\Users\\maksi\\OneDrive\\Рабочий стол\\chek.txt", "\nЦена: " + cena);
        }   
    }
}