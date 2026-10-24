using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Windows.Forms;
using VeterinariaMM261888.Modelo;

namespace VeterinariaMM261888
{
    public partial class frmPropietario : Form
    {
        // DUI del propietario seleccionado en la grilla (null = ninguno)
        private string duiSeleccionado = null;

        public frmPropietario()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            dgvPropietarios.CellClick += dgvPropietarios_CellClick;
            btnLimpiar.Click += btnLimpiar_Click;
            btnNuevo.Click += btnNuevo_Click;
            btnModificar.Click += btnModificar_Click;
            btnEliminar.Click += btnEliminar_Click;
        }

        private void frmPropietario_Load(object sender, EventArgs e)
        {
            Refrescar();
            Limpiar();
        }

        private void Refrescar()
        {
            using (VeterinariaDBEntities db = new VeterinariaDBEntities())
            {
                var lista = from p in db.Propietario
                            orderby p.primer_apellido, p.nombres
                            select new
                            {
                                DUI = p.dui,
                                Nombres = p.nombres,
                                Apellido1 = p.primer_apellido,
                                Apellido2 = p.segundo_apellido,
                                Telefono = p.telefono,
                                Direccion = p.direccion
                            };
                dgvPropietarios.DataSource = lista.ToList();
            }
            dgvPropietarios.ClearSelection();
        }

        private void Limpiar()
        {
            duiSeleccionado = null;
            txtNombres.Clear();
            txtApel1.Clear();
            txtApel2.Clear();
            txtDireccion.Clear();
            mtxtTel.Clear();
            mtxtDui.Clear();
            mtxtDui.Enabled = true;   // el DUI solo se escribe al crear
            lblID.Text = "-";
            dgvPropietarios.ClearSelection();
            txtNombres.Focus();
        }

        // Convierte texto vacío en null (para columnas opcionales)
        private string Nulo(string texto)
        {
            return string.IsNullOrWhiteSpace(texto) ? null : texto.Trim();
        }

        // Teléfono opcional: vacío = null, incompleto = error
        private bool LeerTelefono(out string telefono)
        {
            telefono = null;
            if (mtxtTel.MaskCompleted)
            {
                telefono = mtxtTel.Text;
                return true;
            }
            if (mtxtTel.MaskedTextProvider.AssignedEditPositionCount == 0)
                return true;

            MessageBox.Show("El teléfono está incompleto.");
            return false;
        }

        private bool Validar()
        {
            if (!mtxtDui.MaskCompleted)
            {
                MessageBox.Show("Ingrese el DUI completo (8 dígitos, guion y dígito verificador).");
                return false;
            }
            if (txtNombres.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese los nombres.");
                return false;
            }
            if (txtApel1.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el primer apellido.");
                return false;
            }
            return true;
        }

        private void LlenarDesdeFormulario(Propietario p, string telefono)
        {
            p.nombres = txtNombres.Text.Trim();
            p.primer_apellido = txtApel1.Text.Trim();
            p.segundo_apellido = Nulo(txtApel2.Text);
            p.telefono = telefono;
            p.direccion = Nulo(txtDireccion.Text);
        }

        // Al hacer clic en una fila se cargan los datos en el formulario
        private void dgvPropietarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            duiSeleccionado = dgvPropietarios.Rows[e.RowIndex].Cells[0].Value.ToString();

            using (VeterinariaDBEntities db = new VeterinariaDBEntities())
            {
                Propietario p = db.Propietario.Find(duiSeleccionado);
                if (p == null) return;

                mtxtDui.Text = p.dui;
                txtNombres.Text = p.nombres;
                txtApel1.Text = p.primer_apellido;
                txtApel2.Text = p.segundo_apellido ?? "";
                mtxtTel.Text = p.telefono ?? "";
                txtDireccion.Text = p.direccion ?? "";
            }

            mtxtDui.Enabled = false;
            lblID.Text = duiSeleccionado;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;

            string telefono;
            if (!LeerTelefono(out telefono)) return;

            string dui = mtxtDui.Text;

            using (VeterinariaDBEntities db = new VeterinariaDBEntities())
            {
                if (db.Propietario.Any(x => x.dui == dui))
                {
                    MessageBox.Show("Ya existe un propietario con ese DUI.");
                    return;
                }

                Propietario p = new Propietario();
                p.dui = dui;
                LlenarDesdeFormulario(p, telefono);

                db.Propietario.Add(p);
                db.SaveChanges();
            }

            Refrescar();
            Limpiar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (duiSeleccionado == null)
            {
                MessageBox.Show("Seleccione un propietario de la tabla.");
                return;
            }
            if (!Validar()) return;

            string telefono;
            if (!LeerTelefono(out telefono)) return;

            using (VeterinariaDBEntities db = new VeterinariaDBEntities())
            {
                Propietario p = db.Propietario.Find(duiSeleccionado);
                if (p != null)
                {
                    LlenarDesdeFormulario(p, telefono);
                    db.SaveChanges();
                }
            }

            Refrescar();
            Limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (duiSeleccionado == null)
            {
                MessageBox.Show("Seleccione un propietario de la tabla.");
                return;
            }

            if (MessageBox.Show("¿Eliminar al propietario seleccionado?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                using (VeterinariaDBEntities db = new VeterinariaDBEntities())
                {
                    Propietario p = db.Propietario.Find(duiSeleccionado);
                    if (p != null)
                    {
                        db.Propietario.Remove(p);
                        db.SaveChanges();
                    }
                }
            }
            catch (DbUpdateException)
            {
                MessageBox.Show("No se puede eliminar: el propietario tiene mascotas registradas.");
                return;
            }

            Refrescar();
            Limpiar();
        }

        private void frmPropietario_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmMenu frmMenu = new frmMenu();
            frmMenu.Show();
        }

        private void frmPropietario_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.BeginInvoke(new Action(() => this.Close()));
            }
        }
    }
}