using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var employeeIds = new List<int>
            {
                1,
                2,
                3,
                4,5,6,7,8,9,10,11
            };

            var acceptedRange = new List<int>
            {
                5, 4, 3
            };

            int takeAmount = acceptedRange.Find(x => employeeIds.Count % x >= 3);

            var groups = new HashSet<IEnumerable<int>>();
            var group = new List<int>();

            var rnd = new Random();
            IOrderedEnumerable<int> randomizedEmployeeIds = employeeIds.OrderBy(x => rnd.Next());

            foreach (int employeeId in randomizedEmployeeIds)
            {
                if (group.Count == takeAmount)
                {
                    groups.Add(group);
                    group = new List<int>();
                }
                group.Add(employeeId);   
            }

            groups.Add(group);

            foreach (IEnumerable<int> enumerable in groups)
            {
                foreach (int i in enumerable) Console.Write($" {i},");
                Console.WriteLine();
            }
        }
    }
}
