namespace VeterinariaMM261888
{
    partial class frmRaza
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblID = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRaza = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbEspecie = new System.Windows.Forms.ComboBox();
            this.gbTamano = new System.Windows.Forms.GroupBox();
            this.rbGran = new System.Windows.Forms.RadioButton();
            this.rbMed = new System.Windows.Forms.RadioButton();
            this.rbPeque = new System.Windows.Forms.RadioButton();
            this.dgvRazas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.gbTamano.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRazas)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblID);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanel2);
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvRazas);
            this.splitContainer1.Size = new System.Drawing.Size(800, 481);
            this.splitContainer1.SplitterDistance = 266;
            this.splitContainer1.TabIndex = 0;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(111, 380);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(10, 13);
            this.lblID.TabIndex = 7;
            this.lblID.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 380);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Id seleccionado:";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnLimpiar);
            this.flowLayoutPanel2.Controls.Add(this.btnNuevo);
            this.flowLayoutPanel2.Controls.Add(this.btnModificar);
            this.flowLayoutPanel2.Controls.Add(this.btnEliminar);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 401);
            this.flowLayoutPanel2.MinimumSize = new System.Drawing.Size(266, 80);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.flowLayoutPanel2.Size = new System.Drawing.Size(266, 80);
            this.flowLayoutPanel2.TabIndex = 3;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(3, 3);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(263, 31);
            this.btnLimpiar.TabIndex = 3;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(3, 40);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(83, 37);
            this.btnNuevo.TabIndex = 0;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(92, 40);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(83, 37);
            this.btnModificar.TabIndex = 4;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(181, 40);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(82, 37);
            this.btnEliminar.TabIndex = 5;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lblTitulo);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.txtRaza);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.cmbEspecie);
            this.flowLayoutPanel1.Controls.Add(this.gbTamano);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(20);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(266, 370);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(20, 27);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(0, 7, 7, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(199, 20);
            this.lblTitulo.TabIndex = 14;
            this.lblTitulo.Text = "Gestión de Razas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Nombre de Raza";
            // 
            // txtRaza
            // 
            this.txtRaza.Location = new System.Drawing.Point(23, 73);
            this.txtRaza.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.txtRaza.Name = "txtRaza";
            this.txtRaza.Size = new System.Drawing.Size(200, 20);
            this.txtRaza.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Especie";
            // 
            // cmbEspecie
            // 
            this.cmbEspecie.FormattingEnabled = true;
            this.cmbEspecie.Location = new System.Drawing.Point(23, 119);
            this.cmbEspecie.Name = "cmbEspecie";
            this.cmbEspecie.Size = new System.Drawing.Size(121, 21);
            this.cmbEspecie.TabIndex = 29;
            // 
            // gbTamano
            // 
            this.gbTamano.Controls.Add(this.rbGran);
            this.gbTamano.Controls.Add(this.rbMed);
            this.gbTamano.Controls.Add(this.rbPeque);
            this.gbTamano.Location = new System.Drawing.Point(23, 146);
            this.gbTamano.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.gbTamano.Name = "gbTamano";
            this.gbTamano.Size = new System.Drawing.Size(200, 96);
            this.gbTamano.TabIndex = 30;
            this.gbTamano.TabStop = false;
            this.gbTamano.Text = "Tamaño";
            // 
            // rbGran
            // 
            this.rbGran.AutoSize = true;
            this.rbGran.Location = new System.Drawing.Point(6, 65);
            this.rbGran.Name = "rbGran";
            this.rbGran.Size = new System.Drawing.Size(60, 17);
            this.rbGran.TabIndex = 2;
            this.rbGran.TabStop = true;
            this.rbGran.Text = "Grande";
            this.rbGran.UseVisualStyleBackColor = true;
            // 
            // rbMed
            // 
            this.rbMed.AutoSize = true;
            this.rbMed.Location = new System.Drawing.Point(6, 42);
            this.rbMed.Name = "rbMed";
            this.rbMed.Size = new System.Drawing.Size(66, 17);
            this.rbMed.TabIndex = 1;
            this.rbMed.TabStop = true;
            this.rbMed.Text = "Mediano";
            this.rbMed.UseVisualStyleBackColor = true;
            // 
            // rbPeque
            // 
            this.rbPeque.AutoSize = true;
            this.rbPeque.Location = new System.Drawing.Point(6, 19);
            this.rbPeque.Name = "rbPeque";
            this.rbPeque.Size = new System.Drawing.Size(68, 17);
            this.rbPeque.TabIndex = 0;
            this.rbPeque.TabStop = true;
            this.rbPeque.Text = "Pequeño";
            this.rbPeque.UseVisualStyleBackColor = true;
            // 
            // dgvRazas
            // 
            this.dgvRazas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRazas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRazas.Location = new System.Drawing.Point(0, 0);
            this.dgvRazas.MultiSelect = false;
            this.dgvRazas.Name = "dgvRazas";
            this.dgvRazas.ReadOnly = true;
            this.dgvRazas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRazas.Size = new System.Drawing.Size(530, 481);
            this.dgvRazas.TabIndex = 3;
            // 
            // frmRaza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 481);
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
            this.Name = "frmRaza";
            this.Text = "frmRaza";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmRaza_FormClosed);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmRaza_KeyUp);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.gbTamano.ResumeLayout(false);
            this.gbTamano.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRazas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRaza;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbEspecie;
        private System.Windows.Forms.GroupBox gbTamano;
        private System.Windows.Forms.RadioButton rbGran;
        private System.Windows.Forms.RadioButton rbMed;
        private System.Windows.Forms.RadioButton rbPeque;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvRazas;
    }
}