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
        public MainForm() {
            InitializeComponent();
        }
    }
}
