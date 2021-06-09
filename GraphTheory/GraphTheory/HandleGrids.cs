using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphTheory
{
    public class HandleGrids : GraphTheoryApplication
    {
        public static void NumberAsInput(DataGridView dataGridView, DataGridViewCellValidatingEventArgs e)
        {
            if (!(e.FormattedValue.ToString() == "-" || e.FormattedValue.ToString() == "" || Double.TryParse(e.FormattedValue.ToString(), out double value)))
            {
                e.Cancel = true;
            }
        }

        public static void FillEndGrid(DataGridView dataGridView, float[,] result, int[,] predecessor = null)
        {
            dataGridView.RowCount = result.GetLength(0);
            dataGridView.ColumnCount = result.GetLength(1);
            for (int i = 0; i < result.GetLength(0); i++)
            {
                dataGridView.Rows[i].HeaderCell.Value = Number2String(i, true);
                dataGridView.Columns[i].HeaderText = Number2String(i, true);

                dataGridView.Columns[i].Width = (dataGridView.Width-50)/dataGridView.ColumnCount;

                for (int j = 0; j < result.GetLength(1); j++)
                {
                    if (result[i, j] == float.MaxValue)
                    {
                        dataGridView[j, i].Value = float.PositiveInfinity;
                    }
                    else
                    {
                        dataGridView[j, i].Value = result[i, j];

                        // only floyd
                        if (predecessor != null)
                        {
                            dataGridView[j, i].Value = result[i, j] + ", " + Number2String(predecessor[i, j], true);
                        }
                    }
                }
            }
            
        }

        public static void PrintDijkstraTable(DataGridView dataGridView, float[] shortestPath, int[] predecessor, int startpoint)
        {
            dataGridView.ColumnCount = 2;
            dataGridView.RowCount = shortestPath.GetLength(0);
            dataGridView.Columns[0].HeaderText = "Distance";
            dataGridView.Columns[1].HeaderText = "Predecessor";

            for (int i = 0; i < predecessor.Length; i++)
            {
                if (i == startpoint)
                {
                    dataGridView[0, i].Value = 0;
                }
                else if (shortestPath[i] == float.MaxValue)
                {
                    dataGridView[0, i].Value = float.PositiveInfinity;
                }
                else
                { 
                    dataGridView[0, i].Value = shortestPath[i];
                }
                dataGridView[1, i].Value = Number2String(predecessor[i], true);
                dataGridView.Rows[i].HeaderCell.Value = Number2String(i, true);
            }
        }

        public static void PrintAStarTable(DataGridView dataGridView, float[] shortestPath, float[] minimalPath, int[] predecessor, int startpoint, int endpoint, float[,] distances)
        {
            dataGridView.ColumnCount = 3;
            dataGridView.RowCount = shortestPath.GetLength(0);
            dataGridView.Columns[0].HeaderText = "Distance";
            dataGridView.Columns[1].HeaderText = "f";
            dataGridView.Columns[2].HeaderText = "Predecessor";
            for (int i = 0; i < predecessor.Length; i++)
            {
                if (i == startpoint)
                {
                    dataGridView[0, i].Value = 0;
                }
                else if (shortestPath[i] == float.MaxValue)
                {
                    dataGridView[0, i].Value = float.PositiveInfinity;
                }
                else
                {
                    dataGridView[0, i].Value = shortestPath[i];
                }
                if((predecessor[i] == startpoint && distances[startpoint,i] == float.MaxValue) || minimalPath[i] == float.MaxValue)
                {
                    dataGridView[2, i].Value = string.Empty;
                    dataGridView[1, i].Value = string.Empty;
                    dataGridView[0, i].Value = string.Empty;
                }
                else
                {
                    dataGridView[2, i].Value = Number2String(predecessor[i], true);
                    dataGridView[1, i].Value = minimalPath[i];
                }
                dataGridView.Rows[i].HeaderCell.Value = Number2String(i, true);
            }
        }

        public static void AdjustRowAndColumnHeaderValue(DataGridView dataGridView1, DataGridView dataGridView2, ComboBox comboBoxStart, ComboBox comboBoxEnd)
        {
            comboBoxStart.Items.Clear();
            comboBoxEnd.Items.Clear();

            for (int i = 0; i < dataGridView1.RowCount-1; i++)
            {
                dataGridView2.Rows[i].HeaderCell.Value = Number2String(i, true);
                dataGridView1.Rows[i].HeaderCell.Value = Number2String(i, true);
                dataGridView2.Columns[i].HeaderText = Number2String(i, true);

                // fill combobox for starting point decision using dijkstra and A*
                comboBoxStart.Items.Add(Number2String(i, true));
                // fill combobox for ending point decision using  A*
                comboBoxEnd.Items.Add(Number2String(i, true));
            }
        }

        public static void AppendPointToDataGridView(DataGridView dataGridView, DataPoint point)
        {
            dataGridView.RowCount++;
            dataGridView.Rows[dataGridView.RowCount - 2].Cells[0].Value = point.X.ToString();
            dataGridView.Rows[dataGridView.RowCount - 2].Cells[1].Value = point.Y.ToString();
        }

        public static DataPoint[] GetPointsFromGrid(DataGridView dataGridView)
        {
            DataPoint[] points = new DataPoint[dataGridView.RowCount - 1];

            for (int i = 0; i < dataGridView.RowCount - 1; i++)
            {
                double x = Convert.ToDouble(dataGridView.Rows[i].Cells[0].Value);
                double y = Convert.ToDouble(dataGridView.Rows[i].Cells[1].Value);

                points[i] = new DataPoint(x, y);
            }

            return points;
        }
    }
}
