using System;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MDIEstudiantes
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            this.Text = "Gráfico - Mejores Promedios";
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            CargarGrafico();
        }

        private void CargarGrafico()
        {
            chart1.Series.Clear();
            var series = new Series("Promedios");
            series.ChartType = SeriesChartType.Bar;
            chart1.Series.Add(series);

            chart1.ChartAreas[0].AxisX.Title = "Estudiantes";
            chart1.ChartAreas[0].AxisY.Title = "Notas";

            var sorted = DatosCompartidos.Estudiantes.OrderByDescending(x => x.Promedio).ToList();
            foreach (var est in sorted)
            {
                series.Points.AddXY( est.Nombre, Math.Round(est.Promedio, 2));
            }
            chart1.Invalidate();
        }
    }
}
