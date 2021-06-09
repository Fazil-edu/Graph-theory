using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheory
{
    public class GraphTheoryAlgorithm
    {
        public float[,] distances { get; set; }

        public List<Tuple<float, int, int>> DistancesInSortedList(float[,] distances)
        {
            List<Tuple<float, int, int>> sortedDistances = new List<Tuple<float, int, int>> { };
            for (int i = 0; i < distances.GetLength(0); i++)
            {
                for (int j = i; j < distances.GetLength(1); j++)
                {
                    if (distances[i, j] != 0 && distances[i, j] != float.MaxValue)
                    {
                        sortedDistances.Add(Tuple.Create(distances[i, j], i, j));
                    }
                }
            }
            sortedDistances.Sort();
            return sortedDistances;
        }

        public bool CircuitExistenceCheck(float[,] adj_MatrixOfSearchedMST)
        {
            /* 
             
             The number of edges is used to determine whether or not there is a circuit.
             It is true that the number of edges in a circuit-free graph can be at most the number of vertices -1.
             So finding it and comparing it to the number of vertices is the goal. 
             It should be noted that some vertices are not yet connected. 
             So, the number of not yet connected vertices must be taken into account, so subtracted from the number of total vertices at the calculation.
             
             The number of edges can be calculated with the number of the entries of adjacency matrix. The number of edges is equal to the number of entries divided by 2 

            */
            int numberOfEntries = 0;
            float sumOfEntriesOfTheCurrentRow = 0; // with the sum of the entries in its row in the adjacency matrix, you can calculate whether a vertex is not yet connected
            int numberOfVertices = adj_MatrixOfSearchedMST.GetLength(0);
            int numberOfNotConnectedVertices = 0;

            for (int i = 0; i < numberOfVertices; i++)
            {
                for (int j = 0; j < numberOfVertices; j++)
                {
                    sumOfEntriesOfTheCurrentRow = sumOfEntriesOfTheCurrentRow + adj_MatrixOfSearchedMST[i, j];
                    if (adj_MatrixOfSearchedMST[i, j] > 0)
                    {
                        numberOfEntries += 1;
                    }
                }

                if (!(sumOfEntriesOfTheCurrentRow > 0)) // if the sum of the entries in a row is not greater than zero, it means that this vertex is not yet connected.
                {
                    numberOfNotConnectedVertices += 1;
                }
                sumOfEntriesOfTheCurrentRow = 0;
            }

            int numberOfEdges = numberOfEntries / 2;
            if (numberOfEdges <= numberOfVertices - numberOfNotConnectedVertices - 1) // consideration of the number of vertices not yet connected
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool IsUndirectedGraph(float[,] adjacencyMatrix)
        {
            for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
            {
                for (int j = i; j < adjacencyMatrix.GetLength(1); j++)
                {
                    if (adjacencyMatrix[i,j] != adjacencyMatrix[j,i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool IsConnectedGraph(float[,] adjacencyMatrix)
        {           
            bool searchEmptyRows = true;
            bool searchEmptyColumns = !searchEmptyRows;
            if (SearchEmptyRowOrColumn(searchEmptyRows, adjacencyMatrix) || SearchEmptyRowOrColumn(searchEmptyColumns, adjacencyMatrix))
            {
                return false;
            }
            return true;
        }

        private bool SearchEmptyRowOrColumn(bool searchEmptyRows, float[,] adjacencyMatrix)
        {            
            for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
            {
                int counter = 0;
                for (int j = 0; j < adjacencyMatrix.GetLength(1); j++)
                {
                    bool foundEmpty = false;
                    if (searchEmptyRows)
                    {
                        foundEmpty = IsCurrentRowColumnEmpty(i, j, ref counter, adjacencyMatrix);
                    }
                    else
                    {
                        foundEmpty = IsCurrentRowColumnEmpty(j, i, ref counter, adjacencyMatrix);
                    }
                    if (foundEmpty)
                    {
                        return true;
                    }
                }
            }
            return false;

        }

        private bool IsCurrentRowColumnEmpty(int i, int j, ref int counter, float[,] adjacencyMatrix)
        {
            if (adjacencyMatrix[i, j] != float.MaxValue)
            {
                counter = 0;
            }
            else if (i == j)
            {
                return false;
            }
            else
            {
                counter++;
                if (counter == adjacencyMatrix.GetLength(0) - 1)
                {
                    return true;
                }
            }
            return false;
        }

        public float MinimalEdge(float[,] distances, int index)
        {
            float minimalEdge = float.MaxValue;
            for (int j = 0; j < distances.GetLength(1); j++)
            {
                if (minimalEdge > distances[index, j] && distances[index, j] != 0)
                {
                    minimalEdge = distances[index, j];
                }
            }
            return minimalEdge;
        }
    }
}
