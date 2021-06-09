using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Series;

namespace GraphTheory
{
    public partial class GraphTheoryApplication : Form
    { 
       
        PlotModel myModel = new PlotModel();
        int indexOfCurrentSelectedPoint = -1;
        bool onMouseHold = false;

        public GraphTheoryApplication()
        {
            InitializeComponent();
            myModel.Series.Add(new LineSeries());
            myModel.Series.Add(new LineSeries());
            plotViewGraph.Model = myModel;

            DrawGraph.DrawAll(myModel, dataGridViewGraphTheoryPoints, dataGridViewGraphTheoryDistances);
            InitalizeMouseEvents(myModel);

            plotViewGraph.MouseUp += PlotViewGraph_MouseUp;
        }

        private void InitalizeMouseEvents(PlotModel myModel)
        {


            DataPoint[] points = HandleGrids.GetPointsFromGrid(dataGridViewGraphTheoryPoints);
            LineSeries controlPoints = new LineSeries
            {
                Title = "Nodes",
                MarkerType = MarkerType.Circle,
                LineStyle = LineStyle.None,
                Color = OxyColors.Red
            };
           
            myModel.MouseDown += (s, e) =>
            {

                double x, y;

                DataPoint[] point = HandleGrids.GetPointsFromGrid(dataGridViewGraphTheoryPoints);

                x = controlPoints.InverseTransform(e.Position).X;
                y = controlPoints.InverseTransform(e.Position).Y;

                //Get the distance from two points 9 pixels apart
                ScreenPoint screenPointOne = new ScreenPoint(0, 0);
                ScreenPoint screenPointTwo = new ScreenPoint(7, 7);

                DataPoint dataPointOne = controlPoints.InverseTransform(screenPointOne);
                DataPoint dataPointTwo = controlPoints.InverseTransform(screenPointTwo);

                double dx = dataPointOne.X - dataPointTwo.X;
                double dy = dataPointOne.Y - dataPointTwo.Y;

                double distance = Math.Sqrt(dx * dx + dy * dy);

                int index;
                bool sucessfullGrap = DrawGraph.IsInDistance(distance, point, new DataPoint(x, y), out index);
                if (e.ChangedButton != OxyMouseButton.Middle)
                {
                    DrawGraph.DrawAll(myModel, dataGridViewGraphTheoryPoints, dataGridViewGraphTheoryDistances);
                }

                if (e.ChangedButton == OxyMouseButton.Right && sucessfullGrap)
                {
                    dataGridViewGraphTheoryPoints.Rows.RemoveAt(index);
                    DrawGraph.DrawAll(myModel, dataGridViewGraphTheoryPoints, dataGridViewGraphTheoryDistances);

                    dataGridViewGraphTheoryEndmatrix.RowCount = 0;
                    dataGridViewGraphTheoryEndmatrix.ColumnCount = 0;

                    return;
                }

                if (e.ChangedButton == OxyMouseButton.Left && !sucessfullGrap)
                {
                    HandleGrids.AppendPointToDataGridView(dataGridViewGraphTheoryPoints, new DataPoint(x, y));
                    DrawGraph.DrawAll(myModel, dataGridViewGraphTheoryPoints, dataGridViewGraphTheoryDistances);

                    return;
                }

                if (e.ChangedButton == OxyMouseButton.Left && sucessfullGrap)
                {
                    onMouseHold = true;
                    indexOfCurrentSelectedPoint = index;
                }

            };

            myModel.MouseMove += (s, e) =>
            {
                myModel.ZoomAllAxes(1);
                if (onMouseHold)
                {
                    DataPoint[] point = HandleGrids.GetPointsFromGrid(dataGridViewGraphTheoryPoints);

                    double x, y;

                    x = controlPoints.InverseTransform(e.Position).X;
                    y = controlPoints.InverseTransform(e.Position).Y;

                    dataGridViewGraphTheoryPoints.Rows[indexOfCurrentSelectedPoint].Cells[0].Value = x.ToString();
                    dataGridViewGraphTheoryPoints.Rows[indexOfCurrentSelectedPoint].Cells[1].Value = y.ToString();
                    
                    DrawGraph.DrawAll(myModel, dataGridViewGraphTheoryPoints, dataGridViewGraphTheoryDistances);
                }
            };

            DrawGraph.DrawControlPoints(myModel, controlPoints, points);
        }


        private void buttonGraphTheory_Click(object sender, EventArgs e)
        {
           
            float[,] distances = new float[dataGridViewGraphTheoryDistances.RowCount, dataGridViewGraphTheoryDistances.ColumnCount];
            
            for (int i = 0; i < dataGridViewGraphTheoryDistances.RowCount; i++)  
            {
                for (int j = 0; j < dataGridViewGraphTheoryDistances.ColumnCount; j++)
                {
                    if (i == j)
                    {
                        distances[i, j] = 0;
                    }
                    else if (dataGridViewGraphTheoryDistances[j, i].Value == null) //.ToString() == string.Empty)
                    {
                        distances[i, j] = float.MaxValue;
                    }
                    else
                    {
                        distances[i, j] = Convert.ToSingle(dataGridViewGraphTheoryDistances[j, i].Value);
                    }
                }
            }

            ExecuteSelectedAlgorithm(distances);

        }

        private void ExecuteSelectedAlgorithm(float[,] distances)
        {
            float[,] result = new float[distances.GetLength(0), distances.GetLength(1)];
            List<Tuple<float, int, int>> sortedDistances = new List<Tuple<float, int, int>> { };
            DataPoint[] points = HandleGrids.GetPointsFromGrid(dataGridViewGraphTheoryPoints);
            switch (comboBoxGraphTheory.SelectedItem)
            {
                case "Depth-first search":
                    DepthFirstSearch dfs = new DepthFirstSearch();
                    if (comboBoxStartPoint.SelectedIndex == -1)
                    {
                        MessageBox.Show("Choose starting point");
                        return;
                    }
                    dfs.ExecuteDFS(distances, ref result, comboBoxStartPoint.SelectedIndex, dataGridViewGraphTheoryEndmatrix);
                    DrawGraph.DrawMinimalSpanningTree(myModel, dataGridViewGraphTheoryDistances, result, points, dataGridViewGraphTheoryPoints);
                    break;

                case "Breadth-first search":
                    BreadthFirstSearch bfs = new BreadthFirstSearch();
                    if (comboBoxStartPoint.SelectedIndex == -1)
                    {
                        MessageBox.Show("Choose starting point");
                        return;
                    }
                    bfs.ExecuteBFS(distances, ref result, comboBoxStartPoint.SelectedIndex, dataGridViewGraphTheoryEndmatrix);
                    DrawGraph.DrawMinimalSpanningTree(myModel, dataGridViewGraphTheoryDistances, result, points, dataGridViewGraphTheoryPoints);
                    break;

                case "Boruvka":
                    Boruvka boruvka = new Boruvka();
                    boruvka.ExecuteBorvka(distances, ref result, sortedDistances, dataGridViewGraphTheoryEndmatrix);
                    DrawGraph.DrawMinimalSpanningTree(myModel, dataGridViewGraphTheoryDistances, result, points, dataGridViewGraphTheoryPoints);
                    break;

                case "Kruskal":
                    Kruskal kruskal = new Kruskal();
                    kruskal.ExecuteKruskal(distances, ref result, sortedDistances, dataGridViewGraphTheoryEndmatrix);
                    DrawGraph.DrawMinimalSpanningTree(myModel, dataGridViewGraphTheoryDistances, result, points, dataGridViewGraphTheoryPoints);
                    break;

                case "Prim":
                    Prim prim = new Prim();
                    if (comboBoxStartPoint.SelectedIndex == -1)
                    {
                        MessageBox.Show("Choose starting point");
                        return;
                    }
                    prim.ExecutePrim(distances, ref result, sortedDistances, dataGridViewGraphTheoryEndmatrix);
                    DrawGraph.DrawMinimalSpanningTree(myModel, dataGridViewGraphTheoryDistances, result, points, dataGridViewGraphTheoryPoints);
                    break;

                case "Dijkstra":
                    Dijkstra dijkstra = new Dijkstra();
                    if (comboBoxStartPoint.SelectedIndex == -1)
                    {
                        MessageBox.Show("Choose starting point");
                        return;
                    }
                    dijkstra.ExecuteDijkstra(ref distances, dataGridViewGraphTheoryEndmatrix, comboBoxStartPoint.SelectedIndex);
                    break;

                case "A*":
                    if (comboBoxStartPoint.SelectedIndex == -1 || comboBoxEndPoint.SelectedIndex == -1)
                    {
                        MessageBox.Show("Choose starting point and ending point");
                        return;
                    }
                    AStar astar = new AStar();
                    int[] predecessorA;
                    float[] minimalPath, shortestPathA;
                    astar.AStarAlgorithm(distances, out shortestPathA, out predecessorA, out minimalPath, comboBoxStartPoint.SelectedIndex, comboBoxEndPoint.SelectedIndex);
                    HandleGrids.PrintAStarTable(dataGridViewGraphTheoryEndmatrix, shortestPathA, minimalPath, predecessorA, comboBoxStartPoint.SelectedIndex, comboBoxEndPoint.SelectedIndex, distances);
                    break;

                case "Floyd-Warshall":
                    FloydWarshall floydWarshall = new FloydWarshall();
                    int[,] predecessors = new int[distances.GetLength(0), distances.GetLength(1)];
                    predecessors = floydWarshall.FloydWarshallAlgorithm(ref distances);
                    HandleGrids.FillEndGrid(dataGridViewGraphTheoryEndmatrix, distances, predecessors);
                    break;

                default:
                    MessageBox.Show("You have to choose an algorithm!");
                    break;
            }
        }



        public static String Number2String(int number, bool isCaps)
        {
            string letter;
            if (number < 26)
            {
                Char c = (Char)((isCaps ? 65 : 97) + (number));
                letter = c.ToString();
            }
            else
            {
                Char first = (Char)((isCaps ? 65 : 97) + ((int)Math.Floor(number/25.0) - 1));
                Char second= (Char)((isCaps ? 65 : 97) + (number - ((int)Math.Floor(number / 25.0) * 25 )));
                letter = first.ToString() + second.ToString();
            }
            return letter;
        }

        private void dataGridViewGraphTheoryPoints_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            HandleGrids.NumberAsInput(dataGridViewGraphTheoryPoints,e);
        }

        private void dataGridViewGraphTheoryDistances_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            HandleGrids.NumberAsInput(dataGridViewGraphTheoryDistances, e);
            float number;
            if (float.TryParse(e.FormattedValue.ToString(), out number))
            {
                if(number < 0)
                e.Cancel = true;
            }
        }

        private void dataGridViewGraphTheoryPoints_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dataGridViewGraphTheoryDistances.RowCount = dataGridViewGraphTheoryPoints.RowCount-1;
            dataGridViewGraphTheoryDistances.ColumnCount = dataGridViewGraphTheoryPoints.RowCount - 1;

            dataGridViewGraphTheoryDistances.Columns[dataGridViewGraphTheoryDistances.ColumnCount - 1].SortMode = DataGridViewColumnSortMode.NotSortable;

            HandleGrids.AdjustRowAndColumnHeaderValue(dataGridViewGraphTheoryPoints,dataGridViewGraphTheoryDistances,comboBoxStartPoint, comboBoxEndPoint);
            dataGridViewGraphTheoryDistances.Columns[dataGridViewGraphTheoryDistances.ColumnCount - 1].Width = 50;

            dataGridViewGraphTheoryEndmatrix.RowCount = 0;
            dataGridViewGraphTheoryEndmatrix.ColumnCount = 0;

            DrawGraph.DrawAll(myModel, dataGridViewGraphTheoryPoints, dataGridViewGraphTheoryDistances);
        }

        private void dataGridViewGraphTheoryPoints_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            dataGridViewGraphTheoryDistances.Rows.RemoveAt(e.RowIndex);
            dataGridViewGraphTheoryDistances.Columns.RemoveAt(e.RowIndex);
            HandleGrids.AdjustRowAndColumnHeaderValue(dataGridViewGraphTheoryPoints, dataGridViewGraphTheoryDistances, comboBoxStartPoint, comboBoxEndPoint);

            dataGridViewGraphTheoryEndmatrix.RowCount = 0;
            dataGridViewGraphTheoryEndmatrix.ColumnCount = 0;

            DrawGraph.DrawAll(myModel, dataGridViewGraphTheoryPoints, dataGridViewGraphTheoryDistances);
        }

        private void PlotViewGraph_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && onMouseHold)
            {
                onMouseHold = false;
            }
        }

        private void dataGridViewGraphTheoryDistances_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.Equals(null) || e.ColumnIndex >= dataGridViewGraphTheoryPoints.RowCount-1 || e.RowIndex >= dataGridViewGraphTheoryPoints.RowCount-1)
            {
                return;
            }
            dataGridViewGraphTheoryEndmatrix.RowCount = 0;
            dataGridViewGraphTheoryEndmatrix.ColumnCount = 0;
            DrawGraph.DrawAll(myModel, dataGridViewGraphTheoryPoints, dataGridViewGraphTheoryDistances);
            
        }

        private void dataGridViewGraphTheoryPoints_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.Equals(null) || e.ColumnIndex >= dataGridViewGraphTheoryPoints.RowCount-1 || e.RowIndex >= dataGridViewGraphTheoryPoints.RowCount-1)
            {
                return;
            }
            DrawGraph.DrawAll(myModel, dataGridViewGraphTheoryPoints, dataGridViewGraphTheoryDistances);
        }

        private void comboBoxGraphTheory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxGraphTheory.SelectedItem.ToString() == "Dijkstra" || comboBoxGraphTheory.SelectedItem.ToString() == "Depth-first search"
                || comboBoxGraphTheory.SelectedItem.ToString() == "Breadth-first search")
            {
                labelChooseStartpoint.Visible = true;
                comboBoxStartPoint.Visible = true;
                labelChooseEndpoint.Visible = false;
                comboBoxEndPoint.Visible = false;
            }
            else if(comboBoxGraphTheory.SelectedItem.ToString() == "A*")
            {
                labelChooseStartpoint.Visible = true;
                comboBoxStartPoint.Visible = true;
                labelChooseEndpoint.Visible = true;
                comboBoxEndPoint.Visible = true;
            }
            else
            {
                labelChooseStartpoint.Visible = false;
                comboBoxStartPoint.Visible = false;
                labelChooseEndpoint.Visible = false;
                comboBoxEndPoint.Visible = false;
            }
        }
    }
}
