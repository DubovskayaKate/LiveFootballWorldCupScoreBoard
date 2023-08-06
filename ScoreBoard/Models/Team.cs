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
    }
}
