﻿/* Малиновский Руслан */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
2. Используя Windows Forms, разработать игру «Угадай число». Компьютер загадывает число от 1 до 100,
а человек пытается его угадать за минимальное число попыток. Для ввода данных от человека используется элемент TextBox.
*/
namespace SharpLesson7GuessNumber {
    static class Program {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainFrom());
        }
    }
}
