using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

/*
2. Разработать статический класс Message, содержащий следующие статические методы для обработки текста:
а) Вывести только те слова сообщения, которые содержат не более n букв.
б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
в) Найти самое длинное слово сообщения.
г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
д) ***Создать метод, который производит частотный анализ текста. В качестве параметра в него передается массив слов и текст,
в качестве результата метод возвращает сколько раз каждое из слов массива входит в этот текст. Здесь требуется использовать класс Dictionary. 
*/
namespace SharpLesson5 {
    static class Message {
        //а) Вывести только те слова сообщения, которые содержат не более n букв.
        public static ArrayList WordsLessThenNumber(string message, int number) {
            ArrayList resultArray = new ArrayList();
            string[] inputArray = message.Split(' ');

            for (int i = 0; i < inputArray.Length; i++) {
                if (inputArray[i].Length <= number) resultArray.Add(inputArray[i]);
            }
            return resultArray;
        }

        //б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
        public static string DeleteWordsFromMessage(string message, char endSymbol) {
            string[] inputArray = message.Split(' ');
            StringBuilder resultText = new StringBuilder();

            for (int i = 0; i < inputArray.Length; i++) {
                if (inputArray[i][inputArray[i].Length - 1] != endSymbol) {
                    resultText.Append(inputArray[i] + " ");
                }
            }
            return resultText.ToString();
        }

        //в) Найти самое длинное слово сообщения.
        public static string TheBiggestWord(string message) {
            string[] inputArray = message.Split(' ');
            int biggestIndex = 0; //предполагаем, что самое длинное слово находится по этому индексу
            int biggestSize = inputArray[0].Length;

            for (int i = 1; i < inputArray.Length; i++) {
                if (inputArray[i].Length > biggestSize) {
                    biggestIndex = i;
                    biggestSize = inputArray[i].Length;
                }
            }
            return inputArray[biggestIndex];
        }

        //г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
        public static string TheBiggestWords(string message) {
            string[] inputArray = message.Split(' ');
            StringBuilder resultText = new StringBuilder();
            int biggestSize = inputArray[0].Length;

            //ищем размер самого длинного слова
            for (int i = 1; i < inputArray.Length; i++) {
                if (inputArray[i].Length > biggestSize) {
                    biggestSize = inputArray[i].Length;
                }
            }

            //ищем слова, которые равны самой большой длине
            for (int i = 1; i < inputArray.Length; i++) {
                if (inputArray[i].Length == biggestSize) {
                    resultText.Append(inputArray[i] + " ");
                }
            }

            return resultText.ToString();
        }

        //д) ***Создать метод, который производит частотный анализ текста.В качестве параметра в него передается массив слов и текст,
        //в качестве результата метод возвращает сколько раз каждое из слов массива входит в этот текст.Здесь требуется использовать класс Dictionary.
        
        //    !!!! для работы метода, нужно перенести text.txt в Debug !!!!
        public static Dictionary<string, int> FreqAnalysis(string[] words, string textFile) {
            Dictionary<string, int> wordDictionaty = new Dictionary<string, int>();

            //заполняем словарь начальными значениями
            for (int i = 0; i < words.Length; i++) {
                wordDictionaty.Add(words[i].ToUpper(), 0);
            }

            StreamReader sr = null;
            try {
                sr = new StreamReader(textFile);
                string[] lineArray;
                while (!sr.EndOfStream) {
                    string line = sr.ReadLine();
                    lineArray = line.Split(' ');
                    for (int i = 0; i < lineArray.Length; i++) {
                        if (wordDictionaty.ContainsKey(lineArray[i].ToUpper())) {
                            wordDictionaty[lineArray[i].ToUpper()]++;
                        }
                    }
                }
                
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            } finally {
                if (sr != null) sr.Close();
            }

            return wordDictionaty;
        }
    }

    partial class Program {
        static void Task2() {
            string inputText = "Бранить дураков мы никак не должны " +
                "Ведь если б глупец не рождался " +
                "И были бы все абсолютно умны " +
                "То кто б тогда умным считался";
            int number = 4;
            //a)
            Console.WriteLine(">> а) Сообщение \"{0}\", слова с не болеее {1} букв:", inputText, number);
            ArrayList resultArray = Message.WordsLessThenNumber(inputText, number);

            foreach (var item in resultArray) {
                Console.WriteLine(item);
            }

            //б)
            Console.Write(">> б) Укажите символ: ");
            ConsoleKeyInfo key = Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine("Результат: \"{0}\"", Message.DeleteWordsFromMessage(inputText, key.KeyChar));

            //в
            Console.WriteLine(">> в) Самое длинное слово сообщения: {0}", Message.TheBiggestWord(inputText));

            //г
            Console.WriteLine(">> г) Строка из самых длинных слов: \"{0}\"", Message.TheBiggestWords(inputText));
            inputText = "Трали вали трали вали собака кошка муравей телефон игра телефон семерка";
            Console.WriteLine("Для второго набора: \"{0}\"", Message.TheBiggestWords(inputText));

            //д
            Console.WriteLine(">> д) Частотный анализ текста:");
            Console.WriteLine("Слово\t\t\tСколько раз");
            Dictionary<string, int> dictionary = Message.FreqAnalysis(new string[6] { "быть", "так", "как", "еще", "очень", "знаю" }, "text.txt");

            foreach(var item in dictionary) {
                Console.WriteLine(item.Key + "\t\t\t" + item.Value);
            }
        }
    }
}
