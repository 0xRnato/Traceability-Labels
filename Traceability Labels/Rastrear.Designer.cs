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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Rastrear));
            this.rbtn_Produto = new System.Windows.Forms.RadioButton();
            this.rbtn_Gtin = new System.Windows.Forms.RadioButton();
            this.rbtn_SSCC = new System.Windows.Forms.RadioButton();
            this.rbtn_Usuario = new System.Windows.Forms.RadioButton();
            this.rbtn_Carregamento = new System.Windows.Forms.RadioButton();
            this.rbtn_DataConferido = new System.Windows.Forms.RadioButton();
            this.rbtn_DataImpresso = new System.Windows.Forms.RadioButton();
            this.rbtn_DataGerado = new System.Windows.Forms.RadioButton();
            this.txt_Carregamento = new System.Windows.Forms.TextBox();
            this.txt_Gtin = new System.Windows.Forms.TextBox();
            this.txt_SSCC = new System.Windows.Forms.TextBox();
            this.cbox_Produtos = new System.Windows.Forms.ComboBox();
            this.date_Gerado = new System.Windows.Forms.DateTimePicker();
            this.date_Impresso = new System.Windows.Forms.DateTimePicker();
            this.date_Conferido = new System.Windows.Forms.DateTimePicker();
            this.gbox_Pesquisa = new System.Windows.Forms.GroupBox();
            this.cbox_Usuario = new System.Windows.Forms.ComboBox();
            this.btn_Pesqusiar = new System.Windows.Forms.Button();
            this.tab_Resultado = new System.Windows.Forms.TabControl();
            this.page_Carregamentos = new System.Windows.Forms.TabPage();
            this.grid_Carregamentos = new System.Windows.Forms.DataGridView();
            this.page_Paletes = new System.Windows.Forms.TabPage();
            this.grid_Paletes = new System.Windows.Forms.DataGridView();
            this.tab_Caixas = new System.Windows.Forms.TabPage();
            this.grid_Caixas = new System.Windows.Forms.DataGridView();
            this.btn_Imprimir = new System.Windows.Forms.Button();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.gbox_Resultado = new System.Windows.Forms.GroupBox();
            this.gbox_Pesquisa.SuspendLayout();
            this.tab_Resultado.SuspendLayout();
            this.page_Carregamentos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_Carregamentos)).BeginInit();
            this.page_Paletes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_Paletes)).BeginInit();
            this.tab_Caixas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_Caixas)).BeginInit();
            this.gbox_Resultado.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbtn_Produto
            // 
            this.rbtn_Produto.AutoSize = true;
            this.rbtn_Produto.Location = new System.Drawing.Point(69, 63);
            this.rbtn_Produto.Margin = new System.Windows.Forms.Padding(2);
            this.rbtn_Produto.Name = "rbtn_Produto";
            this.rbtn_Produto.Size = new System.Drawing.Size(82, 17);
            this.rbtn_Produto.TabIndex = 2;
            this.rbtn_Produto.TabStop = true;
            this.rbtn_Produto.Text = "PRODUTO:";
            this.rbtn_Produto.UseVisualStyleBackColor = true;
            this.rbtn_Produto.CheckedChanged += new System.EventHandler(this.rbtn_Produto_CheckedChanged);
            // 
            // rbtn_Gtin
            // 
            this.rbtn_Gtin.AutoSize = true;
            this.rbtn_Gtin.Location = new System.Drawing.Point(69, 88);
            this.rbtn_Gtin.Margin = new System.Windows.Forms.Padding(2);
            this.rbtn_Gtin.Name = "rbtn_Gtin";
            this.rbtn_Gtin.Size = new System.Drawing.Size(54, 17);
            this.rbtn_Gtin.TabIndex = 3;
            this.rbtn_Gtin.TabStop = true;
            this.rbtn_Gtin.Text = "GTIN:";
            this.rbtn_Gtin.UseVisualStyleBackColor = true;
            this.rbtn_Gtin.CheckedChanged += new System.EventHandler(this.rbtn_Gtin_CheckedChanged);
            // 
            // rbtn_SSCC
            // 
            this.rbtn_SSCC.AutoSize = true;
            this.rbtn_SSCC.Location = new System.Drawing.Point(68, 110);
            this.rbtn_SSCC.Margin = new System.Windows.Forms.Padding(2);
            this.rbtn_SSCC.Name = "rbtn_SSCC";
            this.rbtn_SSCC.Size = new System.Drawing.Size(56, 17);
            this.rbtn_SSCC.TabIndex = 4;
            this.rbtn_SSCC.TabStop = true;
            this.rbtn_SSCC.Text = "SSCC:";
            this.rbtn_SSCC.UseVisualStyleBackColor = true;
            this.rbtn_SSCC.CheckedChanged += new System.EventHandler(this.rbtn_SSCC_CheckedChanged);
            // 
            // rbtn_Usuario
            // 
            this.rbtn_Usuario.AutoSize = true;
            this.rbtn_Usuario.Location = new System.Drawing.Point(375, 40);
            this.rbtn_Usuario.Margin = new System.Windows.Forms.Padding(2);
            this.rbtn_Usuario.Name = "rbtn_Usuario";
            this.rbtn_Usuario.Size = new System.Drawing.Size(77, 17);
            this.rbtn_Usuario.TabIndex = 5;
            this.rbtn_Usuario.TabStop = true;
            this.rbtn_Usuario.Text = "USUÁRIO:";
            this.rbtn_Usuario.UseVisualStyleBackColor = true;
            this.rbtn_Usuario.CheckedChanged += new System.EventHandler(this.rbtn_Usuario_CheckedChanged);
            // 
            // rbtn_Carregamento
            // 
            this.rbtn_Carregamento.AutoSize = true;
            this.rbtn_Carregamento.Location = new System.Drawing.Point(69, 40);
            this.rbtn_Carregamento.Margin = new System.Windows.Forms.Padding(2);
            this.rbtn_Carregamento.Name = "rbtn_Carregamento";
            this.rbtn_Carregamento.Size = new System.Drawing.Size(119, 17);
            this.rbtn_Carregamento.TabIndex = 1;
            this.rbtn_Carregamento.TabStop = true;
            this.rbtn_Carregamento.Text = "CARREGAMENTO:";
            this.rbtn_Carregamento.UseVisualStyleBackColor = true;
            this.rbtn_Carregamento.CheckedChanged += new System.EventHandler(this.rbtn_Carregamento_CheckedChanged);
            // 
            // rbtn_DataConferido
            // 
            this.rbtn_DataConferido.AutoSize = true;
            this.rbtn_DataConferido.Location = new System.Drawing.Point(375, 108);
            this.rbtn_DataConferido.Margin = new System.Windows.Forms.Padding(2);
            this.rbtn_DataConferido.Name = "rbtn_DataConferido";
            this.rbtn_DataConferido.Size = new System.Drawing.Size(123, 17);
            this.rbtn_DataConferido.TabIndex = 8;
            this.rbtn_DataConferido.TabStop = true;
            this.rbtn_DataConferido.Text = "DATA CONFERIDO:";
            this.rbtn_DataConferido.UseVisualStyleBackColor = true;
            this.rbtn_DataConferido.CheckedChanged += new System.EventHandler(this.rbtn_DataConferido_CheckedChanged);
            // 
            // rbtn_DataImpresso
            // 
            this.rbtn_DataImpresso.AutoSize = true;
            this.rbtn_DataImpresso.Location = new System.Drawing.Point(375, 87);
            this.rbtn_DataImpresso.Margin = new System.Windows.Forms.Padding(2);
            this.rbtn_DataImpresso.Name = "rbtn_DataImpresso";
            this.rbtn_DataImpresso.Size = new System.Drawing.Size(116, 17);
            this.rbtn_DataImpresso.TabIndex = 7;
            this.rbtn_DataImpresso.TabStop = true;
            this.rbtn_DataImpresso.Text = "DATA IMPRESSO:";
            this.rbtn_DataImpresso.UseVisualStyleBackColor = true;
            this.rbtn_DataImpresso.CheckedChanged += new System.EventHandler(this.rbtn_DataImpresso_CheckedChanged);
            // 
            // rbtn_DataGerado
            // 
            this.rbtn_DataGerado.AutoSize = true;
            this.rbtn_DataGerado.Location = new System.Drawing.Point(375, 64);
            this.rbtn_DataGerado.Margin = new System.Windows.Forms.Padding(2);
            this.rbtn_DataGerado.Name = "rbtn_DataGerado";
            this.rbtn_DataGerado.Size = new System.Drawing.Size(106, 17);
            this.rbtn_DataGerado.TabIndex = 6;
            this.rbtn_DataGerado.TabStop = true;
            this.rbtn_DataGerado.Text = "DATA GERADO:";
            this.rbtn_DataGerado.UseVisualStyleBackColor = true;
            this.rbtn_DataGerado.CheckedChanged += new System.EventHandler(this.rbtn_DataGerado_CheckedChanged);
            // 
            // txt_Carregamento
            // 
            this.txt_Carregamento.Enabled = false;
            this.txt_Carregamento.Location = new System.Drawing.Point(190, 40);
            this.txt_Carregamento.Margin = new System.Windows.Forms.Padding(2);
            this.txt_Carregamento.Name = "txt_Carregamento";
            this.txt_Carregamento.Size = new System.Drawing.Size(140, 20);
            this.txt_Carregamento.TabIndex = 8;
            // 
            // txt_Gtin
            // 
            this.txt_Gtin.Enabled = false;
            this.txt_Gtin.Location = new System.Drawing.Point(190, 87);
            this.txt_Gtin.Margin = new System.Windows.Forms.Padding(2);
            this.txt_Gtin.Name = "txt_Gtin";
            this.txt_Gtin.Size = new System.Drawing.Size(140, 20);
            this.txt_Gtin.TabIndex = 10;
            // 
            // txt_SSCC
            // 
            this.txt_SSCC.Enabled = false;
            this.txt_SSCC.Location = new System.Drawing.Point(190, 110);
            this.txt_SSCC.Margin = new System.Windows.Forms.Padding(2);
            this.txt_SSCC.Name = "txt_SSCC";
            this.txt_SSCC.Size = new System.Drawing.Size(140, 20);
            this.txt_SSCC.TabIndex = 11;
            // 
            // cbox_Produtos
            // 
            this.cbox_Produtos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_Produtos.Enabled = false;
            this.cbox_Produtos.FormattingEnabled = true;
            this.cbox_Produtos.Location = new System.Drawing.Point(190, 63);
            this.cbox_Produtos.Margin = new System.Windows.Forms.Padding(2);
            this.cbox_Produtos.Name = "cbox_Produtos";
            this.cbox_Produtos.Size = new System.Drawing.Size(140, 21);
            this.cbox_Produtos.TabIndex = 13;
            // 
            // date_Gerado
            // 
            this.date_Gerado.CustomFormat = "dd/MM/yy";
            this.date_Gerado.Enabled = false;
            this.date_Gerado.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_Gerado.Location = new System.Drawing.Point(496, 62);
            this.date_Gerado.Margin = new System.Windows.Forms.Padding(2);
            this.date_Gerado.Name = "date_Gerado";
            this.date_Gerado.Size = new System.Drawing.Size(116, 20);
            this.date_Gerado.TabIndex = 14;
            // 
            // date_Impresso
            // 
            this.date_Impresso.CustomFormat = "dd/MM/yy";
            this.date_Impresso.Enabled = false;
            this.date_Impresso.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_Impresso.Location = new System.Drawing.Point(496, 84);
            this.date_Impresso.Margin = new System.Windows.Forms.Padding(2);
            this.date_Impresso.Name = "date_Impresso";
            this.date_Impresso.Size = new System.Drawing.Size(116, 20);
            this.date_Impresso.TabIndex = 15;
            // 
            // date_Conferido
            // 
            this.date_Conferido.CustomFormat = "dd/MM/yy";
            this.date_Conferido.Enabled = false;
            this.date_Conferido.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_Conferido.Location = new System.Drawing.Point(496, 107);
            this.date_Conferido.Margin = new System.Windows.Forms.Padding(2);
            this.date_Conferido.Name = "date_Conferido";
            this.date_Conferido.Size = new System.Drawing.Size(116, 20);
            this.date_Conferido.TabIndex = 16;
            // 
            // gbox_Pesquisa
            // 
            this.gbox_Pesquisa.Controls.Add(this.cbox_Usuario);
            this.gbox_Pesquisa.Controls.Add(this.btn_Pesqusiar);
            this.gbox_Pesquisa.Controls.Add(this.rbtn_Usuario);
            this.gbox_Pesquisa.Controls.Add(this.date_Conferido);
            this.gbox_Pesquisa.Controls.Add(this.rbtn_Produto);
            this.gbox_Pesquisa.Controls.Add(this.date_Impresso);
            this.gbox_Pesquisa.Controls.Add(this.rbtn_Gtin);
            this.gbox_Pesquisa.Controls.Add(this.date_Gerado);
            this.gbox_Pesquisa.Controls.Add(this.rbtn_SSCC);
            this.gbox_Pesquisa.Controls.Add(this.cbox_Produtos);
            this.gbox_Pesquisa.Controls.Add(this.rbtn_DataGerado);
            this.gbox_Pesquisa.Controls.Add(this.rbtn_DataImpresso);
            this.gbox_Pesquisa.Controls.Add(this.txt_SSCC);
            this.gbox_Pesquisa.Controls.Add(this.rbtn_DataConferido);
            this.gbox_Pesquisa.Controls.Add(this.txt_Gtin);
            this.gbox_Pesquisa.Controls.Add(this.rbtn_Carregamento);
            this.gbox_Pesquisa.Controls.Add(this.txt_Carregamento);
            this.gbox_Pesquisa.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbox_Pesquisa.Location = new System.Drawing.Point(0, 0);
            this.gbox_Pesquisa.Margin = new System.Windows.Forms.Padding(2);
            this.gbox_Pesquisa.Name = "gbox_Pesquisa";
            this.gbox_Pesquisa.Padding = new System.Windows.Forms.Padding(2);
            this.gbox_Pesquisa.Size = new System.Drawing.Size(701, 189);
            this.gbox_Pesquisa.TabIndex = 17;
            this.gbox_Pesquisa.TabStop = false;
            this.gbox_Pesquisa.Text = "PESQUISAR POR:";
            // 
            // cbox_Usuario
            // 
            this.cbox_Usuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_Usuario.Enabled = false;
            this.cbox_Usuario.FormattingEnabled = true;
            this.cbox_Usuario.Location = new System.Drawing.Point(496, 37);
            this.cbox_Usuario.Margin = new System.Windows.Forms.Padding(2);
            this.cbox_Usuario.Name = "cbox_Usuario";
            this.cbox_Usuario.Size = new System.Drawing.Size(116, 21);
            this.cbox_Usuario.TabIndex = 18;
            // 
            // btn_Pesqusiar
            // 
            this.btn_Pesqusiar.Enabled = false;
            this.btn_Pesqusiar.Location = new System.Drawing.Point(509, 142);
            this.btn_Pesqusiar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Pesqusiar.Name = "btn_Pesqusiar";
            this.btn_Pesqusiar.Size = new System.Drawing.Size(101, 27);
            this.btn_Pesqusiar.TabIndex = 9;
            this.btn_Pesqusiar.Text = "PESQUISAR";
            this.btn_Pesqusiar.UseVisualStyleBackColor = true;
            this.btn_Pesqusiar.Click += new System.EventHandler(this.btn_Pesqusiar_Click);
            // 
            // tab_Resultado
            // 
            this.tab_Resultado.Controls.Add(this.page_Carregamentos);
            this.tab_Resultado.Controls.Add(this.page_Paletes);
            this.tab_Resultado.Controls.Add(this.tab_Caixas);
            this.tab_Resultado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab_Resultado.Location = new System.Drawing.Point(2, 15);
            this.tab_Resultado.Margin = new System.Windows.Forms.Padding(2);
            this.tab_Resultado.Name = "tab_Resultado";
            this.tab_Resultado.SelectedIndex = 0;
            this.tab_Resultado.Size = new System.Drawing.Size(697, 371);
            this.tab_Resultado.TabIndex = 11;
            // 
            // page_Carregamentos
            // 
            this.page_Carregamentos.Controls.Add(this.grid_Carregamentos);
            this.page_Carregamentos.Location = new System.Drawing.Point(4, 22);
            this.page_Carregamentos.Margin = new System.Windows.Forms.Padding(2);
            this.page_Carregamentos.Name = "page_Carregamentos";
            this.page_Carregamentos.Padding = new System.Windows.Forms.Padding(2);
            this.page_Carregamentos.Size = new System.Drawing.Size(689, 345);
            this.page_Carregamentos.TabIndex = 0;
            this.page_Carregamentos.Text = "CARREGAMENTOS";
            this.page_Carregamentos.UseVisualStyleBackColor = true;
            // 
            // grid_Carregamentos
            // 
            this.grid_Carregamentos.AllowUserToAddRows = false;
            this.grid_Carregamentos.AllowUserToDeleteRows = false;
            this.grid_Carregamentos.AllowUserToOrderColumns = true;
            this.grid_Carregamentos.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.grid_Carregamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_Carregamentos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_Carregamentos.Location = new System.Drawing.Point(2, 2);
            this.grid_Carregamentos.Margin = new System.Windows.Forms.Padding(2);
            this.grid_Carregamentos.Name = "grid_Carregamentos";
            this.grid_Carregamentos.ReadOnly = true;
            this.grid_Carregamentos.RowTemplate.Height = 24;
            this.grid_Carregamentos.Size = new System.Drawing.Size(685, 341);
            this.grid_Carregamentos.TabIndex = 12;
            // 
            // page_Paletes
            // 
            this.page_Paletes.Controls.Add(this.grid_Paletes);
            this.page_Paletes.Location = new System.Drawing.Point(4, 22);
            this.page_Paletes.Margin = new System.Windows.Forms.Padding(2);
            this.page_Paletes.Name = "page_Paletes";
            this.page_Paletes.Padding = new System.Windows.Forms.Padding(2);
            this.page_Paletes.Size = new System.Drawing.Size(689, 345);
            this.page_Paletes.TabIndex = 1;
            this.page_Paletes.Text = "PALETES";
            this.page_Paletes.UseVisualStyleBackColor = true;
            // 
            // grid_Paletes
            // 
            this.grid_Paletes.AllowUserToAddRows = false;
            this.grid_Paletes.AllowUserToDeleteRows = false;
            this.grid_Paletes.AllowUserToOrderColumns = true;
            this.grid_Paletes.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.grid_Paletes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_Paletes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_Paletes.Location = new System.Drawing.Point(2, 2);
            this.grid_Paletes.Margin = new System.Windows.Forms.Padding(2);
            this.grid_Paletes.Name = "grid_Paletes";
            this.grid_Paletes.ReadOnly = true;
            this.grid_Paletes.RowTemplate.Height = 24;
            this.grid_Paletes.Size = new System.Drawing.Size(685, 341);
            this.grid_Paletes.TabIndex = 13;
            // 
            // tab_Caixas
            // 
            this.tab_Caixas.Controls.Add(this.grid_Caixas);
            this.tab_Caixas.Location = new System.Drawing.Point(4, 22);
            this.tab_Caixas.Margin = new System.Windows.Forms.Padding(2);
            this.tab_Caixas.Name = "tab_Caixas";
            this.tab_Caixas.Padding = new System.Windows.Forms.Padding(2);
            this.tab_Caixas.Size = new System.Drawing.Size(689, 345);
            this.tab_Caixas.TabIndex = 2;
            this.tab_Caixas.Text = "CAIXAS";
            this.tab_Caixas.UseVisualStyleBackColor = true;
            // 
            // grid_Caixas
            // 
            this.grid_Caixas.AllowUserToAddRows = false;
            this.grid_Caixas.AllowUserToDeleteRows = false;
            this.grid_Caixas.AllowUserToOrderColumns = true;
            this.grid_Caixas.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.grid_Caixas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_Caixas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_Caixas.Location = new System.Drawing.Point(2, 2);
            this.grid_Caixas.Margin = new System.Windows.Forms.Padding(2);
            this.grid_Caixas.Name = "grid_Caixas";
            this.grid_Caixas.ReadOnly = true;
            this.grid_Caixas.RowTemplate.Height = 24;
            this.grid_Caixas.Size = new System.Drawing.Size(685, 341);
            this.grid_Caixas.TabIndex = 14;
            // 
            // btn_Imprimir
            // 
            this.btn_Imprimir.Enabled = false;
            this.btn_Imprimir.Location = new System.Drawing.Point(472, 587);
            this.btn_Imprimir.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Imprimir.Name = "btn_Imprimir";
            this.btn_Imprimir.Size = new System.Drawing.Size(101, 27);
            this.btn_Imprimir.TabIndex = 15;
            this.btn_Imprimir.Text = "IMPRIMIR";
            this.btn_Imprimir.UseVisualStyleBackColor = true;
            this.btn_Imprimir.Click += new System.EventHandler(this.btn_Imprimir_Click);
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancelar.Location = new System.Drawing.Point(578, 587);
            this.btn_Cancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(101, 27);
            this.btn_Cancelar.TabIndex = 16;
            this.btn_Cancelar.Text = "CANCELAR";
            this.btn_Cancelar.UseVisualStyleBackColor = true;
            // 
            // gbox_Resultado
            // 
            this.gbox_Resultado.Controls.Add(this.tab_Resultado);
            this.gbox_Resultado.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbox_Resultado.Enabled = false;
            this.gbox_Resultado.Location = new System.Drawing.Point(0, 189);
            this.gbox_Resultado.Margin = new System.Windows.Forms.Padding(2);
            this.gbox_Resultado.Name = "gbox_Resultado";
            this.gbox_Resultado.Padding = new System.Windows.Forms.Padding(2);
            this.gbox_Resultado.Size = new System.Drawing.Size(701, 388);
            this.gbox_Resultado.TabIndex = 1;
            this.gbox_Resultado.TabStop = false;
            this.gbox_Resultado.Text = "RESULTADO:";
            // 
            // Rastrear
            // 
            this.AcceptButton = this.btn_Pesqusiar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.CancelButton = this.btn_Cancelar;
            this.ClientSize = new System.Drawing.Size(701, 627);
            this.ControlBox = false;
            this.Controls.Add(this.gbox_Resultado);
            this.Controls.Add(this.btn_Imprimir);
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.gbox_Pesquisa);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Rastrear";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rastrear";
            this.Load += new System.EventHandler(this.Rastrear_Load);
            this.gbox_Pesquisa.ResumeLayout(false);
            this.gbox_Pesquisa.PerformLayout();
            this.tab_Resultado.ResumeLayout(false);
            this.page_Carregamentos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_Carregamentos)).EndInit();
            this.page_Paletes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_Paletes)).EndInit();
            this.tab_Caixas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_Caixas)).EndInit();
            this.gbox_Resultado.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtn_Produto;
        private System.Windows.Forms.RadioButton rbtn_Gtin;
        private System.Windows.Forms.RadioButton rbtn_SSCC;
        private System.Windows.Forms.RadioButton rbtn_Usuario;
        private System.Windows.Forms.RadioButton rbtn_Carregamento;
        private System.Windows.Forms.RadioButton rbtn_DataConferido;
        private System.Windows.Forms.RadioButton rbtn_DataImpresso;
        private System.Windows.Forms.RadioButton rbtn_DataGerado;
        private System.Windows.Forms.TextBox txt_Carregamento;
        private System.Windows.Forms.TextBox txt_Gtin;
        private System.Windows.Forms.TextBox txt_SSCC;
        private System.Windows.Forms.ComboBox cbox_Produtos;
        private System.Windows.Forms.DateTimePicker date_Gerado;
        private System.Windows.Forms.DateTimePicker date_Impresso;
        private System.Windows.Forms.DateTimePicker date_Conferido;
        private System.Windows.Forms.GroupBox gbox_Pesquisa;
        private System.Windows.Forms.Button btn_Pesqusiar;
        private System.Windows.Forms.ComboBox cbox_Usuario;
        private System.Windows.Forms.TabControl tab_Resultado;
        private System.Windows.Forms.TabPage page_Carregamentos;
        private System.Windows.Forms.TabPage page_Paletes;
        private System.Windows.Forms.Button btn_Imprimir;
        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.TabPage tab_Caixas;
        private System.Windows.Forms.DataGridView grid_Carregamentos;
        private System.Windows.Forms.DataGridView grid_Paletes;
        private System.Windows.Forms.DataGridView grid_Caixas;
        private System.Windows.Forms.GroupBox gbox_Resultado;
    }
}