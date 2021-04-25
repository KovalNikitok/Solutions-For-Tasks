﻿using System;
using System.Text.RegularExpressions;

namespace Task16
{
    class Program
    {
        public static bool VerificationMask(string input)
        {
            string maskPattern = @"^[a-z0-9\?\.\u002a]$";
            Regex regex = new Regex(maskPattern);
            bool isCheck = true;
            int countOfSym = 0;
            if (input.Length > 20 || input.Length == 0)
                isCheck = false;
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
                if (!regex.IsMatch(mask.ToString()))
                {
                    isCheck = false;
                    break;
                }
            }

            return isCheck;
        }

        public static bool IsUserInputEqual(string mask, string input)
        {
            bool isEqual = false;
            return isEqual;
        }

        public static bool IsQuestionTrue(Regex regexPattern, char symbol)
        {
            return regexPattern.IsMatch(symbol.ToString()) ? true : false;
        }
        public static bool IsStarTrue(Regex regexPattern, string input)
        {
            int countOfUncheck = 0;
            foreach (char symbol in input)
            {
                if (symbol == '?')
                {
                    if (!IsQuestionTrue(regexPattern, symbol)) countOfUncheck++;
                }
                else
                {
                    if (!regexPattern.IsMatch(input[symbol].ToString())) countOfUncheck++;
                }
            }
            return countOfUncheck > 0 ? false : true;
        }

        static void Main(string[] args)
        {   //@"[a-z0-9\.]\.?[a-z0-9\.]){1,20}";
            string inputPattern = @"^([a-z0-9\.])$";
            Regex userRegex = new Regex(inputPattern);
            string userInput,
                userMask;
            int starLength;
            bool isEqual;

            Console.WriteLine("Enter the mask.");
            userMask = Console.ReadLine();
            if (VerificationMask(userMask))
            {
                Console.WriteLine("Mask is OK!");
                do
                {
                    isEqual = true;
                    starLength = 0;
                    userInput = Console.ReadLine();
                    if (userInput.Length > 20)
                    {
                        isEqual = false;
                        break;
                    }
                    for (int i = 0; i < userMask.Length; i++)
                    {
                        if (!isEqual) break;
                        if (userInput.Length < userMask.Length - 1)
                        {
                            isEqual = false;
                            break;
                        }
                        if (userInput[i + starLength] != userMask[i])
                        {
                            switch (userMask[i])
                            {
                                case '?':
                                    if (!userRegex.IsMatch(userInput[i + starLength].ToString()))
                                        isEqual = false;
                                    break;
                                case '*':
                                    if (userMask.Length == userInput.Length && userMask.Length - 1 == i)
                                    {
                                        if (!userRegex.IsMatch(userInput[i].ToString()))
                                            isEqual = false;
                                        break;
                                    }
                                    if (userMask.Length > userInput.Length && userMask.Length - 1 == i)
                                        break;
                                    if (userInput.Length != userMask.Length)
                                    {
                                        int delta = 1;
                                        for (int j = userInput.Length - 1; j > i - 1; j--)
                                        {
                                            if (userMask[userMask.Length - delta] != '?' && userInput[j] != userMask[userMask.Length - delta])
                                            {
                                                if (userMask[userMask.Length - delta] == '*')
                                                {
                                                    string test = userInput.ToString().Substring(i, j - i + 1);
                                                    foreach (char symbol in test)
                                                    {
                                                        if (userRegex.IsMatch(symbol.ToString()))
                                                            starLength = j - i;
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
                                            else if (userInput.Length < userMask.Length)
                                            {
                                                starLength = -1;
                                                break;
                                            }
                                            delta++;
                                        }
                                    }
                                    else
                                    {
                                        if (!userRegex.IsMatch(userInput[i].ToString()))
                                            isEqual = false;
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
            else Console.WriteLine("Mask is not okay, try it again!");
        }
    }
}
