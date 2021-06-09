using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheory
{
    class AStar : GraphTheoryAlgorithm
    {
        public void AStarAlgorithm(float[,] distances, out float[] shortestPath, out int[] predecessor, out float[] minimalPath, int startpoint, int endpoint)
        {
            shortestPath = new float[distances.GetLength(1)];
            predecessor = new int[distances.GetLength(1)];
            minimalPath = new float[distances.GetLength(1)];

            float smallestDistance = 0;
            InitializeAStarTable(ref shortestPath, ref predecessor, ref minimalPath, distances, startpoint, endpoint);

            for (int j = 0; j < shortestPath.Length; j++)
            {
                float smallest = float.MaxValue;
                int smallestNode = int.MaxValue;

                for (int i = 0; i < minimalPath.Length; i++)
                {
                    if (smallest > minimalPath[i] && smallestDistance < minimalPath[i])
                    {
                        smallest = minimalPath[i];
                        smallestNode = i;
                    }
                }

                if(smallestNode == endpoint || smallest == float.MaxValue)
                {
                    return;
                }

                AdjustDistances(ref shortestPath, ref predecessor, ref minimalPath, distances, startpoint, endpoint, smallestNode);

                smallestDistance = smallest;
            }

        }


        private void InitializeAStarTable(ref float[] shortestPath, ref int[] predecessor, ref float[] minimalPath, float[,] distances, int startpoint, int endpoint)
        {
            for (int i = 0; i < distances.GetLength(1); i++)
            {
                shortestPath[i] = distances[startpoint, i];
                predecessor[i] = startpoint;
                if (i != endpoint)
                {
                    minimalPath[i] = shortestPath[i] + MinimalEdge(distances, i);
                }
                else
                {
                    minimalPath[i] = shortestPath[i];
                }
            }
        }
        private void AdjustDistances(ref float[] shortestPath, ref int[] predecessor, ref float[] minimalPath, float[,] distances, int startpoint, int endpoint, int smallestNode)
        {
            for (int i = 0; i < shortestPath.Length; i++)
            {
                if (i != startpoint)
                {
                    float newDistance = float.MaxValue;
                    if (distances[smallestNode, i] != 0)
                    {
                        newDistance = shortestPath[smallestNode] + distances[smallestNode, i];
                    }
                    if (newDistance < shortestPath[i] || shortestPath[i] == 0 && newDistance != int.MaxValue)
                    {
                        shortestPath[i] = newDistance;
                        predecessor[i] = smallestNode;
                        if (i != endpoint)
                        {
                            minimalPath[i] = shortestPath[i] + MinimalEdge(distances, i);
                        }
                        else
                        {
                            minimalPath[i] = shortestPath[i];
                        }

                    }
                }
            }
        }

    }
}
