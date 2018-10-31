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
using SharpLesson8DBLib;

/*
1. а) Создать приложение, показанное на уроке, добавив в него защиту от
возможных ошибок (не создана база данных, обращение к несуществующему вопросу,
открытие слишком большого файла и т.д.).
б) Изменить интерфейс программы, увеличив шрифт, поменяв цвет элементов и
добавив другие «косметические» улучшения на свое усмотрение.
в) Добавить в приложение меню «О программе» с информацией о программе
(автор, версия,авторские права и др.).
г) Добавить в приложение сообщение с предупреждением при попытке удалить вопрос.
д) Добавить пункт меню Save As, в котором можно выбрать имя для сохранения
базы данных (элемент SaveFileDialog).
*/
namespace SharpLesson8DB {
    public partial class MainForm : Form {
        Database database;
        BindingSource bs;

        public MainForm() {
            InitializeComponent();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e) {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML файлы|*.xml|Все файлы(*.*)|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                database = new Database(saveFileDialog.FileName);
                this.Text = saveFileDialog.FileName;
                bs = new BindingSource();
                bs.DataSource = database;
                bs.DataMember = "List";
                tbQuestion.DataBindings.Add("Text", bs, "Text");
                chbTrueFalse.DataBindings.Add("Checked", bs, "TrueFalse");
                bnQuestion.BindingSource = bs;
                dgvQuestion.DataSource = bs;
            };
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e) {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML файлы|*.xml|Все файлы(*.*)|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                database.Save();
            }
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML файлы|*.xml|Все файлы(*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                database = new Database(openFileDialog.FileName);
                database.Load();
                this.Text = openFileDialog.FileName;
                bs = new BindingSource();
                bs.DataSource = database;
                bs.DataMember = "List";
                tbQuestion.DataBindings.Clear();
                tbQuestion.DataBindings.Add("Text", bs, "Text");
                chbTrueFalse.DataBindings.Clear();
                chbTrueFalse.DataBindings.Add("Checked", bs, "TrueFalse");
                bnQuestion.BindingSource = bs;
                dgvQuestion.DataSource = bs;
            }
        }
    }
}
