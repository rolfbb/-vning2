using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==========================================================================");
            Console.WriteLine("*            MAIN MENU (ÖVNING 2)                                        *");
            Console.WriteLine("* Du navigerar i programmet med siffor, för att testa olika funktioner.  *");
            Console.WriteLine("*                                     *");
            Console.WriteLine("* Tillgängliga kommandon:                                                *");
            Console.WriteLine("*           0: stänger programmet                                        *");
            Console.WriteLine("*           övriga siffor: \"felaktig input\" ;-)                        *");
            Console.WriteLine("==========================================================================");


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
                    Console.WriteLine($"Angivet kommando har fel tye. Du skrev: \"{inputStr}\". Skriv in kommandot med siffror istället!");
                }
                else
                {
                    switch (input)
                    {
                        case 0:
                            Console.WriteLine("Du har valt att avsluta programmet!");
                            stopProgram = true;
                            break;
                        default:
                            break;
                    }
                }
            } while (!parsed
                &&
            !stopProgram);

        }
    }
}
