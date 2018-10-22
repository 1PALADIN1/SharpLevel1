using System;
using System.Collections;

/*
3. *Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой.
Например:
badc являются перестановкой abcd. 
*/
namespace SharpLesson5 {
    partial class Program {
        static void Task3() {
            Console.WriteLine("Для слов \"abcd\", \"bacd\": {0}", IsSwapLine("abcd", "bacd"));
            Console.WriteLine("Для слов \"asdfg\", \"asdfg\": {0}", IsSwapLine("asdfg", "aeeeg"));
            Console.WriteLine("Для слов \"gdsdsf\", \"gdsdsf\": {0}", IsSwapLine("gdsdsf", "gqwesr"));
        }

        static bool IsSwapLine(string line1, string line2) {
            if (line1.Length != line2.Length) return false;

            ArrayList lineArray = new ArrayList();
            //забрасываем символы из строки в массив
            for (int i = 0; i < line1.Length; i++) {
                lineArray.Add(line1[i]);
            }

            for (int i = 0; i < line2.Length; i++) {
                lineArray.Remove(line2[i]);
            }

            if (lineArray.Count == 0) return true;
            else
                return false;
        }
    }
}
