using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Intro2
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintMainMenu();

            bool stopProgram = false;

            do
            {
                int answer = Util.AskInt("\nAnge kommando:", true);

                switch (answer)
                {
                    case 0:
                        Console.WriteLine("Du har valt att avsluta programmet!");
                        stopProgram = true;
                        break;
                    case 1:
                        GetPriceForPerson(true);
                        break;
                    case 2:
                        PrintTenTimes();
                        break;
                    case 3:
                        PrintThirdWord();
                        break;
                    case 4:
                        CalculateGroupPrice();
                        break;
                    case 9:
                        PrintMainMenu();
                        break;
                    default:
                        Console.WriteLine($"Angivet kommando finns ej {answer}");
                        break;
                }
            } while (!stopProgram);
        }

        private static void PrintThirdWord()
        {
            string inputStr = Util.Ask("Skriv en mening med minst tre ord:");
            Console.WriteLine($"'{inputStr}'");

            //Remove duplicate spaces
            inputStr = Regex.Replace(inputStr, @"\s+", " ");
            inputStr = inputStr.Trim();

            string[] stringArr = inputStr.Split();
            if (stringArr.Length < 3)
            {
                Console.WriteLine($"Du har inte angivit en mening med minst tre ord (endast {stringArr.Length} ord)! Försök igen.");
            }
            else
            {
                Console.WriteLine($"Det tredje ordet: {stringArr[2]}");
            }
        }

        private static void PrintTenTimes()
        {
            string inputStr = Util.Ask("Skriv in en godtycklig text: ");

            if (inputStr.Length > 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.Write($"{i + 1}: {inputStr} ");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Du har inte matat in någon text!");
            }
        }

        private static void CalculateGroupPrice()
        {
            int nbrOfPersons = Util.AskInt("Ange hur många ni är i sällskapet: ", true);

            int totalPrice = 0;
            for (int i = 0; i < nbrOfPersons; i++)
            {
                Console.Write($"Ange ålder för person {i + 1}: ");
                totalPrice += GetPriceForPerson(false);
            }
            Console.WriteLine($"Totalt pris för gruppen av {nbrOfPersons} personer är {totalPrice} kr.");
        }

        private static int GetPriceForPerson(bool printMessages)
        {
            int price = 0;
            int age = Util.AskInt("Ange ålder: ", true);
            if (age < 5)
            {
                if (printMessages)
                    Console.WriteLine("Grattis, barn under 5 år går gratis!");
                price = 0;
            }
            else if (age < 20)
            {
                if (printMessages)
                    Console.WriteLine("Ungdomspris: 80 kr.");
                price = 80;
            }
            else if (age > 100)
            {
                if (printMessages)
                    Console.WriteLine("Grattis, pensionärer över 100 går gratis!");
                price = 0;
            }
            else if (age > 64)
            {
                if (printMessages)
                    Console.WriteLine("Pensionärspris: 90 kr.");
                price = 90;
            }
            else
            {
                if (printMessages)
                    Console.WriteLine("Standardpris: 120 kr.");
                price = 120;
            }

            return price;
        }

        private static void PrintMainMenu()
        {
            Console.Clear();
            Console.WriteLine("==========================================================================");
            Console.WriteLine("*            MAIN MENU (ÖVNING 2)                                        *");
            Console.WriteLine("==========================================================================");
            Console.WriteLine("*                                                                        *");
            Console.WriteLine("* I detta program kan du testa olika funktioner...                       *");
            Console.WriteLine("*                                                                        *");
            Console.WriteLine("* Tillgängliga kommandon:                                                *");
            Console.WriteLine("*           0: Avsluta programmet                                        *");
            Console.WriteLine("*           1: Kontrollera ålder, ungdom/pensionär                       *");
            Console.WriteLine("*           2: Upprepa text 10 gånger                                    *");
            Console.WriteLine("*           3: Det tredje ordet                                          *");
            Console.WriteLine("*           4: Beräkna pris för helt sällskap                            *");
            Console.WriteLine("*           9: Skriv ut huvudmenyn                                       *");
            Console.WriteLine("*           övriga siffor: \"felaktig input\" ;-)                          *");
            Console.WriteLine("*                                                                        *");
            Console.WriteLine("==========================================================================");
        }
    }
}

