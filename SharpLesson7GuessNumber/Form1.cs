/* Малиновский Руслан */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
2. Используя Windows Forms, разработать игру «Угадай число». Компьютер загадывает число от 1 до 100,
а человек пытается его угадать за минимальное число попыток. Для ввода данных от человека используется элемент TextBox.
*/
namespace SharpLesson7GuessNumber {
    public partial class MainFrom : Form {
        GameController game;
        const int min = 1;
        const int max = 100;

        public MainFrom() {
            InitializeComponent();
        }

        private void MainFrom_Load(object sender, EventArgs e) {
            InitGame(String.Format("Добро пожаловать в мой трактир, путник!\n" +
                "Не хочешь сыграть со мной в игру?\n" +
                "Я загадываю число от {0} до {1}, а твоя\n" +
                "задача угадать его за {2} попыток.", min, max, GameController.MAX_TRY_COUNT));
        }

        private void InitGame(string startText) {
            game = new GameController(min, max);

            labelDialog.Text = startText;
            buttonStart.Enabled = true;
            buttonStart.Visible = true;
            buttonGuess.Enabled = false;
            buttonGuess.Visible = false;
            buttonRestart.Enabled = false;
            buttonRestart.Visible = false;
            tbGuess.Enabled = false;
            tbGuess.Visible = false;
        }

        //кнопка "Начать"
        private void ButtonStart_Click(object sender, EventArgs e) {
            buttonStart.Enabled = false;
            buttonStart.Visible = false;
            buttonGuess.Enabled = true;
            buttonGuess.Visible = true;
            buttonRestart.Enabled = true;
            buttonRestart.Visible = true;
            tbGuess.Enabled = true;
            tbGuess.Visible = true;

            labelDialog.Text = String.Format("Я загадал число. Какое число я загадал?\n" +
                "Осталось попыток: {0}", game.TriesLeft);
        }

        private void ButtonGuess_Click(object sender, EventArgs e) {
            bool goodNumber = Int32.TryParse(tbGuess.Text, out int inputNumber);
            if (goodNumber) {
                try {
                    if (game.CheckNumber(inputNumber)) {
                        InitGame("Поздравляю! Ты отгдал число!\nНе хочешь ещё раз сыграть?");
                    } else {
                        labelDialog.Text = "Не угадал. ";
                        
                        //подсказываем игроку, загаданное число больше или меньше указанного
                        if (game.IsMyNumberBigger(inputNumber)) {
                            labelDialog.Text += "Моё число меньше твоего!\n";
                        } else {
                            labelDialog.Text += "Моё число больше твоего!\n";
                        }

                        labelDialog.Text += String.Format("Какое число я загадал?\n" +
                            "Осталось попыток: {0}", game.TriesLeft);
                    }
                } catch (Exception exc) {
                    //завершение игры
                    InitGame(exc.Message);
                }
            }
            tbGuess.Text = String.Empty;
        }

        private void ButtonRestart_Click(object sender, EventArgs e) {
            InitGame(String.Format("Добро пожаловать в мой трактир, путник!\n" +
                "Не хочешь сыграть со мной в игру?\n" +
                "Я загадываю число от {0} до {1}, а твоя\n" +
                "задача угадать его за {2} попыток.", min, max, GameController.MAX_TRY_COUNT));
        }
    }
}
