using System;

/*
1. Изменить программу вывода таблицы функции так, чтобы можно было передавать функции
типа double (double, double). Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x).
*/
namespace SharpLesson6 {
    partial class Program {
        public delegate double Fun(double x, double a);

        public static void Table(Fun F, double x, double b, double a) {
            Console.WriteLine("----- X ----- Y -----");
            while (x <= b) {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(x, a));
                x += 1;
            }
            Console.WriteLine("---------------------");
        }
        // Создаем метод для передачи его в качестве параметра в Table
        public static double MyFunc(double x, double a) {
            return x * x * x * a;
        }

        static void Task1() {
            Console.WriteLine("Кубическая функция:");
            Table(MyFunc, -2, 2, 4);

            Console.WriteLine("Квадратичная функция:");
            Table((x, a) => a * x * x, -3, 3, 1.5);

            Console.WriteLine("Синусоида:");
            Table((x, a) => a * Math.Sin(x), -3, 3, 3);
        }
    }
}
