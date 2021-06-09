using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphTheory
{
    public class DrawGraph : GraphTheoryApplication
    {
        public static bool IsInDistance(double maxDistance, DataPoint[] points, DataPoint point, out int indexOfMin)
        {
            int currentIndex = 0;
            double currentMaxDistance = maxDistance;

            for (int i = 0; i < points.Length; i++)
            {
                double dx = points[i].X - point.X;
                double dy = points[i].Y - point.Y;

                double distance = Math.Sqrt(dx * dx + dy * dy);
                if (currentMaxDistance > distance)
                {
                    currentIndex = i;
                    currentMaxDistance = distance;
                }
            }

            if (maxDistance == currentMaxDistance)
            {
                indexOfMin = 0;
                return false;
            }

            indexOfMin = currentIndex;
            return true;
        }

        public static void DrawControlPoints(PlotModel myModel, LineSeries controlPoints, DataPoint[] points)
        {
            controlPoints.Points.Clear();
            for (int i = 0; i < points.Length; i++)
            {
                controlPoints.Points.Add(points[i]);
                var textAnnotation = new TextAnnotation
                {
                    Stroke = OxyColors.Transparent,
                    Text = Number2String(i,true),
                    TextPosition = points[i]
                };
                myModel.Annotations.Add(textAnnotation);
            }
            myModel.Series[0] = controlPoints;
        }

        public static void DrawAll(PlotModel myModel, DataGridView dataGridView1, DataGridView dataGridView2)
        {
            DataPoint[] points = HandleGrids.GetPointsFromGrid(dataGridView1);
            LineSeries controlPoints = new LineSeries
            {
                Title = "Nodes",
                MarkerType = MarkerType.Circle,
                LineStyle = LineStyle.None,
                MarkerOutline = new ScreenPoint[10],
                
                Color = OxyColors.Red
            };
            myModel.Annotations.Clear();
            DrawDistances(myModel, controlPoints, points, dataGridView2, dataGridView1);
            myModel.Series.Clear();
            myModel.Series.Add(new LineSeries());
            DrawControlPoints(myModel, controlPoints, points);

            myModel.InvalidatePlot(true);
        }


        public static  void DrawDistances(PlotModel myModel, LineSeries controlPoints, DataPoint[] points, DataGridView dataGridViewDistance, DataGridView dataGridViewPoint)
        {
            
            for (int i = 0; i < dataGridViewDistance.RowCount; i++)
            {
                for (int j = 0; j < dataGridViewDistance.ColumnCount; j++)
                {
                    if (dataGridViewDistance[j, i].Value != null && dataGridViewDistance[j, i].Value.ToString() != "0" && i != j)
                    {
                        DrawArrow(OxyColors.Blue, myModel, points, dataGridViewPoint, dataGridViewDistance, i, j);                       
                    }
                }
            }
        }


        public static void DrawMinimalSpanningTree(PlotModel myModel, DataGridView dataGridViewDistance, float[,] spanningTree, DataPoint[] points, DataGridView dataGridViewPoint)
        {
            myModel.Annotations.Clear();
            for (int i = 0; i < dataGridViewDistance.RowCount; i++)
            {
                for (int j = 0; j < dataGridViewDistance.ColumnCount; j++)
                {
                    if (dataGridViewDistance[j, i].Value != null && dataGridViewDistance[j, i].Value.ToString() != "0" && i != j)
                    {
                        if (spanningTree[i, j] != 0)
                        {
                            DrawArrow(OxyColors.Red, myModel, points, dataGridViewPoint, dataGridViewDistance, i, j);
                        }
                        else if(spanningTree[j,i] != 0)// && dataGridViewDistance[j, i].Value != null)
                        {
                            //DrawArrow(OxyColors.Blue, myModel, points, dataGridViewPoint, dataGridViewDistance, i, j);
                            DrawArrow(OxyColors.Red, myModel, points, dataGridViewPoint, dataGridViewDistance, i, j);
                        }
                        else
                        {
                            DrawArrow(OxyColors.Blue, myModel, points, dataGridViewPoint, dataGridViewDistance, i, j);
                        }
                    }
                }
            }
            LineSeries controlPoints = new LineSeries()
            {
                Title = "Nodes",
                MarkerType = MarkerType.Circle,
                LineStyle = LineStyle.None,
                Color = OxyColors.Red
            };
            DrawControlPoints(myModel, controlPoints, points);
            myModel.InvalidatePlot(true);
        }

        public static void DrawArrow(OxyColor color, PlotModel myModel, DataPoint[] points, DataGridView dataGridViewPoint, DataGridView dataGridViewDistance, int i, int j)
        {
            var arrowAnnotation = new ArrowAnnotation
            {
                HeadWidth = 3,
                HeadLength = 5,
                StartPoint = points[i],
                EndPoint = points[j],
                Color = color,

                //TextHorizontalAlignment = OxyPlot.HorizontalAlignment.Left,
                //TextVerticalAlignment = VerticalAlignment.Top,
                Text = dataGridViewDistance[j, i].Value.ToString(),
                TextPosition = new DataPoint((Convert.ToDouble(dataGridViewPoint[0, i].Value) + Convert.ToDouble(dataGridViewPoint[0, j].Value)) / 2 + 2,
                                            (Convert.ToDouble(dataGridViewPoint[1, i].Value) + Convert.ToDouble(dataGridViewPoint[1, j].Value)) / 2 + 2)
            };

            myModel.Annotations.Add(arrowAnnotation);
        }
    }
}
