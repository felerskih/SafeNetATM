﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SafeNetATM
{
    //This class is responsible for the display of data and managing
    //calls to the Manager class.
    class ConsoleIO
    {
        private readonly char withdraw = 'W';
        private readonly char inquire = 'I';
        private readonly char restock = 'R';
        private readonly char quit = 'Q';
        private readonly string failed = "F";
        private readonly string[] cansList = { "$100", "$50", "$20", "$10", "$5", "$1" };


        Manager man;

        //Init the manager
        public ConsoleIO()
        {
            man = new Manager();
        }

        //Handle user input and output.
        public void Run()
        {
            string cmd;
            string[] parms;
            string[] canAmounts;

            cmd = Console.ReadLine();
            cmd = cmd.ToUpper();
            while(cmd[0] != quit)
            {
                if (cmd[0] == withdraw)
                {
                    cmd = cmd.Remove(0, 2);

                    canAmounts = man.MakeWithdrawal(cmd);
                    OutputAllCans(canAmounts);
                }
                else if (cmd[0] == inquire)
                {
                    cmd = cmd.Remove(0, 2);

                    parms = man.ParseCannisters(cmd);
                    if (parms[0] != failed)
                    {
                        canAmounts = man.InquireCannisters(parms);
                        OutputCans(parms, canAmounts);
                    }
                    else
                        Console.WriteLine(man.InvalidCommand());
                }
                else if (cmd[0] == restock)
                {
                    canAmounts = man.Restock();
                    OutputAllCans(canAmounts);
                }
                else
                    Console.WriteLine(man.InvalidCommand());

                cmd = Console.ReadLine();
                cmd = cmd.ToUpper();
            }
        }

        //Output all of the cannister counts
        private void OutputAllCans(string[] canAmounts)
        {
            try
            {
                Convert.ToInt32(canAmounts[0]);
                for (int i = 0; i < cansList.Length; i++)
                    Console.WriteLine(cansList[i] + " - " + canAmounts[i]);
            }
            catch (FormatException)
            {
                Console.WriteLine(canAmounts[0]);
            }
        }

        //Output specific list of cannisters
        private void OutputCans(string[] cannisters, string[] canAmounts)
        {
            for (int i = 0; i < cannisters.Length; i++)
                Console.WriteLine(cannisters[i] + " - " + canAmounts[i]);

        }
    }
}
