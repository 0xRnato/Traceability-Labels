namespace Traceability_Labels
{
    partial class CadastrarProduto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CadastrarProduto));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Nome = new System.Windows.Forms.TextBox();
            this.txt_GTIN = new System.Windows.Forms.TextBox();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Embalagem = new System.Windows.Forms.TextBox();
            this.txt_Caixa = new System.Windows.Forms.TextBox();
            this.txt_Validade = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "NOME:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(80, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "GTIN:";
            // 
            // txt_Nome
            // 
            this.txt_Nome.Location = new System.Drawing.Point(122, 12);
            this.txt_Nome.MaxLength = 17;
            this.txt_Nome.Name = "txt_Nome";
            this.txt_Nome.Size = new System.Drawing.Size(156, 20);
            this.txt_Nome.TabIndex = 1;
            // 
            // txt_GTIN
            // 
            this.txt_GTIN.Location = new System.Drawing.Point(122, 38);
            this.txt_GTIN.MaxLength = 14;
            this.txt_GTIN.Name = "txt_GTIN";
            this.txt_GTIN.Size = new System.Drawing.Size(156, 20);
            this.txt_GTIN.TabIndex = 2;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(203, 142);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 7;
            this.btn_Cancel.Text = "Cancelar";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(122, 142);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 6;
            this.btn_Save.Text = "Salvar";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "TARA DA EMBALAGEM:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(81, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "TARA DA CAIXA:";
            // 
            // txt_Embalagem
            // 
            this.txt_Embalagem.Location = new System.Drawing.Point(178, 64);
            this.txt_Embalagem.MaxLength = 5;
            this.txt_Embalagem.Name = "txt_Embalagem";
            this.txt_Embalagem.Size = new System.Drawing.Size(100, 20);
            this.txt_Embalagem.TabIndex = 3;
            // 
            // txt_Caixa
            // 
            this.txt_Caixa.Location = new System.Drawing.Point(178, 90);
            this.txt_Caixa.MaxLength = 5;
            this.txt_Caixa.Name = "txt_Caixa";
            this.txt_Caixa.Size = new System.Drawing.Size(100, 20);
            this.txt_Caixa.TabIndex = 4;
            // 
            // txt_Validade
            // 
            this.txt_Validade.Location = new System.Drawing.Point(178, 116);
            this.txt_Validade.MaxLength = 3;
            this.txt_Validade.Name = "txt_Validade";
            this.txt_Validade.Size = new System.Drawing.Size(100, 20);
            this.txt_Validade.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(110, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "VIDA ÚTIL:";
            // 
            // CadastrarProduto
            // 
            this.AcceptButton = this.btn_Save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(356, 188);
            this.ControlBox = false;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_Validade);
            this.Controls.Add(this.txt_Caixa);
            this.Controls.Add(this.txt_Embalagem);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.txt_GTIN);
            this.Controls.Add(this.txt_Nome);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CadastrarProduto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastrar Produto";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Nome;
        private System.Windows.Forms.TextBox txt_GTIN;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Embalagem;
        private System.Windows.Forms.TextBox txt_Caixa;
        private System.Windows.Forms.TextBox txt_Validade;
        private System.Windows.Forms.Label label5;
    }
}