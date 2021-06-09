using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphTheory
{
    public class Dijkstra : GraphTheoryAlgorithm
    {


        public int[] DijkstraAlgorithm(ref float[,] distances, ref float[] shortestPath, int startpoint)
        {
            //the smallest distance in the iteration before newSmallestDistance (line 75)
            float smallestDistance = 0;

            //save the predecessor  like the "Dijkstra-table"
            int[] predecessor = new int[distances.GetLength(0)];

            //save the shortest distance and predecessors like the "Dijkstra-table"
            for (int i = 0; i < predecessor.Length; i++)
            {
                shortestPath[i] = distances[startpoint, i];
                predecessor[i] = startpoint;
            }

            //search the smallest edge wich wasn't used so far
            for (int j = 0; j < distances.GetLength(1); j++)
            {

                float newSmallestDistance = float.MaxValue;
                int newSmallestDistanceIndex = int.MaxValue;

                for (int i = 0; i < distances.GetLength(1); i++)
                {
                    if (shortestPath[i] != 0 && smallestDistance < shortestPath[i] && newSmallestDistance > shortestPath[i])
                    {
                        newSmallestDistance = shortestPath[i];
                        newSmallestDistanceIndex = i;
                    }
                }
                if (newSmallestDistanceIndex >= distances.GetLength(0))
                {
                    return predecessor;
                }

                //calculate all new distances
                AdjustDistances(ref shortestPath, ref predecessor, distances, startpoint, newSmallestDistance, newSmallestDistanceIndex);
                
                smallestDistance = newSmallestDistance;
            }
            return predecessor;
        }

        private void AdjustDistances(ref float[] shortestPath, ref int[] predecessor, float[,] distances, int startpoint, float newSmallestDistance, int newSmallestDistanceIndex)
        {
            for (int i = 0; i < distances.GetLength(1); i++)
            {
                if (i != startpoint)
                {
                    float newDistance = float.MaxValue;

                    if (distances[newSmallestDistanceIndex, i] != 0)
                    {
                        newDistance = newSmallestDistance + distances[newSmallestDistanceIndex, i];
                    }

                    if (newDistance < shortestPath[i] || shortestPath[i] == 0 && newDistance != float.MaxValue)
                    {
                        shortestPath[i] = newDistance;
                        predecessor[i] = newSmallestDistanceIndex;
                    }
                }
            }
        }

        internal void ExecuteDijkstra(ref float[,] distances, DataGridView dataGridViewGraphTheoryEndmatrix, int index)
        {
            float[] shortestPath = new float[distances.GetLength(0)];
            int[] predecessor = new int[distances.GetLength(0)];
            predecessor = DijkstraAlgorithm(ref distances, ref shortestPath, index);
            if (predecessor != null)
            {
                HandleGrids.PrintDijkstraTable(dataGridViewGraphTheoryEndmatrix, shortestPath, predecessor, index);
            }
        }
    }
}
