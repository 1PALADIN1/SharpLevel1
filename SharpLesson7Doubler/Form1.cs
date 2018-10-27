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
1. а) Добавить в программу «Удвоитель» подсчет количества отданных команд.
б) Добавить меню и команду «Играть». При нажатии появляется сообщение, какое число должен получить игрок.
Игрок должен постараться получить это число за минимальное количество ходов.
в) * Добавить кнопку «Отменить», которая отменяет последние ходы.
*/
namespace SharpLesson7Doubler {
    public partial class Form1 : Form {
        Doubler doubler;

        public Form1() {
            InitializeComponent();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e) {
            doubler = new Doubler(10, 100);

            MessageBox.Show(String.Format("Вы должны получить число {0} за минимальное количество ходов. Игра началась!", doubler.FinishNumber));

            //делаем кнопки доступными после начала новой игры
            plusButton.Enabled = true;
            multiButton.Enabled = true;
            resetButton.Enabled = true;

            UpdateInfo();
        }

        private void UpdateInfo() {
            currebtTextBox.Text = doubler.CurrentNumber.ToString();
            finishLabel.Text = doubler.FinishNumber.ToString();
            commandLabel.Text = doubler.CommandCount.ToString();
        }

        //обработка кнопок
        private void PlusButton_Click(object sender, EventArgs e) {
            doubler.Plus();
            UpdateInfo();
        }

        private void MultiButton_Click(object sender, EventArgs e) {
            doubler.Multiply();
            UpdateInfo();
        }

        private void ResetButton_Click(object sender, EventArgs e) {
            doubler.Reset();
            UpdateInfo();
        }
    }
}
