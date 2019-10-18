using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpareBank1
{
    [TestClass]
    public class BowlingTests
    {
        [TestMethod]
        public void TestAllStrike_AllStrike_300()
        {
            string inString = "X X X X X X X X X X X X";
            Assert.AreEqual(300, Bowling.CalculateScore(inString));
        }
        [TestMethod]
        public void TestAll9_All9AndMiss_90()
        {
            string inString = "9- 9- 9- 9- 9- 9- 9- 9- 9- 9-";
            Assert.AreEqual(90, Bowling.CalculateScore(inString));
        }
        [TestMethod]
        public void TestAllSpare_All5AndMiss_150()
        {
            string inString = "5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5";
            Assert.AreEqual(150, Bowling.CalculateScore(inString));
        }
        [TestMethod]
        public void TestAllOnes_All1_20()
        {
            string inString = "11 11 11 11 11 11 11 11 11 11";
            Assert.AreEqual(20, Bowling.CalculateScore(inString));
        }
        [TestMethod]
        public void TestMostlyStrikes_AllStrikesButTwoLast_238()
        {
            string inString = "X X X X X X X X 44 44";
            Assert.AreEqual(238, Bowling.CalculateScore(inString));
        }
        [TestMethod]
        public void TestAlternating_AlternatingStrikesAndSpares_238()
        {
            string inString = "X 5/ X 5/ X 5/ X 5/ X 5/ X";
            Assert.AreEqual(200, Bowling.CalculateScore(inString));
        }
    }
}
