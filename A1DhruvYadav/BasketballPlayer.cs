

namespace A1DhruvYadav
{
    public class BasketballPlayer : Player
    {
        public int FieldGoals { get; set; }
        public int ThreePointers { get; set; }

        public BasketballPlayer(string name, string team, int games, int fieldGoals, int threePointers)
            : base(PlayerType.BasketballPlayer, name, team, games)
        {
            FieldGoals = fieldGoals;
            ThreePointers = threePointers;
        }

        public override int Points()
        {
            return FieldGoals + (2 * ThreePointers);
        }
    }
}
