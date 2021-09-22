namespace ValueObjects
{
    // avoid using nullable for a third state
    public class PirateMood
    {
        private readonly Moods moods;

        public enum Moods
        {
            Hungry,
            Drunken, 
            HungryAndDrunken
        }

        private PirateMood(Moods moods)
        {
            this.moods = moods;
        }

        // we can have speaking checks
        public Moods Mood => this.moods;

        public bool IsHungry => this.moods == Moods.Hungry || this.moods == Moods.HungryAndDrunken;

        public bool IsDrunken => this.moods == Moods.Drunken || this.moods == Moods.HungryAndDrunken;

        // even business speak
        public bool IsInBadMood => this.moods == Moods.HungryAndDrunken;


        public static PirateMood Drunken() => new PirateMood(Moods.Drunken);

        public static PirateMood Hungry() => new PirateMood(Moods.Hungry);

        public static PirateMood HungryAndDrunken() => new PirateMood(Moods.HungryAndDrunken);

        // no operator overload in this example
    }
}
