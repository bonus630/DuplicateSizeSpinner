using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuplicateSizeSpinner
{
    public class UnitPairs
    {
        private List<UnitPair> internUnitPairList = new List<UnitPair>();

        public bool CheckPairExist(UnitPair pair)
        {
            int firstIndex = -1;
            int lastIndex = -1;
            for (int i = 0; i < internUnitPairList.Count; i++)
            {
                if (pair.First.Equals(internUnitPairList[i].First))
                    firstIndex = i;
                if (pair.Last.Equals(internUnitPairList[i].First))
                    lastIndex = i;
                if (pair.First.Equals(internUnitPairList[i].Last))
                    firstIndex = i;
                if (pair.Last.Equals(internUnitPairList[i].Last))
                    lastIndex = i;
            }
            if (firstIndex.Equals(-1))
                return false;
            if (firstIndex.Equals(lastIndex))
                return true;
            return false;
        }
        public UnitPair FindFirstOrDefaultPair(UnitEnum value)
        {
            int lastIndex = -1;
            for (int i = 0; i < internUnitPairList.Count; i++)
            {
                if (internUnitPairList[i].First.Equals(value))
                    return internUnitPairList[i];
                if (internUnitPairList[i].Last.Equals(value) && lastIndex == -1)
                    lastIndex = i;
            }
            if (lastIndex != -1)
                return internUnitPairList[lastIndex];
            return null;
        }
        public UnitPair FindFirstOrDefaultPair(string value)
        {
            return FindFirstOrDefaultPair((UnitEnum)Enum.Parse(typeof(UnitEnum), value));
        }
        public void AddPair(string value1, string value2)
        {
            UnitEnum unit1 = (UnitEnum)Enum.Parse(typeof(UnitEnum), value1);
            UnitEnum unit2 = (UnitEnum)Enum.Parse(typeof(UnitEnum), value2);
            UnitPair pair = new UnitPair(unit1, unit2);
            if (!CheckPairExist(pair))
                internUnitPairList.Add(pair);

        }
    }
}
