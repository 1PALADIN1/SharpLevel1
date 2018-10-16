using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
3.Описать класс дробей — рациональных чисел, являющихся отношением двух целых чисел. Предусмотреть методы сложения, вычитания, умножения и деления дробей.
Написать программу, демонстрирующую все разработанные элементы класса.
* Добавить свойства типа int для доступа к числителю и знаменателю;
* Добавить свойство типа double только на чтение, чтобы получить десятичную дробь числа;
* Добавить проверку, чтобы знаменатель не равнялся 0. Выбрасывать исключение ArgumentException("Знаменатель не может быть равен 0");
*** Добавить упрощение дробей.
*/
namespace SharpLesson3 {

    class Fraction {
        int numerator; //числитель
        int denominator; //знаменатель

        public int Numerator {
            get {
                return numerator;
            }
            set {
                numerator = value;
            }
        }

        public int Denominator {
            get {
                return denominator;
            }
            set {
                if (value == 0) throw new ArgumentException("Знаменатель не может быть равен 0");
                else
                    denominator = value;
            }
        }

        //получение десятичной дроби
        public double Decimal {
            get {
                return (double) numerator / denominator;
            }
        }

        public Fraction() {
            this.numerator = 0;
            this.denominator = 0;
        }

        public Fraction(int numerator, int denominator) {
            if (denominator == 0) throw new ArgumentException("Знаменатель не может быть равен 0");
            this.numerator = numerator;
            this.denominator = denominator;
        }

        //сложение
        public Fraction Plus(Fraction b) {
            Fraction a = new Fraction();
            a.numerator = ToFract(b).numerator + b.ToFract(this).numerator;
            a.denominator = ToFract(b).denominator;
            return a;
        }

        //вычитание
        public Fraction Sub(Fraction b) {
            Fraction a = new Fraction();
            a.numerator = ToFract(b).numerator - b.ToFract(this).numerator;
            a.denominator = ToFract(b).denominator;
            return a;
        }

        //умножение
        public Fraction Mul(Fraction b) {
            Fraction a = new Fraction();
            a.numerator = numerator * b.numerator;
            a.denominator = denominator * b.denominator;
            return a;
        }

        //деление
        public Fraction Div(Fraction b) {
            if (b.numerator == 0) throw new ArgumentException("Знаменатель не может быть равен 0");
            Fraction a = new Fraction();
            a.numerator = numerator * b.denominator;
            a.denominator = denominator * b.numerator;
            return a;
        }

        //упрощение дробей
        public static Fraction SimplifyFract(Fraction fraction) {
            int lastNumber = 0; //определяем до какого числа бежим в цикле
            int resultNumerator = fraction.numerator;
            int resultDenominator = fraction.denominator;

            lastNumber = (resultNumerator > resultDenominator) ? resultDenominator : resultNumerator;

            for (int i = 1; i < lastNumber; i++) {
                if (resultNumerator%i == 0 && resultDenominator%i == 0) {
                    resultNumerator /= i;
                    resultDenominator /= i;

                    i = 1;
                    lastNumber = (resultNumerator > resultDenominator) ? resultDenominator : resultNumerator;
                }
            }
            return new Fraction(resultNumerator, resultDenominator);
        }

        //приведение дроби к общему знаменателю по шаблону toFract
        private Fraction ToFract(Fraction toFract) {
            Fraction result = new Fraction();
            result.numerator = numerator * toFract.denominator;
            result.denominator = denominator * toFract.denominator;
            return result;
        }

        public override string ToString() {
            return numerator + "/" + denominator;
        }
    }

    partial class Program {
        static void Task3() {
            Fraction x = new Fraction(2, 3);
            Fraction y = new Fraction(5, 6);

            Console.WriteLine("Сложение {0} + {1} = {2}", x, y, x.Plus(y));
            Console.WriteLine("Сложение {0} - {1} = {2}", x, y, x.Sub(y));
            Console.WriteLine("Умножение {0} * {1} = {2}", x, y, x.Mul(y));
            Console.WriteLine("Деление {0} : {1} = {2}", x, y, x.Div(y));
            Console.WriteLine("Десятичные дроби {0} = {1:F5}, {2} = {3:F5}", x, x.Decimal, y, y.Decimal);

            Fraction fraction = new Fraction(27, 18);
            Console.WriteLine("Упрощение дроби {0} => {1}", fraction, Fraction.SimplifyFract(fraction));

            try {
                Console.WriteLine("Попытка присвоить знаменателю 0");
                Fraction errorFraction = new Fraction();
                errorFraction.Denominator = 0;
            } catch (ArgumentException e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
