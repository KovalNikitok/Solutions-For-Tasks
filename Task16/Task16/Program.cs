using System;
using System.Text.RegularExpressions;

namespace Task16
{
    class Program
    {
        public static bool VerificationMask(string input)
        {// метод для проверки на правильность ввода маски
            string maskPattern = @"^[a-z0-9\?\.\u002a]$"; // регулярное выражение, по которому проверяется маска на соответсвие по введённым символам
            Regex maskRegex = new Regex(maskPattern);
            bool isCheck = true;
            int countOfSym = 0;
            if (input.Length > 20 || input.Length == 0) //проверка на длину введённой маски (не больше 20/не меньше 0)
                isCheck = false;
            foreach (char mask in input)
            {
                if (mask == '*') //за каждую * в маске прибавляем счётчик звёзд
                {
                    countOfSym++;
                }
                if (countOfSym > 1) //если звёзд больше одной, то маска неверна по условию
                {
                    isCheck = false;
                    break;
                }
                if (!IsSymbolTrue(maskRegex, mask)) // вызываем метод для проверки символа на соответствие регулярному выражению ([+])
                {
                    isCheck = false;
                    break;
                }
            }
            return isCheck;
        }
        public static bool IsSymbolTrue(Regex regexPattern, char symbol)
        { // возвращает true или false, в зависимости от того, прошёл ли символ по укащанному regex или нет
            return regexPattern.IsMatch(symbol.ToString()) ? true : false;
        }
        public static bool IsUserInputEqual(string mask, string input, Regex regexPattern)
        {// метод для получения значения (true/false) на соответствие введённому пользователем тексту и маски
            int starLength = 0;
            bool isEqual = true;
            if (input.Length > 20 || input.Length == 0)
            {// Проверка на длину введённого текста
                isEqual = false;
            }
            if (input.Length < mask.Length - 1)//если длина введённого пользователем текста меньше на 2 и более символом, то выходим из цикла
            {//(по условию, только * может быть "пустой",а значит длина не может отличаться более чем на 1 символ в меньшую сторону
                isEqual = false;
            }
            for (int i = 0; i < mask.Length; i++)
            {
                if (!isEqual) break; // проверка на булевую переменную, отвечающую за конечный вывод метода (если false, то выходим из цикла)
                if (input[i + starLength] != mask[i])
                {// входим, если символы по одному индексу не равны (starlength отвечает за длину текста от индекса появления * до завершения её последовательности)
                    switch (mask[i])
                    {
                        case '?':// если встретился ?
                            if (!IsSymbolTrue(regexPattern, input[i + starLength]))// [+]
                                isEqual = false;
                            break;
                        case '*':// если встретилась *
                            if (mask.Length == input.Length && mask.Length - 1 == i)
                            {// если длина маски и введённого пользователем текста совпадают и * встретилась в самом конце
                                if (!IsSymbolTrue(regexPattern, input[i]))// [+]
                                    isEqual = false;
                                break;
                            }
                            if (mask.Length > input.Length && mask.Length - 1 == i)// если * встретилась в конце, а длина текста пользователя меньше маски на 1 (пустая последовательность)
                                break;
                            if (input.Length != mask.Length)// если длина разлчается
                            {
                                int delta = 1;
                                for (int j = input.Length - 1; j > i - 1; j--)
                                {
                                    if (mask[mask.Length - delta] != '?' && input[j] != mask[mask.Length - delta])
                                    {// если символ с конца текста и маски не совпадает и он не ? (определяем длину последовательности в *)
                                        if (mask[mask.Length - delta] == '*')
                                        {// после прохода по циклу от конца и до * выделяем строку с последовательностью
                                            string test = input.ToString().Substring(i, j - i + 1); // получаем последовательность, выделяя строку по индексам (от i,до (j-i-1))
                                            foreach (char symbol in test)
                                            {
                                                if (IsSymbolTrue(regexPattern, symbol))// [+]
                                                    starLength = j - i; // формируем длину последовательности для дальнейшей проверки текста
                                                else isEqual = false;
                                            }
                                            break;
                                        }
                                        else
                                        {
                                            isEqual = false;
                                            break;
                                        }
                                    }
                                    else if (input.Length < mask.Length)
                                    {// если последовательность пустая 
                                        starLength = -1;
                                        break;
                                    }
                                    delta++;
                                }
                            }
                            else
                            {
                                if (!IsSymbolTrue(regexPattern, input[i]))// [+]
                                    isEqual = false;
                            }
                            break;
                        default:
                            //если встретился обычный символ
                            isEqual = false;
                            break;
                    }
                }
                else if (mask[mask.Length - 1] == '*' && mask.Length > input.Length)
                {// В случае появления ситуации, когда в последнем индексе маски стоит * и она больше введённой пользователем строки, вызываем рекурсию,
                 // удалив из строки * 
                    isEqual = IsUserInputEqual(new System.Text.StringBuilder(mask).Remove(mask.Length - 1, 1).ToString()
                        , input, regexPattern);
                    break;
                }
            }
            return isEqual;
        }
        static void Main(string[] args)
        {   //@"[a-z0-9\.]\.?[a-z0-9\.]){1,20}";
            string inputPattern = @"^([a-z0-9\.])$";
            Regex userRegex = new Regex(inputPattern);
            string userInput,
                userMask;
            Console.WriteLine("Enter the mask.");
            userMask = Console.ReadLine();// вводим маску
            if (VerificationMask(userMask))// вызываем метод проверки маски и, если выпадает true, то проходим условие
            {
                Console.WriteLine("Mask is OK!");
                Console.WriteLine("Enter the text.");
                do
                {
                    userInput = Console.ReadLine();// вводим текст
                    // выдаём сообщение с текстом пользователя и результатом выполнения метода проверки на соответствие текста и маски
                    Console.WriteLine("{0} -> {1}", userInput, IsUserInputEqual(userMask, userInput, userRegex) ? "YES" : "NO");
                } while (true);// выполняем цикл до выхода из программы
            }
            else Console.WriteLine("Mask is not okay, try it again!");
        }
    }
}
