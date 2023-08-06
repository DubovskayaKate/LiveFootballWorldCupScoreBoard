namespace ScoreBoard.Interfaces
{
    public interface IMatch
    {
        public void StartMatch(int matchId);
        public void FinishMatch(int matchId);
    }
}
