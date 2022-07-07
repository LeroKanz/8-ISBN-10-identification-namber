using System;
using System.Collections.Generic;

namespace ISBN_10_identification_namber
{
    class Program
    {
        static void Main(string[] args)
        {
            //проверка валидности идентификатора книги (#-###-#####-* можно без прочерковб последняя "*" может быть 10) 
            string one = "3-598-21507-X";
            string two = "3598215088";
            string three = "039304002X";
            string four = "35A98-2150----88";
            string five = "359821507--FX";
            string six = "3-598-21508-9";

            Console.WriteLine(IsValid(one));
            Console.WriteLine(IsValid(two));
            Console.WriteLine(IsValid(three));
            Console.WriteLine(IsValid(four));
            Console.WriteLine(IsValid(five));
            Console.WriteLine(IsValid(six));
        }
        
        public static bool IsValid(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                throw new ArgumentException("Number is null or empty or whitespace.");
            }

            var bookISBN = number.ToCharArray();

            List<int> digits = new List<int>();

            for (int i = 0; i < bookISBN.Length; i++)
            {
                switch (bookISBN[i])
                {
                    case '0':
                        digits.Add(0);
                        break;
                    case '1':
                        digits.Add(1);
                        break;
                    case '2':
                        digits.Add(2);
                        break;
                    case '3':
                        digits.Add(3);
                        break;
                    case '4':
                        digits.Add(4);
                        break;
                    case '5':
                        digits.Add(5);
                        break;
                    case '6':
                        digits.Add(6);
                        break;
                    case '7':
                        digits.Add(7);
                        break;
                    case '8':
                        digits.Add(8);
                        break;
                    case '9':
                        digits.Add(9);
                        break;
                    case 'X':
                        if (i == bookISBN.Length - 1)
                        {
                            digits.Add(10);
                        }
                        else
                        {
                            return false;
                        }

                        break;
                    case '-':
                        if (i == 1 || i == 5 || i == 11)
                        {
                            continue;
                        }
                        else
                        {
                            return false;
                        }

                    default:
                        return false;
                }
            }

            if (digits.Count != 10)
            {
                return false;
            }

            int key = 0;
            int multiplier = 10;

            for (int i = 0; i < digits.Count; i++)
            {
                key += digits[i] * multiplier;
                multiplier--;
            }

            if (key % 11 == 0)
            {
                return true;
            }

            return false;
        }
    }
}
