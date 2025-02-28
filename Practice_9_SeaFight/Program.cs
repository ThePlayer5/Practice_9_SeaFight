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
            int[,] map = new int[10, 10];
            Console.WriteLine("  а б в г д е ж з к и");
            for (int i = 0; i < map.GetLength(0); i++)
            {
                Console.Write(i+1 + " ");
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write("+ ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n-- Размещение кораблей --");
            Console.Write("Выберите корабль (Один/Два/Три/Четыре): ");
            string sheep = Console.ReadLine();
            switch (sheep)
            {
                
                case "Один":
                    int[] coords = new int[2];
                    Console.WriteLine("Введите координаты: ");
                    for (int i = 0; i < coords.GetLength(0); i++)
                    {
                        coords[i] = Convert.ToInt32(Console.ReadLine());
                    }

                    for (int i = 0; i < map.GetLength(0); i++)
                    {
                        Console.Write(i + 1 + " ");
                        for (int j = 0; j < map.GetLength(1); j++)
                        {
                            if (map[i, j] == coords[j]) Console.WriteLine(coords[j]);
                            Console.Write("+ ");
                        }
                        Console.WriteLine();
                    }
                    break;
                case "Два":
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
