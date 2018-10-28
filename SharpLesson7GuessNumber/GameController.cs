using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//класс, управляющий игрой
namespace SharpLesson7GuessNumber {
    class GameController {
        int number; //загаданное число
        int tryCount; //количество попыток, совершённых игроком

        public static readonly int MAX_TRY_COUNT = 5; //максимальное количество попыток

        public int TriesLeft {
            get {
                return MAX_TRY_COUNT - tryCount;
            }
        }

        public GameController(int min, int max) {
            Random rand = new Random();
            number = rand.Next(min, max + 1);
            tryCount = 0;

            //Console.WriteLine("Загаданное число: " + number);
        }

        public bool CheckNumber(int number) {
            tryCount++;
            if (this.number == number) return true;
            if (TriesLeft == 0) throw new Exception(String.Format("Больше не осталось попыток!\nЗагаданное число: {0}.\nНе хочешь ещё раз сыграть?", number));
            return false;
        }

        //проверяет больше ли указанное число загаданного
        public bool IsMyNumberBigger(int number) {
            return this.number < number;
        }
    }
}
