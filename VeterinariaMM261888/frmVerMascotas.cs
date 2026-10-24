using System;
using System.Linq;
using System.Windows.Forms;
using VeterinariaMM261888.Modelo;

namespace VeterinariaMM261888
{
    public partial class frmVerMascotas : Form
    {
        public frmVerMascotas()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        // Consulta general: mascota + raza + especie + propietario en una sola grilla
        private void frmVerMascotas_Load(object sender, EventArgs e)
        {
            using (VeterinariaDBEntities db = new VeterinariaDBEntities())
            {
                var lista = from m in db.Mascota
                            join r in db.Raza on m.codigo_raza equals r.codigo_raza
                            join es in db.Especie on r.codigo_especie equals es.codigo_especie
                            join p in db.Propietario on m.dui_propietario equals p.dui
                            orderby m.nombre
                            select new
                            {
                                Codigo = m.codigo_mascota,
                                Mascota = m.nombre,
                                Sexo = m.sexo,
                                Peso_kg = m.peso_kg,
                                Ingreso = m.fecha_ingreso,
                                Raza = r.nombre_raza,
                                Especie = es.nombre_especie,
                                Propietario = p.nombres + " " + p.primer_apellido,
                                DUI = p.dui,
                                Telefono = p.telefono
                            };

                dgvVerMascotas.DataSource = lista.ToList();
            }

            dgvVerMascotas.Columns["Ingreso"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvVerMascotas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVerMascotas.ClearSelection();
        }

        private void frmVerMascotas_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmMenu frmMenu = new frmMenu();
            frmMenu.Show();
        }

        private void frmVerMascotas_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.BeginInvoke(new Action(() => this.Close()));
            }
        }
    }
}