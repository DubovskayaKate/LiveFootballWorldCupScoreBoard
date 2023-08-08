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
            match.StartMatch();

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

            match.StartMatch();
            match2.StartMatch();

            var activeMatches = _board.GetAcviteMatches();

            activeMatches.Should().HaveCount(2);
            activeMatches.Should().BeEquivalentTo(new List<Match> { match2, match });
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
        public void AddMatch_ScheduledMatch_MatchAreNotInTheList()
        {
            var match = new Match(new DateTime(2023, 1, 1), "homeTeam", "awayTeam");

            _board.AddMatch(match);

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
            match.UpdateScore(1, 0);
            match.UpdateScore(2, 0);
            match.UpdateScore(2, 1);

            match2.StartMatch();
            match.UpdateScore(1, 0);
            match.UpdateScore(2, 0);
            match.UpdateScore(2, 1);

            match3.StartMatch();
            match.UpdateScore(1, 0);
            match.UpdateScore(1, 1);

            _board.AddMatch(match);
            _board.AddMatch(match2);
            _board.AddMatch(match3);

            var activeMatches = _board.GetAcviteMatches();

            activeMatches.Should().HaveCount(3);
            activeMatches.Should().BeEquivalentTo(new List<Match> { match2, match, match3 });
        }

        [Test]
        public void AddMultipleMatchesToBoard_MatchAreInTheListInCorrectOrder()
        {
            var match = new Match(new DateTime(2023, 1, 1), "Mexico", "Canada");
            var match2 = new Match(new DateTime(2023, 1, 2), "Spain", "Brazil");
            var match3 = new Match(new DateTime(2023, 1, 3), "Germany", "France");
            var match4 = new Match(new DateTime(2023, 1, 4), "Uruguay", "Italy");
            var match5 = new Match(new DateTime(2023, 1, 5), "Argentina", "Australia");

            _board.AddMatch(match);
            _board.AddMatch(match2);
            _board.AddMatch(match3);
            _board.AddMatch(match4);
            _board.AddMatch(match5);

            match.StartMatch();
            match.UpdateScore(0, 5);

            match2.StartMatch();
            match.UpdateScore(10, 2);

            match3.StartMatch();
            match.UpdateScore(2, 2);

            match4.StartMatch();
            match.UpdateScore(6, 6);

            match5.StartMatch();
            match.UpdateScore(3, 1);

            var activeMatches = _board.GetAcviteMatches();

            activeMatches.Should().HaveCount(5);
            activeMatches.Should().BeEquivalentTo(new List<Match> { match4, match2, match, match5, match3 });
        }
    }
}