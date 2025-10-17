using System;
using System.Windows.Forms;

namespace MDIEstudiantes
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.Text = "Ingresar Estudiante";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validate
            if (string.IsNullOrWhiteSpace(txtCarnet.Text) || string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingrese carnet y nombre.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var estudiante = new Estudiante
            {
                Carnet = txtCarnet.Text.Trim(),
                Nombre = txtNombre.Text.Trim()
            };

            foreach (DataGridViewRow fila in dgvAsignaturas.Rows)
            {
                if (fila.IsNewRow) continue;
                var nom = fila.Cells[0].Value;
                var nota = fila.Cells[1].Value;
                if (nom != null && nota != null)
                {
                    double n;
                    if (double.TryParse(nota.ToString(), out n))
                    {
                        estudiante.Asignaturas.Add(new Asignatura { Nombre = nom.ToString(), Nota = n });
                    }
                }
            }

            DatosCompartidos.Estudiantes.Add(estudiante);
            MessageBox.Show("Estudiante agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // clear for next entry
            txtCarnet.Clear();
            txtNombre.Clear();
            dgvAsignaturas.Rows.Clear();
            txtCarnet.Focus();
        }
    }
}
