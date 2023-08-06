using System.Linq;
using ScoreBoard.Interfaces;

namespace ScoreBoard.Models
{
    public class Board : IBoard
    {
        private List<Match> matches = new List<Match>();

        public void AddMatch(Match match)
        {
            matches.Add(match);
        }

        public IList<Match> GetAcviteMatches()
        {
            return matches.Where(match => match.Status is Status.InProgress or Status.Scheduled).OrderBy(match => match.TotalScore).ThenByDescending(match => match.MatchDate).ToList();
        }
    }
}
