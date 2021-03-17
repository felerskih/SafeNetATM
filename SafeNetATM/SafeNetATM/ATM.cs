using System;
using System.Collections.Generic;
using System.Text;

namespace SafeNetATM
{
    //This class defines an ATM. It is the core backend processing of
    //the program. It keeps track of the cannister (or bill) counts
    //in descending order from 100s to 1s (see comment above 
    //cannisters[] definition0, which is the classes only data member.
    //ATM has a constructor, a method to handle withdrawals, a method
    //to handle supplies inquiries, and a method to return the count of
    //all bill counts (This one was needed to implement testing 
    //correctly.)
    //Author: Henry Felerski
    public class ATM
    {
        private const int MAX_BILL_COUNT = 10;
        
        //Each cannister on an ATM contains a different denomination of
        //paper currency.
        //[0] - 100s, [1] - 50s, [2] - 20s, [3] - 10s, [4] - 5s, [5] - 1s
        private int[] cannisters = new int[6];

        //Restocks the ATM. By doing this it must reset the cannister
        //amounts to 10.
        public ATM()
        {
            for (int i = 0; i < cannisters.Length; i++)
                cannisters[i] = MAX_BILL_COUNT;
        }

        //This method withdraws a provided amount from the ATM using
        //the least amount of bills possible. After, it adjusts the 
        //bill count. If the ATM does not have sufficient funds, 
        //returns -1 in the 0th index. Otherwise, returns the cannister
        //ammounts.
        public int[] Withdraw(int amt)
        {
            int[] tempCounts = cannisters;
            int canAmt;

            while (amt > 0 && tempCounts[0] != -1)
            {   //Haven't fulfilled or rejected transation
                for (int i = 0; i < tempCounts.Length; i++)
                {
                    canAmt = 100 - 50 * (i / 1) - 30 * (i / 2) 
                             - 10 * (i / 3) - 5 * (i / 4) - 4 * (i / 5);
                    if (tempCounts[i] != 0 && amt > canAmt)
                    {
                        tempCounts[i]--;
                        amt -= canAmt;
                        i = tempCounts.Length;
                    }
                    else if (i == tempCounts.Length - 1)
                    {
                        tempCounts = new int[6];
                        tempCounts[0] = -1;
                    }
                }
            }
            if (tempCounts[0] != -1)
                cannisters = tempCounts;
            return tempCounts;
        }

        //This method takes a string of desired bill amounts to be
        //returned. Returns the list of bill counts in descending 
        //order.
        public int[] GetCounts(string[] bills)
        {
            int[] retCans = new int[bills.Length];

            if (retCans.Length == cannisters.Length)
                return GetAllCounts();

            for (int i = 0; i < bills.Length; i++)
            {
                if (bills[i][1] == '1')
                {
                    if (bills[i].Length == 4)
                        retCans[i] = cannisters[0];
                    if (bills[i].Length == 3)
                        retCans[i] = cannisters[3];
                    if (bills[i].Length == 2)
                        retCans[i] = cannisters[5];
                }
                else if (bills[i][1] == '5')
                {
                    if (bills[i].Length == 3)
                        retCans[i] = cannisters[1];
                    if (bills[i].Length == 2)
                        retCans[i] = cannisters[4];
                }
                else if (bills[i][1] == '2')
                    retCans[i] = cannisters[2];
            }

            return retCans;
        }

        //Returns all Cannister counts.
        public int[] GetAllCounts()
        {
            return cannisters;
        }
    }
}
