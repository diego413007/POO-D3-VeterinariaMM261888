using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Windows.Forms;
using VeterinariaMM261888.Modelo;

namespace VeterinariaMM261888
{
    public partial class frmEspecie : Form
    {
        // Id de la especie seleccionada en la grilla (null = ninguna)
        private int? idSeleccionado = null;

        public frmEspecie()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += frmEspecie_Load;
            dgvEspecies.CellClick += dgvEspecies_CellClick;
            btnLimpiar.Click += btnLimpiar_Click;
            btnNuevo.Click += btnNuevo_Click;
            btnModificar.Click += btnModificar_Click;
            btnEliminar.Click += btnEliminar_Click;
        }

        private void frmEspecie_Load(object sender, EventArgs e)
        {
            Refrescar();
            Limpiar();
        }

        private void Refrescar()
        {
            using (VeterinariaDBEntities db = new VeterinariaDBEntities())
            {
                var lista = from esp in db.Especie
                            orderby esp.nombre_especie
                            select new
                            {
                                Codigo = esp.codigo_especie,
                                Especie = esp.nombre_especie
                            };
                dgvEspecies.DataSource = lista.ToList();
            }
            dgvEspecies.ClearSelection();
        }

        private void Limpiar()
        {
            idSeleccionado = null;
            txtNombre.Clear();
            lblID.Text = "-";
            dgvEspecies.ClearSelection();
            txtNombre.Focus();
        }

        // Al hacer clic en una fila se cargan los datos en el formulario
        private void dgvEspecies_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dgvEspecies.Rows[e.RowIndex];
            idSeleccionado = Convert.ToInt32(fila.Cells[0].Value);
            txtNombre.Text = fila.Cells[1].Value.ToString();
            lblID.Text = idSeleccionado.ToString();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            if (nombre == "")
            {
                MessageBox.Show("Ingrese el nombre de la especie.");
                return;
            }

            using (VeterinariaDBEntities db = new VeterinariaDBEntities())
            {
                if (db.Especie.Any(x => x.nombre_especie == nombre))
                {
                    MessageBox.Show("Ya existe una especie con ese nombre.");
                    return;
                }

                Especie esp = new Especie();
                esp.nombre_especie = nombre;
                db.Especie.Add(esp);
                db.SaveChanges();
            }

            Refrescar();
            Limpiar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == null)
            {
                MessageBox.Show("Seleccione una especie de la tabla.");
                return;
            }

            string nombre = txtNombre.Text.Trim();
            if (nombre == "")
            {
                MessageBox.Show("Ingrese el nombre de la especie.");
                return;
            }

            int id = idSeleccionado.Value;
            using (VeterinariaDBEntities db = new VeterinariaDBEntities())
            {
                if (db.Especie.Any(x => x.nombre_especie == nombre && x.codigo_especie != id))
                {
                    MessageBox.Show("Ya existe otra especie con ese nombre.");
                    return;
                }

                Especie esp = db.Especie.Find(id);
                if (esp != null)
                {
                    esp.nombre_especie = nombre;
                    db.SaveChanges();
                }
            }

            Refrescar();
            Limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == null)
            {
                MessageBox.Show("Seleccione una especie de la tabla.");
                return;
            }

            if (MessageBox.Show("¿Eliminar la especie seleccionada?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                using (VeterinariaDBEntities db = new VeterinariaDBEntities())
                {
                    Especie esp = db.Especie.Find(idSeleccionado.Value);
                    if (esp != null)
                    {
                        db.Especie.Remove(esp);
                        db.SaveChanges();
                    }
                }
            }
            catch (DbUpdateException)
            {
                MessageBox.Show("No se puede eliminar: la especie tiene razas registradas.");
                return;
            }

            Refrescar();
            Limpiar();
        }

        private void frmEspecie_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmMenu frmMenu = new frmMenu();
            frmMenu.Show();
        }

        private void frmEspecie_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.BeginInvoke(new Action(() => this.Close()));
            }
        }
    }
}