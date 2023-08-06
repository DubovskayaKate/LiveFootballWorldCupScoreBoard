using NUnit.Framework;
using ScoreBoard.Models;
using ScoreBoard.Interfaces;

namespace ScoreBoard.Tests
{
    public class MatchTests
    {
        private IMatch _match; 

        [SetUp]
        public void Setup()
        {
            _match = new Match(new DateTime(2023, 1, 1), "homeTeam", "awayTeam");
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}