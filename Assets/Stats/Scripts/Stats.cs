namespace Stats.Scripts
{
    public class Stats
    {
        public Stats(int strength, int intelligence, int dexterity)
        {
            Strength = strength;
            Intelligence = intelligence;
            Dexterity = dexterity;
        }
        
        public int Strength { get; }
        public int Intelligence { get; }
        public int Dexterity { get; }

        public static Stats operator +(Stats left, Stats right) => 
            new(
                left.Strength + right.Strength, 
                left.Intelligence + right.Intelligence, 
                left.Dexterity + right.Dexterity
            );
        
        public static Stats operator *(Stats left, Stats right) => 
            new(
                left.Strength * right.Strength, 
                left.Intelligence * right.Intelligence, 
                left.Dexterity * right.Dexterity
            );

        public override string ToString() => 
            $"Strength: {Strength}; Intelligence: {Intelligence}; Dexterity: {Dexterity};";
    }
}