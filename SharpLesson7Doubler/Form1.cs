using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            //делаем кнопки доступными после начала новой игры
            plusButton.Enabled = true;
            multiButton.Enabled = true;
            resetButton.Enabled = true;

            UpdateInfo();
        }

        private void UpdateInfo() {
            currebtTextBox.Text = doubler.CurrentNumber.ToString();
            finishLabel.Text = doubler.FinishNumber.ToString();
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
