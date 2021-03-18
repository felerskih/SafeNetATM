using System;
using System.Collections.Generic;
using System.Text;

namespace SafeNetATM
{
    //Class handles requests from the front end process and makes
    //requests to the ATM. Managers main responsibility is to validate
    //input. Contains a string array to compare the cannister IDs, a
    //couple of strings for error msgs, and an atm instance.
    //Author: Henry Felerski
    public class Manager
    {
        private readonly string[] cansList = { "$100", "$50", "$20", "$10", "$5", "$1" };
        private readonly string InvalidAmt = "Failure: Insufficient Funds";
        private readonly string InvalidCmd = "Failure: Invalid Command";
        private ATM atm;

        //Constructs an ATM object
        public Manager()
        {
            atm = new ATM();
        }

        //Validates the provided amount is an integer that is greater
        //than 0. If so, returns the cannister counts. Otherwise,
        //returns the error string in the 0th index.
        public string[] MakeWithdrawal(string strAmt)
        {
            int amt;
            string[] canCounts = new string[6];
            int[] returnedCounts = new int[6];

            try
            {
                amt = Convert.ToInt32(strAmt);
                if (amt < 0)
                    throw new ArgumentException();
                returnedCounts = atm.Withdraw(amt);
                if (returnedCounts[0] == -1)
                    canCounts[0] = InvalidAmt;
                else
                {
                    for (int i = 0; i < returnedCounts.Length; i++)
                        canCounts[i] = Convert.ToString(returnedCounts[i]);
                }
            }
            catch (Exception ex)
            {//Handle expected Exceptions, throw on the rest
                if (ex is FormatException 
                    || ex is ArgumentException)
                    canCounts[0] = InvalidCmd;
                else
                    throw;
            }

            return canCounts;
        }

        //Parses and validates the command paramaters. If so, returns
        //the requested cannister counts. Otherwise, returns the error
        //string in the 0th index.
        public string[] ParseCanisters(string inquiry)
        {
            bool isIn = false;
            string[] toPass;
            toPass = inquiry.Split(' ');

            if (toPass.Length > 6)
            {
                toPass = new string[1];
                toPass[0] = InvalidCmd;
                return toPass;
            }

            for (int i = 0; i < toPass.Length; i++)
            {
                for (int j = 0; j < cansList.Length; j++)
                {
                    if (toPass[i] == cansList[j])
                        isIn = true;
                }
                if (isIn == false)
                {
                    toPass = new string[1];
                    toPass[0] = InvalidCmd;
                    return toPass;
                }
                isIn = false;
            }

            return toPass;
        }
        
        //Processes the params of the Inquiry command. Returns the
        //desired canister counts.
        public string[] InquireCanisters(string[] toPass)
        {
            string[] canCounts;
            int[] returnedCounts;

            canCounts = new string[toPass.Length];
            returnedCounts = new int[toPass.Length];

            returnedCounts = atm.GetCounts(toPass);
            for (int i = 0; i < returnedCounts.Length; i++)
                canCounts[i] = Convert.ToString(returnedCounts[i]);

            return canCounts;
        }

        //Calls the ATM to restock. Returns all cannister counts.
        public string[] Restock()
        {
            string[] canCounts = new string[6];
            int[] returnedCounts = new int[6];

            atm = new ATM();
            returnedCounts = atm.GetAllCounts();
            for (int i = 0; i < returnedCounts.Length; i++)
                canCounts[i] = Convert.ToString(returnedCounts[i]);
            return canCounts;
        }

        //Returns the Invalid Command error message.
        public string InvalidCommand()
        {
            return InvalidCmd;
        }
    }
}
