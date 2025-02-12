
namespace A1DhruvYadav
{
    public enum PlayerType { HockeyPlayer, BasketballPlayer, BaseballPlayer }

    public abstract class Player
    {
        public PlayerType Type { get; set; }
        public int PlayerId { get; private set; }
        public string PlayerName { get; set; }
        public string TeamName { get; set; }
        public int GamesPlayed { get; set; }
        private static int idCounter = 1;

        public Player(PlayerType type, string name, string team, int games)
        {
            PlayerId = idCounter++;
            Type = type;
            PlayerName = name;
            TeamName = team;
            GamesPlayed = games;
        }

        public abstract int Points();
        // Took help from ChatGPT on how to use override in C#.
        // The screenshots of my prompts and ChatGPT responses are included
        // in the attached Word document.
        public override string ToString()
        {
            return $"{PlayerId,-5} {PlayerName,-15} {TeamName,-15} {GamesPlayed,-5} {Points(),-5}";
        }
    }
}
