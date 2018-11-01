using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpLesson8DBLib;

namespace SharpLesson8Game {
    public partial class MainForm : Form {
        Database database;
        GameController game;

        public MainForm() {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            InitGame();
        }

        private void InitGame() {
            btStart.Visible = true;
            btStart.Enabled = true;

            btTrue.Enabled = false;
            btTrue.Visible = false;

            btFalse.Enabled = false;
            btFalse.Visible = false;

            tbQuestion.Text = "Нажмите кнопку начать, чтобы запустить игру";
        }

        private void BtStart_Click(object sender, EventArgs e) {
            btStart.Enabled = false;
            btStart.Visible = false;

            btTrue.Enabled = true;
            btTrue.Visible = true;

            btFalse.Enabled = true;
            btFalse.Visible = true;

            //загружаем список вопросов
            database = new Database("data.xml");
            database.Load();
            game = new GameController(database.List);
            tbQuestion.Text = game.Question;
        }

        private void UpdateInfo() {
            //переходим на следующий вопрос
            if (!game.NextQuestion()) {
                MessageBox.Show(String.Format("Игра окончена! Количество правильных ответов {0} их {1}", game.CorrectAnswers, game.QuestionNumber));
                InitGame();
                return;
            }
            tbQuestion.Text = game.Question;
        }

        private void BtTrue_Click(object sender, EventArgs e) {
            game.CheckAnswer(true);
            UpdateInfo();
        }

        private void btFalse_Click(object sender, EventArgs e) {
            game.CheckAnswer(false);
            UpdateInfo();
        }
    }
}
