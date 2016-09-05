namespace Traceability_Labels
{
    partial class Home
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.produtosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrarProdutoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deletarProdutoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listarProdutosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sSCCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listaDeSSCCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.etiquetasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.caixaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gerarNovaEtiquetaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listarEtiquetasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gerarNovaEtiquetaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.listarEtiquetasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.impressorasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbl_Printer = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.produtosToolStripMenuItem,
            this.sSCCToolStripMenuItem,
            this.etiquetasToolStripMenuItem,
            this.configuraçõesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(613, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // produtosToolStripMenuItem
            // 
            this.produtosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrarProdutoToolStripMenuItem,
            this.deletarProdutoToolStripMenuItem,
            this.listarProdutosToolStripMenuItem});
            this.produtosToolStripMenuItem.Name = "produtosToolStripMenuItem";
            this.produtosToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.produtosToolStripMenuItem.Text = "Produtos";
            // 
            // cadastrarProdutoToolStripMenuItem
            // 
            this.cadastrarProdutoToolStripMenuItem.Name = "cadastrarProdutoToolStripMenuItem";
            this.cadastrarProdutoToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.cadastrarProdutoToolStripMenuItem.Text = "Cadastrar produto";
            this.cadastrarProdutoToolStripMenuItem.Click += new System.EventHandler(this.cadastrarProdutoToolStripMenuItem_Click);
            // 
            // deletarProdutoToolStripMenuItem
            // 
            this.deletarProdutoToolStripMenuItem.Name = "deletarProdutoToolStripMenuItem";
            this.deletarProdutoToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.deletarProdutoToolStripMenuItem.Text = "Editar produto";
            this.deletarProdutoToolStripMenuItem.Click += new System.EventHandler(this.deletarProdutoToolStripMenuItem_Click);
            // 
            // listarProdutosToolStripMenuItem
            // 
            this.listarProdutosToolStripMenuItem.Name = "listarProdutosToolStripMenuItem";
            this.listarProdutosToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.listarProdutosToolStripMenuItem.Text = "Listar produtos";
            this.listarProdutosToolStripMenuItem.Click += new System.EventHandler(this.listarProdutosToolStripMenuItem_Click);
            // 
            // sSCCToolStripMenuItem
            // 
            this.sSCCToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listaDeSSCCToolStripMenuItem});
            this.sSCCToolStripMenuItem.Name = "sSCCToolStripMenuItem";
            this.sSCCToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.sSCCToolStripMenuItem.Text = "SSCC";
            // 
            // listaDeSSCCToolStripMenuItem
            // 
            this.listaDeSSCCToolStripMenuItem.Name = "listaDeSSCCToolStripMenuItem";
            this.listaDeSSCCToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.listaDeSSCCToolStripMenuItem.Text = "Lista de SSCC";
            this.listaDeSSCCToolStripMenuItem.Click += new System.EventHandler(this.listaDeSSCCToolStripMenuItem_Click);
            // 
            // etiquetasToolStripMenuItem
            // 
            this.etiquetasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.caixaToolStripMenuItem,
            this.paleteToolStripMenuItem});
            this.etiquetasToolStripMenuItem.Name = "etiquetasToolStripMenuItem";
            this.etiquetasToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.etiquetasToolStripMenuItem.Text = "Etiquetas";
            // 
            // caixaToolStripMenuItem
            // 
            this.caixaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gerarNovaEtiquetaToolStripMenuItem,
            this.listarEtiquetasToolStripMenuItem});
            this.caixaToolStripMenuItem.Name = "caixaToolStripMenuItem";
            this.caixaToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.caixaToolStripMenuItem.Text = "Caixa";
            // 
            // gerarNovaEtiquetaToolStripMenuItem
            // 
            this.gerarNovaEtiquetaToolStripMenuItem.Name = "gerarNovaEtiquetaToolStripMenuItem";
            this.gerarNovaEtiquetaToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.gerarNovaEtiquetaToolStripMenuItem.Text = "Gerar nova etiqueta";
            this.gerarNovaEtiquetaToolStripMenuItem.Click += new System.EventHandler(this.gerarNovaEtiquetaToolStripMenuItem_Click);
            // 
            // listarEtiquetasToolStripMenuItem
            // 
            this.listarEtiquetasToolStripMenuItem.Name = "listarEtiquetasToolStripMenuItem";
            this.listarEtiquetasToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.listarEtiquetasToolStripMenuItem.Text = "Listar etiquetas";
            this.listarEtiquetasToolStripMenuItem.Click += new System.EventHandler(this.listarEtiquetasToolStripMenuItem_Click);
            // 
            // paleteToolStripMenuItem
            // 
            this.paleteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gerarNovaEtiquetaToolStripMenuItem1,
            this.listarEtiquetasToolStripMenuItem1});
            this.paleteToolStripMenuItem.Name = "paleteToolStripMenuItem";
            this.paleteToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.paleteToolStripMenuItem.Text = "Palete";
            // 
            // gerarNovaEtiquetaToolStripMenuItem1
            // 
            this.gerarNovaEtiquetaToolStripMenuItem1.Name = "gerarNovaEtiquetaToolStripMenuItem1";
            this.gerarNovaEtiquetaToolStripMenuItem1.Size = new System.Drawing.Size(177, 22);
            this.gerarNovaEtiquetaToolStripMenuItem1.Text = "Gerar nova etiqueta";
            this.gerarNovaEtiquetaToolStripMenuItem1.Click += new System.EventHandler(this.gerarNovaEtiquetaToolStripMenuItem1_Click);
            // 
            // listarEtiquetasToolStripMenuItem1
            // 
            this.listarEtiquetasToolStripMenuItem1.Name = "listarEtiquetasToolStripMenuItem1";
            this.listarEtiquetasToolStripMenuItem1.Size = new System.Drawing.Size(177, 22);
            this.listarEtiquetasToolStripMenuItem1.Text = "Listar etiquetas";
            this.listarEtiquetasToolStripMenuItem1.Click += new System.EventHandler(this.listarEtiquetasToolStripMenuItem1_Click);
            // 
            // configuraçõesToolStripMenuItem
            // 
            this.configuraçõesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.impressorasToolStripMenuItem});
            this.configuraçõesToolStripMenuItem.Name = "configuraçõesToolStripMenuItem";
            this.configuraçõesToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.configuraçõesToolStripMenuItem.Text = "Configurações";
            // 
            // impressorasToolStripMenuItem
            // 
            this.impressorasToolStripMenuItem.Name = "impressorasToolStripMenuItem";
            this.impressorasToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.impressorasToolStripMenuItem.Text = "Impressoras";
            this.impressorasToolStripMenuItem.Click += new System.EventHandler(this.impressorasToolStripMenuItem_Click);
            // 
            // lbl_Printer
            // 
            this.lbl_Printer.AutoSize = true;
            this.lbl_Printer.Location = new System.Drawing.Point(12, 389);
            this.lbl_Printer.Name = "lbl_Printer";
            this.lbl_Printer.Size = new System.Drawing.Size(84, 13);
            this.lbl_Printer.TabIndex = 1;
            this.lbl_Printer.Text = "IMPRESSORA: ";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 411);
            this.Controls.Add(this.lbl_Printer);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Etiquetas de Rastreabilidade";
            this.Activated += new System.EventHandler(this.Home_Activated);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem produtosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrarProdutoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deletarProdutoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listarProdutosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sSCCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listaDeSSCCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem etiquetasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem caixaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraçõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem impressorasToolStripMenuItem;
        private System.Windows.Forms.Label lbl_Printer;
        private System.Windows.Forms.ToolStripMenuItem gerarNovaEtiquetaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listarEtiquetasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gerarNovaEtiquetaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem listarEtiquetasToolStripMenuItem1;
    }
}

