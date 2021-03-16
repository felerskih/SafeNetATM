using Microsoft.VisualStudio.TestTools.UnitTesting;
using SafeNetATM;

namespace SafeNetATMTest
{
    //A class to test the methods in the ATM class.
    //Author: Henry Felerski
    [TestClass]
    public class ATMTest
    {
        //Tests the only case for the constructor. We need each 
        //cannister count to be 10. Also tests GetAllCounts.
        [TestMethod]
        public void TestConstructor()
        {
            ATM atm = new ATM();
            int[] exCounts = new int[6];
            for (int i = 0; i < exCounts.Length; i++)
                exCounts[i] = 10;
            Assert.AreEqual(exCounts, atm.GetAllCounts());
        }

        //Test Cases for Withdraw
        //1.  Withdrawal over $100
        //2.  Withdrawal equal to $100
        //3.  Withdrawal greater than $50, less than $100
        //4.  Withdrawal equal to $50
        //5.  Withdrawal greater than $20, less than 50$
        //6.  Withdrawal equal to $20
        //7.  Withdrawal greater than $10, less than $20
        //8.  Withdrawal equal to $10
        //9.  Withdrawal greater than $5, less than $10
        //10. Withdrawal equal to $5
        //11. Withdrawal greater than $1, less than $5
        //12. Withdrawal equal to $1
        //13. Withdrawal with no money in the ATM
        //14. Withdrawal of small amount not possible due to not enough small bills
        //15. Withdrawal of $100, but no $100s
        //16. Withdrawal of $50, but no $50s
        //17. Withdrawal of $20, but no $20s
        //18. Withdrawal of $10, but no $10s
        //19. Withdrawal of $5, but no $5s
        //20. Withdrawal of $100, no $10, $20, $50, $100
        //21. Withdrawal of $50, no $5, $10, $20, $50
        //22. Withdrawal of $20, no $5, $10, $20
        //23. Withdrawal of $10, no $1, $5, $10
        //24. Withdrawal of $5, no $1, $5
        //25. withdrawal of $1, no $1
        //These test cases handle most edge cases and ensures the logic
        //works for multiple withdrawal amounts without testing every
        //single value.

        //1.  Withdrawal over $100
        //Should have 9 bills in the 100s and 1s cannisters, 10 in the rest
        [TestMethod]
        public void TestWithdrawOverOneHundred()
        {
            ATM atm = new ATM();
            int[] exCounts = new int[6];
            int[] acCounts = new int[6];

            acCounts = atm.Withdraw(101);
            exCounts[0] = 9;
            exCounts[5] = 9;
            for (int i = 0; i < exCounts.Length - 1; i++)
                exCounts[i] = 10;

            Assert.AreEqual(exCounts, acCounts);
        }

        //2.  Withdrawal equal to $100
        //Should have 9 bills in the 100s cannister, 10 in the rest
        [TestMethod]
        public void TestWithdrawOneHundred()
        {
            ATM atm = new ATM();
            int[] exCounts = new int[6];
            int[] acCounts = new int[6];

            acCounts = atm.Withdraw(100);
            exCounts[0] = 9;
            for (int i = 1; i < exCounts.Length; i++)
                exCounts[i] = 10;

            Assert.AreEqual(exCounts, acCounts);
        }

        //3.  Withdrawal greater than $50, less than $100
        //Should have 9 bills in the 50s and 1s cannister, 10 in the rest
        [TestMethod]
        public void TestWithdrawOverFifty()
        {
            ATM atm = new ATM();
            int[] exCounts = new int[6];
            int[] acCounts = new int[6];

            acCounts = atm.Withdraw(51);
            for (int i = 0; i < exCounts.Length; i++)
                exCounts[i] = 10 - (i / 1) + (i / 2) - (i / 5);

            Assert.AreEqual(exCounts, acCounts);
        }

        //4.  Withdrawal equal to $50
        //Should have 9 bills in the 50s cannister, 10 in the rest
        [TestMethod]
        public void TestWithdrawFifty()
        {
            ATM atm = new ATM();
            int[] exCounts = new int[6];
            int[] acCounts = new int[6];

            acCounts = atm.Withdraw(50);
            for (int i = 0; i < exCounts.Length; i++)
                exCounts[i] = 10 - (i / 1) + (i / 2);

            Assert.AreEqual(exCounts, acCounts);
        }

        //5.  Withdrawal greater than $20, less than 50$
        //Should have 9 bills in 20s and 1s cannister, 10 in the rest
        [TestMethod]
        public void TestWithdrawOverTwenty()
        {
            ATM atm = new ATM();
            int[] exCounts = new int[6];
            int[] acCounts = new int[6];

            acCounts = atm.Withdraw(21);
            for (int i = 0; i < exCounts.Length - 1; i++)
                exCounts[i] = 10 - (i / 2) + (i / 3) - (i / 5);

            Assert.AreEqual(exCounts, acCounts);
        }

        //6.  Withdrawal equal to $20
        //Should have 9 bills in the 20s cannister, 10 in the rest
        [TestMethod]
        public void TestWithdrawTwenty()
        {
            ATM atm = new ATM();
            int[] exCounts = new int[6];
            int[] acCounts = new int[6];

            acCounts = atm.Withdraw(20);
            for (int i = 0; i < exCounts.Length; i++)
                exCounts[i] = 10 - (i / 2) + (i / 3);

            Assert.AreEqual(exCounts, acCounts);
        }

        //7.  Withdrawal greater than $10, less than $20
        //Should be 9 in the 10s and 1s cannister, 10 in the rest
        [TestMethod]
        public void TestWithdrawOverTen()
        {
            ATM atm = new ATM();
            int[] exCounts = new int[6];
            int[] acCounts = new int[6];

            acCounts = atm.Withdraw(11);
            for (int i = 0; i < exCounts.Length - 1; i++)
                exCounts[i] = 10 - (i / 3) + (i / 4) - (i / 5);

            Assert.AreEqual(exCounts, acCounts);
        }

        //8.  Withdrawal equal to $10
        //Should be 9 bills in 10s cannister, 10 in the rest
        [TestMethod]
        public void TestWithdrawTen()
        {
            ATM atm = new ATM();
            int[] exCounts = new int[6];
            int[] acCounts = new int[6];

            acCounts = atm.Withdraw(10);
            for (int i = 0; i < exCounts.Length; i++)
                exCounts[i] = 10 - (i / 3) + (i / 4);

            Assert.AreEqual(exCounts, acCounts);
        }

        //9.  Withdrawal greater than $5, less than $10
        //Should be 9 bills in 5s and 1s cannister, 10 in the rest
        [TestMethod]
        public void TestWithdrawOverFive()
        {
            ATM atm = new ATM();
            int[] exCounts = new int[6];
            int[] acCounts = new int[6];

            acCounts = atm.Withdraw(6);
            for (int i = 0; i < exCounts.Length; i++)
                exCounts[i] = 10 - (i/4);

            Assert.AreEqual(exCounts, acCounts);
        }
        //10. Withdrawal equal to $5
        //Should be 9 bills in the 5s cannister, 10 in the rest
        [TestMethod]
        public void TestWithdrawFive()
        {
            ATM atm = new ATM();
            int[] exCounts = new int[6];
            int[] acCounts = new int[6];

            acCounts = atm.Withdraw(5);
            for (int i = 0; i < exCounts.Length; i++)
                exCounts[i] = 10 - (i / 4) + (i / 5);

            Assert.AreEqual(exCounts, acCounts);
        }

        //11. Withdrawal greater than $1, less than $5
        //Should be 8 bills in 1s cannister, 10 in the rest
        [TestMethod]
        public void TestWithdrawOverOne()
        {
            ATM atm = new ATM();
            int[] exCounts = new int[6];
            int[] acCounts = new int[6];

            acCounts = atm.Withdraw(2);
            for (int i = 0; i < exCounts.Length; i++)
                exCounts[i] = 10 - (2 * (i / 5));

            Assert.AreEqual(exCounts, acCounts);
        }

        //12. Withdrawal equal to $1
        //Should be 9 bills in 1s cannister, 10 in the rest
        [TestMethod]
        public void TestWithdrawOne()
        {
            ATM atm = new ATM();
            int[] exCounts = new int[6];
            int[] acCounts = new int[6];

            acCounts = atm.Withdraw(1);
            for (int i = 0; i < exCounts.Length; i++)
                exCounts[i] = 10 - (i / 5);

            Assert.AreEqual(exCounts, acCounts);
        }

        //13. Withdrawal with no money in the ATM
        //Should return -1
        [TestMethod]
        public void TestWithdrawNoMoney()
        {
            ATM atm = new ATM();
            int[] exCounts = new int[6];
            int[] acCounts = new int[6];

            atm.Withdraw(1860);
            acCounts = atm.Withdraw(50);
            exCounts[0] = -1;

            Assert.AreEqual(exCounts, acCounts);
        }

        //14. Withdrawal of small amount not possible due to not enough small bills
        //Should return -1
        [TestMethod]
        public void TestWithdrawNoSmallBills()
        {
            ATM atm = new ATM();
            int[] exCounts = new int[6];
            int[] acCounts = new int[6];

            atm.Withdraw(55);
            acCounts = atm.Withdraw(6);
            exCounts[0] = -1;

            Assert.AreEqual(exCounts, acCounts);
        }

        //15. Withdrawal of $100, but no $100s
        //Should be 0 bills in 100s, 8 in 50s cannister, 10 in the rest
        [TestMethod]
        public void TestWithdrawNoHundred()
        {
            ATM atm = new ATM();
            int[] exCounts = new int[6];
            int[] acCounts = new int[6];

            atm.Withdraw(1000);
            acCounts = atm.Withdraw(100);
            exCounts[0] = 0;
            acCounts[1] = 8;
            for (int i = 2; i < exCounts.Length; i++)
                exCounts[i] = 10;

            Assert.AreEqual(exCounts, acCounts);
        }

        //16. Withdrawal of $50, but no $50s
        //Should be 0 bills in 50s, 8 in 20s, 9 in 5s, 10 in the rest
        [TestMethod]
        public void TestWithdrawNoFifty()
        {
            ATM atm = new ATM();
            int[] exCounts = new int[6];
            int[] acCounts = new int[6];
            for (int i = 0; i < 10; i++)
                atm.Withdraw(50);
            acCounts = atm.Withdraw(50);
            exCounts[0] = 10;
            exCounts[1] = 0;
            exCounts[2] = 8;
            for (int i = 3; i < exCounts.Length; i++)
                exCounts[i] = 10 - (i / 4) + (i + 5);

            Assert.AreEqual(exCounts, acCounts);
        }

        //17. Withdrawal of $20, but no $20s
        //Should be 0 bills in Twentys, 8 in 10s cannister, 10 in the rest
        [TestMethod]
        public void TestWithdrawNoTwenty()
        {
            ATM atm = new ATM();
            int[] exCounts = new int[6];
            int[] acCounts = new int[6];

            for (int i = 0; i < 10; i++)
                atm.Withdraw(20);
            acCounts = atm.Withdraw(20);
            exCounts[0] = 10;
            exCounts[1] = 10;
            exCounts[2] = 0;
            exCounts[3] = 8;
            for (int i = 4; i < exCounts.Length; i++)
                exCounts[i] = 10 - (i / 4) + (i + 5);

            Assert.AreEqual(exCounts, acCounts);
        }

        //18. Withdrawal of $10, but no $10s
        //Should be 0 in 10s, 8 in 5s cannister, 10 in the rest
        [TestMethod]
        public void TestWithdrawNoTen()
        {
            ATM atm = new ATM();
            int[] exCounts = new int[6];
            int[] acCounts = new int[6];

            for (int i = 0; i < 10; i++)
                atm.Withdraw(10);
            acCounts = atm.Withdraw(10);
            exCounts[0] = 10;
            exCounts[1] = 10;
            exCounts[2] = 10;
            exCounts[3] = 0;
            exCounts[4] = 8;
            exCounts[5] = 10;

            Assert.AreEqual(exCounts, acCounts);
        }

        //19. Withdrawal of $5, but no $5s
        //Should be 0 bills in 5s, 5 in 1s cannister, 10 in the rest
        [TestMethod]
        public void TestWithdrawNoFive()
        {
            ATM atm = new ATM();
            int[] exCounts = new int[6];
            int[] acCounts = new int[6];

            for (int i = 0; i < 10; i++)
                atm.Withdraw(5);
            acCounts = atm.Withdraw(5);
            exCounts[0] = 10;
            exCounts[1] = 10;
            exCounts[2] = 10;
            exCounts[3] = 10;
            exCounts[4] = 0;
            exCounts[5] = 5;

            Assert.AreEqual(exCounts, acCounts);
        }

        //20. Withdrawal of $100, no $10, $20, $50, $100
        //Should return -1, out of bills
        [TestMethod]
        public void TestWithdrawNoHundredPossible()
        {
            ATM atm = new ATM();
            int[] exCounts = new int[6];
            int[] acCounts = new int[6];

            atm.Withdraw(1900); //All 100s, 50s, 20s, 10s
            acCounts = atm.Withdraw(100);
            exCounts[0] = -1;

            Assert.AreEqual(exCounts, acCounts);
        }

        //21. Withdrawal of $50, no $5, $10, $20, $50
        //Should return -1, out of bills
        [TestMethod]
        public void TestWithdrawNoFiftyPossible()
        {
            ATM atm = new ATM();
            int[] exCounts = new int[6];
            int[] acCounts = new int[6];

            for (int i = 0; i < 10; i++)
            {
                atm.Withdraw(50);
                atm.Withdraw(20);
                atm.Withdraw(10);
                atm.Withdraw(5);
            }
            acCounts = atm.Withdraw(50);
            exCounts[0] = -1;

            Assert.AreEqual(exCounts, acCounts);
        }

        //22. Withdrawal of $20, no $5, $10, $20
        //Should return -1, out of bills
        [TestMethod]
        public void TestWithdrawNoTwentyPossible()
        {
            ATM atm = new ATM();
            int[] exCounts = new int[6];
            int[] acCounts = new int[6];

            for (int i = 0; i < 10; i++)
            {
                atm.Withdraw(20);
                atm.Withdraw(10);
                atm.Withdraw(5);
            }
            acCounts = atm.Withdraw(20);
            exCounts[0] = -1;

            Assert.AreEqual(exCounts, acCounts);
        }

        //23. Withdrawal of $10, no $1, $5, $10
        //Should return -1, out of bills
        [TestMethod]
        public void TestWithdrawNoTenPossible()
        {
            ATM atm = new ATM();
            int[] exCounts = new int[6];
            int[] acCounts = new int[6];

            for (int i = 0; i < 10; i++)
            {
                atm.Withdraw(10);
                atm.Withdraw(5);
                atm.Withdraw(1);
            }
            acCounts = atm.Withdraw(10);
            exCounts[0] = -1;

            Assert.AreEqual(exCounts, acCounts);
        }

        //24. Withdrawal of $5, no $1, $5
        //Should return -1, out of bills
        [TestMethod]
        public void TestWithdrawNoFivePossible()
        {
            ATM atm = new ATM();
            int[] exCounts = new int[6];
            int[] acCounts = new int[6];

            for (int i = 0; i < 10; i++)
            {
                atm.Withdraw(5);
                atm.Withdraw(1);
            }
            acCounts = atm.Withdraw(5);
            exCounts[0] = -1;

            Assert.AreEqual(exCounts, acCounts);
        }

        //25. withdrawal of $1, no $1
        //Should return -1, out of bills
        [TestMethod]
        public void TestWithdrawNoOnePossible()
        {
            ATM atm = new ATM();
            int[] exCounts = new int[6];
            int[] acCounts = new int[6];

            for (int i = 0; i < 10; i++)
                atm.Withdraw(1);
            acCounts = atm.Withdraw(1);
            exCounts[0] = -1;

            Assert.AreEqual(exCounts, acCounts);
        }

        //Test Cases for GetCounts
        //1. Get All counts, in order
        //2. Get 5 counts, in order
        //3. Get 4 counts, in order
        //4. Get 3 counts, in order
        //5. Get 2 counts, in order
        //6. Get 1 count
        //It's hard to differentiate between single cannisters being returned

        //1. Get All counts, in order
        [TestMethod]
        public void TestGetCountsNoAll()
        {
            ATM atm = new ATM();
            int[] exCounts = new int[6];
            int[] acCounts = new int[6];
            string[] toRetrieve = ["$100", "$50", "$20", "$10", "$5", "$1"];

            atm.Withdraw(50);
            atm.Withdraw(20);
            atm.Withdraw(20);
            atm.Withdraw(10);
            atm.Withdraw(10);
            atm.Withdraw(10);
            atm.Withdraw(5);
            atm.Withdraw(5);
            atm.Withdraw(5);
            atm.Withdraw(5);
            atm.Withdraw(1);
            atm.Withdraw(1);
            atm.Withdraw(1);
            atm.Withdraw(1);
            atm.Withdraw(1);
            acCounts = atm.GetCounts(toRetrieve);
            for (int i = 0; i < exCounts.Length; i++)
                exCounts[1] = 10 - i;

            Assert.AreEqual(exCounts, acCounts);
        }

        //2. Get 5 counts, in order
        [TestMethod]
        public void TestGetCountsFive()
        {
            ATM atm = new ATM();
            int[] exCounts = new int[5];
            int[] acCounts = new int[5];
            string[] toRetrieve = ["$50", "$20", "$10", "$5", "$1"];

            atm.Withdraw(50);
            atm.Withdraw(20);
            atm.Withdraw(20);
            atm.Withdraw(10);
            atm.Withdraw(10);
            atm.Withdraw(10);
            atm.Withdraw(5);
            atm.Withdraw(5);
            atm.Withdraw(5);
            atm.Withdraw(5);
            atm.Withdraw(1);
            atm.Withdraw(1);
            atm.Withdraw(1);
            atm.Withdraw(1);
            atm.Withdraw(1);
            acCounts = atm.GetCounts(toRetrieve);
            for (int i = 0; i < exCounts.Length; i++)
                exCounts[1] = 10 - i - 1;

            Assert.AreEqual(exCounts, acCounts);
        }

        //3. Get 4 counts, in order
        [TestMethod]
        public void TestGetCountsFour()
        {
            ATM atm = new ATM();
            int[] exCounts = new int[4];
            int[] acCounts = new int[4];
            string[] toRetrieve = ["$20", "$10", "$5", "$1"];

            atm.Withdraw(20);
            atm.Withdraw(20);
            atm.Withdraw(10);
            atm.Withdraw(10);
            atm.Withdraw(10);
            atm.Withdraw(5);
            atm.Withdraw(5);
            atm.Withdraw(5);
            atm.Withdraw(5);
            atm.Withdraw(1);
            atm.Withdraw(1);
            atm.Withdraw(1);
            atm.Withdraw(1);
            atm.Withdraw(1);
            acCounts = atm.GetCounts(toRetrieve);
            for (int i = 0; i < exCounts.Length; i++)
                exCounts[1] = 10 - i - 2;

            Assert.AreEqual(exCounts, acCounts);
        }

        //4. Get 3 counts, in order
        [TestMethod]
        public void TestGetCountsThree()
        {
            ATM atm = new ATM();
            int[] exCounts = new int[3];
            int[] acCounts = new int[3];
            string[] toRetrieve = ["$10", "$5", "$1"];

            atm.Withdraw(10);
            atm.Withdraw(10);
            atm.Withdraw(10);
            atm.Withdraw(5);
            atm.Withdraw(5);
            atm.Withdraw(5);
            atm.Withdraw(5);
            atm.Withdraw(1);
            atm.Withdraw(1);
            atm.Withdraw(1);
            atm.Withdraw(1);
            atm.Withdraw(1);
            acCounts = atm.GetCounts(toRetrieve);
            for (int i = 0; i < exCounts.Length; i++)
                exCounts[1] = 10 - i - 3;

            Assert.AreEqual(exCounts, acCounts);
        }

        //5. Get 2 counts, in order
        [TestMethod]
        public void TestGetCountsTwo()
        {
            ATM atm = new ATM();
            int[] exCounts = new int[2];
            int[] acCounts = new int[2];
            string[] toRetrieve = ["$5", "$1"];

            atm.Withdraw(5);
            atm.Withdraw(5);
            atm.Withdraw(5);
            atm.Withdraw(5);
            atm.Withdraw(1);
            atm.Withdraw(1);
            atm.Withdraw(1);
            atm.Withdraw(1);
            atm.Withdraw(1);
            acCounts = atm.GetCounts(toRetrieve);
            for (int i = 0; i < exCounts.Length; i++)
                exCounts[1] = 10 - i - 4;

            Assert.AreEqual(exCounts, acCounts);
        }

        //6. Get 1 count
        [TestMethod]
        public void TestGetCountsOne()
        {
            ATM atm = new ATM();
            int[] exCounts = new int[1];
            int[] acCounts = new int[1];
            string[] toRetrieve = ["$1"];

            atm.Withdraw(1);
            atm.Withdraw(1);
            atm.Withdraw(1);
            atm.Withdraw(1);
            atm.Withdraw(1);
            acCounts = atm.GetCounts(toRetrieve);
            for (int i = 0; i < exCounts.Length; i++)
                exCounts[1] = 10 - i - 5;

            Assert.AreEqual(exCounts, acCounts);
        }
    }
}
