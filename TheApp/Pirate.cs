namespace TheApp
{
    using System;

    using ValueObjects;

    public class Pirate
    {
        public PirateMood PirateMood { get; set; } = PirateMood.Hungry();

        public void FindTreasure(TreasureChestId treasureChestId)
        {
            throw new NotImplementedException();
        }

        public void ShootAtShip(Distance distanceToSea)
        {
            throw new NotImplementedException();
        }

        public void Drink()
        {
            if (this.PirateMood.IsHungry)
            {
                this.PirateMood = PirateMood.HungryAndDrunken();
            }
        }
    }
}
