using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpLesson8DBLib {
    // Класс для вопроса    
    [Serializable]
    public class Question {
        string text;       // Текст вопроса
        bool trueFalse;// Правда или нет

        public string Text {
            get { return text; }
            set { text = value; }
        }

        public bool TrueFalse {
            get { return trueFalse; }
            set { trueFalse = value; }

        }

        public Question() { }

        public Question(string text, bool trueFalse) {
            this.text = text;
            this.trueFalse = trueFalse;
        }
    }
}
