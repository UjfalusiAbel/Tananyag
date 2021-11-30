using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q_Learning.src
{
    public enum Action
    {
        Up,
        Down,
        Right,
        Left
    }
    public class LearningEnvironment
    {
        private int numberOfActions;
        public static float[,,] QTable;
        public static int[,] rewardTable;

        public LearningEnvironment(int rows, int columns)
        {
            numberOfActions = 4;
            QTable = FillQTable(rows,columns);
            rewardTable = SetupEnvironment(rows,columns);
        } 

        public static bool IsFailure(int rowInd, int columnInd)
        {
            if(rewardTable[rowInd,columnInd]==-100)
            {
                return true;
            }
            return false;
        }
        
        public static bool IsTerminalState(int rowInd, int columnInd)
        {
            if(rewardTable[rowInd,columnInd]==-1)
            {
                return false;
            }
            return true;
        }

        private int[,] SetupEnvironment(int rows, int columns)
        {
            int[,] table = new int[rows,columns];
            String input = File.ReadAllText("Data/Input.txt");
            int i=0;
            int j=0;
            foreach(var row in input.Split('\n'))
            {
                j=0;
                foreach(var col in row.Trim().Split(' '))
                {
                    table[i,j]=int.Parse(col.Trim());
                    j++;
                }
                i++;
            }

            for(i=0;i<rows;i++)
            {
                for(j=0;j<columns;j++)
                {
                    Console.Write(table[i,j]+" ");
                }
                Console.WriteLine();
            }

            return table;
        }

        private float[,,] FillQTable(int rows, int columns)
        {
            float[,,] table = new float[rows, columns, numberOfActions];
            for(int i=0;i<rows;i++)
            {
                for(int j=0;j<columns;j++)
                {
                    for(int k=0;k<numberOfActions;k++)
                    {
                        table[i,j,k]=0f;
                    }
                }
            }
            return table;
        }
    }
}