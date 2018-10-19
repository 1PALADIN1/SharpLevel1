using System;
using System.IO;

/*
4. Решить задачу с логинами из урока 2, только логины и пароли считать из файла в массив.
Создайте структуру Account, содержащую Login и Password.
*/
namespace SharpLesson4 {
    partial class Program {
        public const string LOGIN = "root";
        public const string PASSWORD = "GeekBrains";

        struct Account {
            public string login;
            public string password;

            public bool CheckLoginPass() {
                return login == LOGIN && password == PASSWORD;
            }
        }

        static Account[] ReadFileIntoAccount(string filePath) {
            Account[] result = null;
            int size = 0;
            int i = 0;
            StreamReader streamReader = null;

            try {
                streamReader = new StreamReader(filePath);

                //вычисляем размер для массива
                while (!streamReader.EndOfStream) {
                    streamReader.ReadLine();
                    size++;
                }

                //сброс позиции
                streamReader.DiscardBufferedData();
                streamReader.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);

                //записываем данные в массив
                result = new Account[size];
                while (!streamReader.EndOfStream) {
                    string readString = streamReader.ReadLine();
                    result[i].login = readString.Split(' ')[0];
                    result[i].password = readString.Split(' ')[1];
                    i++;
                }

            } catch (FileNotFoundException e) {
                Console.WriteLine("Ошибка: {0}", e.Message);
            } finally {
                if (streamReader != null) streamReader.Close();
            }

            return result;
        }

        static void Task4() {
            //тестовый набор данных
            Console.WriteLine("Первый набор данных:");
            StreamWriter sw = new StreamWriter("test1.txt");
            sw.WriteLine("login password\n" +
                        "admin 123123\n" +
                        "root root\n" +
                        "admin admin");
            sw.Close();
            Account[] acc1 = ReadFileIntoAccount("test1.txt");

            foreach (var item in acc1) {
                Console.Write("Проверка логина {0}", item.login);
                if (item.CheckLoginPass()) Console.WriteLine(" - данные подошли, Вы вошли в систему");
                else
                    Console.WriteLine(" - некорректные логин и/или пароль");
            }

            //тестовый набор данных с корректными логином и паролем
            Console.WriteLine("\nВторой набор данных:");
            sw = new StreamWriter("test2.txt");
            sw.WriteLine("user1 password\n" +
                        "test test\n" +
                        "root GeekBrains");
            sw.Close();
            Account[] acc2 = ReadFileIntoAccount("test2.txt");

            foreach (var item in acc2) {
                Console.Write("Проверка логина {0}", item.login);
                if (item.CheckLoginPass()) Console.WriteLine(" - данные подошли, Вы вошли в систему");
                else
                    Console.WriteLine(" - некорректные логин и/или пароль");
            }
        }
    }
}
