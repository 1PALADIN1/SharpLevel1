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
        List<Question> list;

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
            list = database.List;
        }
    }
}
