using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphTheory
{
    class DepthFirstSearch : GraphTheoryAlgorithm
    {
        public void ExecuteDFS(float[,] distances, ref float[,] result, int startpoint, DataGridView dataGridView)
        {
            if (!IsConnectedGraph(distances))
            {
                MessageBox.Show("The given graph is not connected or directed!");
                return;
            }
            result = DFSAlgorithm(distances, startpoint);
            HandleGrids.FillEndGrid(dataGridView, result);
        }


        public float[,] DFSAlgorithm(float[,] adjacencyMatrix, int startpoint)
        {
            float[,] result = new float[adjacencyMatrix.GetLength(0), adjacencyMatrix.GetLength(1)];

            List<int> visitedNodes = new List<int> { startpoint };

            int currentNode = startpoint;

            // max iterations only if every node has just a connection to the startpoint
            for (int iterations = 0; iterations < adjacencyMatrix.GetLength(0); iterations++)
            {

                for (int j = 0; j < adjacencyMatrix.GetLength(1); j++)
                {
                    if (adjacencyMatrix[currentNode, j] != 0 && adjacencyMatrix[currentNode, j] != float.MaxValue)
                    {
                        if (!visitedNodes.Contains(j))
                        {
                            visitedNodes.Add(j);
                            result[currentNode, j] = adjacencyMatrix[currentNode, j];
                            currentNode = j;
                        }
                    }
                }
                if (visitedNodes.Count == adjacencyMatrix.GetLength(0))
                {
                    return result;
                }
                currentNode = visitedNodes[iterations];
             
            }
            return result;
        }
    }
}
