using ScoreBoard.Interfaces;

namespace ScoreBoard.Models
{
    public class Match : IMatch
    {
        public Guid MatchId { get; private set; }
        public DateTime MatchDate { get; private set; }
        public Team HomeTeam { get; private set; }
        public Team AwayTeam { get; private set; }
        public Status Status { get; private set; }

        public int TotalSctore => HomeTeam.Score + AwayTeam.Score;

        public Match(DateTime matchDate, string homeTeamName, string awayTeamName)
        {
            MatchId = Guid.NewGuid();
            MatchDate = matchDate;
            HomeTeam = new Team(homeTeamName);
            AwayTeam = new Team(awayTeamName);
            Status = Status.Scheduled;
        }

        public void StartMatch()
        {
            throw new NotImplementedException();
        }

        public void FinishMatch()
        {
            throw new NotImplementedException();
        }

        public void AddGoalToTeam(string teamName)
        {
            throw new NotImplementedException();
        }
    }
}
