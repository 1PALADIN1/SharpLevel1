using System;
using System.IO;

/*
2. Реализуйте задачу 1 в виде статического класса StaticClass;
а) Класс должен содержать статический метод, который принимает на вход массив и решает задачу 1;
б) Добавьте статический метод для считывания массива из текстового файла. Метод должен возвращать массив целых чисел;
в)*Добавьте обработку ситуации отсутствия файла на диске.
*/
namespace SharpLesson4 {
    static class StaticClass {

        //а) Класс должен содержать статический метод, который принимает на вход массив и решает задачу 1;
        public static int FindPairs(int[] arr) {
            int pairCount = 0;
            for (int i = 0; i < arr.Length - 1; i++) {
                if (arr[i] % 3 == 0 && arr[i + 1] % 3 != 0 ||
                    arr[i] % 3 != 0 && arr[i + 1] % 3 == 0) {
                    pairCount++;
                }
            }

            return pairCount;
        }

        //TODO
        //б) Добавьте статический метод для считывания массива из текстового файла. Метод должен возвращать массив целых чисел;
        public static int[] ReadArrayFromFile(string filePath) {
            int[] result = null;
            int size = 0;
            int i = 0;
            StreamReader streamReader = null;

            try {
                streamReader = new StreamReader(filePath);

                //вычисляем размер для массива
                while(!streamReader.EndOfStream) {
                    streamReader.ReadLine();
                    size++;
                }

                //сброс позиции
                streamReader.DiscardBufferedData();
                streamReader.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);

                //записываем данные в массив
                result = new int[size];
                while (!streamReader.EndOfStream) {
                    result[i] = int.Parse(streamReader.ReadLine());
                    i++;
                }

            } catch (FileNotFoundException e) {
                Console.WriteLine("Ошибка: {0}", e.Message);
            } finally {
                if (streamReader != null) streamReader.Close();
            }

            return result;
        }

        public static string ArrayToString(int[] arr) {
            string result = "[";
            for (int i = 0; i < arr.Length; i++) {
                if (i == arr.Length - 1) result += string.Format("{0}", arr[i]);
                else
                    result += string.Format("{0}, ", arr[i]);
            }

            result += "]";
            return result;
        }
    }

    partial class Program {
        static void Task2() {
            int[] arr = new int[20];
            Random rand = new Random();

            Console.Write("Дан массив: [");
            for (int i = 0; i < arr.Length; i++) {
                arr[i] = rand.Next(-10_000, 10_001);
                if (i == arr.Length - 1) Console.WriteLine("{0}]", arr[i]);
                else
                    Console.Write("{0}, ", arr[i]);
            }

            Console.WriteLine("Количество пар: {0}", StaticClass.FindPairs(arr));

            //Записываем файл для теста
            StreamWriter sw = new StreamWriter("test.txt");
            for (int i = 0; i < 20; i++) {
                sw.WriteLine(rand.Next(-100, 101));
            }
            sw.Close();

            StaticClass.ReadArrayFromFile("file_not_exist.txt"); //проверка exception
            int[] arrFromFile = StaticClass.ReadArrayFromFile("test.txt");
            Console.WriteLine("Чтение в массив из файла: {0}", StaticClass.ArrayToString(arrFromFile));
        }
    }
}
