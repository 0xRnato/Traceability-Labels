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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menu_Produtos = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_CadastrarProduto = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_EditarProduto = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_ListarProdutos = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_Etiquetas = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_ImprimirEtiquetas = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_GerarEtiquetas = new System.Windows.Forms.ToolStripMenuItem();
            this.novoCarregamentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarCarregamentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_Rastrear = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_Configuracoes = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_Impressoras = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_Leitor = new System.Windows.Forms.ToolStripMenuItem();
            this.salvarCarregamentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gerarChaveDeUsuárioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_CadastrarUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_EditarUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_Sobre = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_Sair = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbl_User = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_Printer = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_Produtos,
            this.menu_Etiquetas,
            this.menu_Configuracoes,
            this.menu_Sobre,
            this.menu_Sair});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(714, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menu_Produtos
            // 
            this.menu_Produtos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_CadastrarProduto,
            this.menu_EditarProduto,
            this.menu_ListarProdutos});
            this.menu_Produtos.Name = "menu_Produtos";
            this.menu_Produtos.Size = new System.Drawing.Size(67, 20);
            this.menu_Produtos.Text = "Produtos";
            // 
            // menu_CadastrarProduto
            // 
            this.menu_CadastrarProduto.Name = "menu_CadastrarProduto";
            this.menu_CadastrarProduto.Size = new System.Drawing.Size(170, 22);
            this.menu_CadastrarProduto.Text = "Cadastrar produto";
            this.menu_CadastrarProduto.Click += new System.EventHandler(this.menu_CadastrarProduto_Click);
            // 
            // menu_EditarProduto
            // 
            this.menu_EditarProduto.Name = "menu_EditarProduto";
            this.menu_EditarProduto.Size = new System.Drawing.Size(170, 22);
            this.menu_EditarProduto.Text = "Editar produto";
            this.menu_EditarProduto.Click += new System.EventHandler(this.menu_EditarProduto_Click);
            // 
            // menu_ListarProdutos
            // 
            this.menu_ListarProdutos.Name = "menu_ListarProdutos";
            this.menu_ListarProdutos.Size = new System.Drawing.Size(170, 22);
            this.menu_ListarProdutos.Text = "Listar produtos";
            this.menu_ListarProdutos.Click += new System.EventHandler(this.menu_ListarProdutos_Click);
            // 
            // menu_Etiquetas
            // 
            this.menu_Etiquetas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_ImprimirEtiquetas,
            this.menu_GerarEtiquetas,
            this.menu_Rastrear});
            this.menu_Etiquetas.Name = "menu_Etiquetas";
            this.menu_Etiquetas.Size = new System.Drawing.Size(67, 20);
            this.menu_Etiquetas.Text = "Etiquetas";
            // 
            // menu_ImprimirEtiquetas
            // 
            this.menu_ImprimirEtiquetas.Name = "menu_ImprimirEtiquetas";
            this.menu_ImprimirEtiquetas.Size = new System.Drawing.Size(206, 22);
            this.menu_ImprimirEtiquetas.Text = "Imprimir etiquetas";
            this.menu_ImprimirEtiquetas.Click += new System.EventHandler(this.menu_ImprimirEtiquetas_Click);
            // 
            // menu_GerarEtiquetas
            // 
            this.menu_GerarEtiquetas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novoCarregamentoToolStripMenuItem,
            this.editarCarregamentoToolStripMenuItem});
            this.menu_GerarEtiquetas.Name = "menu_GerarEtiquetas";
            this.menu_GerarEtiquetas.Size = new System.Drawing.Size(206, 22);
            this.menu_GerarEtiquetas.Text = "Gerenciar carregamentos";
            // 
            // novoCarregamentoToolStripMenuItem
            // 
            this.novoCarregamentoToolStripMenuItem.Name = "novoCarregamentoToolStripMenuItem";
            this.novoCarregamentoToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.novoCarregamentoToolStripMenuItem.Text = "Novo carregamento";
            this.novoCarregamentoToolStripMenuItem.Click += new System.EventHandler(this.novoCarregamentoToolStripMenuItem_Click);
            // 
            // editarCarregamentoToolStripMenuItem
            // 
            this.editarCarregamentoToolStripMenuItem.Name = "editarCarregamentoToolStripMenuItem";
            this.editarCarregamentoToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.editarCarregamentoToolStripMenuItem.Text = "Deletar carregamento";
            this.editarCarregamentoToolStripMenuItem.Click += new System.EventHandler(this.editarCarregamentoToolStripMenuItem_Click);
            // 
            // menu_Rastrear
            // 
            this.menu_Rastrear.Name = "menu_Rastrear";
            this.menu_Rastrear.Size = new System.Drawing.Size(206, 22);
            this.menu_Rastrear.Text = "Rastrear mercadoria";
            this.menu_Rastrear.Click += new System.EventHandler(this.menu_Rastrear_Click);
            // 
            // menu_Configuracoes
            // 
            this.menu_Configuracoes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_Impressoras,
            this.menu_Leitor,
            this.menu_CadastrarUsuario,
            this.menu_EditarUsuario});
            this.menu_Configuracoes.Name = "menu_Configuracoes";
            this.menu_Configuracoes.Size = new System.Drawing.Size(96, 20);
            this.menu_Configuracoes.Text = "Configurações";
            // 
            // menu_Impressoras
            // 
            this.menu_Impressoras.Name = "menu_Impressoras";
            this.menu_Impressoras.Size = new System.Drawing.Size(166, 22);
            this.menu_Impressoras.Text = "Impressoras";
            this.menu_Impressoras.Click += new System.EventHandler(this.menu_Impressoras_Click);
            // 
            // menu_Leitor
            // 
            this.menu_Leitor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salvarCarregamentoToolStripMenuItem,
            this.gerarChaveDeUsuárioToolStripMenuItem});
            this.menu_Leitor.Name = "menu_Leitor";
            this.menu_Leitor.Size = new System.Drawing.Size(166, 22);
            this.menu_Leitor.Text = "Leitor";
            // 
            // salvarCarregamentoToolStripMenuItem
            // 
            this.salvarCarregamentoToolStripMenuItem.Name = "salvarCarregamentoToolStripMenuItem";
            this.salvarCarregamentoToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.salvarCarregamentoToolStripMenuItem.Text = "Salvar carregamento";
            this.salvarCarregamentoToolStripMenuItem.Click += new System.EventHandler(this.salvarCarregamentoToolStripMenuItem_Click);
            // 
            // gerarChaveDeUsuárioToolStripMenuItem
            // 
            this.gerarChaveDeUsuárioToolStripMenuItem.Name = "gerarChaveDeUsuárioToolStripMenuItem";
            this.gerarChaveDeUsuárioToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.gerarChaveDeUsuárioToolStripMenuItem.Text = "Gerar chave de usuário";
            this.gerarChaveDeUsuárioToolStripMenuItem.Click += new System.EventHandler(this.gerarChaveDeUsuárioToolStripMenuItem_Click);
            // 
            // menu_CadastrarUsuario
            // 
            this.menu_CadastrarUsuario.Name = "menu_CadastrarUsuario";
            this.menu_CadastrarUsuario.Size = new System.Drawing.Size(166, 22);
            this.menu_CadastrarUsuario.Text = "Cadastrar usuário";
            this.menu_CadastrarUsuario.Click += new System.EventHandler(this.menu_CadastrarUsuario_Click);
            // 
            // menu_EditarUsuario
            // 
            this.menu_EditarUsuario.Name = "menu_EditarUsuario";
            this.menu_EditarUsuario.Size = new System.Drawing.Size(166, 22);
            this.menu_EditarUsuario.Text = "Editar usuário";
            this.menu_EditarUsuario.Click += new System.EventHandler(this.menu_EditarUsuario_Click);
            // 
            // menu_Sobre
            // 
            this.menu_Sobre.Name = "menu_Sobre";
            this.menu_Sobre.Size = new System.Drawing.Size(49, 20);
            this.menu_Sobre.Text = "Sobre";
            this.menu_Sobre.Click += new System.EventHandler(this.menu_Sobre_Click);
            // 
            // menu_Sair
            // 
            this.menu_Sair.Name = "menu_Sair";
            this.menu_Sair.Size = new System.Drawing.Size(38, 20);
            this.menu_Sair.Text = "Sair";
            this.menu_Sair.Click += new System.EventHandler(this.menu_Sair_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbl_User,
            this.lbl_Printer});
            this.statusStrip1.Location = new System.Drawing.Point(0, 389);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(714, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lbl_User
            // 
            this.lbl_User.Name = "lbl_User";
            this.lbl_User.Size = new System.Drawing.Size(215, 17);
            this.lbl_User.Text = "Nome: 1111111111 Tipo: Administrador";
            // 
            // lbl_Printer
            // 
            this.lbl_Printer.Name = "lbl_Printer";
            this.lbl_Printer.Size = new System.Drawing.Size(80, 17);
            this.lbl_Printer.Text = "IMPRESSORA:";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BackgroundImage = global::Traceability_Labels.Properties.Resources.logo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(714, 411);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rastreabilidade logística";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.Home_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Home_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menu_Produtos;
        private System.Windows.Forms.ToolStripMenuItem menu_CadastrarProduto;
        private System.Windows.Forms.ToolStripMenuItem menu_EditarProduto;
        private System.Windows.Forms.ToolStripMenuItem menu_ListarProdutos;
        private System.Windows.Forms.ToolStripMenuItem menu_Etiquetas;
        private System.Windows.Forms.ToolStripMenuItem menu_Configuracoes;
        private System.Windows.Forms.ToolStripMenuItem menu_Impressoras;
        private System.Windows.Forms.ToolStripMenuItem menu_Sobre;
        private System.Windows.Forms.ToolStripMenuItem menu_Sair;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lbl_Printer;
        public System.Windows.Forms.ToolStripStatusLabel lbl_User;
        private System.Windows.Forms.ToolStripMenuItem menu_CadastrarUsuario;
        private System.Windows.Forms.ToolStripMenuItem menu_EditarUsuario;
        private System.Windows.Forms.ToolStripMenuItem menu_ImprimirEtiquetas;
        private System.Windows.Forms.ToolStripMenuItem menu_GerarEtiquetas;
        private System.Windows.Forms.ToolStripMenuItem menu_Rastrear;
        private System.Windows.Forms.ToolStripMenuItem novoCarregamentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarCarregamentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu_Leitor;
        private System.Windows.Forms.ToolStripMenuItem salvarCarregamentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gerarChaveDeUsuárioToolStripMenuItem;
    }
}

