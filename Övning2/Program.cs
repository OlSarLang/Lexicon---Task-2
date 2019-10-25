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
                switch (GetInput())
                {
                    case "0":
                        running = false;
                        break;
                    case "1":
                        CheckAge();
                        break;
                    case "2":
                        HandleCompany();
                        break;
                    case "3":
                        RepeatTenTimes();
                        break;
                    case "4":
                        SplitSentence();
                        break;
                    default:
                        WrongFormat();
                        break;
                }
            }
        }

        public static void CheckAge()
        {
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
        }

        public static int InputAge(int i)
        {
            int age;

            Console.WriteLine($"Skriv åldern på person {i}\n");

            if (int.TryParse(GetInput(), out age))
            {
                return (CheckAgeGetPrice(age));
            }
            else
            {
                WrongFormat();
            }
            return InputAge(i);
        }
        public static int CheckAgeGetPrice(int age)
        {
            if (age < 20 && age >= 5) {return 80;}
            else if (age > 64 && age < 100) {return 90;}
            else if (age < 5) {return 0;}
            else if (age >= 100) {return 0;}
            else {return 120;}
        }

        public static void HandleCompany()
        {
            int amount = AskHowMany();
            int total = 0;

            for (int i = 1; i <= amount; i++)
            {
                total += InputAge(i);
            }

            Console.WriteLine($"Antal Personer: {amount}.\n" +
                $"Totalpris: {total}\n");
        }

        public static int AskHowMany()
        {
            int amount;

            Console.WriteLine("Hur många personer?\n");

            if (int.TryParse(GetInput(), out amount))
            {
                return (amount);
            }
            else
            {
                WrongFormat();
            }
            return amount;
        }

        public static void RepeatTenTimes()
        {
            Console.WriteLine("Skriv in vad som helst.\n");
            var input = GetInput();
            for (int i = 0; i < 10; i++)
            {
                Console.Write($"{input}");
            }
            Console.Write("\n");
        }

        public static void SplitSentence()
        {
            Console.WriteLine("Skriv en sträng med åtminstone tre ord.\n");

            string thirdWord = "";

            string[] str = GetInput().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

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

        public static string GetInput()
        {
            var input = Console.ReadLine();
            return input;
        }

        public static void WrongFormat()
        {
            Console.WriteLine("Felaktigt format. Försök igen.\n");
        }
    }
}
