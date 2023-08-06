namespace ScoreBoard.Interfaces
{
    public interface IMatch
    {
        public void StartMatch();
        public void FinishMatch();
        public void AddGoalToTeam(string teamName);
    }
}
