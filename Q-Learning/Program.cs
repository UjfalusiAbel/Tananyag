using System;
using System.Collections.Generic;
using Q_Learning.src;

namespace Q_Learning
{
    class Program
    {
        static void Main(string[] args)
        {
            LearningEnvironment environment = new LearningEnvironment(11,11);            
            Agent agent = new Agent();

            agent.SetRandomStartPosition();
            agent.discountFactor = 0.9f;
            agent.epsilon = 0.01f;
            agent.learningRate = 0.9f;
            agent.trainingEpisodes = 1000;
            agent.Train();
            Console.WriteLine("A cél a 0 5 pozíció");
            List<Pair> path = agent.GetShortestPath(7,8);
            foreach(var x in path)
            {
                Console.WriteLine(x.rowIndex + " " + x.columnIndex);
            }
            Console.ReadKey();
        }
    }
}
