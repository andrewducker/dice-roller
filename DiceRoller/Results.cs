using System.Collections.Generic;

namespace DiceRoller
{
    class Results
    {
        readonly Dictionary<int,int> resultSet = new Dictionary<int, int>();
        private int minValue = int.MaxValue;
        private int maxValue = int.MinValue;

        public int this[int result]
        {
            get
            {
                if (resultSet.ContainsKey(result))
                {
                    return resultSet[result];    
                }
                return 0;
            }
        }

        public int MinValue
        {
            get { return minValue; }
        }

        public int MaxValue
        {
            get { return maxValue; }
        }

        public void AddResult(int result)
        {
            if (!resultSet.ContainsKey(result))
            {
                resultSet[result] = 0;
            }
            resultSet[result]++;
            if (result < MinValue)
            {
                minValue = result;
            }
            if (result > MaxValue)
            {
                maxValue = result;
            }
        }
    }
}
