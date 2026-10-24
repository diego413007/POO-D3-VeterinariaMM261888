using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Windows.Forms;
using VeterinariaMM261888.Modelo;

namespace VeterinariaMM261888
{
    public partial class frmMascota : Form
    {
        // Valores que se guardan en la columna sexo (según el CHECK de la tabla Mascota).
        private const string SEXO_MASCULINO = "M";
        private const string SEXO_FEMENINO = "H";

        // Id de la mascota seleccionada en la grilla (null = ninguna)
        private int? idSeleccionado = null;

        public frmMascota()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            // Configuración de controles
            cmbRaza.DropDownStyle = ComboBoxStyle.DropDownList;
            numPeso.DecimalPlaces = 2;
            numPeso.Increment = 0.5M;
            numPeso.Minimum = 0;
            numPeso.Maximum = 200;
            dtpIngreso.Format = DateTimePickerFormat.Short;

            this.Load += frmMascota_Load;
            dgvMascotas.CellClick += dgvMascotas_CellClick;
            btnLimpiar.Click += btnLimpiar_Click;
            btnNuevo.Click += btnNuevo_Click;
            btnModificar.Click += btnModificar_Click;
            btnEliminar.Click += btnEliminar_Click;
        }

        private void frmMascota_Load(object sender, EventArgs e)
        {
            CargarRazas();
            Refrescar();
            Limpiar();
        }

        private void CargarRazas()
        {
            using (VeterinariaDBEntities db = new VeterinariaDBEntities())
            {
                var razas = (from r in db.Raza
                             orderby r.nombre_raza
                             select new
                             {
                                 r.codigo_raza,
                                 Nombre = r.nombre_raza + " (" + r.Especie.nombre_especie + ")"
                             }).ToList();

                cmbRaza.DisplayMember = "Nombre";
                cmbRaza.ValueMember = "codigo_raza";
                cmbRaza.DataSource = razas;
            }
        }

        private void Refrescar()
        {
            using (VeterinariaDBEntities db = new VeterinariaDBEntities())
            {
                var lista = from m in db.Mascota
                            orderby m.nombre
                            select new
                            {
                                Codigo = m.codigo_mascota,
                                Nombre = m.nombre,
                                Sexo = m.sexo,
                                Peso_kg = m.peso_kg,
                                Ingreso = m.fecha_ingreso,
                                Raza = m.Raza.nombre_raza,
                                DUI = m.dui_propietario
                            };
                dgvMascotas.DataSource = lista.ToList();
            }
            dgvMascotas.Columns["Ingreso"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvMascotas.ClearSelection();
        }

        private void Limpiar()
        {
            idSeleccionado = null;
            txtNombre.Clear();
            rbMas.Checked = false;
            rbFem.Checked = false;
            numPeso.Value = 0;
            dtpIngreso.Value = DateTime.Today;
            cmbRaza.SelectedIndex = -1;
            mtxtDui.Clear();
            lblID.Text = "-";
            dgvMascotas.ClearSelection();
            txtNombre.Focus();
        }

        private bool Validar(VeterinariaDBEntities db)
        {
            if (txtNombre.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el nombre de la mascota.");
                return false;
            }
            if (!rbMas.Checked && !rbFem.Checked)
            {
                MessageBox.Show("Seleccione el sexo.");
                return false;
            }
            if (numPeso.Value <= 0)
            {
                MessageBox.Show("Ingrese un peso mayor que cero.");
                return false;
            }
            if (dtpIngreso.Value.Date > DateTime.Today)
            {
                MessageBox.Show("La fecha de ingreso no puede ser futura.");
                return false;
            }
            if (cmbRaza.SelectedValue == null)
            {
                MessageBox.Show("Seleccione la raza.");
                return false;
            }
            if (!mtxtDui.MaskCompleted)
            {
                MessageBox.Show("Ingrese el DUI completo del propietario.");
                return false;
            }

            string dui = mtxtDui.Text;
            if (!db.Propietario.Any(p => p.dui == dui))
            {
                MessageBox.Show("No existe un propietario con ese DUI. Regístrelo primero en Propietarios.");
                return false;
            }
            return true;
        }

        private void LlenarDesdeFormulario(Mascota m)
        {
            m.nombre = txtNombre.Text.Trim();
            m.sexo = rbMas.Checked ? SEXO_MASCULINO : SEXO_FEMENINO;
            m.peso_kg = numPeso.Value;
            m.fecha_ingreso = dtpIngreso.Value.Date;
            m.codigo_raza = (int)cmbRaza.SelectedValue;
            m.dui_propietario = mtxtDui.Text;
        }

        // Al hacer clic en una fila se cargan los datos en el formulario
        private void dgvMascotas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            idSeleccionado = Convert.ToInt32(dgvMascotas.Rows[e.RowIndex].Cells[0].Value);

            using (VeterinariaDBEntities db = new VeterinariaDBEntities())
            {
                Mascota m = db.Mascota.Find(idSeleccionado.Value);
                if (m == null) return;

                txtNombre.Text = m.nombre;
                rbMas.Checked = (m.sexo == SEXO_MASCULINO);
                rbFem.Checked = (m.sexo == SEXO_FEMENINO);
                numPeso.Value = Convert.ToDecimal(m.peso_kg);
                dtpIngreso.Value = (DateTime)m.fecha_ingreso;
                cmbRaza.SelectedValue = m.codigo_raza;
                mtxtDui.Text = m.dui_propietario;
            }

            lblID.Text = idSeleccionado.ToString();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using (VeterinariaDBEntities db = new VeterinariaDBEntities())
            {
                if (!Validar(db)) return;

                Mascota m = new Mascota();
                LlenarDesdeFormulario(m);

                db.Mascota.Add(m);
                db.SaveChanges();
            }

            Refrescar();
            Limpiar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == null)
            {
                MessageBox.Show("Seleccione una mascota de la tabla.");
                return;
            }

            using (VeterinariaDBEntities db = new VeterinariaDBEntities())
            {
                if (!Validar(db)) return;

                Mascota m = db.Mascota.Find(idSeleccionado.Value);
                if (m != null)
                {
                    LlenarDesdeFormulario(m);
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
                MessageBox.Show("Seleccione una mascota de la tabla.");
                return;
            }

            if (MessageBox.Show("¿Eliminar la mascota seleccionada?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                using (VeterinariaDBEntities db = new VeterinariaDBEntities())
                {
                    Mascota m = db.Mascota.Find(idSeleccionado.Value);
                    if (m != null)
                    {
                        db.Mascota.Remove(m);
                        db.SaveChanges();
                    }
                }
            }
            catch (DbUpdateException)
            {
                MessageBox.Show("No se puede eliminar: la mascota tiene registros relacionados.");
                return;
            }

            Refrescar();
            Limpiar();
        }

        private void frmMascota_FormClosed(object sender, FormClosedEventArgs e)
        {
             frmMenu frmMenu = new frmMenu();
             frmMenu.Show();
        }

        private void frmMascota_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.BeginInvoke(new Action(() => this.Close()));
            }
        }
    }
}