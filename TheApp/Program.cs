namespace TheApp
{
    using System;

    using ValueObjects;

    public class Program
    {
        public static void Main()
        {
            var pirate = new Pirate();
            pirate.Drink();

            if (PirateWantsTreasure(pirate))
            {
                FindTreasure(pirate);
            }
            else
            {
                Shoot(pirate);
            }
        }

        // TODO mention structs for performance (but no inheritence)

        // use value object to model stat and access
        private static bool PirateWantsTreasure(Pirate pirate)
        {
            // nice to uses
            if (pirate.PirateMood.IsDrunken)
            {
                return true;
            }

            // a derived mood
            if (pirate.PirateMood.IsInBadMood)
            {
                return false;
            }

            return true;
        }

        // do not mess up units and amounts
        private static void Shoot(Pirate pirate)
        {
            var distanceToSea = Distance.FromNauticalMile(1);
            var stepLength = Distance.FromFoot(34);

            // no mix up in units
            var stepsToSea = distanceToSea / stepLength;

            // passing values around is more save
            pirate.ShootAtShip(distanceToSea);
        }

        // pass values typed
        private static void FindTreasure(Pirate pirate)
        {
            // from bar tender (or http request or DB)
            var externalKey = Guid.NewGuid();

            // now make it save as fast as possible
            var treasureChestId = new TreasureChestId(externalKey);

            // only typed ids can be passed, no mix up from now on.
            pirate.FindTreasure(treasureChestId);
        }
    }
}
