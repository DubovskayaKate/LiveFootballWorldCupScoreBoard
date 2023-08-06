using ScoreBoard.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ScoreBoard.Models
{
    public class Match : IMatch
    {
        public Guid MatchId { get; private set; }
        public DateTime MatchDateTime { get; private set; }
        public Team HomeTeam { get; private set; }
        public Team AwayTeam { get; private set; }
        public Status Status { get; private set; }

        public int TotalScore => HomeTeam.Score + AwayTeam.Score;

        public Match(DateTime matchDate, string homeTeamName, string awayTeamName)
        {
            MatchId = Guid.NewGuid();
            MatchDateTime = matchDate;
            HomeTeam = new Team(homeTeamName);
            AwayTeam = new Team(awayTeamName);
            Status = Status.Scheduled;
        }

        public void StartMatch()
        {
            switch (Status)
            {
                case Status.Scheduled: Status = Status.InProgress; return;
                case Status.InProgress: throw new ValidationException("Already starded match can't be started");
                case Status.Finished: throw new ValidationException("Already finished match can't be started");
                default: throw new ValidationException("Unhandled status");
            }
        }

        public void FinishMatch()
        {
            switch (Status)
            {
                case Status.Scheduled: throw new ValidationException("Not started match can't be finished");
                case Status.InProgress: Status = Status.Finished; return;
                case Status.Finished: throw new ValidationException("Already finished match can't be finished");
                default: throw new ValidationException("Unhandled status");
            }
        }

        public void UpdateScore(int homeTeamScore, int awayTeamScore)
        {
            switch (Status)
            {
                case Status.Scheduled: throw new ValidationException("Not possible to add goal for scheduled match");
                case Status.InProgress:
                    {
                        HomeTeam.Score = homeTeamScore; ;
                        AwayTeam.Score = awayTeamScore;
                        return;
                    }
                case Status.Finished: throw new ValidationException("Not possible to add goal for not finished match");
                default: throw new ValidationException("Unhandled status");
            }            
        }
    }
}
