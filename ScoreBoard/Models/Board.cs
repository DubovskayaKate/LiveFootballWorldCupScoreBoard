using ScoreBoard.Interfaces;

namespace ScoreBoard.Models
{
    public class Board : IBoard
    {
        private List<Match> matches = new List<Match>();

        public void AddGoalToTeam(int matchId, string teamName)
        {
            throw new NotImplementedException();
        }

        public void AddMatch(Match match)
        {
            throw new NotImplementedException();
        }

        public IList<Match> GetAcviteMatches()
        {
            throw new NotImplementedException();
        }
    }
}
