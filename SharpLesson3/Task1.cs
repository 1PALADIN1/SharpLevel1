using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
1.а) Дописать структуру Complex, добавив метод вычитания комплексных чисел. Продемонстрировать работу структуры.
б) Дописать класс Complex, добавив методы вычитания и произведения чисел. Проверить работу класса.
в) Добавить диалог с использованием switch демонстрирующий работу класса. 
*/
namespace SharpLesson3 {
    partial class Program {
        //структура
        struct Complex {
            public double im;
            public double re;

            // в C# в структурах могут храниться также действия над данными
            public Complex Plus(Complex x) {
                Complex y;
                y.im = im + x.im;
                y.re = re + x.re;
                return y;
            }

            // Пример произведения двух комплексных чисел
            public Complex Multi(Complex x) {
                Complex y;
                y.im = re * x.im + im * x.re;
                y.re = re * x.re - im * x.im;
                return y;
            }

            public Complex Div(Complex x) {
                Complex y;
                y.im = im - x.im;
                y.re = re - x.re;
                return y;
            }

            override public string ToString() {
                if (im > 0) return re + "+" + im + "i";
                else {
                    if (im < 0) return re.ToString() + im + "i";
                    return re.ToString();
                }
            }
        }

        //класс
        class ComplexClass {
            public double im;
            public double re;

            public ComplexClass() {
                this.re = 0;
                this.im = 0;
            }

            public ComplexClass(double re, double im) {
                this.re = re;
                this.im = im;
            }

            public ComplexClass Plus(ComplexClass x) {
                ComplexClass y = new ComplexClass();
                y.im = x.im + im;
                y.re = x.re + re;
                return y;
            }

            public ComplexClass Div(ComplexClass x) {
                ComplexClass y = new ComplexClass();
                y.re = re - x.re;
                y.im = im - x.im;
                return y;
            }

            public ComplexClass Multi(ComplexClass x) {
                ComplexClass y = new ComplexClass();
                y.im = re * x.im + im * x.re;
                y.re = re * x.re - im * x.im;
                return y;
            }

            override public string ToString() {
                if (im > 0) return re + "+" + im + "i";
                else {
                    if (im < 0) return re.ToString() + im + "i";
                    return re.ToString();
                }
            }
        }

        static void Task1() {
            Console.WriteLine("Демонстрация структуры");

            Complex a, b;
            a.re = 10.89;
            a.im = 2.2;

            b.re = 12.012;
            b.im = -5.67;

            Console.Write("Сложение ({0}) + ({1}): {2}\n", a, b, a.Plus(b));
            Console.Write("Вычитание ({0}) - ({1}): {2}\n", a, b, a.Div(b));
            Console.Write("Умножение ({0}) * ({1}): {2}\n", a, b, a.Multi(b));

            //работа через класс
            Console.WriteLine("Демонстрация работы класса");
            bool work = true;
            ComplexClass x, y;
            x = new ComplexClass(23.05, -1.25);
            y = new ComplexClass(-12.81, 4.67);

            Console.WriteLine("Операция:\n0. Выход\n1. Сложение\n2. Вычитание\n3. Умножение");
            do {
                Console.Write("Введите операцию: ");
                var key = Console.ReadKey();
                Console.WriteLine();

                switch (key.Key) {
                    case ConsoleKey.D0:
                    case ConsoleKey.NumPad0:
                        work = false;
                        break;
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Console.Write("Сложение ({0}) + ({1}): {2}\n", x, y, x.Plus(y));
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Console.Write("Вычитание ({0}) - ({1}): {2}\n", x, y, x.Div(y));
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        Console.Write("Умножение ({0}) * ({1}): {2}\n", x, y, x.Multi(y));
                        break;
                    default:
                        Console.WriteLine("Команда не распознана!");
                        break;
                }

            } while (work);
        }
    }
}
