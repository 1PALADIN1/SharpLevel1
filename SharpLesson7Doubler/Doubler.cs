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
        }

        public void Plus() {
            currentNumber++;
            commandCount++;
        }

        public void Multiply() {
            currentNumber *= 2;
            commandCount++;
        }

        public void Reset() {
            currentNumber = 1;
            commandCount = 0;
        }
    }
}
