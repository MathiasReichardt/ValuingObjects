namespace ValueObjects
{
    using System;

    public class TreasureChestId : IdBase  
    {
        public TreasureChestId(Guid id)
            : base(id)
        {
        }

        public TreasureChestId()
            : base(Guid.Empty) // or Guid.NewGuid()? depends on design
        {
        }
    }

    public abstract class IdBase
    {
        private readonly Guid id;

        protected IdBase(Guid id)
        {
            if (id == null)
            {
                throw new Exception("Id may not ben null");
            }

            this.id = id;
        }

        protected IdBase()
        {
            this.id = Guid.NewGuid();
        }

        public static bool operator ==(IdBase a, IdBase b)
        {
            if (a == null && b == null)
            {
                return true;
            }

            if (a == null ^ b == null)
            {
                return false;
            }

            return a.id == b.id;
        }

        public static bool operator !=(IdBase a, IdBase b) => !(a == b);
    }
}