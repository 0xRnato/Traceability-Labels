namespace Traceability_Labels
{
    partial class Rastrear
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
            this.dg1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbox_Carregamento = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rbtn_Conferido = new System.Windows.Forms.RadioButton();
            this.rbtn_Impresso = new System.Windows.Forms.RadioButton();
            this.cbox_Carregamentos = new System.Windows.Forms.ComboBox();
            this.rbtn_Gerado = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbox_Caixas = new System.Windows.Forms.ListBox();
            this.lbox_Paletes = new System.Windows.Forms.ListBox();
            this.btn_Palete = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Done = new System.Windows.Forms.Button();
            this.btn_Caixa = new System.Windows.Forms.Button();
            this.btn_Carregamento = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dg1)).BeginInit();
            this.gbox_Carregamento.SuspendLayout();
            this.SuspendLayout();
            // 
            // dg1
            // 
            this.dg1.AllowUserToAddRows = false;
            this.dg1.AllowUserToDeleteRows = false;
            this.dg1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dg1.Location = new System.Drawing.Point(410, 12);
            this.dg1.Name = "dg1";
            this.dg1.ReadOnly = true;
            this.dg1.Size = new System.Drawing.Size(369, 494);
            this.dg1.TabIndex = 6;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "RESULTADO";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // gbox_Carregamento
            // 
            this.gbox_Carregamento.Controls.Add(this.label2);
            this.gbox_Carregamento.Controls.Add(this.rbtn_Conferido);
            this.gbox_Carregamento.Controls.Add(this.rbtn_Impresso);
            this.gbox_Carregamento.Controls.Add(this.cbox_Carregamentos);
            this.gbox_Carregamento.Controls.Add(this.rbtn_Gerado);
            this.gbox_Carregamento.Location = new System.Drawing.Point(12, 12);
            this.gbox_Carregamento.Name = "gbox_Carregamento";
            this.gbox_Carregamento.Size = new System.Drawing.Size(392, 108);
            this.gbox_Carregamento.TabIndex = 9;
            this.gbox_Carregamento.TabStop = false;
            this.gbox_Carregamento.Text = "CARREGAMENTO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(54, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "CARREGAMENTOS:";
            // 
            // rbtn_Conferido
            // 
            this.rbtn_Conferido.AutoSize = true;
            this.rbtn_Conferido.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtn_Conferido.Location = new System.Drawing.Point(220, 32);
            this.rbtn_Conferido.Name = "rbtn_Conferido";
            this.rbtn_Conferido.Size = new System.Drawing.Size(88, 17);
            this.rbtn_Conferido.TabIndex = 4;
            this.rbtn_Conferido.TabStop = true;
            this.rbtn_Conferido.Text = "CONFERIDO";
            this.rbtn_Conferido.UseVisualStyleBackColor = true;
            this.rbtn_Conferido.CheckedChanged += new System.EventHandler(this.rbtn_Conferido_CheckedChanged);
            // 
            // rbtn_Impresso
            // 
            this.rbtn_Impresso.AutoSize = true;
            this.rbtn_Impresso.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtn_Impresso.Location = new System.Drawing.Point(133, 32);
            this.rbtn_Impresso.Name = "rbtn_Impresso";
            this.rbtn_Impresso.Size = new System.Drawing.Size(81, 17);
            this.rbtn_Impresso.TabIndex = 3;
            this.rbtn_Impresso.TabStop = true;
            this.rbtn_Impresso.Text = "IMPRESSO";
            this.rbtn_Impresso.UseVisualStyleBackColor = true;
            this.rbtn_Impresso.CheckedChanged += new System.EventHandler(this.rbtn_Impresso_CheckedChanged);
            // 
            // cbox_Carregamentos
            // 
            this.cbox_Carregamentos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_Carregamentos.FormattingEnabled = true;
            this.cbox_Carregamentos.Location = new System.Drawing.Point(170, 60);
            this.cbox_Carregamentos.Name = "cbox_Carregamentos";
            this.cbox_Carregamentos.Size = new System.Drawing.Size(138, 21);
            this.cbox_Carregamentos.TabIndex = 1;
            this.cbox_Carregamentos.SelectedIndexChanged += new System.EventHandler(this.cbox_Carregamentos_SelectedIndexChanged);
            // 
            // rbtn_Gerado
            // 
            this.rbtn_Gerado.AutoSize = true;
            this.rbtn_Gerado.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtn_Gerado.Location = new System.Drawing.Point(56, 32);
            this.rbtn_Gerado.Name = "rbtn_Gerado";
            this.rbtn_Gerado.Size = new System.Drawing.Size(71, 17);
            this.rbtn_Gerado.TabIndex = 2;
            this.rbtn_Gerado.TabStop = true;
            this.rbtn_Gerado.Text = "GERADO";
            this.rbtn_Gerado.UseVisualStyleBackColor = true;
            this.rbtn_Gerado.CheckedChanged += new System.EventHandler(this.rbtn_Gerado_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(201, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "CAIXAS:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "PALETES:";
            // 
            // lbox_Caixas
            // 
            this.lbox_Caixas.FormattingEnabled = true;
            this.lbox_Caixas.Location = new System.Drawing.Point(201, 165);
            this.lbox_Caixas.Name = "lbox_Caixas";
            this.lbox_Caixas.Size = new System.Drawing.Size(203, 342);
            this.lbox_Caixas.TabIndex = 11;
            this.lbox_Caixas.SelectedIndexChanged += new System.EventHandler(this.lbox_Caixas_SelectedIndexChanged);
            // 
            // lbox_Paletes
            // 
            this.lbox_Paletes.FormattingEnabled = true;
            this.lbox_Paletes.Location = new System.Drawing.Point(15, 165);
            this.lbox_Paletes.Name = "lbox_Paletes";
            this.lbox_Paletes.Size = new System.Drawing.Size(180, 342);
            this.lbox_Paletes.TabIndex = 10;
            this.lbox_Paletes.SelectedIndexChanged += new System.EventHandler(this.lbox_Paletes_SelectedIndexChanged);
            // 
            // btn_Palete
            // 
            this.btn_Palete.Enabled = false;
            this.btn_Palete.Location = new System.Drawing.Point(188, 512);
            this.btn_Palete.Name = "btn_Palete";
            this.btn_Palete.Size = new System.Drawing.Size(105, 23);
            this.btn_Palete.TabIndex = 15;
            this.btn_Palete.Text = "PALETE";
            this.btn_Palete.UseVisualStyleBackColor = true;
            this.btn_Palete.Click += new System.EventHandler(this.btn_Palete_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(677, 512);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(102, 23);
            this.btn_Cancel.TabIndex = 27;
            this.btn_Cancel.Text = "CANCELAR";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Done
            // 
            this.btn_Done.Enabled = false;
            this.btn_Done.Location = new System.Drawing.Point(569, 512);
            this.btn_Done.Name = "btn_Done";
            this.btn_Done.Size = new System.Drawing.Size(102, 23);
            this.btn_Done.TabIndex = 26;
            this.btn_Done.Text = "IMPRIMIR";
            this.btn_Done.UseVisualStyleBackColor = true;
            // 
            // btn_Caixa
            // 
            this.btn_Caixa.Enabled = false;
            this.btn_Caixa.Location = new System.Drawing.Point(299, 512);
            this.btn_Caixa.Name = "btn_Caixa";
            this.btn_Caixa.Size = new System.Drawing.Size(105, 23);
            this.btn_Caixa.TabIndex = 14;
            this.btn_Caixa.Text = "CAIXA";
            this.btn_Caixa.UseVisualStyleBackColor = true;
            this.btn_Caixa.Click += new System.EventHandler(this.btn_Caixa_Click);
            // 
            // btn_Carregamento
            // 
            this.btn_Carregamento.Enabled = false;
            this.btn_Carregamento.Location = new System.Drawing.Point(69, 513);
            this.btn_Carregamento.Name = "btn_Carregamento";
            this.btn_Carregamento.Size = new System.Drawing.Size(113, 23);
            this.btn_Carregamento.TabIndex = 28;
            this.btn_Carregamento.Text = "CARREGAMENTO";
            this.btn_Carregamento.UseVisualStyleBackColor = true;
            this.btn_Carregamento.Click += new System.EventHandler(this.btn_Carregamento_Click);
            // 
            // Rastrear
            // 
            this.AcceptButton = this.btn_Done;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(791, 543);
            this.ControlBox = false;
            this.Controls.Add(this.btn_Carregamento);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Done);
            this.Controls.Add(this.btn_Palete);
            this.Controls.Add(this.btn_Caixa);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbox_Caixas);
            this.Controls.Add(this.lbox_Paletes);
            this.Controls.Add(this.gbox_Carregamento);
            this.Controls.Add(this.dg1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Rastrear";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rastrear";
            ((System.ComponentModel.ISupportInitialize)(this.dg1)).EndInit();
            this.gbox_Carregamento.ResumeLayout(false);
            this.gbox_Carregamento.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dg1;
        private System.Windows.Forms.GroupBox gbox_Carregamento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbtn_Conferido;
        private System.Windows.Forms.RadioButton rbtn_Impresso;
        private System.Windows.Forms.ComboBox cbox_Carregamentos;
        private System.Windows.Forms.RadioButton rbtn_Gerado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbox_Caixas;
        private System.Windows.Forms.ListBox lbox_Paletes;
        private System.Windows.Forms.Button btn_Palete;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Done;
        private System.Windows.Forms.Button btn_Caixa;
        private System.Windows.Forms.Button btn_Carregamento;
    }
}