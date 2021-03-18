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

        }

        //Parses and validates the command paramaters. If so, returns
        //the requested cannister counts. Otherwise, returns the error
        //string in the 0th index.
        public string[] InquireCannisters(string inquiry)
        {

        }

        //Calls the ATM to restock. Returns all cannister counts.
        public string[] Restock()
        {

        }

        //Returns the Invalid Command error message.
        public string InvalidCommand()
        {
            
        }
    }
}
