using System;
using System.Collections.Generic;

namespace Graf
{
    public class Graph
    {
        int n;
        bool[,] adjMatrix;
        bool[] visited;
        public Graph(int n)
        {
            this.n = n;
            adjMatrix = new bool[n,n];
            visited = new bool[n];
            for(int i=0;i<n;i++)
            {
                for(int j=0;j<n;j++)
                {
                    adjMatrix[i,j]=false;
                }
            }
            for(int i=0;i<n;i++)
            {
                visited[i]=false;
            }
        }

        public void AddEdge(int v, int w)
        {
            adjMatrix[v,w]=true;
            adjMatrix[w,v]=true;
        }

        //Rekurzív algoritmus 2 nódus közötti út megkeresésére
        public void DepthFirstSearch(int start, int end)
        {
            Console.Write(start + " ");
            visited[start]=true;
            for(int i=0;i<n;i++)
            {
                if(start == end)
                {
                    Console.WriteLine("Van út");
                    return;
                }
                if(adjMatrix[start, i] && !visited[i])
                {
                    DepthFirstSearch(i, end);
                }
            }
        }

        //Egy másik algoritmus megkeresni 2 nódus közötti utat
        public void BreadFirstSearch(int start, int end)
        {
            Console.WriteLine();
            Queue<int> queue = new Queue<int>();

            for(int i=0;i<n;i++)
            {
                visited[i]=false;
            }
            visited[start]=true;
            queue.Enqueue(start);
            int vis;
            while(queue.Count != 0)
            {
                vis = queue.Dequeue();
                Console.Write(vis + " ");
                if(vis == end)
                {
                    Console.WriteLine("Van út");
                    return;
                }

                for(int i=0;i<n;i++)
                {
                    if(adjMatrix[vis,i] == true && !visited[i])
                    {
                        visited[i]=true;
                        queue.Enqueue(i);
                    }
                }
            }
        }
    }
}