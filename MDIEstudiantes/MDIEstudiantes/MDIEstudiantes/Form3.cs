using System;
using System.Linq;
using System.Windows.Forms;

namespace MDIEstudiantes
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            this.Text = "Listado de Estudiantes";
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            CargarListado();
        }

        public void CargarListado()
        {
            dgvEstudiantes.Rows.Clear();
            foreach (var est in DatosCompartidos.Estudiantes)
            {
                dgvEstudiantes.Rows.Add(est.Carnet, est.Nombre, Math.Round(est.Promedio, 2));
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarListado();
        }

        private void dgvEstudiantes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.RowIndex < DatosCompartidos.Estudiantes.Count)
            {
                var est = DatosCompartidos.Estudiantes[e.RowIndex];
                var detalles = new DetalleEstudianteForm(est);
                detalles.MdiParent = this.MdiParent;
                detalles.Show();
            }
        }
    }
}
