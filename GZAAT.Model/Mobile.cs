using System;

namespace GZAAT.Model
{
    [Serializable]
    public class DD_Mobile
    {
        public string Mobile { get; set; }
        public string Name { get; set; }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        
        public override bool Equals(object obj)
        {
            return ((obj is DD_Mobile) && (Mobile == ((DD_Mobile)obj).Mobile));
        }
        public bool Equals(DD_Mobile obj)
        {
            return this == obj;
        }
    }
}
