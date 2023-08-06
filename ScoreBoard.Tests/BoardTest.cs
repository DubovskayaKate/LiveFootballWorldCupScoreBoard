using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using ScoreBoard.Interfaces;
using ScoreBoard.Models;

namespace ScoreBoardTests
{
    public class BoardTest
    {
        private IBoard _board;

        [SetUp]
        public void Setup()
        {
            _board = new Board();
        }

        [Test]
        public void Board_AddMatch_MatchisInTheList()
        {
            var match = new Match(new DateTime(2023, 1, 1), "homeTeam", "awayTeam");
            _board.AddMatch(match);
            var activeMatches = _board.GetAcviteMatches();

            activeMatches.Should().HaveCount(1);
            activeMatches.First().Should().Be(match);
        }

        [Test]
        public void Board_AddMultipleMatches_MatchesAreInTheList()
        {
            var match = new Match(new DateTime(2023, 1, 1), "homeTeam", "awayTeam");
            var match2 = new Match(new DateTime(2023, 1, 2), "homeTeam-2", "awayTeam-2");

            _board.AddMatch(match2);
            _board.AddMatch(match);

            var activeMatches = _board.GetAcviteMatches();

            activeMatches.Should().HaveCount(2);
            activeMatches.First().Should().Be(match);
        }
    }
}