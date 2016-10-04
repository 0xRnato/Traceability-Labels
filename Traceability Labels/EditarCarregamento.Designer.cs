namespace Traceability_Labels
{
    partial class EditarCarregamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditarCarregamento));
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.gbox_ProdutosAdd = new System.Windows.Forms.GroupBox();
            this.lbox_Paletes = new System.Windows.Forms.ListBox();
            this.gbox_Carregamento = new System.Windows.Forms.GroupBox();
            this.btn_Deletar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.rbtn_Conferido = new System.Windows.Forms.RadioButton();
            this.rbtn_Impresso = new System.Windows.Forms.RadioButton();
            this.cbox_Carregamento = new System.Windows.Forms.ComboBox();
            this.rbtn_Gerado = new System.Windows.Forms.RadioButton();
            this.gbox_ProdutosAdd.SuspendLayout();
            this.gbox_Carregamento.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btn_Cancel, "btn_Cancel");
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // gbox_ProdutosAdd
            // 
            this.gbox_ProdutosAdd.Controls.Add(this.lbox_Paletes);
            resources.ApplyResources(this.gbox_ProdutosAdd, "gbox_ProdutosAdd");
            this.gbox_ProdutosAdd.Name = "gbox_ProdutosAdd";
            this.gbox_ProdutosAdd.TabStop = false;
            // 
            // lbox_Paletes
            // 
            resources.ApplyResources(this.lbox_Paletes, "lbox_Paletes");
            this.lbox_Paletes.FormattingEnabled = true;
            this.lbox_Paletes.Name = "lbox_Paletes";
            // 
            // gbox_Carregamento
            // 
            this.gbox_Carregamento.Controls.Add(this.btn_Deletar);
            this.gbox_Carregamento.Controls.Add(this.label1);
            this.gbox_Carregamento.Controls.Add(this.rbtn_Conferido);
            this.gbox_Carregamento.Controls.Add(this.rbtn_Impresso);
            this.gbox_Carregamento.Controls.Add(this.cbox_Carregamento);
            this.gbox_Carregamento.Controls.Add(this.rbtn_Gerado);
            resources.ApplyResources(this.gbox_Carregamento, "gbox_Carregamento");
            this.gbox_Carregamento.Name = "gbox_Carregamento";
            this.gbox_Carregamento.TabStop = false;
            // 
            // btn_Deletar
            // 
            resources.ApplyResources(this.btn_Deletar, "btn_Deletar");
            this.btn_Deletar.Name = "btn_Deletar";
            this.btn_Deletar.UseVisualStyleBackColor = true;
            this.btn_Deletar.Click += new System.EventHandler(this.btn_Deletar_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // rbtn_Conferido
            // 
            resources.ApplyResources(this.rbtn_Conferido, "rbtn_Conferido");
            this.rbtn_Conferido.Name = "rbtn_Conferido";
            this.rbtn_Conferido.TabStop = true;
            this.rbtn_Conferido.UseVisualStyleBackColor = true;
            this.rbtn_Conferido.CheckedChanged += new System.EventHandler(this.rbtn_Conferido_CheckedChanged);
            // 
            // rbtn_Impresso
            // 
            resources.ApplyResources(this.rbtn_Impresso, "rbtn_Impresso");
            this.rbtn_Impresso.Name = "rbtn_Impresso";
            this.rbtn_Impresso.TabStop = true;
            this.rbtn_Impresso.UseVisualStyleBackColor = true;
            this.rbtn_Impresso.CheckedChanged += new System.EventHandler(this.rbtn_Impresso_CheckedChanged);
            // 
            // cbox_Carregamento
            // 
            this.cbox_Carregamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_Carregamento.FormattingEnabled = true;
            resources.ApplyResources(this.cbox_Carregamento, "cbox_Carregamento");
            this.cbox_Carregamento.Name = "cbox_Carregamento";
            this.cbox_Carregamento.SelectedIndexChanged += new System.EventHandler(this.cbox_Carregamento_SelectedIndexChanged);
            // 
            // rbtn_Gerado
            // 
            resources.ApplyResources(this.rbtn_Gerado, "rbtn_Gerado");
            this.rbtn_Gerado.Name = "rbtn_Gerado";
            this.rbtn_Gerado.TabStop = true;
            this.rbtn_Gerado.UseVisualStyleBackColor = true;
            this.rbtn_Gerado.CheckedChanged += new System.EventHandler(this.rbtn_Gerado_CheckedChanged);
            // 
            // EditarCarregamento
            // 
            this.AcceptButton = this.btn_Deletar;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.ControlBox = false;
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.gbox_ProdutosAdd);
            this.Controls.Add(this.gbox_Carregamento);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditarCarregamento";
            this.ShowIcon = false;
            this.gbox_ProdutosAdd.ResumeLayout(false);
            this.gbox_Carregamento.ResumeLayout(false);
            this.gbox_Carregamento.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.GroupBox gbox_ProdutosAdd;
        private System.Windows.Forms.ListBox lbox_Paletes;
        private System.Windows.Forms.GroupBox gbox_Carregamento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbtn_Conferido;
        private System.Windows.Forms.RadioButton rbtn_Impresso;
        private System.Windows.Forms.ComboBox cbox_Carregamento;
        private System.Windows.Forms.RadioButton rbtn_Gerado;
        private System.Windows.Forms.Button btn_Deletar;
    }
}