using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphTheory
{
    class Prim : GraphTheoryAlgorithm
    {

        public float[,] PrimAlgorithm(float[,] adjacencyMatrix)
        {
            List<int> connectedNodes = new List<int> { 0 };
            float[,] mstAdjacencyMatrix = new float[adjacencyMatrix.GetLength(0), adjacencyMatrix.GetLength(1)];

            float smallestEdge = float.MaxValue;
            int shortestNodeofStartNode = int.MaxValue;
            int startNode = 0;
            for (int j = 0; j < adjacencyMatrix.GetLength(0); j++)
            {
                foreach (int node in connectedNodes)
                {
                    for (int i = 0; i < adjacencyMatrix.GetLength(1); i++)
                    {
                        if (adjacencyMatrix[node, i] != 0 && smallestEdge > adjacencyMatrix[node, i])
                        {
                            smallestEdge = adjacencyMatrix[node, i];
                            shortestNodeofStartNode = i;
                            startNode = node;
                        }
                    }
                }
                if (shortestNodeofStartNode != int.MaxValue)
                {
                    mstAdjacencyMatrix[startNode, shortestNodeofStartNode] = smallestEdge;
                    mstAdjacencyMatrix[shortestNodeofStartNode, startNode] = smallestEdge;
                    connectedNodes.Add(shortestNodeofStartNode);
                    adjacencyMatrix[startNode, shortestNodeofStartNode] = float.MaxValue;
                    adjacencyMatrix[shortestNodeofStartNode, startNode] = float.MaxValue;
                    if (CircuitExistenceCheck(mstAdjacencyMatrix))
                    {
                        mstAdjacencyMatrix[startNode, shortestNodeofStartNode] = 0;
                        mstAdjacencyMatrix[shortestNodeofStartNode, startNode] = 0;
                        connectedNodes.Remove(shortestNodeofStartNode);
                        if (j != 0) { j--; }
                    }
                    smallestEdge = float.MaxValue;
                    shortestNodeofStartNode = int.MaxValue;
                    startNode = 0;
                }
            }
            return mstAdjacencyMatrix;
        }

        internal void ExecutePrim(float[,] distances, ref float[,] result, List<Tuple<float, int, int>> sortedDistances, DataGridView dataGridViewGraphTheoryEndmatrix)
        {
            if (!(IsConnectedGraph(distances) && IsUndirectedGraph(distances)))
            {
                MessageBox.Show("The given graph is not connected or directed!");
                return;
            }
            result = PrimAlgorithm(distances);
            HandleGrids.FillEndGrid(dataGridViewGraphTheoryEndmatrix, result);
        }
    }
}
