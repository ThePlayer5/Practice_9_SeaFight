using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_9_SeaFight
{
    internal class Program
    {
        static Random rnd = new Random();
        static string[,] map = new string[10, 10];
        static int coord1;
        static int coord2;
        static string[,] enemyMap = new string[10, 10];
        static int coord3;
        static int coord4;
        static void Main(string[] args)
        {
            Console.WriteLine("Press Enter");
            EnemySheep();
            DrawEnemyMap();
            string direction;
            int single_deck = 0;
            int double_deck = 0;
            int triple_deck = 0;
            int four_deck = 0;
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = ".";
                }
            }
            DrawMap();
            Console.WriteLine("\n-- Размещение кораблей --");
            for (int i = 1; i <= 10; i++)
            {
                Console.Write("Выберите корабль (Один | Два | Три | Четыре): ");
                string sheep = Console.ReadLine();
                Console.WriteLine("Введите координаты: ");
                coord1 = SetCoord1();
                coord2 = SetCoord2();
                if (sheep == "Один")
                {
                    if (single_deck == 4)
                    {
                        Console.WriteLine("Вы уже разместили все однопалубные карабли!");
                        i--;
                    }
                    else
                    {
                        if (coord1 < 0 || coord1 > 9 || coord2 < 0 || coord2 > 9)
                        {
                            Console.WriteLine("Координаты выходлят за границы карты!");
                            i--;
                        }
                        else
                        {
                            if (map[coord1, coord2] == "O" || map[coord1, coord2 - 1] == "O" || map[coord1, coord2 + 1] == "O" || map[coord1 - 1, coord2] == "O" || map[coord1 + 1, coord2] == "O"
                                || map[coord1 - 1, coord2 - 1] == "O" || map[coord1 + 1, coord2 - 1] == "O" || map[coord1 - 1, coord2 + 1] == "O" || map[coord1 + 1, coord2 + 1] == "O")
                            {
                                Console.WriteLine("Эта ячейка уже занята");
                                i--;
                            }
                            else
                            {
                                map[coord1, coord2] = "O";
                                single_deck++;
                            }
                        }
                    }
                }
                else if (sheep == "Два")
                {
                    if (double_deck == 3)
                    {
                        Console.WriteLine("Вы уже разместили все двухпалубные карабли!");
                        i--;
                    }
                    else
                    {
                        Console.Write("Выберите направление корабля: ");
                        direction = Console.ReadLine();
                        switch (direction)
                        {
                            case "влево":
                                if (coord1 < 0 || coord1 > 9 || coord2 < 0 || coord2 > 9 || coord2 - 1 <= 0)
                                {
                                    Console.WriteLine("Координаты выходлят за границы карты!");
                                    i--;
                                }
                                else
                                {
                                    if (map[coord1, coord2] == "O" || map[coord1, coord2 - 1] == "O"
                                        || map[coord1 - 1, coord2 - 1] == "O" || map[coord1 + 1, coord2 - 1] == "O" || map[coord1 - 1, coord2 + 1] == "O" || map[coord1 + 1, coord2 + 1] == "O")
                                    {
                                        Console.WriteLine("Эта ячейка уже занята");
                                        i--;
                                    }
                                    else
                                    {
                                        map[coord1, coord2] = "O";
                                        map[coord1, coord2 - 1] = "O";
                                        double_deck++;
                                    }
                                }
                                break;
                            case "вправо":
                                if (coord1 < 0 || coord1 > 9 || coord2 < 0 || coord2 > 9 || coord2 + 1 > 8)
                                {
                                    Console.WriteLine("Координаты выходлят за границы карты!");
                                    i--;
                                }
                                else
                                {
                                    if (map[coord1, coord2] == "O" || map[coord1, coord2 + 1] == "O" ||
                                        map[coord1 - 1, coord2 - 1] == "O" || map[coord1 + 1, coord2 - 1] == "O" || map[coord1 - 1, coord2 + 1] == "O" || map[coord1 + 1, coord2 + 1] == "O")
                                    {
                                        Console.WriteLine("Эта ячейка уже занята");
                                        i--;
                                    }
                                    else
                                    {
                                        map[coord1, coord2] = "O";
                                        map[coord1, coord2 + 1] = "O";
                                        double_deck++;
                                    }
                                }
                                break;
                            case "вверх":
                                if (coord1 < 0 || coord1 > 9 || coord2 < 0 || coord2 > 9 || coord1 - 1 <= 0)
                                {
                                    Console.WriteLine("Координаты выходлят за границы карты!");
                                    i--;
                                }
                                else
                                {
                                    if (map[coord1, coord2] == "O" || map[coord1 - 1, coord2] == "O" ||
                                        map[coord1 - 1, coord2 - 1] == "O" || map[coord1 + 1, coord2 - 1] == "O" || map[coord1 - 1, coord2 + 1] == "O" || map[coord1 + 1, coord2 + 1] == "O")
                                    {
                                        Console.WriteLine("Эта ячейка уже занята");
                                        i--;
                                    }
                                    else
                                    {
                                        map[coord1, coord2] = "O";
                                        map[coord1 - 1, coord2] = "O";
                                        double_deck++;
                                    }
                                }
                                break;
                            case "вниз":
                                if (coord1 < 0 || coord1 > 9 || coord2 < 0 || coord2 > 9 || coord1 + 1 > 8)
                                {
                                    Console.WriteLine("Координаты выходлят за границы карты!");
                                    i--;
                                }
                                else
                                {
                                    if (map[coord1, coord2] == "O" || map[coord1 + 1, coord2] == "O" ||
                                        map[coord1 - 1, coord2 - 1] == "O" || map[coord1 + 1, coord2 - 1] == "O" || map[coord1 - 1, coord2 + 1] == "O" || map[coord1 + 1, coord2 + 1] == "O")
                                    {
                                        Console.WriteLine("Эта ячейка уже занята");
                                        i--;
                                    }
                                    else
                                    {
                                        map[coord1, coord2] = "O";
                                        map[coord1 + 1, coord2] = "O";
                                        double_deck++;
                                    }
                                }
                                break;
                            default:
                                Console.WriteLine("Такого направления нет");
                                i--;
                                break;
                        }
                    }
                }
                else if (sheep == "Три")
                {
                    if (triple_deck == 2)
                    {
                        Console.WriteLine("Вы уже разместили все трёхпалубные карабли!");
                        i--;
                    }
                    else
                    {
                        Console.Write("Выберите направление корабля: ");
                        direction = Console.ReadLine();
                        switch (direction)
                        {
                            case "влево":
                                if (coord1 < 0 || coord1 > 9 || coord2 < 0 || coord2 > 9 || coord2 - 1 < 0 || coord2 - 2 < 0)
                                {
                                    Console.WriteLine("Координаты выходлят за границы карты!");
                                    i--;
                                }
                                else
                                {
                                    if (map[coord1, coord2] == "O" || map[coord1, coord2 - 1] == "O" || map[coord1, coord2 - 2] == "O" ||
                                        map[coord1 - 1, coord2 - 1] == "O" || map[coord1 + 1, coord2 - 1] == "O" || map[coord1 - 1, coord2 + 1] == "O" || map[coord1 + 1, coord2 + 1] == "O")
                                    {
                                        Console.WriteLine("Эта ячейка уже занята");
                                        i--;
                                    }
                                    else
                                    {
                                        map[coord1, coord2] = "O";
                                        map[coord1, coord2 - 1] = "O";
                                        map[coord1, coord2 - 2] = "O";
                                        triple_deck++;
                                    }
                                }
                                break;
                            case "вправо":
                                if (coord1 < 0 || coord1 > 9 || coord2 < 0 || coord2 > 9 || coord2 + 1 > 8 || coord2 + 2 > 8)
                                {
                                    Console.WriteLine("Координаты выходлят за границы карты!");
                                    i--;
                                }
                                else
                                {
                                    if (map[coord1, coord2] == "O" || map[coord1, coord2 + 1] == "O" || map[coord1, coord2 + 2] == "O" ||
                                        map[coord1 - 1, coord2 - 1] == "O" || map[coord1 + 1, coord2 - 1] == "O" || map[coord1 - 1, coord2 + 1] == "O" || map[coord1 + 1, coord2 + 1] == "O")
                                    {
                                        Console.WriteLine("Эта ячейка уже занята");
                                        i--;
                                    }
                                    else
                                    {
                                        map[coord1, coord2] = "O";
                                        map[coord1, coord2 + 1] = "O";
                                        map[coord1, coord2 + 2] = "O";
                                        triple_deck++;
                                    }
                                }
                                break;
                            case "вверх":
                                if (coord1 < 0 || coord1 > 9 || coord2 < 0 || coord2 > 9 || coord1 - 1 < 0 || coord1 - 2 < 0)
                                {
                                    Console.WriteLine("Координаты выходлят за границы карты!");
                                    i--;
                                }
                                else
                                {
                                    if (map[coord1, coord2] == "O" || map[coord1 - 1, coord2] == "O" || map[coord1 - 2, coord2] == "O" ||
                                        map[coord1 - 1, coord2 - 1] == "O" || map[coord1 + 1, coord2 - 1] == "O" || map[coord1 - 1, coord2 + 1] == "O" || map[coord1 + 1, coord2 + 1] == "O")
                                    {
                                        Console.WriteLine("Эта ячейка уже занята");
                                        i--;
                                    }
                                    else
                                    {
                                        map[coord1, coord2] = "O";
                                        map[coord1 - 1, coord2] = "O";
                                        map[coord1 - 2, coord2] = "O";
                                        triple_deck++;
                                    }
                                }
                                break;
                            case "вниз":
                                if (coord1 < 0 || coord1 > 9 || coord2 < 0 || coord2 > 9 || coord1 + 1 > 8 || coord1 + 2 > 8)
                                {
                                    Console.WriteLine("Координаты выходлят за границы карты!");
                                    i--;
                                }
                                else
                                {
                                    if (map[coord1, coord2] == "O" || map[coord1 + 1, coord2] == "O" || map[coord1 + 2, coord2] == "O" ||
                                        map[coord1 - 1, coord2 - 1] == "O" || map[coord1 + 1, coord2 - 1] == "O" || map[coord1 - 1, coord2 + 1] == "O" || map[coord1 + 1, coord2 + 1] == "O")
                                    {
                                        Console.WriteLine("Эта ячейка уже занята");
                                        i--;
                                    }
                                    else
                                    {
                                        map[coord1, coord2] = "O";
                                        map[coord1 + 1, coord2] = "O";
                                        map[coord1 + 2, coord2] = "O";
                                        triple_deck++;
                                    }
                                }
                                break;
                            default:
                                Console.WriteLine("Такого направления нет");
                                i--;
                                break;
                        }
                    }
                }
                else if (sheep == "Четыре")
                {
                    if (four_deck == 1)
                    {
                        Console.WriteLine("Вы уже разместили все четырёхпалубные карабли!");
                        i--;
                    }
                    else
                    {
                        Console.Write("Выберите направление корабля: ");
                        direction = Console.ReadLine();
                        switch (direction)
                        {
                            case "влево":
                                if (coord1 < 0 || coord1 > 9 || coord2 < 0 || coord2 > 9 || coord2 - 1 < 0 || coord2 - 2 < 0 || coord2 - 3 < 0)
                                {
                                    Console.WriteLine("Координаты выходлят за границы карты!");
                                    i--;
                                }
                                else
                                {
                                    if (map[coord1, coord2] == "O" || map[coord1, coord2 - 1] == "O" || map[coord1, coord2 - 2] == "O" || map[coord1, coord2 - 3] == "O" ||
                                        map[coord1 - 1, coord2 - 1] == "O" || map[coord1 + 1, coord2 - 1] == "O" || map[coord1 - 1, coord2 + 1] == "O" || map[coord1 + 1, coord2 + 1] == "O")
                                    {
                                        Console.WriteLine("Эта ячейка уже занята");
                                        i--;
                                    }
                                    else
                                    {
                                        map[coord1, coord2] = "O";
                                        map[coord1, coord2 - 1] = "O";
                                        map[coord1, coord2 - 2] = "O";
                                        map[coord1, coord2 - 3] = "O";
                                        four_deck++;
                                    }

                                }
                                break;
                            case "вправо":
                                if (coord1 < 0 || coord1 > 9 || coord2 < 0 || coord2 > 9 || coord2 + 1 > 8 || coord2 + 2 > 8 || coord2 + 3 > 8)
                                {
                                    Console.WriteLine("Координаты выходлят за границы карты!");
                                    i--;
                                }
                                else
                                {
                                    if (map[coord1, coord2] == "O" || map[coord1, coord2 + 1] == "O" || map[coord1, coord2 + 2] == "O" || map[coord1, coord2 + 3] == "O" ||
                                        map[coord1 - 1, coord2 - 1] == "O" || map[coord1 + 1, coord2 - 1] == "O" || map[coord1 - 1, coord2 + 1] == "O" || map[coord1 + 1, coord2 + 1] == "O")
                                    {
                                        Console.WriteLine("Эта ячейка уже занята");
                                        i--;
                                    }
                                    else
                                    {
                                        map[coord1, coord2] = "O";
                                        map[coord1, coord2 + 1] = "O";
                                        map[coord1, coord2 + 2] = "O";
                                        map[coord1, coord2 + 3] = "O";
                                        four_deck++;
                                    }
                                }
                                break;
                            case "вверх":
                                if (coord1 < 0 || coord1 > 9 || coord2 < 0 || coord2 > 9 || coord1 - 1 < 0 || coord1 - 2 < 0 || coord1 - 3 < 0)
                                {
                                    Console.WriteLine("Координаты выходлят за границы карты!");
                                    i--;
                                }
                                else
                                {
                                    if (map[coord1, coord2] == "O" || map[coord1 - 1, coord2] == "O" || map[coord1 - 2, coord2] == "O" || map[coord1 - 3, coord2] == "O" ||
                                        map[coord1 - 1, coord2 - 1] == "O" || map[coord1 + 1, coord2 - 1] == "O" || map[coord1 - 1, coord2 + 1] == "O" || map[coord1 + 1, coord2 + 1] == "O")
                                    {
                                        Console.WriteLine("Эта ячейка уже занята");
                                        i--;
                                    }
                                    else
                                    {
                                        map[coord1, coord2] = "O";
                                        map[coord1 - 1, coord2] = "O";
                                        map[coord1 - 2, coord2] = "O";
                                        map[coord1 - 3, coord2] = "O";
                                        four_deck++;
                                    }
                                }
                                break;
                            case "вниз":
                                if (coord1 < 0 || coord1 > 9 || coord2 < 0 || coord2 > 9 || coord1 + 1 > 8 || coord1 + 2 > 8 || coord1 + 3 > 8)
                                {
                                    Console.WriteLine("Координаты выходлят за границы карты!");
                                    i--;
                                }
                                else
                                {
                                    if (map[coord1, coord2] == "O" || map[coord1 + 1, coord2] == "O" || map[coord1 + 2, coord2] == "O" || map[coord1 + 3, coord2] == "O" ||
                                        (map[coord1 - 1, coord2 - 1] == "O" && map[coord1 + 1, coord2 - 1] == "O" && map[coord1 - 1, coord2 + 1] == "O" && map[coord1 + 1, coord2 + 1] == "O"))
                                    {
                                        Console.WriteLine("Эта ячейка уже занята");
                                        i--;
                                    }
                                    else
                                    {
                                        map[coord1, coord2] = "O";
                                        map[coord1 + 1, coord2] = "O";
                                        map[coord1 + 2, coord2] = "O";
                                        map[coord1 + 3, coord2] = "O";
                                        four_deck++;
                                    }
                                }
                                break;
                            default:
                                Console.WriteLine("Такого направления нет");
                                i--;
                                break;
                        }
                    }
                }
                else if (sheep == "проверка")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Такого карабля нету!");
                    i--;
                }
                DrawMap();
            }
            FightProcess();
            Console.ReadKey();
        }
        public static void DrawMap()
        {
            Console.WriteLine("  а б в г д е ж з и к");
            for (int i = 0; i < map.GetLength(0); i++)
            {
                Console.Write(i + 1 + " ");
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write($"{map[i, j]} ");
                }
                Console.WriteLine();
            }
        }
        public static int SetCoord1()
        {
            coord1 = Convert.ToInt32(Console.ReadLine());
            if (coord1 == 1) coord1 = 0;
            if (coord1 == 2) coord1 = 1;
            if (coord1 == 3) coord1 = 2;
            if (coord1 == 4) coord1 = 3;
            if (coord1 == 5) coord1 = 4;
            if (coord1 == 6) coord1 = 5;
            if (coord1 == 7) coord1 = 6;
            if (coord1 == 8) coord1 = 7;
            if (coord1 == 9) coord1 = 8;
            if (coord1 == 10) coord1 = 9;
            return coord1;
        }
        public static int SetCoord2()
        {
            char letter;
            letter = Convert.ToChar(Console.ReadLine());
            if (letter == 'а') coord2 = 0;
            if (letter == 'б') coord2 = 1;
            if (letter == 'в') coord2 = 2;
            if (letter == 'г') coord2 = 3;
            if (letter == 'д') coord2 = 4;
            if (letter == 'е') coord2 = 5;
            if (letter == 'ж') coord2 = 6;
            if (letter == 'з') coord2 = 7;
            if (letter == 'и') coord2 = 8;
            if (letter == 'к') coord2 = 9;
            return coord2;
        }
        public static void DrawEnemyMap()
        {
            Console.WriteLine("  а б в г д е ж з и к");
            for (int i = 0; i < enemyMap.GetLength(0); i++)
            {
                Console.Write(i + 1 + " ");
                for (int j = 0; j < enemyMap.GetLength(1); j++)
                {
                    Console.Write($"{enemyMap[i, j]} ");
                }
                Console.WriteLine();
            }
        }
        public static void EnemySheep()
        {
            for (int i = 0; i < enemyMap.GetLength(0); i++)
            {
                for (int j = 0; j < enemyMap.GetLength(1); j++)
                {
                    enemyMap[i, j] = ".";
                }
            }

            string[] direction = { "влево", "вправо", "вверх", "вниз" };
            string[] rnd_Sheep = { "Один", "Два", "Три", "Четыре" };
            int single_deck = 0;
            int double_deck = 0;
            int triple_deck = 0;
            int four_deck = 0;
            for (int i = 1; i <= 10; i++)
            {
                coord3 = rnd.Next(1, 9);
                coord4 = rnd.Next(1, 9);
                int sheep_Choice = rnd.Next(0, 4);
                string sheep = rnd_Sheep[sheep_Choice];
                if (sheep == "Один")
                {
                    if (single_deck == 4)
                    {
                        i--;
                    }
                    else
                    {
                        if (coord3 < 0 || coord3 > 9 || coord4 < 0 || coord4 > 9)
                        {
                            i--;
                        }
                        else if (PositionCheck(coord3, coord4, enemyMap))
                        {
                            i--;
                        }
                        else if (enemyMap[coord3, coord4] == "O")
                        {
                            i--;
                        }
                        else
                        {
                            enemyMap[coord3, coord4] = "O";
                            single_deck++;
                        }
                    }
                }
                else if (sheep == "Два")
                {
                    if (double_deck == 3)
                    {
                        i--;
                    }
                    else
                    {
                        int direct_Choice = rnd.Next(0, 4);
                        string choosen_Direct = direction[direct_Choice];
                        bool canPlace = true;
                        switch (choosen_Direct)
                        {
                            case "влево":
                                if (coord4 - 1 < 0)
                                {
                                    canPlace = false;
                                    break;
                                }
                                for (int k = coord4; k >= coord4 - 1; k--)
                                {
                                    if (PositionCheck(coord3, k, enemyMap) || enemyMap[coord3, k] == "O")
                                    {
                                        canPlace = false;
                                        break;
                                    }
                                }
                                break;
                            case "вправо":
                                if (coord4 + 1 > 9)
                                {
                                    canPlace = false;
                                    break;
                                }
                                for (int k = coord4; k <= coord4 + 1; k++)
                                {
                                    if (PositionCheck(coord3, k, enemyMap) || enemyMap[coord3, k] == "O")
                                    {
                                        canPlace = false;
                                        break;
                                    }
                                }
                                break;
                            case "вверх":
                                if (coord3 - 1 < 0)
                                {
                                    canPlace = false;
                                    break;
                                }
                                for (int k = coord3; k <= coord3 - 1; k--)
                                {
                                    if (PositionCheck(k, coord4, enemyMap) || enemyMap[k, coord4] == "O")
                                    {
                                        canPlace = false;
                                        break;
                                    }
                                }
                                break;
                            case "вниз":
                                if (coord3 + 1 > 9)
                                {
                                    canPlace = false;
                                    break;
                                }
                                for (int k = coord3; k <= coord3 + 1; k++)
                                {
                                    if (PositionCheck(k, coord4, enemyMap) || enemyMap[k, coord4] == "O")
                                    {
                                        canPlace = false;
                                        break;
                                    }
                                }
                                break;
                            default:
                                Console.WriteLine("Такого направления нет");
                                i--;
                                break;
                        }
                        if (canPlace)
                        {
                            switch (choosen_Direct)
                            {
                                case "влево":
                                    enemyMap[coord3, coord4] = "O";
                                    enemyMap[coord3, coord4 - 1] = "O";
                                    break;
                                case "вправо":
                                    enemyMap[coord3, coord4] = "O";
                                    enemyMap[coord3, coord4 + 1] = "O";
                                    break;
                                case "вверх":
                                    enemyMap[coord3, coord4] = "O";
                                    enemyMap[coord3 - 1, coord4] = "O";
                                    break;
                                case "вниз":
                                    enemyMap[coord3, coord4] = "O";
                                    enemyMap[coord3 + 1, coord4] = "O";
                                    break;
                            }
                            double_deck++;
                        }
                        else i--;
                    }
                }
                else if (sheep == "Три")
                {
                    if (triple_deck == 2)
                    {
                        i--;
                    }
                    else
                    {
                        int direct_Choice = rnd.Next(0, 4);
                        string choosen_Direct = direction[direct_Choice];
                        bool canPlace = true;
                        switch (choosen_Direct)
                        {
                            case "влево":
                                if (coord4 - 1 < 0)
                                {
                                    canPlace = false;
                                    break;
                                }
                                for (int k = coord4; k >= coord4 - 1; k--)
                                {
                                    if (PositionCheck(coord3, k, enemyMap) || enemyMap[coord3, k] == "O")
                                    {
                                        canPlace = false;
                                        break;
                                    }
                                }
                                break;
                            case "вправо":
                                if (coord4 + 1 > 9)
                                {
                                    canPlace = false;
                                    break;
                                }
                                for (int k = coord4; k <= coord4 + 1; k++)
                                {
                                    if (PositionCheck(coord3, k, enemyMap) || enemyMap[coord3, k] == "O")
                                    {
                                        canPlace = false;
                                        break;
                                    }
                                }
                                break;
                            case "вверх":
                                if (coord3 - 1 < 0)
                                {
                                    canPlace = false;
                                    break;
                                }
                                for (int k = coord3; k <= coord3 - 1; k--)
                                {
                                    if (PositionCheck(k, coord4, enemyMap) || enemyMap[k, coord4] == "O")
                                    {
                                        canPlace = false;
                                        break;
                                    }
                                }
                                break;
                            case "вниз":
                                if (coord3 + 1 > 9)
                                {
                                    canPlace = false;
                                    break;
                                }
                                for (int k = coord3; k <= coord3 + 1; k++)
                                {
                                    if (PositionCheck(k, coord4, enemyMap) || enemyMap[k, coord4] == "O")
                                    {
                                        canPlace = false;
                                        break;
                                    }
                                }
                                break;
                            default:
                                Console.WriteLine("Такого направления нет");
                                i--;
                                break;
                        }
                        if (canPlace)
                        {
                            switch (choosen_Direct)
                            {
                                case "влево":
                                    enemyMap[coord3, coord4] = "O";
                                    enemyMap[coord3, coord4 - 1] = "O";
                                    enemyMap[coord3, coord4 - 2] = "O";
                                    break;
                                case "вправо":
                                    enemyMap[coord3, coord4] = "O";
                                    enemyMap[coord3, coord4 + 1] = "O";
                                    enemyMap[coord3, coord4 + 2] = "O";
                                    break;
                                case "вверх":
                                    enemyMap[coord3, coord4] = "O";
                                    enemyMap[coord3 - 1, coord4] = "O";
                                    enemyMap[coord3 - 2, coord4] = "O";
                                    break;
                                case "вниз":
                                    enemyMap[coord3, coord4] = "O";
                                    enemyMap[coord3 + 1, coord4] = "O";
                                    enemyMap[coord3 + 2, coord4] = "O";
                                    break;
                            }
                            triple_deck++;
                        }
                        else i--;
                    }
                }
                else if (sheep == "Четыре")
                {
                    if (four_deck == 1)
                    {
                        i--;
                    }
                    else
                    {
                        int direct_Choice = rnd.Next(0, 4);
                        string choosen_Direct = direction[direct_Choice];
                        bool canPlace = true;
                        switch (choosen_Direct)
                        {
                            case "влево":
                                if (coord4 - 1 < 0)
                                {
                                    canPlace = false;
                                    break;
                                }
                                for (int k = coord4; k >= coord4 - 1; k--)
                                {
                                    if (PositionCheck(coord3, k, enemyMap) || enemyMap[coord3, k] == "O")
                                    {
                                        canPlace = false;
                                        break;
                                    }
                                }
                                break;
                            case "вправо":
                                if (coord4 + 1 > 9)
                                {
                                    canPlace = false;
                                    break;
                                }
                                for (int k = coord4; k <= coord4 + 1; k++)
                                {
                                    if (PositionCheck(coord3, k, enemyMap) || enemyMap[coord3, k] == "O")
                                    {
                                        canPlace = false;
                                        break;
                                    }
                                }
                                break;
                            case "вверх":
                                if (coord3 - 1 < 0)
                                {
                                    canPlace = false;
                                    break;
                                }
                                for (int k = coord3; k <= coord3 - 1; k--)
                                {
                                    if (PositionCheck(k, coord4, enemyMap) || enemyMap[k, coord4] == "O")
                                    {
                                        canPlace = false;
                                        break;
                                    }
                                }
                                break;
                            case "вниз":
                                if (coord3 + 1 > 9)
                                {
                                    canPlace = false;
                                    break;
                                }
                                for (int k = coord3; k <= coord3 + 1; k++)
                                {
                                    if (PositionCheck(k, coord4, enemyMap) || enemyMap[k, coord4] == "O")
                                    {
                                        canPlace = false;
                                        break;
                                    }
                                }
                                break;
                            default:
                                Console.WriteLine("Такого направления нет");
                                i--;
                                break;
                        }
                        if (canPlace)
                        {
                            switch (choosen_Direct)
                            {
                                case "влево":
                                    enemyMap[coord3, coord4] = "O";
                                    enemyMap[coord3, coord4 - 1] = "O";
                                    enemyMap[coord3, coord4 - 2] = "O";
                                    enemyMap[coord3, coord4 - 3] = "O";
                                    break;
                                case "вправо":
                                    enemyMap[coord3, coord4] = "O";
                                    enemyMap[coord3, coord4 + 1] = "O";
                                    enemyMap[coord3, coord4 + 2] = "O";
                                    enemyMap[coord3, coord4 + 3] = "O";
                                    //
                                    break;
                                case "вверх":
                                    enemyMap[coord3, coord4] = "O";
                                    enemyMap[coord3 - 1, coord4] = "O";
                                    enemyMap[coord3 - 2, coord4] = "O";
                                    enemyMap[coord3 - 3, coord4] = "O";
                                    break;
                                case "вниз":
                                    enemyMap[coord3, coord4] = "O";
                                    enemyMap[coord3 + 1, coord4] = "O";
                                    enemyMap[coord3 + 2, coord4] = "O";
                                    enemyMap[coord3 + 3, coord4] = "O";
                                    break;
                            }
                            four_deck++;
                        }
                        else i--;
                    }
                }
            }
        }
        public static bool PositionCheck(int x, int y, string[,] map)
        {
            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (i >= 0 && i < map.GetLength(0) && j >= 0 && j < map.GetLength(1))
                    {
                        if (map[i, j] == "O")
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public static void FightProcess()
        {
            while (true)
            {
                int count = 0;
                for (int i = 0; i < enemyMap.GetLength(0); i++)
                {
                    for (int j = 0; j < enemyMap.GetLength(1); j++)
                    {
                        if (enemyMap[i, j] == "O") count++;
                    }
                }
                if (count == 0)
                {
                    Console.WriteLine("Вы выиграли!");
                    break;
                }
                Console.WriteLine("Введите координаты, по которым произойдёт удар:");
                coord1 = SetCoord1();
                coord2 = SetCoord2();
                if (enemyMap[coord1, coord2] == "O")
                {
                    enemyMap[coord1, coord2] = "X";
                    Console.WriteLine("Попал!");
                }
                else Console.WriteLine("Мимо!");

                count = 0;
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        if (map[i, j] == "O") count++;
                    }
                }
                if (count == 0)
                {
                    Console.WriteLine("Вы проиграли!");
                    break;
                }
                coord3 = rnd.Next(0, 10);
                coord4 = rnd.Next(0, 10);
                int enemyCoord = 0;
                if (coord3 == 0) enemyCoord = 1;
                if (coord3 == 1) enemyCoord = 2;
                if (coord3 == 2) enemyCoord = 3;
                if (coord3 == 3) enemyCoord = 4;
                if (coord3 == 4) enemyCoord = 5;
                if (coord3 == 5) enemyCoord = 6;
                if (coord3 == 6) enemyCoord = 7;
                if (coord3 == 7) enemyCoord = 8;
                if (coord3 == 8) enemyCoord = 9;
                if (coord3 == 9) enemyCoord = 10;
                char letter = 'a';
                if (coord4 == 0) letter = 'а';
                if (coord4 == 1) letter = 'б';
                if (coord4 == 2) letter = 'в';
                if (coord4 == 3) letter = 'г';
                if (coord4 == 4) letter = 'д';
                if (coord4 == 5) letter = 'е';
                if (coord4 == 6) letter = 'ж';
                if (coord4 == 7) letter = 'з';
                if (coord4 == 8) letter = 'и';
                if (coord4 == 9) letter = 'к';
                Console.WriteLine($"Противник вводит координаты: {enemyCoord} {letter}");
                if (map[coord3, coord4] == "O")
                {
                    map[coord3, coord4] = "X";
                }
                DrawMap();
            }
        }
    }
}
