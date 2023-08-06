namespace ScoreBoard.Models
{
    public class Team
    {
        public string Name { get; set; }
        public int Score {  get; set; }

        public Team(string name)
        {
            Name = name;
            Score = 0;
        }

        public bool AddGoalToTeam(string teamName)
        {
            if (Name == teamName)
            {
                Score++;
                return true;
            }
            return false;
        }
    }
}
