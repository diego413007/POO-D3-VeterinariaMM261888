using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VeterinariaMM261888
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void btnVerMascotas_Click(object sender, EventArgs e)
        {
            frmVerMascotas frmVerMascotas = new frmVerMascotas();
            frmVerMascotas.Show();
            this.Hide();
        }

        private void btnMascotas_Click(object sender, EventArgs e)
        {
            frmMascota frmMascota = new frmMascota();
            frmMascota.Show();
            this.Hide();
        }

        private void btnPropietarios_Click(object sender, EventArgs e)
        {
            frmPropietario frmPropietario = new frmPropietario();
            frmPropietario.Show();
            this.Hide();
        }

        private void btnEspecies_Click(object sender, EventArgs e)
        {
            frmEspecie frmEspecie = new frmEspecie();
            frmEspecie.Show();
            this.Hide();
        }

        private void btnRazas_Click(object sender, EventArgs e)
        {
            frmRaza frmRaza = new frmRaza();
            frmRaza.Show();
            this.Hide();
        }

        private void frmMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
