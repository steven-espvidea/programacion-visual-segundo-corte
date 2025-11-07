using System;
using System.Linq;
using System.Windows.Forms;

namespace MDIEstudiantes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            IsMdiContainer = true;
           
            this.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.Text = "MDI Estudiantes - Dashboard";
        }

        private void btnForm2_Click(object sender, EventArgs e)
        {
          
            var open = this.MdiChildren.FirstOrDefault(f => f is Form2);
            if (open != null)
            {
                open.BringToFront();
                return;
            }

            Form2 f2 = new Form2();
            f2.MdiParent = this;
            f2.Show();
        }

        private void btnForm3_Click(object sender, EventArgs e)
        {
            var open = this.MdiChildren.FirstOrDefault(f => f is Form3);
            if (open != null)
            {
                open.BringToFront();
                return;
            }

            Form3 f3 = new Form3();
            f3.MdiParent = this;
            f3.Show();
        }

        private void btnForm4_Click(object sender, EventArgs e)
        {
            var open = this.MdiChildren.FirstOrDefault(f => f is Form4);
            if (open != null)
            {
                open.BringToFront();
                return;
            }

            Form4 f4 = new Form4();
            f4.MdiParent = this;
            f4.Show();
        }
    }
}
