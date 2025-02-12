

namespace A1DhruvYadav
{
    public class HockeyPlayer : Player
    {
        public int Assists { get; set; }
        public int Goals { get; set; }

        public HockeyPlayer(string name, string team, int games, int assists, int goals)
            : base(PlayerType.HockeyPlayer, name, team, games)
        {
            Assists = assists;
            Goals = goals;
        }

        public override int Points()
        {
            return Assists + (2 * Goals);
        }
    }
}
