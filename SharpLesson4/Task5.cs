using System;
using SharpLesson4Lib;

/*
5. а) Реализовать библиотеку с классом для работы с двумерным массивом.
Реализовать конструктор, заполняющий массив случайными числами. Создать методы, которые возвращают сумму
всех элементов массива, сумму всех элементов массива больше заданного, свойство, возвращающее минимальный
элемент массива, свойство, возвращающее максимальный элемент массива, метод, возвращающий номер максимального
элемента массива (через параметры, используя модификатор ref или out).
*б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
**в) Обработать возможные исключительные ситуации при работе с файлами. 
*/
namespace SharpLesson4 {
    partial class Program {
        static void Task5() {
            ArrayLib array = new ArrayLib(4, 5);
            Console.WriteLine("Сгенерированый массив:");
            array.PrintToConsole();
            Console.WriteLine("Сумма элементов массива: {0}", array.Sum());

            int overNum = 1250;
            Console.WriteLine("Сумма элементов массива, которые больше {0}: {1}", overNum, array.SumOverNumber(overNum));
            Console.WriteLine("Минимальный элемент массива: {0}", array.MinNum);
            Console.WriteLine("Максимальный элемент массива: {0}", array.MaxNum);

            int maxRow, maxCol;
            array.GetIndexOfMaxElement(out maxRow, out maxCol);
            Console.WriteLine("Индекс максимального элемента массива: ({0}, {1})", maxRow + 1, maxCol + 1);
        }
    }
}
