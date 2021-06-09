namespace GraphTheory
{
    partial class GraphTheoryApplication
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewGraphTheoryEndmatrix = new System.Windows.Forms.DataGridView();
            this.buttonGraphTheory = new System.Windows.Forms.Button();
            this.comboBoxGraphTheory = new System.Windows.Forms.ComboBox();
            this.labelGraphTheorie = new System.Windows.Forms.Label();
            this.dataGridViewGraphTheoryDistances = new System.Windows.Forms.DataGridView();
            this.dataGridViewGraphTheoryPoints = new System.Windows.Forms.DataGridView();
            this.X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plotViewGraph = new OxyPlot.WindowsForms.PlotView();
            this.Nodes = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxStartPoint = new System.Windows.Forms.ComboBox();
            this.labelChooseStartpoint = new System.Windows.Forms.Label();
            this.labelChooseEndpoint = new System.Windows.Forms.Label();
            this.comboBoxEndPoint = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGraphTheoryEndmatrix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGraphTheoryDistances)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGraphTheoryPoints)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewGraphTheoryEndmatrix
            // 
            this.dataGridViewGraphTheoryEndmatrix.AllowUserToAddRows = false;
            this.dataGridViewGraphTheoryEndmatrix.AllowUserToDeleteRows = false;
            this.dataGridViewGraphTheoryEndmatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGraphTheoryEndmatrix.Location = new System.Drawing.Point(900, 334);
            this.dataGridViewGraphTheoryEndmatrix.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewGraphTheoryEndmatrix.Name = "dataGridViewGraphTheoryEndmatrix";
            this.dataGridViewGraphTheoryEndmatrix.ReadOnly = true;
            this.dataGridViewGraphTheoryEndmatrix.RowHeadersWidth = 50;
            this.dataGridViewGraphTheoryEndmatrix.Size = new System.Drawing.Size(514, 304);
            this.dataGridViewGraphTheoryEndmatrix.TabIndex = 12;
            // 
            // buttonGraphTheory
            // 
            this.buttonGraphTheory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.buttonGraphTheory.Location = new System.Drawing.Point(899, 224);
            this.buttonGraphTheory.Margin = new System.Windows.Forms.Padding(4);
            this.buttonGraphTheory.Name = "buttonGraphTheory";
            this.buttonGraphTheory.Size = new System.Drawing.Size(387, 48);
            this.buttonGraphTheory.TabIndex = 11;
            this.buttonGraphTheory.Text = "Calculate";
            this.buttonGraphTheory.UseVisualStyleBackColor = true;
            this.buttonGraphTheory.Click += new System.EventHandler(this.buttonGraphTheory_Click);
            // 
            // comboBoxGraphTheory
            // 
            this.comboBoxGraphTheory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGraphTheory.FormattingEnabled = true;
            this.comboBoxGraphTheory.Items.AddRange(new object[] {
            "Depth-first search",
            "Breadth-first search",
            "Boruvka",
            "Kruskal",
            "Prim",
            "Dijkstra",
            "A*",
            "Floyd-Warshall"});
            this.comboBoxGraphTheory.Location = new System.Drawing.Point(900, 56);
            this.comboBoxGraphTheory.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxGraphTheory.Name = "comboBoxGraphTheory";
            this.comboBoxGraphTheory.Size = new System.Drawing.Size(387, 24);
            this.comboBoxGraphTheory.TabIndex = 10;
            this.comboBoxGraphTheory.SelectedIndexChanged += new System.EventHandler(this.comboBoxGraphTheory_SelectedIndexChanged);
            // 
            // labelGraphTheorie
            // 
            this.labelGraphTheorie.AutoSize = true;
            this.labelGraphTheorie.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.labelGraphTheorie.Location = new System.Drawing.Point(895, 22);
            this.labelGraphTheorie.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelGraphTheorie.Name = "labelGraphTheorie";
            this.labelGraphTheorie.Size = new System.Drawing.Size(214, 30);
            this.labelGraphTheorie.TabIndex = 9;
            this.labelGraphTheorie.Text = "Choose algorithm";
            // 
            // dataGridViewGraphTheoryDistances
            // 
            this.dataGridViewGraphTheoryDistances.AllowUserToAddRows = false;
            this.dataGridViewGraphTheoryDistances.AllowUserToDeleteRows = false;
            this.dataGridViewGraphTheoryDistances.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGraphTheoryDistances.Location = new System.Drawing.Point(340, 56);
            this.dataGridViewGraphTheoryDistances.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewGraphTheoryDistances.Name = "dataGridViewGraphTheoryDistances";
            this.dataGridViewGraphTheoryDistances.RowHeadersWidth = 60;
            this.dataGridViewGraphTheoryDistances.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewGraphTheoryDistances.Size = new System.Drawing.Size(483, 258);
            this.dataGridViewGraphTheoryDistances.TabIndex = 8;
            this.dataGridViewGraphTheoryDistances.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewGraphTheoryDistances_CellEndEdit);
            this.dataGridViewGraphTheoryDistances.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridViewGraphTheoryDistances_CellValidating);
            // 
            // dataGridViewGraphTheoryPoints
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewGraphTheoryPoints.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewGraphTheoryPoints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGraphTheoryPoints.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.X,
            this.Y});
            this.dataGridViewGraphTheoryPoints.Location = new System.Drawing.Point(12, 56);
            this.dataGridViewGraphTheoryPoints.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewGraphTheoryPoints.Name = "dataGridViewGraphTheoryPoints";
            this.dataGridViewGraphTheoryPoints.RowHeadersWidth = 60;
            this.dataGridViewGraphTheoryPoints.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewGraphTheoryPoints.Size = new System.Drawing.Size(255, 258);
            this.dataGridViewGraphTheoryPoints.TabIndex = 7;
            this.dataGridViewGraphTheoryPoints.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewGraphTheoryPoints_CellEndEdit);
            this.dataGridViewGraphTheoryPoints.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridViewGraphTheoryPoints_CellValidating);
            this.dataGridViewGraphTheoryPoints.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridViewGraphTheoryPoints_RowsAdded);
            this.dataGridViewGraphTheoryPoints.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridViewGraphTheoryPoints_RowsRemoved);
            // 
            // X
            // 
            this.X.HeaderText = "X";
            this.X.Name = "X";
            this.X.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.X.Width = 60;
            // 
            // Y
            // 
            this.Y.HeaderText = "Y";
            this.Y.Name = "Y";
            this.Y.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Y.Width = 60;
            // 
            // plotViewGraph
            // 
            this.plotViewGraph.BackColor = System.Drawing.SystemColors.ControlLight;
            this.plotViewGraph.Location = new System.Drawing.Point(12, 334);
            this.plotViewGraph.Name = "plotViewGraph";
            this.plotViewGraph.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotViewGraph.Size = new System.Drawing.Size(811, 304);
            this.plotViewGraph.TabIndex = 13;
            this.plotViewGraph.Text = "plotView1";
            this.plotViewGraph.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotViewGraph.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotViewGraph.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            this.plotViewGraph.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PlotViewGraph_MouseUp);
            // 
            // Nodes
            // 
            this.Nodes.AutoSize = true;
            this.Nodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Nodes.Location = new System.Drawing.Point(12, 22);
            this.Nodes.Name = "Nodes";
            this.Nodes.Size = new System.Drawing.Size(57, 20);
            this.Nodes.TabIndex = 14;
            this.Nodes.Text = "Nodes";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(337, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "Distances";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(897, 297);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "Results";
            // 
            // comboBoxStartPoint
            // 
            this.comboBoxStartPoint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStartPoint.FormattingEnabled = true;
            this.comboBoxStartPoint.Location = new System.Drawing.Point(900, 118);
            this.comboBoxStartPoint.Name = "comboBoxStartPoint";
            this.comboBoxStartPoint.Size = new System.Drawing.Size(386, 24);
            this.comboBoxStartPoint.TabIndex = 17;
            this.comboBoxStartPoint.Visible = false;
            // 
            // labelChooseStartpoint
            // 
            this.labelChooseStartpoint.AutoSize = true;
            this.labelChooseStartpoint.Location = new System.Drawing.Point(897, 98);
            this.labelChooseStartpoint.Name = "labelChooseStartpoint";
            this.labelChooseStartpoint.Size = new System.Drawing.Size(119, 17);
            this.labelChooseStartpoint.TabIndex = 18;
            this.labelChooseStartpoint.Text = "Choose startpoint";
            this.labelChooseStartpoint.Visible = false;
            // 
            // labelChooseEndpoint
            // 
            this.labelChooseEndpoint.AutoSize = true;
            this.labelChooseEndpoint.Location = new System.Drawing.Point(898, 157);
            this.labelChooseEndpoint.Name = "labelChooseEndpoint";
            this.labelChooseEndpoint.Size = new System.Drawing.Size(115, 17);
            this.labelChooseEndpoint.TabIndex = 20;
            this.labelChooseEndpoint.Text = "Choose endpoint";
            this.labelChooseEndpoint.Visible = false;
            // 
            // comboBoxEndPoint
            // 
            this.comboBoxEndPoint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEndPoint.FormattingEnabled = true;
            this.comboBoxEndPoint.Location = new System.Drawing.Point(901, 177);
            this.comboBoxEndPoint.Name = "comboBoxEndPoint";
            this.comboBoxEndPoint.Size = new System.Drawing.Size(386, 24);
            this.comboBoxEndPoint.TabIndex = 19;
            this.comboBoxEndPoint.Visible = false;
            // 
            // GraphTheoryApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1435, 650);
            this.Controls.Add(this.labelChooseEndpoint);
            this.Controls.Add(this.comboBoxEndPoint);
            this.Controls.Add(this.labelChooseStartpoint);
            this.Controls.Add(this.comboBoxStartPoint);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Nodes);
            this.Controls.Add(this.plotViewGraph);
            this.Controls.Add(this.dataGridViewGraphTheoryEndmatrix);
            this.Controls.Add(this.buttonGraphTheory);
            this.Controls.Add(this.comboBoxGraphTheory);
            this.Controls.Add(this.labelGraphTheorie);
            this.Controls.Add(this.dataGridViewGraphTheoryDistances);
            this.Controls.Add(this.dataGridViewGraphTheoryPoints);
            this.Name = "GraphTheoryApplication";
            this.Text = "Graph-Theory application";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGraphTheoryEndmatrix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGraphTheoryDistances)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGraphTheoryPoints)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewGraphTheoryEndmatrix;
        private System.Windows.Forms.Button buttonGraphTheory;
        private System.Windows.Forms.ComboBox comboBoxGraphTheory;
        private System.Windows.Forms.Label labelGraphTheorie;
        private System.Windows.Forms.DataGridView dataGridViewGraphTheoryDistances;
        private System.Windows.Forms.DataGridView dataGridViewGraphTheoryPoints;
        private OxyPlot.WindowsForms.PlotView plotViewGraph;
        private System.Windows.Forms.Label Nodes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxStartPoint;
        private System.Windows.Forms.Label labelChooseStartpoint;
        private System.Windows.Forms.DataGridViewTextBoxColumn X;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y;
        private System.Windows.Forms.Label labelChooseEndpoint;
        private System.Windows.Forms.ComboBox comboBoxEndPoint;
    }
}

