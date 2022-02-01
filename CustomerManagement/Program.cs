using System;
using System.Collections.Generic;
using System.Diagnostics;
using TurboCollections;

namespace CustomerManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var turboList = new List<float>(100000);
            for (var i = 0; i < 100000; i++)
            {
                turboList.Add(i);
            }
            for (var i = 0; i < 100000; i++)
            {
                turboList.Remove(i);
            }

            Console.WriteLine(stopwatch.ElapsedTicks);
        }
    }
}