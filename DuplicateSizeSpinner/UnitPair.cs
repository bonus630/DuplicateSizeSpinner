using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuplicateSizeSpinner
{

    public class UnitPair
    {
        private UnitEnum first;

        public UnitEnum First
        {
            get { return first; }
            set { first = value; }
        }
        private UnitEnum last;

        public UnitEnum Last
        {
            get { return last; }
            set { last = value; }
        }

        public UnitPair(UnitEnum first,UnitEnum last)
        {
            this.first = first;
            this.last = last;
        }
        public bool HaveValue(UnitEnum value)
        {
            if (first.Equals(value))
                return true;
            if (last.Equals(value))
                return true;
            return false;
        }
        public UnitEnum ReverseUnit(UnitEnum value)
        {
            if (value.Equals(first))
                return last;
            else 
                return first;
        }
        public int ReverseUnit(string value)
        {
            UnitEnum unitR = ReverseUnit((UnitEnum)Enum.Parse(typeof(UnitEnum), value));
            return (int)unitR;
        }

    }
}
