namespace StringDisperser
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
      
    public class StringDisperser : IEnumerable<Char>, IComparable<StringDisperser>, ICloneable
    {
        public IList<char> Chars { get; set; }

        public StringDisperser()
        {
            this.Chars = new List<char>();
        }

        public StringDisperser(params string[] newStrings)
            : this()
        {
            this.Add(newStrings);
        }

        public void Add(params string[] newStrings)
        {
            foreach (var str in newStrings)
            {
                foreach (var ch in str)
                {
                    this.Chars.Add(ch);
                }
            }
        }

        public override string ToString()
        {
            return String.Join(" ", this.Chars);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public IEnumerator<char> GetEnumerator()
        {
            return this.Chars.GetEnumerator();
        }

        public static bool operator ==(StringDisperser customer1,
                                        StringDisperser customer2)
        {
            return StringDisperser.Equals(customer1, customer2);
        }

        public static bool operator !=(StringDisperser customer1,
                                        StringDisperser customer2)
        {
            return !StringDisperser.Equals(customer1, customer2);
        }
        
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public object Clone()
        {
            StringDisperser cloneStringDisperser = new StringDisperser();
            cloneStringDisperser.Chars = this.Chars.ToList();
            return cloneStringDisperser;
        }

        public int CompareTo(StringDisperser other)
        {
            if (this.Chars.Count == other.Chars.Count)
            {
                return (this.Chars.SequenceEqual(other.Chars) == true) ? 0 : -1;
            }
            else
            {
                return (this.Chars.Count - other.Chars.Count > 0) ? 1 : -1;
            }
        }
    }
}
