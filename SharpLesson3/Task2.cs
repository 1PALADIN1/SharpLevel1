using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
2.а) С клавиатуры вводятся числа, пока не будет введён 0 (каждое число в новой строке). Требуется подсчитать сумму всех нечётных положительных чисел.
Сами числа и сумму вывести на экран, используя tryParse.
*/
namespace SharpLesson3 {
    partial class Program {
        static void Task2() {
            Console.WriteLine("Вводите числа:");
            int sum = 0;

            do {
                string input = Console.ReadLine();
                bool isCorrect = int.TryParse(input, out int result);

                if (isCorrect) {
                    if (result == 0) break;
                    if (result > 0 && result % 2 == 0) {
                        sum += result;
                    }
                } else {
                    Console.WriteLine("Введено некорректное число!");
                }

            } while (true);

            Console.WriteLine("Сумма чисел: {0}", sum);
        }
    }
}
