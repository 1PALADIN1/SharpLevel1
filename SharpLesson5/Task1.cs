using System;
using System.Text.RegularExpressions;

/*
1. Создать программу, которая будет проверять корректность ввода логина. Корректным логином будет строка от 2 до 10 символов,
содержащая только буквы латинского алфавита или цифры, при этом цифра не может быть первой:
а) без использования регулярных выражений;
б) **с использованием регулярных выражений.
*/
namespace SharpLesson5 {
    partial class Program {
        static ConsoleColor defaultColor = Console.ForegroundColor;

        static void Task1() {
            bool isWorking = true;

            do {
                Console.WriteLine("Введите логин (для выхода введите exit):");
                string input = Console.ReadLine();

                if (input.Equals("exit")) {
                    isWorking = false;
                } else {
                    Console.Write(">> Проверка с помощью средств C#: ");
                    if (CheckLogin(input)) {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("логин корректный");
                    } else {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("логин некорректный");
                    }
                    Console.ForegroundColor = defaultColor;


                    Console.Write(">> Проверка с помощью RegExp: ");
                    if (CheckLoginRegExp(input)) {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("логин корректный");
                    } else {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("логин некорректный");
                    }
                    Console.ForegroundColor = defaultColor;
                }

            } while (isWorking);

        }

        //а) без использования регулярных выражений;
        static bool CheckLogin(string login) {
            char[] loginCharArray = login.ToCharArray();

            //проверка на длину логина
            if (loginCharArray.Length < 2 || loginCharArray.Length > 10) return false;
            //проверка на первый символ (не должен быть цифрой)
            if (char.IsDigit(loginCharArray[0])) return false;
            //проверка на только символы латинского алфавита и цифры
            for (int i = 1; i < loginCharArray.Length; i++) {
                if (!char.IsDigit(loginCharArray[i]) &&
                    (char.ToLower(loginCharArray[i]) < 'a' || char.ToLower(loginCharArray[i]) > 'z')) {
                    return false;
                }
            }
            return true;
        }

        //б) **с использованием регулярных выражений.
        static bool CheckLoginRegExp(string login) {
            Regex loginPattern = new Regex(@"^[A-Za-z]{1}[A-Za-z0-9]{1,9}$");
            if (loginPattern.IsMatch(login)) return true;
            else
                return false;
        }
    }
}
