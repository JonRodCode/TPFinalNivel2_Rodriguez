namespace ventanas
{
    partial class OpcionesAvanzadas
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
            this.btnVerEliminados = new System.Windows.Forms.Button();
            this.dgvArticulosEliminados = new System.Windows.Forms.DataGridView();
            this.lblArticulosEliminados = new System.Windows.Forms.Label();
            this.btnRestaurar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnVolverAlMenu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulosEliminados)).BeginInit();
            this.SuspendLayout();
            // 
            // btnVerEliminados
            // 
            this.btnVerEliminados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerEliminados.Location = new System.Drawing.Point(17, 98);
            this.btnVerEliminados.Name = "btnVerEliminados";
            this.btnVerEliminados.Size = new System.Drawing.Size(140, 40);
            this.btnVerEliminados.TabIndex = 0;
            this.btnVerEliminados.Text = "Ver";
            this.btnVerEliminados.UseVisualStyleBackColor = true;
            this.btnVerEliminados.Click += new System.EventHandler(this.btnVerEliminados_Click);
            // 
            // dgvArticulosEliminados
            // 
            this.dgvArticulosEliminados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvArticulosEliminados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticulosEliminados.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvArticulosEliminados.Location = new System.Drawing.Point(196, 29);
            this.dgvArticulosEliminados.Name = "dgvArticulosEliminados";
            this.dgvArticulosEliminados.RowHeadersWidth = 51;
            this.dgvArticulosEliminados.RowTemplate.Height = 24;
            this.dgvArticulosEliminados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvArticulosEliminados.Size = new System.Drawing.Size(565, 333);
            this.dgvArticulosEliminados.TabIndex = 1;
            // 
            // lblArticulosEliminados
            // 
            this.lblArticulosEliminados.AutoSize = true;
            this.lblArticulosEliminados.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArticulosEliminados.Location = new System.Drawing.Point(34, 27);
            this.lblArticulosEliminados.Name = "lblArticulosEliminados";
            this.lblArticulosEliminados.Size = new System.Drawing.Size(107, 50);
            this.lblArticulosEliminados.TabIndex = 2;
            this.lblArticulosEliminados.Text = "Articulos\r\nEliminados";
            this.lblArticulosEliminados.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnRestaurar
            // 
            this.btnRestaurar.Enabled = false;
            this.btnRestaurar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestaurar.Location = new System.Drawing.Point(17, 151);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(140, 40);
            this.btnRestaurar.TabIndex = 0;
            this.btnRestaurar.Text = "Restaurar";
            this.btnRestaurar.UseVisualStyleBackColor = true;
            this.btnRestaurar.Click += new System.EventHandler(this.btnRestaurar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Enabled = false;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(17, 204);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(140, 40);
            this.btnEliminar.TabIndex = 0;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnVolverAlMenu
            // 
            this.btnVolverAlMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnVolverAlMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolverAlMenu.Location = new System.Drawing.Point(17, 346);
            this.btnVolverAlMenu.Name = "btnVolverAlMenu";
            this.btnVolverAlMenu.Size = new System.Drawing.Size(140, 40);
            this.btnVolverAlMenu.TabIndex = 0;
            this.btnVolverAlMenu.Text = "Volver al Menú";
            this.btnVolverAlMenu.UseVisualStyleBackColor = true;
            this.btnVolverAlMenu.Click += new System.EventHandler(this.btnVolverAlMenu_Click);
            // 
            // OpcionesAvanzadas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(796, 401);
            this.Controls.Add(this.lblArticulosEliminados);
            this.Controls.Add(this.dgvArticulosEliminados);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnRestaurar);
            this.Controls.Add(this.btnVolverAlMenu);
            this.Controls.Add(this.btnVerEliminados);
            this.MinimumSize = new System.Drawing.Size(814, 448);
            this.Name = "OpcionesAvanzadas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OpcionesAvanzadas";
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulosEliminados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVerEliminados;
        private System.Windows.Forms.DataGridView dgvArticulosEliminados;
        private System.Windows.Forms.Label lblArticulosEliminados;
        private System.Windows.Forms.Button btnRestaurar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnVolverAlMenu;
    }
}