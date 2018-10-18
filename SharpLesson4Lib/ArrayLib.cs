using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//без заданий под звёздочками

/*
5. а) Реализовать библиотеку с классом для работы с двумерным массивом.
Реализовать конструктор, заполняющий массив случайными числами. Создать методы, которые возвращают сумму
всех элементов массива, сумму всех элементов массива больше заданного, свойство, возвращающее минимальный
элемент массива, свойство, возвращающее максимальный элемент массива, метод, возвращающий номер максимального
элемента массива (через параметры, используя модификатор ref или out).
*б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
**в) Обработать возможные исключительные ситуации при работе с файлами. 
*/

namespace SharpLesson4Lib
{
    public class ArrayLib
    {
        int[,] array;
        const int MIN_RANGE = -10_000;
        const int MAX_RANGE = 10_000;

        //свойство, возвращающее минимальный элемент массива
        public int MinNum {
            get {
                int minNum = array[0, 0];

                for (int i = 0; i < array.GetLength(0); i++) {
                    for (int j = 0; j < array.GetLength(1); j++) {
                        if (array[i, j] < minNum) minNum = array[i, j];
                    }
                }
                return minNum;
            }
        }

        //свойство, возвращающее максимальный элемент массива
        public int MaxNum {
            get {
                int maxNum = array[0, 0];

                for (int i = 0; i < array.GetLength(0); i++) {
                    for (int j = 0; j < array.GetLength(1); j++) {
                        if (array[i, j] > maxNum) maxNum = array[i, j];
                    }
                }
                return maxNum;
            }
        }

        public ArrayLib(int rows, int cols) {
            array = new int[rows, cols];
            Random rand = new Random();

            for (int i = 0; i < array.GetLength(0); i++) {
                for (int j = 0; j < array.GetLength(1); j++) {
                    array[i, j] = rand.Next(MIN_RANGE, MAX_RANGE + 1);
                }
            }
        }

        //сумма всех элементов массива
        public int Sum() {
            int sum = 0;
            for (int i = 0; i < array.GetLength(0); i++) {
                for (int j = 0; j < array.GetLength(1); j++) {
                    sum += array[i, j];
                }
            }
            return sum;
        }

        //сумма всех элементов массива больше заданного
        public int SumOverNumber(int overNum) {
            int sum = 0;
            for (int i = 0; i < array.GetLength(0); i++) {
                for (int j = 0; j < array.GetLength(1); j++) {
                    if (array[i, j] > overNum) sum += array[i, j];
                }
            }
            return sum;
        }

        //метод, возвращающий номер максимального элемента массива
        public void GetIndexOfMaxElement(out int row, out int col) {
            int maxNum = array[0, 0];
            int maxI = 0;
            int maxJ = 0;

            for (int i = 0; i < array.GetLength(0); i++) {
                for (int j = 0; j < array.GetLength(1); j++) {
                    if (array[i, j] > maxNum) {
                        maxNum = array[i, j];
                        maxI = i;
                        maxJ = j;
                    }
                }
            }

            row = maxI;
            col = maxJ;
        }

        public void PrintToConsole() {
            for (int i = 0; i < array.GetLength(0); i++) {
                for (int j = 0; j < array.GetLength(1); j++) {
                    Console.Write("{0}\t", array[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
