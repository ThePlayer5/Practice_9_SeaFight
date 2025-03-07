using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_9_SeaFight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int[][][][] coords = new int[][][][];
            //int coorDs = 0;
            //Dictionary<string, int> sheeps = new Dictionary<string, int>()
            //{
            //    { "Один", coorDs },
            //    { "Два", coorDs },
            //    { "Три", coorDs },
            //    { "Четыре", coorDs }
            //};
            int coord1_1;
            int coord1_2;
            string[,] map = { { ".", ".", ".", ".", ".", ".", ".", ".", ".", "." }, { ".", ".", ".", ".", ".", ".", ".", ".", ".", "." } };
            Console.WriteLine("  а б в г д е ж з к и");
            for (int i = 0; i < map.GetLength(0); i++)
            {
                Console.Write(i + 1 + " ");
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(". ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n-- Размещение кораблей --");
            Console.Write("Выберите корабль (Один | Два | Три | Четыре): ");
            string sheep = Console.ReadLine();
            switch (sheep)
            {
                
                case "Один":
                    Console.WriteLine("Введите координаты: ");
                    coord1_1 = Convert.ToInt32(Console.ReadLine());
                    coord1_2 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("  а б в г д е ж з к и");
                    for (int i = 0; i < map.GetLength(0); i++)
                    {
                        Console.Write(i + 1 + " ");
                        for (int j = 0; j < map.GetLength(1); j++)
                        {
                            if (i == coord1_1 && j == coord1_2)
                            {
                                Console.Write("+ ");
                                continue;
                            }
                            Console.Write(". ");
                        }
                        Console.WriteLine();
                    }
                    break;
                case "Два":
                    Console.WriteLine("Введите координаты: ");
                    coord1_1 = Convert.ToInt32(Console.ReadLine());
                    coord1_2 = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Выберите направление корабля: ");
                    string direction = Console.ReadLine();

                    Console.WriteLine("  а б в г д е ж з к и");
                    for (int i = 0; i < map.GetLength(0); i++)
                    {
                        Console.Write(i + 1 + " ");
                        for (int j = 0; j < map.GetLength(1); j++)
                        {
                            switch (direction)
                            {
                                case "влево":
                                    if (i == coord1_1 && j == coord1_2)
                                    {
                                        Console.Write("+ ");

                                        continue;
                                    }
                                    break;
                            }
                            Console.Write(". ");
                        }
                        Console.WriteLine();
                    }
                    break;
                case "Три":
                    break;
                case "Четыре":
                    break;
            }


            Console.ReadKey();
        }
    }
}
