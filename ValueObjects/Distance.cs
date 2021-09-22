namespace ValueObjects
{
    // Avoid unit problems, m, km, cm...
    // Do not pass int, which has unclear meaning and is not type save (on meta level).
    //  - Not every int is a distance
    //  - makes function calls much more easy and error resistant: e.g. no accidental passing of distance to index parameter 
    public class Distance
    {
        // no ambiguous creation

        private readonly int internalStateInMm;

        private Distance(int inMm)
        {
            this.internalStateInMm = inMm;
        }

        public int AsMm => this.internalStateInMm;

        public int AsCm => this.internalStateInMm * 10;

        public int AsKm => this.internalStateInMm * 1000 * 1000;

        public static Distance FromNauticalMile(int nm)
        {
            return new Distance(nm * 1852000);
        }        
        
        public static Distance FromFoot(int f)
        {
            return new Distance((int)(f * 304.8));
        }
        
        public static Distance FromKm(int km)
        {
            return new Distance(km * 1000 * 1000);
        }

        public static Distance FromM(int m)
        {
            return new Distance(m * 1000);
        }

        public static Distance FromDm(int dm)
        {
            return new Distance(dm * 100);
        }

        public static Distance FromCm(int cm)
        {
            return new Distance(cm * 10);
        }

        public static Distance FromMm(int mm)
        {
            return new Distance(mm);
        }

#region Operators

        // support operators
        public static Distance operator +(Distance a, Distance b) => new Distance(a.AsMm + b.AsMm);

        public static Distance operator -(Distance a, Distance b) => new Distance(a.AsMm - b.AsMm);

        public static Distance operator *(Distance a, Distance b) => new Distance(a.AsMm * b.AsMm);

        public static Distance operator /(Distance a, Distance b) => new Distance(a.AsMm / b.AsMm);

#endregion

#region MyRegion

        // support equality operations
        public static bool operator ==(Distance a, Distance b)
        {
            if (a == null && b == null)
            {
                return true;
            }

            if (a == null ^ b == null)
            {
                return false;
            }

            return a.AsMm == b.AsMm;
        }

        public static bool operator !=(Distance a, Distance b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return this.Equals((Distance)obj);
        }

        // used by dictionaries and hashSets, if hashcode collides equality is checked
        // see generic implementation https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/implement-value-objects#value-object-implementation-in-c
        public override int GetHashCode()
        {
            return this.internalStateInMm;
        }

        protected bool Equals(Distance other)
        {
            return this.internalStateInMm == other.internalStateInMm;
        }
    }
#endregion
}
