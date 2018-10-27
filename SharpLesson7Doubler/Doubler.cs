using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//класс "удвоитель"
namespace SharpLesson7Doubler {
    class Doubler {
        int finishNumber;
        int currentNumber;
        int commandCount;
        Stack<CommandType> history; //очередь для записи истории ходов

        //ходы хранятся ввиде перечислений
        enum CommandType {
            PLUS, MULTI
        };

        public int FinishNumber {
            get {
                return finishNumber;
            }
        }

        public int CurrentNumber {
            get {
                return currentNumber;
            }
        }

        public int CommandCount {
            get {
                return commandCount;
            }
        }

        public Doubler(int min, int max) {
            Random rand = new Random();
            finishNumber = rand.Next(min, max + 1);
            currentNumber = 1;
            commandCount = 0;
            history = new Stack<CommandType>();
        }

        public void Plus() {
            currentNumber++;
            commandCount++;

            //запись хода в историю
            history.Push(CommandType.PLUS);
        }

        public void Multiply() {
            currentNumber *= 2;
            commandCount++;

            //запись хода в историю
            history.Push(CommandType.MULTI);
        }

        public void Reset() {
            currentNumber = 1;
            commandCount = 0;
        }

        //отмена хода
        public void CancelTurn() {
            if (history.Count == 0) throw new Exception("Не осталось ходов для отмены!");

            //если остались ходы
            CommandType cType = history.Pop();

            switch(cType) {
                case CommandType.PLUS:
                    currentNumber--;
                    break;
                case CommandType.MULTI:
                    currentNumber /= 2;
                    break;
            }
            commandCount--;
        }
    }
}
