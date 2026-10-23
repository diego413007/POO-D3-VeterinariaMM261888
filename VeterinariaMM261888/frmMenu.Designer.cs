namespace VeterinariaMM261888
{
    partial class frmMenu
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnRazas = new System.Windows.Forms.Button();
            this.btnEspecies = new System.Windows.Forms.Button();
            this.btnPropietarios = new System.Windows.Forms.Button();
            this.btnMascotas = new System.Windows.Forms.Button();
            this.btnVerMascotas = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnRazas, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnEspecies, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnPropietarios, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnMascotas, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(54, 220);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(686, 174);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnRazas
            // 
            this.btnRazas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRazas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRazas.Location = new System.Drawing.Point(346, 90);
            this.btnRazas.Name = "btnRazas";
            this.btnRazas.Size = new System.Drawing.Size(337, 81);
            this.btnRazas.TabIndex = 5;
            this.btnRazas.Text = "Gestionar Razas";
            this.btnRazas.UseVisualStyleBackColor = true;
            this.btnRazas.Click += new System.EventHandler(this.btnRazas_Click);
            // 
            // btnEspecies
            // 
            this.btnEspecies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEspecies.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEspecies.Location = new System.Drawing.Point(3, 90);
            this.btnEspecies.Name = "btnEspecies";
            this.btnEspecies.Size = new System.Drawing.Size(337, 81);
            this.btnEspecies.TabIndex = 4;
            this.btnEspecies.Text = "Gestionar Especies";
            this.btnEspecies.UseVisualStyleBackColor = true;
            this.btnEspecies.Click += new System.EventHandler(this.btnEspecies_Click);
            // 
            // btnPropietarios
            // 
            this.btnPropietarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPropietarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPropietarios.Location = new System.Drawing.Point(346, 3);
            this.btnPropietarios.Name = "btnPropietarios";
            this.btnPropietarios.Size = new System.Drawing.Size(337, 81);
            this.btnPropietarios.TabIndex = 3;
            this.btnPropietarios.Text = "Gestionar Propietarios";
            this.btnPropietarios.UseVisualStyleBackColor = true;
            this.btnPropietarios.Click += new System.EventHandler(this.btnPropietarios_Click);
            // 
            // btnMascotas
            // 
            this.btnMascotas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMascotas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMascotas.Location = new System.Drawing.Point(3, 3);
            this.btnMascotas.Name = "btnMascotas";
            this.btnMascotas.Size = new System.Drawing.Size(337, 81);
            this.btnMascotas.TabIndex = 2;
            this.btnMascotas.Text = "Gestionar Mascotas";
            this.btnMascotas.UseVisualStyleBackColor = true;
            this.btnMascotas.Click += new System.EventHandler(this.btnMascotas_Click);
            // 
            // btnVerMascotas
            // 
            this.btnVerMascotas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerMascotas.Location = new System.Drawing.Point(54, 168);
            this.btnVerMascotas.Name = "btnVerMascotas";
            this.btnVerMascotas.Size = new System.Drawing.Size(686, 46);
            this.btnVerMascotas.TabIndex = 1;
            this.btnVerMascotas.Text = "Ver Mascotas Registradas";
            this.btnVerMascotas.UseVisualStyleBackColor = true;
            this.btnVerMascotas.Click += new System.EventHandler(this.btnVerMascotas_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(53, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(687, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gestión de Clínica Veterinaria";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnVerMascotas);
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMenu_FormClosed);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnVerMascotas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEspecies;
        private System.Windows.Forms.Button btnPropietarios;
        private System.Windows.Forms.Button btnMascotas;
        private System.Windows.Forms.Button btnRazas;
    }
}

