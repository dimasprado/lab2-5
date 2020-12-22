using Library;
using System;
using System.Collections.Generic;

namespace lab2_5
{
    class Program
    {
        static void Main(string[] args)
        {
            var complexNumbers = new List<Complex>();
            PrintHelp();
            while (ReadCommands(complexNumbers)) ;
        }
        /// <summary>
        /// Чтение и выполнение комманд
        /// </summary>
        /// <param name="complexNumbers">Список для хранения комплексных чисел</param>
        /// <returns>false если ввод завершен</returns>
        static bool ReadCommands(List<Complex> complexNumbers)
        {
            string buf;
            string[] command;
            try
            {
                buf = Console.ReadLine();
                command = buf.Split(' ');
                switch (command[0].ToLower())
                {
                    case "stop":
                        return false;

                    case "new":
                        AddNewComplex(complexNumbers, command);
                        break;

                    case "plus":
                        complexNumbers.Add(complexNumbers[Convert.ToInt32(command[1])] + complexNumbers[Convert.ToInt32(command[2])]);
                        break;
                    case "minus":
                        complexNumbers.Add(complexNumbers[Convert.ToInt32(command[1])] - complexNumbers[Convert.ToInt32(command[2])]);
                        break;

                    case "mul":
                        complexNumbers.Add(complexNumbers[Convert.ToInt32(command[1])] * complexNumbers[Convert.ToInt32(command[2])]);
                        break;

                    case "exp":
                        Console.WriteLine(complexNumbers[Convert.ToInt32(command[1])].GetExp());
                        break;

                    case "print":
                        PrintStrings(complexNumbers);
                        break;

                    case "help":
                        PrintHelp();
                        break;

                    default:
                        Console.WriteLine("Команда не найдена\n");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Комманда некорректна:{e?.Message}");
            }
            return true;
        }
        /// <summary>
        /// Вывод всех копмлесных чисел
        /// </summary>
        /// <param name="complexNumbers">Список комплексных чисел</param>
        static void PrintStrings(List<Complex> complexNumbers)
        {
            for (int i = 0; i < complexNumbers.Count; i++)
            {
                Console.WriteLine($"Complex №{i}\n{complexNumbers[i]}");
                Console.WriteLine("---------------------------------");
            }
        }
        /// <summary>
        /// Ввод комплесного числа
        /// </summary>
        /// <param name="complexNumbers">Список для зранения комплексных чисел</param>
        /// <param name="command">Команда для добавления коплексного числа</param>
        static void AddNewComplex(List<Complex> complexNumbers, string[] command)
        {
            complexNumbers.Add(new Complex(Convert.ToDecimal(command[1]), Convert.ToDecimal(command[2])));
        }
        /// <summary>
        /// Вывод всех комманд
        /// </summary>
        static void PrintHelp()
        {
            Console.WriteLine("Список комманд:\n" +
                "new Real Im -  добавить Complex\n" +
                "mul Complex1 Complex2 - умножаем Complex1 на Complex2\n" +
                "plus Complex1 Complex2 - складываем Complex1 и Complex2\n" +
                "minus Complex1 Complex2 - вычитаем Complex2 из Complex1\n" +
                "exp Complex - Печаетает Complex в эскпоненциальном виде\n" +
                "help - печатает список всех комманд\n" +
                "stop - заканичвает работу програмыы");
        }
    }
}

