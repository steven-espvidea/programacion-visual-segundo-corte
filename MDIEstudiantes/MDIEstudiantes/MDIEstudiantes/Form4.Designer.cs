namespace MDIEstudiantes
{
    partial class Form4
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            var ca = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            var lg = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.chart1.BeginInit();
            ca.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(ca);
            lg.Name = "Legend1";
            this.chart1.Legends.Add(lg);
            this.chart1.Location = new System.Drawing.Point(15, 15);
            this.chart1.Size = new System.Drawing.Size(760, 420);
            this.chart1.EndInit();

            // Form4
            this.ClientSize = new System.Drawing.Size(800, 460);
            this.Controls.Add(this.chart1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.Form4_Load);
        }
    }
}
