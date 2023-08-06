using System;
using System.Collections.Generic;
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
        public void AddMatch_MatchisInTheList()
        {
            var match = new Match(new DateTime(2023, 1, 1), "homeTeam", "awayTeam");
            _board.AddMatch(match);
            var activeMatches = _board.GetAcviteMatches();

            activeMatches.Should().HaveCount(1);
            activeMatches.First().Should().Be(match);
        }

        [Test]
        public void AddMultipleMatches_MatchesAreInTheList()
        {
            var match = new Match(new DateTime(2023, 1, 1), "homeTeam", "awayTeam");
            var match2 = new Match(new DateTime(2023, 1, 2), "homeTeam-2", "awayTeam-2");

            _board.AddMatch(match2);
            _board.AddMatch(match);

            var activeMatches = _board.GetAcviteMatches();

            activeMatches.Should().HaveCount(2);
            activeMatches.First().Should().Be(match);
        }

        [Test]
        public void AddMatch_FinishMatch_MatchAreNotInTheList()
        {
            var match = new Match(new DateTime(2023, 1, 1), "homeTeam", "awayTeam");

            _board.AddMatch(match);

            match.StartMatch();
            match.FinishMatch();

            var activeMatches = _board.GetAcviteMatches();

            activeMatches.Should().HaveCount(0);
        }

        [Test]
        public void AddMultipleMatches_MatchAreInTheListInCorrectOrder()
        {
            var match = new Match(new DateTime(2023, 1, 1), "homeTeam", "awayTeam");
            var match2 = new Match(new DateTime(2023, 1, 2), "homeTeam", "awayTeam");
            var match3 = new Match(new DateTime(2023, 1, 1), "homeTeam", "awayTeam");

            match.StartMatch();
            match.AddGoalToTeam("homeTeam");
            match.AddGoalToTeam("homeTeam");
            match.AddGoalToTeam("awayTeam");

            match2.StartMatch();
            match2.AddGoalToTeam("homeTeam");
            match2.AddGoalToTeam("homeTeam");
            match2.AddGoalToTeam("awayTeam");

            match3.StartMatch();
            match3.AddGoalToTeam("homeTeam");
            match3.AddGoalToTeam("awayTeam");

            _board.AddMatch(match);
            _board.AddMatch(match2);
            _board.AddMatch(match3);

            var activeMatches = _board.GetAcviteMatches();

            activeMatches.Should().HaveCount(3);
            activeMatches.Should().BeEquivalentTo(new List<Match> { match2, match, match3 });
        }
    }
}