namespace ScoreBoard.Interfaces
{
    public interface IMatch
    {
        public void StartMatch();
        public void FinishMatch();
        public void UpdateScore(int homeTeamScore, int awayTeamScore);
    }
}
