using System;

namespace client
{
    [Serializable]
    public class TestResult
    {
        public TestResult(double task1, double task2, double task3, double task4, double task5, double task6)
        {
            Task1 = task1;
            Task2 = task2;
            Task3 = task3;
            Task4 = task4;
            Task5 = task5;
            Task6 = task6;
        }

        public double Task1 { get; set; }
            public double Task2 { get; set; }
            public double Task3 { get; set; }
            public double Task4 { get; set; }
            public double Task5 { get; set; }
            public double Task6 { get; set; }

            public TestResult()
            {
                
            }
    }
}