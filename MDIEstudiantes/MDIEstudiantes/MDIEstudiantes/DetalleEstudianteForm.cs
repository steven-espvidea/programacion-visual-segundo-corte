using System;
using System.Windows.Forms;

namespace MDIEstudiantes
{
    public partial class DetalleEstudianteForm : Form
    {
        private Estudiante estudiante;
        public DetalleEstudianteForm(Estudiante e)
        {
            estudiante = e;
            InitializeComponent();
            this.Text = $"Detalle - {estudiante.Nombre}";
        }

        private void DetalleEstudianteForm_Load(object sender, EventArgs e)
        {
            txtCarnet.Text = estudiante.Carnet;
            txtNombre.Text = estudiante.Nombre;
            dgvDatos.Rows.Clear();
            foreach (var a in estudiante.Asignaturas)
            {
                dgvDatos.Rows.Add(a.Nombre, a.Nota);
            }
        }
    }
}
