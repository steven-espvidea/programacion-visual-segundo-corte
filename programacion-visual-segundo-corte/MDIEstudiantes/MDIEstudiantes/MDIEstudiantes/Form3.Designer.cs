namespace MDIEstudiantes
{
    partial class Form3
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvEstudiantes;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCarnet;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPromedio;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgvEstudiantes = new System.Windows.Forms.DataGridView();
            this.colCarnet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPromedio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRefrescar = new System.Windows.Forms.Button();

            // dgvEstudiantes
            this.dgvEstudiantes.Location = new System.Drawing.Point(15, 15);
            this.dgvEstudiantes.Size = new System.Drawing.Size(600, 320);
            this.dgvEstudiantes.AllowUserToAddRows = false;
            this.dgvEstudiantes.RowHeadersVisible = false;
            this.dgvEstudiantes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEstudiantes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colCarnet, this.colNombre, this.colPromedio
            });
            this.dgvEstudiantes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEstudiantes_CellDoubleClick);

            // columns
            this.colCarnet.HeaderText = "Carnet";
            this.colCarnet.Width = 120;
            this.colNombre.HeaderText = "Nombre";
            this.colNombre.Width = 320;
            this.colPromedio.HeaderText = "Promedio";
            this.colPromedio.Width = 120;

            // btnRefrescar
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.Location = new System.Drawing.Point(520, 345);
            this.btnRefrescar.Size = new System.Drawing.Size(95, 30);
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);

            // Form3
            this.ClientSize = new System.Drawing.Size(640, 390);
            this.Controls.Add(this.dgvEstudiantes);
            this.Controls.Add(this.btnRefrescar);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.Form3_Load);
        }
    }
}
