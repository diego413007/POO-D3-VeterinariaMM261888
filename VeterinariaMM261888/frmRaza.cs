using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Windows.Forms;
using VeterinariaMM261888.Modelo;

namespace VeterinariaMM261888
{
    public partial class frmRaza : Form
    {
        // Id de la raza seleccionada en la grilla (null = ninguna)
        private int? idSeleccionado = null;

        public frmRaza()
        {
            InitializeComponent();

            cmbEspecie.DropDownStyle = ComboBoxStyle.DropDownList;
           this.Load += frmRaza_Load;
            dgvRazas.CellClick += dgvRazas_CellClick;
            btnLimpiar.Click += btnLimpiar_Click;
            btnNuevo.Click += btnNuevo_Click;
            btnModificar.Click += btnModificar_Click;
            btnEliminar.Click += btnEliminar_Click;
            
        }

        private void frmRaza_Load(object sender, EventArgs e)
        {
            CargarEspecies();
            Refrescar();
            Limpiar();
        }

        private void CargarEspecies()
        {
            using (VeterinariaDBEntities db = new VeterinariaDBEntities())
            {
                var especies = (from esp in db.Especie
                                orderby esp.nombre_especie
                                select new { esp.codigo_especie, esp.nombre_especie }).ToList();

                cmbEspecie.DisplayMember = "nombre_especie";
                cmbEspecie.ValueMember = "codigo_especie";
                cmbEspecie.DataSource = especies;
            }
        }

        private void Refrescar()
        {
            using (VeterinariaDBEntities db = new VeterinariaDBEntities())
            {
                var lista = from r in db.Raza
                            orderby r.nombre_raza
                            select new
                            {
                                Codigo = r.codigo_raza,
                                Raza = r.nombre_raza,
                                Especie = r.Especie.nombre_especie,
                                Tamano = r.tamano
                            };
                dgvRazas.DataSource = lista.ToList();
            }
            dgvRazas.ClearSelection();
        }

        private void Limpiar()
        {
            idSeleccionado = null;
            txtRaza.Clear();
            cmbEspecie.SelectedIndex = -1;
            PonerTamano(null);
            lblID.Text = "-";
            dgvRazas.ClearSelection();
            txtRaza.Focus();
        }

        // Tamaño: lee el RadioButton marcado (null si no hay ninguno)
        private string LeerTamano()
        {
            if (rbPeque.Checked) return "Pequeño";
            if (rbMed.Checked) return "Mediano";
            if (rbGran.Checked) return "Grande";
            return null;
        }

        private void PonerTamano(string tamano)
        {
            rbPeque.Checked = (tamano == "Pequeño");
            rbMed.Checked = (tamano == "Mediano");
            rbGran.Checked = (tamano == "Grande");
        }

        private bool Validar()
        {
            if (txtRaza.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el nombre de la raza.");
                return false;
            }
            if (cmbEspecie.SelectedValue == null)
            {
                MessageBox.Show("Seleccione la especie.");
                return false;
            }
            return true;
        }

        // Al hacer clic en una fila se cargan los datos en el formulario
        private void dgvRazas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            idSeleccionado = Convert.ToInt32(dgvRazas.Rows[e.RowIndex].Cells[0].Value);

            using (VeterinariaDBEntities db = new VeterinariaDBEntities())
            {
                Raza raza = db.Raza.Find(idSeleccionado.Value);
                if (raza == null) return;

                txtRaza.Text = raza.nombre_raza;
                cmbEspecie.SelectedValue = raza.codigo_especie;
                PonerTamano(raza.tamano);
            }

            lblID.Text = idSeleccionado.ToString();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;

            string nombre = txtRaza.Text.Trim();
            int codEspecie = (int)cmbEspecie.SelectedValue;

            using (VeterinariaDBEntities db = new VeterinariaDBEntities())
            {
                if (db.Raza.Any(x => x.nombre_raza == nombre && x.codigo_especie == codEspecie))
                {
                    MessageBox.Show("Esa raza ya existe para la especie seleccionada.");
                    return;
                }

                Raza raza = new Raza();
                raza.nombre_raza = nombre;
                raza.codigo_especie = codEspecie;
                raza.tamano = LeerTamano();

                db.Raza.Add(raza);
                db.SaveChanges();
            }

            Refrescar();
            Limpiar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == null)
            {
                MessageBox.Show("Seleccione una raza de la tabla.");
                return;
            }
            if (!Validar()) return;

            int id = idSeleccionado.Value;
            string nombre = txtRaza.Text.Trim();
            int codEspecie = (int)cmbEspecie.SelectedValue;

            using (VeterinariaDBEntities db = new VeterinariaDBEntities())
            {
                if (db.Raza.Any(x => x.nombre_raza == nombre &&
                                     x.codigo_especie == codEspecie &&
                                     x.codigo_raza != id))
                {
                    MessageBox.Show("Esa raza ya existe para la especie seleccionada.");
                    return;
                }

                Raza raza = db.Raza.Find(id);
                if (raza != null)
                {
                    raza.nombre_raza = nombre;
                    raza.codigo_especie = codEspecie;
                    raza.tamano = LeerTamano();
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
                MessageBox.Show("Seleccione una raza de la tabla.");
                return;
            }

            if (MessageBox.Show("¿Eliminar la raza seleccionada?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                using (VeterinariaDBEntities db = new VeterinariaDBEntities())
                {
                    Raza raza = db.Raza.Find(idSeleccionado.Value);
                    if (raza != null)
                    {
                        db.Raza.Remove(raza);
                        db.SaveChanges();
                    }
                }
            }
            catch (DbUpdateException)
            {
                MessageBox.Show("No se puede eliminar: la raza tiene mascotas registradas.");
                return;
            }

            Refrescar();
            Limpiar();
        }

        private void frmRaza_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmMenu frmMenu = new frmMenu();
            frmMenu.Show();
        }

        private void frmRaza_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}