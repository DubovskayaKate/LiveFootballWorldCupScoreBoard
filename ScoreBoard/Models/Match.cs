using ScoreBoard.Interfaces;

namespace ScoreBoard.Models
{
    public class Match : IMatch
    {
        public int MatchId { get; private set; }
        public DateTime MatchDate { get; private set; }
        public Team HomeTeam { get; private set; }
        public Team AwayTeam { get; private set; }
        public Status Status { get; private set; }

        public int TotalSctore => HomeTeam.Score + AwayTeam.Score;

        public Match(DateTime matchDate, string homeTeamName, string awayTeamName)
        {
            MatchId = 0;
            MatchDate = matchDate;
            HomeTeam = new Team(homeTeamName);
            AwayTeam = new Team(awayTeamName);
            Status = Status.Scheduled;
        }

        public void StartMatch(int matchId)
        {
            throw new NotImplementedException();
        }

        public void FinishMatch(int matchId)
        {
            throw new NotImplementedException();
        }
    }
}
