using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphTheory
{
    public class Kruskal : GraphTheoryAlgorithm
    {

        public float[,] KruskalAlgorithm(List<Tuple<float, int, int>> sortedEdges, int numberOfVertices)
        {
           
            float[,] adj_MatrixOfSearchedMST = new float[numberOfVertices, numberOfVertices]; // it will be the adjacency matrix of the sought  MST

            foreach (Tuple<float, int, int> item in sortedEdges) // the edges are allready sorted, it is necessary to find MST with Kruskal
            {
                adj_MatrixOfSearchedMST[item.Item2, item.Item3] = item.Item1; // the vertices of this edge are connected to see if a circuit is created
                adj_MatrixOfSearchedMST[item.Item3, item.Item2] = item.Item1; // for this, this connection must be established at each vertex

                if (CircuitExistenceCheck(adj_MatrixOfSearchedMST)) // if this results in a circuit, then this step is undone
                {
                    adj_MatrixOfSearchedMST[item.Item2, item.Item3] = 0;
                    adj_MatrixOfSearchedMST[item.Item3, item.Item2] = 0;
                }
            }
            return adj_MatrixOfSearchedMST; // in the end, MST is created
        }

        public void ExecuteKruskal(float[,] distances, ref float[,] result, List<Tuple<float, int, int>> sortedDistances, DataGridView dataGridViewGraphTheoryEndmatrix)
        {
            if (!(IsConnectedGraph(distances) && IsUndirectedGraph(distances)))
            {
                MessageBox.Show("The given graph is not connected or directed!");
                return;
            }
            sortedDistances = DistancesInSortedList(distances);
            result = KruskalAlgorithm(sortedDistances, distances.GetLength(0));
            HandleGrids.FillEndGrid(dataGridViewGraphTheoryEndmatrix, result);
        }
    }
}
