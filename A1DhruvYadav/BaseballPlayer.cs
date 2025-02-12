

namespace A1DhruvYadav
{
    public class BaseballPlayer : Player
    {
        public int Runs { get; set; }
        public int HomeRuns { get; set; }

        public BaseballPlayer(string name, string team, int games, int runs, int homeRuns)
            : base(PlayerType.BaseballPlayer, name, team, games)
        {
            Runs = runs;
            HomeRuns = homeRuns;
        }

        public override int Points()
        {
            return Runs + (2 * HomeRuns);
        }
    }
}
