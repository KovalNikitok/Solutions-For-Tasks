using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Task16
{
    class Program
    {
        public static bool VerificationMask(string input)
        {
            string maskPattern = @"[a-z0-9\?\.\u002a]";
            Regex regex = new Regex(maskPattern);
            bool isCheck = true;
            int countOfSym = 0;
            foreach (char mask in input)
            {
                if (mask == '*')
                {
                    countOfSym++;
                }
                if (countOfSym > 1)
                {
                    isCheck = false;
                    break;
                }
                if ((regex.IsMatch(mask.ToString()) ? isCheck = true : isCheck = false) && !isCheck) break;
                Console.WriteLine("{0} - {1}", mask, isCheck);
            }
            return isCheck;
        }
        static void Main(string[] args)
        {   //@"[a-z0-9\.]\.?[a-z0-9\.]){1,20}";
            string inputPattern = @"[a-z0-9\.]";
            Regex userRegex = new Regex(inputPattern);
            string userInput,
                userMask = "oo*oo";
            bool isEqual = false;
            if (VerificationMask(userMask)) Console.WriteLine("OK");
            else Console.WriteLine("NOT OK");
            do
            {
                userInput = Console.ReadLine();
                if (userInput.Length > 20) break;
                //for (int i = 0; i < userInput.Length; i++)//foreach (char iter in userInput)
                for (int i = 0; i < userMask.Length; i++)
                {
                    if (/*userMask.Length <= userInput.Length &&*/ userInput[i] != userMask[i])
                    {
                        switch (userMask[i])
                        {
                            case '?':
                                if (userRegex.IsMatch(userInput[i].ToString()))
                                    isEqual = true;
                                else isEqual = false;
                                break;
                            case '*':
                                if ((userMask.Length - 1) != i/*&& userInput.Length != userMask.Length*/)
                                {
                                    int delta = 1;
                                    for (int j = userInput.Length - 1; j > i; j--)
                                    {
                                        if (userMask[userMask.Length - delta] != '?' && userInput[j] != userMask[userMask.Length - delta])
                                        {
                                            if (userRegex.IsMatch(userInput.ToString().Substring(i, j - i)))
                                                isEqual = true;
                                            else isEqual = false;
                                            break;
                                        }
                                        delta++;
                                    }
                                }
                                else
                                {
                                    if (userRegex.IsMatch(userInput[i].ToString()))
                                        isEqual = true;
                                    else isEqual = false;
                                    break;
                                }
                                break;
                            default:
                                isEqual = false;
                                break;
                        }
                    }
                }
                Console.WriteLine("{0} -> {1}", userInput, isEqual ? "YES" : "NO");
            } while (true);
        }
    }
}
