using NUnit.Framework;
using ScoreBoard.Models;
using ScoreBoard.Interfaces;
using System;
using FluentAssertions;
using System.ComponentModel.DataAnnotations;

namespace ScoreBoard.Tests
{
    public class MatchTests
    {
        private Match _match; 

        [SetUp]
        public void Setup()
        {
            _match = new Match(new DateTime(2023, 1, 1), "homeTeam", "awayTeam");
        }

        [Test]
        public void CreatedNewMatch_MatchStatusIsScheduled()
        {
            _match.Status.Should().Be(Status.Scheduled);
        }

        [Test]
        public void StartNewMatch_MatchStatusIsInProgress()
        {
            _match.StartMatch();
            _match.Status.Should().Be(Status.InProgress);
        }

        [Test]
        public void FinishMatch_MatchStatusIsFinished()
        {
            _match.StartMatch();
            _match.FinishMatch();
            _match.Status.Should().Be(Status.Finished);
        }

        [Test]
        public void StartAlreadyStartedMatch_ThrowException()
        {
            _match.StartMatch();
            var action = () => _match.StartMatch();
            action.Should().Throw<ValidationException>().WithMessage("Already starded match can't be started");
        }

        [Test]
        public void StartAlreadyFinishedMatch_ThrowException()
        {
            _match.StartMatch();
            _match.FinishMatch();
            var action = () => _match.StartMatch();
            action.Should().Throw<ValidationException>().WithMessage("Already finished match can't be started");
        }

        [Test]
        public void FinishScheduledMatch_ThrowException()
        {
            var action = () => _match.FinishMatch();
            action.Should().Throw<ValidationException>().WithMessage("Not started match can't be finished");
        }

        [Test]
        public void FinishAlreadyFinishedMatch_ThrowException()
        {
            _match.StartMatch();
            _match.FinishMatch();
            var action = () => _match.FinishMatch();
            action.Should().Throw<ValidationException>().WithMessage("Already finished match can't be finished");
        }

        [Test]
        public void AddGoalForScheduledMatch_ThrowException()
        {
            var action = () => _match.AddGoalToTeam("homeTeam");
            action.Should().Throw<ValidationException>().WithMessage("Not possible to add goal for scheduled match");
        }

        [Test]
        public void AddGoalForFinisheddMatch_ThrowException()
        {
            _match.StartMatch();
            _match.FinishMatch();
            var action = () => _match.AddGoalToTeam("homeTeam");
            action.Should().Throw<ValidationException>().WithMessage("Not possible to add goal for not finished match");
        }

        [Test]
        public void AddGoalForNotExistingTeam_ThrowException()
        {
            _match.StartMatch();
            var action = () => _match.AddGoalToTeam("otherTeam");
            action.Should().Throw<ValidationException>().WithMessage("Name of the team is inmccorect");
        }

        [Test]
        public void AddGoalForTeams_ScoreIsCorrect()
        {
            _match.StartMatch();

            _match.AddGoalToTeam("homeTeam");
            _match.AddGoalToTeam("awayTeam");
            _match.AddGoalToTeam("homeTeam");
            _match.AddGoalToTeam("homeTeam");
            _match.AddGoalToTeam("awayTeam");

            _match.TotalScore.Should().Be(5);
            _match.HomeTeam.Score.Should().Be(3);
            _match.AwayTeam.Score.Should().Be(2);
        }
    }
}