/* Малиновский Руслан */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpLesson6 {
    partial class Program {
        static void Main(string[] args) {
            Menu();
            FinishProgram();
        }

        static void Menu() {
            Console.WriteLine("Задания:\n0. Выход\n1. Проверка корректности ввода логина\n2. Статический класс Message" +
                "\n3. Перестановка строк в методе\n4. Задача ЕГЭ");
            bool work = true;

            do {
                Console.Write("\nВведите номер задания: ");
                var key = Console.ReadKey();
                Console.WriteLine();

                switch (key.Key) {
                    case ConsoleKey.D0:
                    case ConsoleKey.NumPad0:
                        work = false;
                        break;
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Task1();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        //Task2();
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        //Task3();
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        //Task4();
                        break;
                    default:
                        Console.WriteLine("Команда не распознана!");
                        break;
                }
            } while (work);
        }

        static void FinishProgram() {
            Console.WriteLine("Программа завершила свою работу, нажмите любую клавишу для выхода");
            Console.ReadKey();
        }
    }
}
