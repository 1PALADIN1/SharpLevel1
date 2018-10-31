using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpLesson8DBLib;

namespace SharpLesson8Game {
    class GameController {
        List<Question> list; //список всех вопросов
        int curPos; //текущий позиция в списке
        int numRight; //количество правильных ответов

        //количество правильных ответов
        public int CorrectAnswers {
            get {
                return numRight;
            }
        }

        public int QuestionNumber {
            get {
                return list.Count;
            }
        }

        //текущий вопрос
        public string Question {
            get {
                return list[curPos].Text;
            }
        }

        public GameController(List<Question> list) {
            this.list = list;
            curPos = 0;
            numRight = 0;
        }

        //проверка текушего вопроса
        public bool CheckAnswer(bool answer) {
            if (list[curPos].TrueFalse == answer) {
                numRight++;
                return true;
            }
            return false;
        }

        //переход на следующий вопрос
        //возращает истину, если есть ещё вопросы в списке
        public bool NextQuestion() {
            curPos++;
            if (curPos > list.Count - 1) return false;
            return true;
        }
    }
}
