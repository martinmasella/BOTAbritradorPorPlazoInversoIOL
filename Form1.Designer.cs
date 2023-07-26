namespace BOTAbritradorPorPlazoIOL
{
    partial class frmBOT
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbxLogin = new System.Windows.Forms.GroupBox();
            this.txtBearer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.lblContraseña = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.grdPanel = new System.Windows.Forms.DataGridView();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.lbLog = new System.Windows.Forms.ListBox();
            this.btnWS = new System.Windows.Forms.Button();
            this.chkBeep = new System.Windows.Forms.CheckBox();
            this.tmr = new System.Windows.Forms.Timer(this.components);
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.cboUmbral = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkFollow = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gbxLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxLogin
            // 
            this.gbxLogin.Controls.Add(this.txtBearer);
            this.gbxLogin.Controls.Add(this.label1);
            this.gbxLogin.Controls.Add(this.btnIngresar);
            this.gbxLogin.Controls.Add(this.txtContraseña);
            this.gbxLogin.Controls.Add(this.lblContraseña);
            this.gbxLogin.Controls.Add(this.txtUsuario);
            this.gbxLogin.Controls.Add(this.lblUsuario);
            this.gbxLogin.Controls.Add(this.btnCerrar);
            this.gbxLogin.Location = new System.Drawing.Point(12, 12);
            this.gbxLogin.Name = "gbxLogin";
            this.gbxLogin.Size = new System.Drawing.Size(541, 47);
            this.gbxLogin.TabIndex = 1;
            this.gbxLogin.TabStop = false;
            this.gbxLogin.Text = "Login";
            // 
            // txtBearer
            // 
            this.txtBearer.Location = new System.Drawing.Point(427, 16);
            this.txtBearer.Name = "txtBearer";
            this.txtBearer.ReadOnly = true;
            this.txtBearer.Size = new System.Drawing.Size(38, 20);
            this.txtBearer.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(383, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Bearer:";
            // 
            // btnIngresar
            // 
            this.btnIngresar.Location = new System.Drawing.Point(302, 16);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(72, 21);
            this.btnIngresar.TabIndex = 4;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = true;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // txtContraseña
            // 
            this.txtContraseña.Location = new System.Drawing.Point(209, 16);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.PasswordChar = '*';
            this.txtContraseña.Size = new System.Drawing.Size(86, 20);
            this.txtContraseña.TabIndex = 3;
            this.txtContraseña.UseSystemPasswordChar = true;
            // 
            // lblContraseña
            // 
            this.lblContraseña.AutoSize = true;
            this.lblContraseña.Location = new System.Drawing.Point(142, 20);
            this.lblContraseña.Name = "lblContraseña";
            this.lblContraseña.Size = new System.Drawing.Size(64, 13);
            this.lblContraseña.TabIndex = 2;
            this.lblContraseña.Text = "Contraseña:";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(55, 16);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtUsuario.Size = new System.Drawing.Size(76, 20);
            this.txtUsuario.TabIndex = 1;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(6, 21);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(46, 13);
            this.lblUsuario.TabIndex = 0;
            this.lblUsuario.Text = "Usuario:";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(473, 16);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(60, 22);
            this.btnCerrar.TabIndex = 7;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // grdPanel
            // 
            this.grdPanel.AllowUserToAddRows = false;
            this.grdPanel.AllowUserToDeleteRows = false;
            this.grdPanel.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grdPanel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdPanel.DefaultCellStyle = dataGridViewCellStyle3;
            this.grdPanel.Location = new System.Drawing.Point(12, 98);
            this.grdPanel.Name = "grdPanel";
            this.grdPanel.ReadOnly = true;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdPanel.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.grdPanel.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Courier New", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdPanel.RowTemplate.Height = 15;
            this.grdPanel.RowTemplate.ReadOnly = true;
            this.grdPanel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPanel.Size = new System.Drawing.Size(541, 118);
            this.grdPanel.TabIndex = 3;
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Location = new System.Drawing.Point(99, 65);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(44, 27);
            this.btnRefrescar.TabIndex = 4;
            this.btnRefrescar.Text = "API";
            this.btnRefrescar.UseVisualStyleBackColor = true;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // lbLog
            // 
            this.lbLog.FormattingEnabled = true;
            this.lbLog.Location = new System.Drawing.Point(14, 222);
            this.lbLog.Name = "lbLog";
            this.lbLog.Size = new System.Drawing.Size(540, 43);
            this.lbLog.TabIndex = 6;
            // 
            // btnWS
            // 
            this.btnWS.Location = new System.Drawing.Point(12, 65);
            this.btnWS.Name = "btnWS";
            this.btnWS.Size = new System.Drawing.Size(81, 27);
            this.btnWS.TabIndex = 9;
            this.btnWS.Text = "WebSockets";
            this.btnWS.UseVisualStyleBackColor = true;
            this.btnWS.Click += new System.EventHandler(this.btnWS_Click);
            // 
            // chkBeep
            // 
            this.chkBeep.AutoSize = true;
            this.chkBeep.Checked = true;
            this.chkBeep.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBeep.Location = new System.Drawing.Point(154, 71);
            this.chkBeep.Name = "chkBeep";
            this.chkBeep.Size = new System.Drawing.Size(58, 17);
            this.chkBeep.TabIndex = 11;
            this.chkBeep.Text = "Alarma";
            this.chkBeep.UseVisualStyleBackColor = true;
            // 
            // tmr
            // 
            this.tmr.Interval = 5000;
            this.tmr.Tick += new System.EventHandler(this.tmr_Tick);
            // 
            // txtStatus
            // 
            this.txtStatus.Enabled = false;
            this.txtStatus.Location = new System.Drawing.Point(493, 69);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(60, 20);
            this.txtStatus.TabIndex = 30;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(443, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Status:";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(271, 65);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(51, 27);
            this.btnClear.TabIndex = 33;
            this.btnClear.Text = "Limpiar";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // cboUmbral
            // 
            this.cboUmbral.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUmbral.FormattingEnabled = true;
            this.cboUmbral.Location = new System.Drawing.Point(380, 69);
            this.cboUmbral.Name = "cboUmbral";
            this.cboUmbral.Size = new System.Drawing.Size(42, 21);
            this.cboUmbral.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(337, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Umbral:";
            // 
            // chkFollow
            // 
            this.chkFollow.AutoSize = true;
            this.chkFollow.Checked = true;
            this.chkFollow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFollow.Location = new System.Drawing.Point(213, 71);
            this.chkFollow.Name = "chkFollow";
            this.chkFollow.Size = new System.Drawing.Size(52, 17);
            this.chkFollow.TabIndex = 36;
            this.chkFollow.Text = "Scroll";
            this.chkFollow.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(424, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 13);
            this.label4.TabIndex = 37;
            this.label4.Text = "%";
            // 
            // frmBOT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 270);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkFollow);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboUmbral);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.chkBeep);
            this.Controls.Add(this.btnWS);
            this.Controls.Add(this.lbLog);
            this.Controls.Add(this.btnRefrescar);
            this.Controls.Add(this.grdPanel);
            this.Controls.Add(this.gbxLogin);
            this.Name = "frmBOT";
            this.Text = "Tincho BOT arbitrador INVERSO Contado Inmediato contra 48hs para IOL";
            this.Load += new System.EventHandler(this.frmBOT_Load);
            this.gbxLogin.ResumeLayout(false);
            this.gbxLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPanel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxLogin;
        private System.Windows.Forms.TextBox txtBearer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.Label lblContraseña;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.DataGridView grdPanel;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.ListBox lbLog;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnWS;
        private System.Windows.Forms.CheckBox chkBeep;
        private System.Windows.Forms.Timer tmr;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ComboBox cboUmbral;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkFollow;
        private System.Windows.Forms.Label label4;
    }
}

