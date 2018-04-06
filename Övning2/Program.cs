using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/*
 * 
 * A new Git repository has been created for you in c:\Users\User\Documents\source\repos\Övning2.
Opening repositories:
c:\Users\User\Documents\source\repos\Övning2
 * 
 * */

namespace Intro2
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 
             * 1.Print main menu
             * 2.Parse input & make sure it's a correct command
             * 3.Iterate the program until command 0
             */

            PrintMainMenu();

            bool parsed = true;
            bool stopProgram = false;
            do
            {
                string inputStr;
                Console.Write("Ange kommando: ");
                inputStr = Console.ReadLine();
                parsed = int.TryParse(inputStr, out int input);
                if (!parsed)
                {
                    Console.WriteLine($"Angivet kommando har fel typ. Du skrev: \"{inputStr}\". Skriv in kommandot med siffror istället!");
                }
                else
                {
                    switch (input)
                    {
                        case 0:
                            Console.WriteLine("Du har valt att avsluta programmet!");
                            stopProgram = true;
                            break;
                        case 1:
                            GetPriceForPerson(true);
                            break;
                        case 2:
                            PrintTenTimes(input);
                            break;
                        case 3:
                            PrintThirdWord(input);
                            break;
                        case 4:
                            CalculateGroupPrice();
                            break;
                        case 9:
                            PrintMainMenu();
                            break;
                        default:
                            Console.WriteLine($"Angivet kommando finns ej {input}");
                            break;
                    }
                }
            } while (!parsed || !stopProgram);

        }

        private static void PrintThirdWord(int input)
        {
            /*
             * Ask user to enter a sentence with at least three words,
             * then print the third word.
             */
            Console.Write("Skriv en mening med minst tre ord: ");
            string inputStr = Console.ReadLine();
            
            //Remove duplicate spaces
            inputStr = Regex.Replace(inputStr, @"\s+", " ");

            string[] stringArr = inputStr.Split();
            if (stringArr.Length < 3)
            {
                Console.WriteLine($"Du har inte angivit en mening med minst tre ord (endast {stringArr.Length} ord)! Försök igen.");
            }
            else
            {
                Console.WriteLine($"{inputStr}");
                Console.WriteLine($"Det tredje ordet: {stringArr[2]}");
            }
        }

        private static void PrintTenTimes(int input)
        {
            /*
             * Ask the user to enter some text. Print the text ten times on the same row.
             */
            string inputStr;
            Console.Write("Skriv in en godtycklig text: ");
            inputStr = Console.ReadLine();

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
            /*
             * Ask the user for how many persons they are; calculate total price for the group.
             */

            int nbrOfPersons = GetNumberOfPersons();

            int totalPrice = 0;
            for (int i = 0; i < nbrOfPersons; i++)
            {
                Console.Write($"Ange ålder för person {i + 1}: ");
                totalPrice += GetPriceForPerson(false);
            }
            Console.WriteLine($"Totalt pris för gruppen av {nbrOfPersons} personer är {totalPrice} kr.");
        }

        private static int GetNumberOfPersons()
        {
            bool parsed = true;
            int numberOfPersons;
            do
            {
                string inputStr;
                Console.Write("Ange hur många ni är i sällskapet: ");
                inputStr = Console.ReadLine();
                parsed = int.TryParse(inputStr, out numberOfPersons);
                if (!parsed)
                {
                    Console.WriteLine($"Du måste ange sällskapets antal med en siffra. Du skrev: \"{inputStr}\". Skriv in antalet med en siffra istället!");
                }
            } while (!parsed);

            return numberOfPersons;
        }

        private static int GetPriceForPerson(bool printMessages)
        {
            /*
             * Menyval 1: Ungdom eller pensionär
             * 1. Användaren anger en ålder i siffror
             * 2. Programmet konverterar detta från en ​sträng till en ​int
             * 3. Programmet kollar om personen är ungdom (​under 20 år)
             * 4. Om det ovanstående är sant skall programmet skriva ut: Ungdomspris: 80kr
             * 5. Annars kollar programmet om personen är en pensionär (​över 64 år)
             * 6. Om ovanstående är sant skall programmet skruva ut: Pensionärspris: 90kr
             * 7. Annars skall programmet skriva ut: Standardpris: 120kr
             */

            int price = 0;
            bool parsed = true;
            do
            {
                if (printMessages)
                    Console.Write("Ange ålder: ");

                string inputStr;
                inputStr = Console.ReadLine();
                parsed = int.TryParse(inputStr, out int age);
                if (!parsed)
                {
                    Console.WriteLine($"Du måste ange ålder med siffror. Du skrev: \"{inputStr}\". Skriv in ålder med siffror istället!");
                }
                else
                {
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
                }
            } while (!parsed);

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

