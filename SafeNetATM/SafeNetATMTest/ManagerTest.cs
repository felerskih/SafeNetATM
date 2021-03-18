using Microsoft.VisualStudio.TestTools.UnitTesting;
using SafeNetATM;

namespace SafeNetATMTest
{
    //A class to test the methods in the Manager class
    //Author: Henry Felerski
    [TestClass]
    class ManagerTest
    {
        [TestMethod]
        public void TestMakeWithdrawalSuccess()
        {
            Manager man = new Manager();
            string[] actual = new string[6];
            string[] expected = { "10", "9", "10", "10", "10", "10" };

            actual = man.MakeWithdrawal("50");

            CollectionAssert.AreEqual(expected, actual);
        }

        public void TestMakeWithdrawalTooMuch()
        {
            Manager man = new Manager();
            string[] actual = new string[6];
            string[] expected = new string[6];

            actual = man.MakeWithdrawal("2000");
            expected[0] = "Failure: Insufficient Funds";

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMakeWithdrawalFailureNoInt()
        {
            Manager man = new Manager();
            string[] actual = new string[6];
            string[] expected = new string[6];

            actual = man.MakeWithdrawal("temp");
            expected[0] = "Failure: Invalid Command";

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMakeWithdrawalFailureLessThanZero()
        {
            Manager man = new Manager();
            string[] actual = new string[6];
            string[] expected = new string[6];

            actual = man.MakeWithdrawal("-1");
            expected[0] = "Failure: Invalid Command";

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestInquireCannistersSuccess()
        {
            Manager man = new Manager();
            string[] actual = new string[1];
            string[] expected = new string[1];

            actual = man.InquireCannisters("$20");
            expected[0] = "10";

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestInquireCannistersFailure()
        {
            Manager man = new Manager();
            string[] actual = new string[1];
            string[] expected = new string[1];

            actual = man.InquireCannisters("$20 bad data");
            expected[0] = "Failure: Invalid Command";

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestInvalidCommand()
        {
            Manager man = new Manager();
            string actual;
            string expected = "Failure: Invalid Command";

            actual = man.InvalidCommand();

            Assert.AreEqual(expected, actual);
        }
    }
}
