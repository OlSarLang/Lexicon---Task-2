using System;
using System.Collections.Generic;
using System.Linq;

namespace Övning2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("Meny:\n" +
                    "Tryck på '0' för att avsluta programmet.\n" +
                    "Tryck på '1' för att kontrollera rabbaterad pris.\n" +
                    "Tryck på '2' för att sammanställa pris för ett sällskap\n" +
                    "Tryck på '3' för att iterera en input 10ggr\n" +
                    "Tryck på '4' för att dela upp en sträng\n");
                var input = Console.ReadLine();
                switch (input)
                {
                    case "0":
                        running = false;
                        break;
                    case "1":
                        int price = InputAge(1);
                        string rabatt = "";
                        switch (price)
                        {
                            case 80:
                                rabatt = "Ungdomspris:";
                                break;
                            case 90:
                                rabatt = "Pensionärspris:";
                                break;
                            case 120:
                                rabatt = "Standardpris:";
                                break;
                            case 0:
                                rabatt = "Gratis!";
                                break;
                        }
                        Console.WriteLine($"{rabatt} {price}");
                        break;
                    case "2":
                        var info = HandleCompany();
                        int amountPeople = info.Item1;
                        int totalPrice = info.Item2;
                        Console.WriteLine($"Antal Personer: {amountPeople}.\n" +
                            $"Totalpris: {totalPrice}\n");
                        break;
                    case "3":
                        RepeatTenTimes();
                        break;
                    case "4":
                        SplitSentence();
                        break;
                    default:
                        Console.WriteLine("Felaktigt format.\n");
                        break;
                }
            }
        }

        public static int InputAge(int i)
        {
            int age;

            Console.WriteLine($"Skriv åldern på person {i}\n");
            var input = Console.ReadLine();

            if (int.TryParse(input, out age))
            {
                return (CheckAgeGetPrice(age));
            }
            else
            {
                Console.WriteLine("Felaktigt format. Försök igen.\n");
            }
            return InputAge(i);
        }
        public static int CheckAgeGetPrice(int age)
        {
            if (age < 20 && age >= 5)
            {
                return 80;
            }
            else if (age > 64)
            {
                return 90;
            }
            else if (age < 5)
            {
                return 0;
            }
            else if (age > 100)
            {
                return 0;
            }
            else
            {
                return 120;
            }
        }

        public static Tuple<int, int> HandleCompany()
        {
            int amount = AskHowMany();
            int total = 0;


            for (int i = 1; i <= amount; i++)
            {
                total += InputAge(i);
            }

            return Tuple.Create(amount, total);
        }

        public static int AskHowMany()
        {
            int amount;

            Console.WriteLine("Hur många personer?\n");
            var input = Console.ReadLine();

            if (int.TryParse(input, out amount))
            {
                return (amount);
            }
            else
            {
                Console.WriteLine("Felaktigt format. Försök igen.\n");
            }
            return amount;
        }

        public static void RepeatTenTimes()
        {
            Console.WriteLine("Skriv in vad som helst.\n");
            var input = Console.ReadLine();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{i}: {input}");
            }
        }

        public static void SplitSentence()
        {
            Console.WriteLine("Skriv en sträng med åtminstone tre ord.\n");
            var input = Console.ReadLine();

            string thirdWord = "";

            string[] str = input.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            //List<string> fixedStrings = new List<string>();

            if(str.Length > 2)
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if(i == 2)
                    {
                        thirdWord = str[i];
                    }
                    else
                    {
                        Console.WriteLine($"{i} : {str[i]}");
                    }
                }
                Console.WriteLine($"Tredje ordet var: {thirdWord}");
            }
            else
            {
                Console.WriteLine("För få ord... Försök igen.\n");
                SplitSentence();
            }
        }
    }
}
