namespace Otomasyon_Projesi
{
    partial class FrmAdminİstatistik
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAdminİstatistik));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tabloTool = new System.Windows.Forms.ToolStripButton();
            this.pastaTool = new System.Windows.Forms.ToolStripButton();
            this.histTool = new System.Windows.Forms.ToolStripButton();
            this.chartHist = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartPasta = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ToolAlım = new System.Windows.Forms.ToolStripButton();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartHist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPasta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tabloTool,
            this.ToolAlım,
            this.pastaTool,
            this.histTool});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(520, 22);
            this.toolStrip1.TabIndex = 2;
            // 
            // tabloTool
            // 
            this.tabloTool.Checked = true;
            this.tabloTool.CheckOnClick = true;
            this.tabloTool.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tabloTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tabloTool.Image = ((System.Drawing.Image)(resources.GetObject("tabloTool.Image")));
            this.tabloTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tabloTool.Name = "tabloTool";
            this.tabloTool.Size = new System.Drawing.Size(48, 19);
            this.tabloTool.Text = "Satışlar";
            this.tabloTool.Click += new System.EventHandler(this.tabloTool_Click);
            // 
            // pastaTool
            // 
            this.pastaTool.Checked = true;
            this.pastaTool.CheckOnClick = true;
            this.pastaTool.CheckState = System.Windows.Forms.CheckState.Checked;
            this.pastaTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.pastaTool.Image = ((System.Drawing.Image)(resources.GetObject("pastaTool.Image")));
            this.pastaTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pastaTool.Name = "pastaTool";
            this.pastaTool.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always;
            this.pastaTool.Size = new System.Drawing.Size(73, 19);
            this.pastaTool.Text = "Pasta Grafik";
            this.pastaTool.Click += new System.EventHandler(this.pastaTool_Click);
            // 
            // histTool
            // 
            this.histTool.Checked = true;
            this.histTool.CheckOnClick = true;
            this.histTool.CheckState = System.Windows.Forms.CheckState.Checked;
            this.histTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.histTool.Image = ((System.Drawing.Image)(resources.GetObject("histTool.Image")));
            this.histTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.histTool.Name = "histTool";
            this.histTool.Size = new System.Drawing.Size(67, 19);
            this.histTool.Text = "Histogram";
            this.histTool.Click += new System.EventHandler(this.histTool_Click_1);
            // 
            // chartHist
            // 
            chartArea3.Name = "ChartArea1";
            this.chartHist.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartHist.Legends.Add(legend3);
            this.chartHist.Location = new System.Drawing.Point(0, 25);
            this.chartHist.Name = "chartHist";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Satışlar";
            this.chartHist.Series.Add(series3);
            this.chartHist.Size = new System.Drawing.Size(519, 344);
            this.chartHist.TabIndex = 3;
            this.chartHist.Text = "chart1";
            this.chartHist.Visible = false;
            // 
            // chartPasta
            // 
            chartArea4.Name = "ChartArea1";
            this.chartPasta.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            legend4.Title = "Toplam Tutar Dağılımları";
            this.chartPasta.Legends.Add(legend4);
            this.chartPasta.Location = new System.Drawing.Point(0, 25);
            this.chartPasta.Name = "chartPasta";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chartPasta.Series.Add(series4);
            this.chartPasta.Size = new System.Drawing.Size(519, 344);
            this.chartPasta.TabIndex = 4;
            this.chartPasta.Text = "chart1";
            this.chartPasta.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 25);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(519, 344);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // ToolAlım
            // 
            this.ToolAlım.Checked = true;
            this.ToolAlım.CheckOnClick = true;
            this.ToolAlım.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ToolAlım.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToolAlım.Image = ((System.Drawing.Image)(resources.GetObject("ToolAlım.Image")));
            this.ToolAlım.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolAlım.Name = "ToolAlım";
            this.ToolAlım.Size = new System.Drawing.Size(49, 19);
            this.ToolAlım.Text = "Alımlar";
            this.ToolAlım.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(1, 25);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(519, 344);
            this.dataGridView2.TabIndex = 6;
            this.dataGridView2.Visible = false;
            // 
            // FrmAdminİstatistik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(520, 369);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.chartPasta);
            this.Controls.Add(this.chartHist);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAdminİstatistik";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "İstatistik";
            this.Load += new System.EventHandler(this.FrmAdminİstatistik_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartHist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPasta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn perADDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn perSoyadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn perSatisTutarDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartHist;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPasta;
        private System.Windows.Forms.ToolStripButton tabloTool;
        private System.Windows.Forms.ToolStripButton pastaTool;
        private System.Windows.Forms.ToolStripButton histTool;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripButton ToolAlım;
        private System.Windows.Forms.DataGridView dataGridView2;
    }
}