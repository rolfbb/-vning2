using System;

namespace Intro2
{
    class Util
    {
        public static int AskInt(string question, bool posVal)
        {
            int retval;
            bool parsed;
            bool ready = true;
            string errMsg = "Angivet svar har fel typ. Du skrev: \"{0}\". Skriv in svaret med en siffra istället!";
            do
            {
                string inputStr = Ask(question);
                parsed = int.TryParse(inputStr, out retval);

                //Console.WriteLine("Parsed (" + parsed + ") int (retval): '" + retval + "' posVal: " + posVal.ToString());

                if (parsed && posVal)
                {
                    errMsg = "Angivet svar är fel. Du skrev: \"{0}\". Skriv in svaret med en positiv siffra istället!";

                    if (retval < 0)
                    {
                        //Console.WriteLine("Setting ready till false!");
                        ready = false;
                    }
                    else
                    {
                        //Console.WriteLine("Setting ready till true!");
                        ready = true;
                    }
                }

                if (!parsed || !ready)
                {
                    Console.WriteLine(errMsg, inputStr);
                }
            } while (!parsed || !ready);
            return retval;
        }

        public static string Ask(string question)
        {
            string inputStr;
            Console.Write(question + " ");
            inputStr = Console.ReadLine();
            return inputStr;
        }
    }
}