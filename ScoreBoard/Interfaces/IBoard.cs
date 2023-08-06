using ScoreBoard.Models;

namespace ScoreBoard.Interfaces
{
    public interface IBoard
    {
        public void AddMatch(Match match);
        public IList<Match> GetAcviteMatches();
        public void AddGoalToTeam(int matchId, string teamName);
    }
}
