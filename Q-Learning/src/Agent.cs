using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q_Learning.src
{
    public class Agent
    {
        private int currentRowIndex;
        private int currentColumnIndex;
        public int trainingEpisodes;
        public float epsilon;
        public float learningRate;
        public float discountFactor;
        Random randomGenerator = new Random();
        public void SetRandomStartPosition()
        {
            int matrixLength = LearningEnvironment.QTable.GetLength(0);
            currentRowIndex = randomGenerator.Next(0, matrixLength);
            currentColumnIndex = randomGenerator.Next(0,matrixLength);
            while(LearningEnvironment.IsTerminalState(currentRowIndex, currentColumnIndex))
            {
                currentRowIndex = randomGenerator.Next(0, matrixLength);
                currentColumnIndex = randomGenerator.Next(0,matrixLength);
            }
        }

        private Action GetNextAction()
        {
            if(randomGenerator.NextDouble()>epsilon)
            {
                return (Action)GetMaxValueIndex(currentRowIndex, currentColumnIndex) ;
            }
            else
            {
                return (Action)randomGenerator.Next(0,4);
            }
        }

        private void GetNextLocation(int rowInd, int columnInd, Action action)
        {
            currentRowIndex=rowInd;
            currentColumnIndex=columnInd;
            switch(action)
            {
                case Action.Up:
                    if(currentRowIndex!=0)
                    {
                        currentRowIndex -= 1;
                    }
                    break;
                case Action.Right:
                    if(currentColumnIndex < LearningEnvironment.rewardTable.GetLength(1)-1)
                    {
                        currentColumnIndex +=1;
                    }
                    break;
                case Action.Down:
                    if(currentRowIndex < LearningEnvironment.rewardTable.GetLength(0)-1)
                    {
                        currentRowIndex += 1;
                    }
                    break;
                case Action.Left:
                    if(currentColumnIndex > 0)
                    {
                        currentColumnIndex -= 1;
                    }
                    break;
            }
        }

        public List<Pair> GetShortestPath(int startRowInd, int startColumnInd)
        {
            if(LearningEnvironment.IsTerminalState(startRowInd, startColumnInd))
            {
                return new List<Pair>();
            }
            else
            {
                currentRowIndex = startRowInd;
                currentColumnIndex = startColumnInd;
                List<Pair> shortesPath = new List<Pair>();
                shortesPath.Add(new Pair(currentRowIndex, currentColumnIndex));
                while(!LearningEnvironment.IsTerminalState(currentRowIndex, currentColumnIndex))
                {
                    Action currentAction = GetNextAction();
                    GetNextLocation(currentRowIndex, currentColumnIndex, currentAction);
                    shortesPath.Add(new Pair(currentRowIndex, currentColumnIndex));
                }
                return shortesPath;
            }
        }

        public void Train()
        {
            Console.WriteLine("Képzés indul:");

            List<Tuple<int,Dictionary<Action,float[][]>>> list = new List<Tuple<int, Dictionary<Action, float[][]>>>();
            List<Tuple<int, int>> totalRewards = new List<Tuple<int, int>>();
            List<Tuple<int, float>> failures = new List<Tuple<int, float>>();
            List<Tuple<int, float>> successes = new List<Tuple<int, float>>();

            int rewardSum = 0;
            int failureCount = 0;
            int successCount = 0;
            int counter = 50;

            for(int i=0;i<trainingEpisodes;i++)
            {
                list.Add(StructureData(i));
                SetRandomStartPosition();

                rewardSum = 0;

                while(!LearningEnvironment.IsTerminalState(currentRowIndex, currentColumnIndex))
                {
                    Action currentAction = GetNextAction();
                    int oldRowIndex = currentRowIndex;
                    int oldColumnIndex = currentColumnIndex;
                    GetNextLocation(currentRowIndex, currentColumnIndex, currentAction);
                    if(LearningEnvironment.IsFailure(currentRowIndex, currentColumnIndex))
                    {
                        failureCount++;
                    }
                    else if(LearningEnvironment.IsTerminalState(currentRowIndex, currentColumnIndex) && !LearningEnvironment.IsFailure(currentRowIndex, currentColumnIndex))
                    {
                        successCount++;
                    }
                    float reward = LearningEnvironment.rewardTable[currentRowIndex, currentColumnIndex];
                    float oldQValue = LearningEnvironment.QTable[oldRowIndex, oldColumnIndex, (int)currentAction];
                    float temporalDifference = reward + (discountFactor * GetMaxValue(currentRowIndex, currentColumnIndex)) - oldQValue;
                    float newQValue = oldQValue + (learningRate * temporalDifference);
                    LearningEnvironment.QTable[oldRowIndex, oldColumnIndex, (int)currentAction] = newQValue;
                    rewardSum+=(int)reward;
                }

                totalRewards.Add(new Tuple<int, int>(i, rewardSum));
                if(i % (counter-1) == 0 && i!=0)
                {
                    failures.Add(new Tuple<int, float>(i/counter,(float)failureCount/(float)counter));
                    successes.Add(new Tuple<int, float>(i/counter,(float)successCount/(float)counter));
                    failureCount = 0;
                    successCount = 0;
                }
            }

            WriteData(list, totalRewards, failures, successes);
            
            Console.WriteLine("Képzés kész!");
        }

        private int GetMaxValueIndex(int rowInd, int columnInd)
        {
            int ind = 0;
            float maxValue = float.MinValue;
            for(int i=0;i<4;i++)
            {
                if(LearningEnvironment.QTable[rowInd,columnInd,i]>maxValue)
                {
                    ind = i;
                    maxValue = LearningEnvironment.QTable[rowInd,columnInd,i];
                }
            }
            return ind;
        }

        private float GetMaxValue(int rowInd, int columnInd)
        {
            float maxValue = float.MinValue;
            for(int i=0;i<4;i++)
            {
                if(LearningEnvironment.QTable[rowInd,columnInd,i]>maxValue)
                {
                    maxValue = LearningEnvironment.QTable[rowInd,columnInd,i];
                }
            }
            return maxValue;
        }

        private Tuple<int,Dictionary<Action,float[][]>> StructureData(int episode)
        { 
            Dictionary<Action, float[][]> map = new Dictionary<Action, float[][]>();
            for(int i=0;i<LearningEnvironment.QTable.GetLength(2);i++)
            {
                float[][] values = new float[LearningEnvironment.QTable.GetLength(0)][];
                for(int j=0;j<LearningEnvironment.QTable.GetLength(1);j++)
                {
                    values[j] = new float[LearningEnvironment.QTable.GetLength(1)];
                    for(int k=0;k<LearningEnvironment.QTable.GetLength(0);k++)
                    {
                        values[j][k]=LearningEnvironment.QTable[j,k,i];
                    }
                }
                map.Add((Action)i, values);
            }
            return new Tuple<int, Dictionary<Action, float[][]>>(episode, map);
        }

        private void WriteData(List<Tuple<int,Dictionary<Action,float[][]>>> list, List<Tuple<int, int>> totalRewards, List<Tuple<int, float>> failures, List<Tuple<int, float>> successes)
        {
            string jsonQTable = JsonSerializer.Serialize(list);
            string jsonTotalRewards = JsonSerializer.Serialize(totalRewards);
            string jsonFailures = JsonSerializer.Serialize(failures);
            string jsonSuccesses = JsonSerializer.Serialize(successes);

            File.WriteAllText("Data/QTable.json", "QTable = " + jsonQTable);
            File.WriteAllText("Data/RewardSum.json", "rewards = " + jsonTotalRewards);
            File.WriteAllText("Data/Failures.json", "failures = " + jsonFailures);
            File.WriteAllText("Data/Successes.json", "successes = " + jsonSuccesses);
        }
    }

    public struct Pair
    {
        public int rowIndex;
        public int columnIndex;
        public Pair(int rowIndex, int columnIndex)
        {
            this.rowIndex = rowIndex;
            this.columnIndex = columnIndex;
        }
    }

}