namespace MDIEstudiantes
{
    partial class DetalleEstudianteForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtCarnet;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAsig;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNota;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtCarnet = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.colAsig = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNota = new System.Windows.Forms.DataGridViewTextBoxColumn();

            // txtCarnet
            this.txtCarnet.Location = new System.Drawing.Point(20, 20);
            this.txtCarnet.ReadOnly = true;
            this.txtCarnet.Width = 250;

            // txtNombre
            this.txtNombre.Location = new System.Drawing.Point(20, 55);
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Width = 400;

            // dgvDatos
            this.dgvDatos.Location = new System.Drawing.Point(20, 95);
            this.dgvDatos.Size = new System.Drawing.Size(520, 240);
            this.dgvDatos.RowHeadersVisible = false;
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colAsig, this.colNota
            });

            this.colAsig.HeaderText = "Asignatura";
            this.colAsig.Width = 380;
            this.colNota.HeaderText = "Nota";
            this.colNota.Width = 120;

            // Form
            this.ClientSize = new System.Drawing.Size(560, 360);
            this.Controls.Add(this.txtCarnet);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.dgvDatos);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.DetalleEstudianteForm_Load);
        }
    }
}
