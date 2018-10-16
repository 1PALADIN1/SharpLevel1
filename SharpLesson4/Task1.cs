using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
1. Дан целочисленный массив из 20 элементов. Элементы массива могут принимать целые значения от –10 000 до 10 000 включительно.
Заполнить случайными числами. Написать программу, позволяющую найти и вывести количество пар элементов массива, в которых только одно число делится на 3.
В данной задаче под парой подразумевается два подряд идущих элемента массива. Например, для массива из пяти элементов: 6; 2; 9; –3; 6 ответ — 2.
*/
namespace SharpLesson4 {
    partial class Program {
        static void Task1() {
            int[] arr = new int[20];
            Random rand = new Random();

            Console.Write("Дан массив: [");
            for (int i = 0; i < arr.Length; i++) {
                arr[i] = rand.Next(-10_000, 10_001);
                if (i == arr.Length - 1) Console.WriteLine("{0}]", arr[i]);
                else
                    Console.Write("{0}, ", arr[i]);
            }

            int pairCount = 0;
            for (int i = 0; i < arr.Length - 1; i++) {
                if (arr[i] % 3 == 0 && arr[i + 1] % 3 != 0 || 
                    arr[i] % 3 != 0 && arr[i + 1] % 3 == 0) {
                    pairCount++;
                }
            }
            Console.WriteLine("Количество пар: {0}", pairCount);
        }
    }
}
