using AssignmentSharing.Algorithms.Exceptions;

namespace AssignmentSharing.Algorithms
{
    public class BipartitionAlgorithm<T> : IPartitionAlgorithm<T>
    {
        public Func<T, int> InterpretAsWeight { get; set; }
        public int SubsetsCount
        {
            get { return 2; }
            set { if (value != 2) throw new UnsupportedSubsetsCountException(); }
        }

        public List<HashSet<T>> Run(IEnumerable<T> set)
        {
            List<T> input = set.ToList();
            if (set.Any(a => InterpretAsWeight(a) <= 0))
                throw new InappropriateWeightException();
            int totalWeight = input.Sum(InterpretAsWeight);
            if (totalWeight % 2 == 1)
                throw new InputSetUnsplittableException();
            bool[,] dp = new bool[input.Count + 1, totalWeight / 2 + 1];
            
            //dp[x, y] is true if using elements 0..x we can create sum y 
            
            //initialization:
            // we can create sum 0 despite of the elements we have
            for (int i = 0; i <= input.Count; i++)
                dp[i, 0] = true;
            // we can't create sum y > 0 if we don't have any elements
            for (int j = 1; j <= totalWeight / 2; j++)
                dp[0, j] = false;
            // we can crete sum y > 0 with elements 0..x either
            // 1) if we can create sum y > 0 with elements 0..x-1 or
            // 2) if we can create sum y - input[x] with elements 0..x-1
            for (int i = 1; i <= input.Count; i++)
                for (int j = 1; j <= totalWeight / 2; j++)
                {
                    var ithWeight = InterpretAsWeight(input[i - 1]);
                    dp[i, j] = dp[i - 1, j] || 
                        (j >= ithWeight && dp[i - 1, j - ithWeight]);
                }

            // if dp[input.Count, totalWeight / 2] is true we can split
            // the set to two subsets of equal sum = totalWeight / 2
            if (!dp[input.Count, totalWeight / 2])
                throw new InputSetUnsplittableException();

            int x = input.Count;
            int y = totalWeight / 2;
            List<HashSet<T>> result = new List<HashSet<T>>();
            result.Add(new HashSet<T>());
            result.Add(new HashSet<T>());
            while (x > 0 && y > 0)
            {
                if (dp[x - 1, y])
                {
                    result[0].Add(input[x - 1]);
                    x--;
                }
                else
                {
                    result[1].Add(input[x - 1]);
                    y -= InterpretAsWeight(input[x - 1]);
                    x--;
                }
            }
            return result;
        }
    }
}
