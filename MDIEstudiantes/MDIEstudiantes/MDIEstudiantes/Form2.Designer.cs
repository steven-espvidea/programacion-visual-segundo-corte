namespace MDIEstudiantes
{
    partial class Form2
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblCarnet;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtCarnet;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.DataGridView dgvAsignaturas;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAsignatura;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNota;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblCarnet = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtCarnet = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.dgvAsignaturas = new System.Windows.Forms.DataGridView();
            this.colAsignatura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGuardar = new System.Windows.Forms.Button();

            // lblCarnet
            this.lblCarnet.AutoSize = true;
            this.lblCarnet.Location = new System.Drawing.Point(20, 20);
            this.lblCarnet.Text = "Carnet:";

            // txtCarnet
            this.txtCarnet.Location = new System.Drawing.Point(100, 16);
            this.txtCarnet.Width = 250;

            // lblNombre
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(20, 55);
            this.lblNombre.Text = "Nombre:";

            // txtNombre
            this.txtNombre.Location = new System.Drawing.Point(100, 52);
            this.txtNombre.Width = 400;

            // dgvAsignaturas
            this.dgvAsignaturas.Location = new System.Drawing.Point(20, 90);
            this.dgvAsignaturas.Size = new System.Drawing.Size(540, 240);
            this.dgvAsignaturas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colAsignatura,
                this.colNota
            });
            this.dgvAsignaturas.AllowUserToAddRows = true;
            this.dgvAsignaturas.RowHeadersVisible = false;

            // colAsignatura
            this.colAsignatura.HeaderText = "Asignatura";
            this.colAsignatura.Width = 380;

            // colNota
            this.colNota.HeaderText = "Nota Final";
            this.colNota.Width = 120;

            // btnGuardar
            this.btnGuardar.Text = "Guardar Estudiante";
            this.btnGuardar.Location = new System.Drawing.Point(420, 350);
            this.btnGuardar.Size = new System.Drawing.Size(140, 35);
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            // Form2
            this.ClientSize = new System.Drawing.Size(600, 410);
            this.Controls.Add(this.lblCarnet);
            this.Controls.Add(this.txtCarnet);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.dgvAsignaturas);
            this.Controls.Add(this.btnGuardar);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
        }
        #endregion
    }
}
