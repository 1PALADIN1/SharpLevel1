using System;
using System.IO;

/* Сделано только a */

/*
3. а) Дописать класс для работы с одномерным массивом. Реализовать конструктор, создающий массив определенного размера
и заполняющий массив числами от начального значения с заданным шагом. Создать свойство Sum, которое возвращает сумму
элементов массива, метод Inverse, возвращающий новый массив с измененными знаками у всех элементов массива
(старый массив, остается без изменений), метод Multi, умножающий каждый элемент массива на определённое число,
свойство MaxCount, возвращающее количество максимальных элементов. 
б)** Создать библиотеку содержащую класс для работы с массивом. Продемонстрировать работу библиотеки
е) *** Подсчитать частоту вхождения каждого элемента в массив (коллекция Dictionary<int,int>)
*/
namespace SharpLesson4 {
    class MyArray {
        private int[] a;

        public bool Error = false;

        public MyArray(int size) {
            a = new int[size];
        }

        //Реализовать конструктор, создающий массив определенного размера
        //и заполняющий массив числами от начального значения с заданным шагом
        public MyArray(int size, int step) : this(size) {
            Random rnd = new Random();
            for (int i = 0; i < a.Length; i++) {
                if (i != 0) {
                    if ((i + step - 1) >= a.Length) break;
                    i += step - 1;
                }
                a[i] = rnd.Next(-100, 101);
            }
        }

        public MyArray(int size, int min, int max) : this(size) {
            Random rnd = new Random();
            for (int i = 0; i < a.Length; i++)
                a[i] = rnd.Next(min, max + 1);
        }

        public MyArray(string filename) {
            StreamReader sr = null;

            try {
                sr = new StreamReader(filename);
                int size = int.Parse(sr.ReadLine());
                a = new int[size];
                int i = 0;
                while (!sr.EndOfStream) {
                    a[i] = int.Parse(sr.ReadLine());
                    i++;
                }

            } catch (FileNotFoundException exc) {
                Console.WriteLine(exc.Message);
                Error = true;
            } catch (DirectoryNotFoundException exc) {
                Console.WriteLine(exc.Message);
                Error = true;
            } catch (Exception exc) {
                Console.WriteLine(exc.Message);
                Error = true;
            } finally {
                if (sr != null) sr.Close();
            }

        }

        public int this[int index] {
            get { return a[index]; }
            set { a[index] = value; }
        }

        public void WriteToFile(string filename) {
            StreamWriter sw = null;
            sw = new StreamWriter(filename);

            sw.WriteLine(a.Length);
            foreach (int el in a)
                sw.WriteLine(el);
            sw.Close();
        }
        
        public int Max() {
            int m = a[0];
            foreach (int element in a) {
                if (element > m) m = element;
            }
            return m;
        }

        public override string ToString() {
            string s = "";
            for (int i = 0; i < a.Length; i++)
                s = s + String.Format("{0,5}", a[i]);
            return s;
        }

        //Создать свойство Sum, которое возвращает сумму
        //элементов массива, метод Inverse, возвращающий новый массив с измененными знаками у всех элементов массива
        //(старый массив, остается без изменений), метод Multi, умножающий каждый элемент массива на определённое число,
        //свойство MaxCount, возвращающее количество максимальных элементов
        public int Sum() {
            int sum = 0;
            foreach (int item in a) {
                sum += item;
            }
            return sum;
        }

        public int[] Inverse() {
            int[] result = new int[a.Length];
            for (int i = 0; i < result.Length; i++) {
                result[i] = -1 * a[i];
            }
            return result;
        }

        public void Multi(int num) {
            for (int i = 0; i < a.Length; i++) {
                a[i] = a[i] * num;
            }
        }

        public int MaxCount {
            get {
                int maxCount = 0;
                int maxNum = a[0];

                //находим максимальный элемент
                for (int i = 1; i < a.Length; i++) {
                    if (a[i] > maxNum) maxNum = a[i];
                }

                //ищем количество максимальных
                foreach (int item in a) {
                    if (item == maxNum) maxCount++;
                }

                return maxCount;
            }
        }

        //метод, возвращающий массив a
        public int[] ToIntArray() {
            return a;
        }
    }

    partial class Program {
        static void Task3() {
            int step = 2;
            int size = 12;
            int multiNum = 3;

            MyArray arr = new MyArray(size, step);

            Console.WriteLine("Массив с размером {0} и шагом {1}: {2}", size, step, StaticClass.ArrayToString(arr.ToIntArray()));
            Console.WriteLine("Сумма элементов массива: {0}", arr.Sum());
            Console.WriteLine("Массив с изменёнными знаками: {0}", StaticClass.ArrayToString(arr.Inverse()));
            arr.Multi(multiNum);
            Console.WriteLine("Умножаем массив на {0}, итог: {1}", multiNum, StaticClass.ArrayToString(arr.ToIntArray()));
            Console.WriteLine("Количество максимальных элементов: {0}", arr.MaxCount);
            //тест для большого количества элементов
            MyArray arrBig = new MyArray(10_000, -100, 100);
            Console.WriteLine("Количество максимальных элементов (тест 2): {0}", arrBig.MaxCount);
        }
    }
}
