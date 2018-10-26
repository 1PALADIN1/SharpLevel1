using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
2. Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата.
а) Сделать меню с различными функциями и представить пользователю выбор, для какой функции и на каком отрезке находить минимум.
Использовать массив (или список) делегатов, в котором хранятся различные функции.
б) *Переделать функцию Load, чтобы она возвращала коллекцию List<double> считанных значений.
Пусть она возвращает минимум через параметр (с использованием модификатора out).
*/
namespace SharpLesson6 {
    partial class Program {
        public delegate double SaveFunction(double x);

        //обработка функций
        public static void SaveFunc(string fileName, double a, double b, double h, SaveFunction function) {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x <= b) {
                bw.Write(function(x));
                x += h; // x=x+h;
            }
            bw.Close();
            fs.Close();
        }
        public static List<double> Load(string fileName, out double minVal) {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            List<double> result = new List<double>();
            double min = double.MaxValue;
            double d;
            for (int i = 0; i < fs.Length / sizeof(double); i++) {
                // Считываем значение и переходим к следующему
                d = bw.ReadDouble();
                if (d < min) min = d;
                //добавляем значение в результирующий список
                result.Add(d);
            }
            bw.Close();
            fs.Close();

            minVal = min;
            return result;
        }

        static void Task2() {
            bool checkFunc = true;
            List<SaveFunction> funList = new List<SaveFunction> {
                //функции
                x => x * x - 50 * x + 10,
                x => 25 * x * x * x + 12 * x,
                x => Math.Abs(Math.Sin(x)) - Math.Tan(x),
                x => Math.Cos(x) * Math.Cos(x) + Math.Sin(x)
            };

            SaveFunction curFunction = null;

            do {
                Console.WriteLine("\nФункции:");
                Console.WriteLine("0. Выход");
                Console.WriteLine("1. x^2 - 50x + 10");
                Console.WriteLine("2. 25x^3 + 12x");
                Console.WriteLine("3. |sin(x)| - tan(x)");
                Console.WriteLine("4. cos(x)^2 + sin(x)");

                Console.Write("\nВыберете функцию: ");
                var key = Console.ReadKey();
                Console.WriteLine();

                switch (key.Key) {
                    case ConsoleKey.D0:
                    case ConsoleKey.NumPad0:
                        checkFunc = false;
                        break;
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        curFunction = funList.ElementAt(0);
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        curFunction = funList.ElementAt(1);
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        curFunction = funList.ElementAt(2);
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        curFunction = funList.ElementAt(3);
                        break;
                    default:
                        Console.WriteLine("Команда не распознана!");
                        break;
                }

                //если функция выбрана
                if (curFunction != null) {
                    bool checkRange = true;
                    double high = 0;
                    double low = 0;
                    double step = 0;

                    do {
                        if (low == 0) {
                            Console.WriteLine("Введите нижнюю границу:");
                            if (!Double.TryParse(Console.ReadLine(), out low)) {
                                Console.WriteLine("Значение некорректно, повторите ввод");
                                continue;
                            }
                        }
                        if (high == 0) {
                            Console.WriteLine("Введите вверхнюю границу:");
                            if (!Double.TryParse(Console.ReadLine(), out high)) {
                                Console.WriteLine("Значение некорректно, повторите ввод");
                                continue;
                            }
                        }
                        if (step == 0) {
                            Console.WriteLine("Введите шаг:");
                            if (!Double.TryParse(Console.ReadLine(), out step)) {
                                Console.WriteLine("Значение некорректно, повторите ввод");
                                continue;
                            }
                        }

                        if (low != 0 && high != 0 && step != 0) {
                            checkRange = false;
                            double min = 0;

                            //выгружаем функцию
                            SaveFunc("data.bin", low, high, step, curFunction);
                            List<double> result = Load("data.bin", out min);
                            Console.WriteLine("Минимальное значение функции: {0}", min);
                            Console.WriteLine("Список значений: ");
                            foreach (var item in result) {
                                Console.Write("{0}\t", item);
                            }
                            Console.WriteLine();
                            curFunction = null;
                        }
                    } while (checkRange);

                }
            } while (checkFunc);
        }
    }
}
