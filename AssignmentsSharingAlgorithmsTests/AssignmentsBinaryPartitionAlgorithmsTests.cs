using AssignmentSharing.Algorithms;
using AssignmentSharing.Algorithms.Exceptions;
using AssignmentSharing.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentsSharingAlgorithmsTests
{
    [TestFixture(typeof(AssignmentSharing.Algorithms.BipartitionAlgorithm<Assignment>))]
    public class AssignmentsBinaryPartitionAlgorithmsTests<T> 
        where T : IPartitionAlgorithm<Assignment>, new ()
    {
        private IPartitionAlgorithm<Assignment> _algorithm;

        private static IEnumerable<List<int>> GenerateTestCases()
        {
            Random random = new Random();
            for (int i = 0; i < 100; i++)
            {
                List<int> ints = new List<int>();
                for (int j = 0; j < 3; j++)
                {
                    ints.Add(random.Next(-100, 100));
                }
                yield return ints;   
            }
        }

        private static List<int> GenerateSplittableSet(int sum)
        {
            int firstsum = sum;
            int secondsum = sum;
            List<int> set = new List<int>();
            Random random = new Random();
            while (firstsum > 0)
            {
                int next = random.Next(1, firstsum);
                set.Add(next);
                firstsum -= next;
            }
            while (secondsum > 0)
            {
                int next = random.Next(1, secondsum);
                set.Add(next);
                secondsum -= next;
            }
            return set;
        }

        private static IEnumerable<List<int>> GenerateFiftySplittableSets()
        {
            for (int i = 0; i < 50; i++)
            {
                yield return GenerateSplittableSet(i + 50);
            }
        }

        [SetUp]
        public void Setup()
        {
            _algorithm = new T();
            _algorithm.InterpretAsWeight = a => a.TimeCost;
        }

        [Test]
        public void WrongSubsetsCountTest([NUnit.Framework. Range(3, 11, 1)] int n)
        {
            Assert.That(
                    () => _algorithm.SubsetsCount = n, 
                    Throws.Exception.TypeOf<UnsupportedSubsetsCountException>()
                );
        }

        [TestCaseSource(nameof(GenerateTestCases))]
        public void WeightTests(List<int> weights)
        {
            Assume.That(weights, Is.Not.All.Positive);

            Assert.That(
                    () => _algorithm.Run(weights.Select(w => new Assignment { TimeCost = w })),
                    Throws.Exception.TypeOf<InappropriateWeightException>()
                );
        }

        [TestCase(2)]
        [TestCase(2, 4)]
        [TestCase(2, 5, 5)]
        [TestCase(2, 2, 6, 6, 7)]
        [TestCase(2, 2, 2, 2, 2, 2, 2)]
        public void CannotSplitTest(params int[] set)
        {
            Assert.That(
                    () => _algorithm.Run(set.Select(w => new Assignment { TimeCost = w })),
                    Throws.Exception.TypeOf<InputSetUnsplittableException>()
                );
        }

        [TestCaseSource(nameof(GenerateFiftySplittableSets))]
        public void CanSplitTest(List<int> set)
        {
            List<HashSet<Assignment>> result;
            result = _algorithm.Run(set.Select(w => new Assignment { TimeCost = w }));
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result[0].Sum(a => a.TimeCost), 
                Is.EqualTo(result[1].Sum(a => a.TimeCost)));
        }

        
    }
}
