using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace VisorDeImagenes
{
    public partial class Form1 : Form
    {
        string carpeta = @"C:\Users\50585\OneDrive - BicentenariaUNANLeon212Años\PROGRAMACIÓN VISUAL II CORTE\Semana 4\source";
        List<string> listaImagenes = new List<string>();
        int indiceActual = -1;

        private bool modoGris = false;
        private bool sincronizando = false;
        public Form1()
        {
            InitializeComponent();
            CargarImagenes();

            toolStripButton1.CheckOnClick = true; 
            toolStripButton2.CheckOnClick = true;

            girar90ALaDerechaToolStripMenuItem.Click += rotarDerecha_Click;
            girar90ALaIzquierdaToolStripMenuItem1.Click += rotarIzquierda_Click;
            copiarToolStripMenuItem.Click += copiar_Click;

            // ToolStripButtons (normal / grises)
            toolStripButton1.Click += toolStripButton1_Click; // Normal
            toolStripButton2.Click += toolStripButton2_Click; // Grises

            checkBox1.Click += (s, e) => SetMode(false); // Normal
            checkBox2.Click += (s, e) => SetMode(true);  // Escala de grises

            // MenuStrip items (si existen)
            normalToolStripMenuItem.Click += (s, e) => SetMode(false);
            escalaDeGrisesToolStripMenuItem.Click += (s, e) => SetMode(true);
        }

        private void CargarImagenes()
        {
            string[] extensiones = { "*.jpg", "*.png", "*.jpeg", "*.bmp", "*.gif" };

            foreach (var ext in extensiones)
            {
                string[] archivos = Directory.GetFiles(carpeta, ext);
                foreach (var archivo in archivos)
                {
                    listaImagenes.Add(archivo);
                    comboBox1.Items.Add(Path.GetFileName(archivo));
                }
            }

            if (listaImagenes.Count > 0)
            {
                SetMode(false); 
                MostrarImagen(0);
            }
        }

        private void MostrarImagen(int indice)
        {
            if (indice < 0 || indice >= listaImagenes.Count) return;

            indiceActual = indice;
            string archivoSeleccionado = listaImagenes[indice];

            if (pictureBox1.Image != null)
            {
                var prev = pictureBox1.Image;
                pictureBox1.Image = null;
                prev.Dispose();
            }

           
            using (FileStream fs = new FileStream(archivoSeleccionado, FileMode.Open, FileAccess.Read))
            using (var temp = Image.FromStream(fs))
            {
               
                Image original = new Bitmap(temp);

                if (modoGris)
                    pictureBox1.Image = ConvertirAGris(original);
                else
                    pictureBox1.Image = new Bitmap(original);

                original.Dispose();
            } 

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            comboBox1.SelectedIndex = indice;
            toolStripStatusLabel1.Text = archivoSeleccionado;
        }

        private Bitmap ConvertirAGris(Image original)
        {
            
            Bitmap src = new Bitmap(original);

            Rectangle rect = new Rectangle(0, 0, src.Width, src.Height);
            System.Drawing.Imaging.BitmapData bmpData =
                src.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
                src.PixelFormat);

            IntPtr ptr = bmpData.Scan0;

            int bytes = bmpData.Stride * src.Height;
            byte[] rgbValues = new byte[bytes];

            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

           
            int colorDepth = System.Drawing.Image.GetPixelFormatSize(src.PixelFormat) / 8;

            for (int i = 0; i < bytes; i += colorDepth)
            {
               
                byte gray = (byte)((rgbValues[i] + rgbValues[i + 1] + rgbValues[i + 2]) / 3);

                rgbValues[i] = gray;     
                rgbValues[i + 1] = gray; 
                rgbValues[i + 2] = gray;  

               
            }

            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);

            src.UnlockBits(bmpData);

            return src;
        }

        private void SetMode(bool gris)
        {
            if (sincronizando) return;

            sincronizando = true;
            modoGris = gris;

            checkBox2.Checked = gris;   
            checkBox1.Checked = !gris;  

            toolStripButton2.Checked = gris;
            toolStripButton1.Checked = !gris;

            if (this.normalToolStripMenuItem != null)
                normalToolStripMenuItem.Checked = !gris;
            if (this.escalaDeGrisesToolStripMenuItem != null)
                escalaDeGrisesToolStripMenuItem.Checked = gris;

            if (indiceActual >= 0)
                MostrarImagen(indiceActual);

            sincronizando = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarImagen(comboBox1.SelectedIndex);
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (indiceActual > 0) MostrarImagen(indiceActual - 1);
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (indiceActual < listaImagenes.Count - 1) MostrarImagen(indiceActual + 1);
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            MostrarImagen(0);
        }

        private void btnFinal_Click(object sender, EventArgs e)
        {
            MostrarImagen(listaImagenes.Count - 1);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SetMode(false);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            SetMode(toolStripButton2.Checked);
        }

        private void rotarIzquierda_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null) return;
            pictureBox1.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            pictureBox1.Refresh();
        }

        private void rotarDerecha_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null) return;
            pictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox1.Refresh();
        }

        private void copiar_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Clipboard.SetImage(pictureBox1.Image);
                MessageBox.Show("Imagen copiada en el portapapeles.");
            }
        }

        private void checkBox3_Click(object sender, EventArgs e)
        {
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
            pictureBox1.Refresh();
        }

        private void checkBox4_Click(object sender, EventArgs e)
        {
            checkBox3.Checked = false;
            checkBox5.Checked = false;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Refresh();
        }

        private void checkBox5_Click(object sender, EventArgs e)
        {
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Refresh();
        }

        private void toolStripButtonGuardar_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("No hay ninguna imagen para guardar.");
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Guardar imagen";
                saveFileDialog.Filter = "Imagen JPG|*.jpg|Imagen PNG|*.png|Bitmap|*.bmp";
                saveFileDialog.FileName = "miImagen";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var formato = System.Drawing.Imaging.ImageFormat.Png;

                    switch (saveFileDialog.FilterIndex)
                    {
                        case 1: formato = System.Drawing.Imaging.ImageFormat.Jpeg; break;
                        case 2: formato = System.Drawing.Imaging.ImageFormat.Png; break;
                        case 3: formato = System.Drawing.Imaging.ImageFormat.Bmp; break;
                    }

                    pictureBox1.Image.Save(saveFileDialog.FileName, formato);
                    MessageBox.Show("Imagen guardada en:\n" + saveFileDialog.FileName);
                }
            }
        }

        private void toolStripButtonSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
