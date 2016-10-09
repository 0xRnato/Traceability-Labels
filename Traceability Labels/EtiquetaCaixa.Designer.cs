namespace Traceability_Labels
{
    partial class EtiquetaCaixa
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
            this.cbox_Produtos = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.datePick_Fabricacao = new System.Windows.Forms.DateTimePicker();
            this.datePick_Validade = new System.Windows.Forms.DateTimePicker();
            this.txt_Lote = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_Confirmar = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_Quantidade = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cbox_Produtos
            // 
            this.cbox_Produtos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_Produtos.FormattingEnabled = true;
            this.cbox_Produtos.Location = new System.Drawing.Point(90, 12);
            this.cbox_Produtos.Name = "cbox_Produtos";
            this.cbox_Produtos.Size = new System.Drawing.Size(302, 21);
            this.cbox_Produtos.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "PRODUTO:";
            // 
            // datePick_Fabricacao
            // 
            this.datePick_Fabricacao.CustomFormat = "dd/MM/yyyy";
            this.datePick_Fabricacao.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePick_Fabricacao.Location = new System.Drawing.Point(90, 39);
            this.datePick_Fabricacao.Name = "datePick_Fabricacao";
            this.datePick_Fabricacao.Size = new System.Drawing.Size(100, 20);
            this.datePick_Fabricacao.TabIndex = 3;
            // 
            // datePick_Validade
            // 
            this.datePick_Validade.CustomFormat = "dd/MM/yyyy";
            this.datePick_Validade.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePick_Validade.Location = new System.Drawing.Point(90, 65);
            this.datePick_Validade.Name = "datePick_Validade";
            this.datePick_Validade.Size = new System.Drawing.Size(100, 20);
            this.datePick_Validade.TabIndex = 4;
            // 
            // txt_Lote
            // 
            this.txt_Lote.Location = new System.Drawing.Point(292, 39);
            this.txt_Lote.MaxLength = 20;
            this.txt_Lote.Name = "txt_Lote";
            this.txt_Lote.Size = new System.Drawing.Size(100, 20);
            this.txt_Lote.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "FABRICAÇÃO:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "VALIDADE";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(251, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "LOTE";
            // 
            // btn_Confirmar
            // 
            this.btn_Confirmar.Location = new System.Drawing.Point(236, 91);
            this.btn_Confirmar.Name = "btn_Confirmar";
            this.btn_Confirmar.Size = new System.Drawing.Size(75, 23);
            this.btn_Confirmar.TabIndex = 8;
            this.btn_Confirmar.Text = "Confirmar";
            this.btn_Confirmar.UseVisualStyleBackColor = true;
            this.btn_Confirmar.Click += new System.EventHandler(this.btn_Confirmar_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(317, 91);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 9;
            this.btn_Cancel.Text = "Cancelar";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(205, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "QUANTIDADE:";
            // 
            // txt_Quantidade
            // 
            this.txt_Quantidade.Location = new System.Drawing.Point(292, 65);
            this.txt_Quantidade.Name = "txt_Quantidade";
            this.txt_Quantidade.Size = new System.Drawing.Size(100, 20);
            this.txt_Quantidade.TabIndex = 2;
            // 
            // EtiquetaCaixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(413, 126);
            this.Controls.Add(this.txt_Quantidade);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Confirmar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_Lote);
            this.Controls.Add(this.datePick_Validade);
            this.Controls.Add(this.datePick_Fabricacao);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbox_Produtos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EtiquetaCaixa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Etiqueta para caixas";
            this.Load += new System.EventHandler(this.EtiquetaCaixa_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbox_Produtos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker datePick_Fabricacao;
        private System.Windows.Forms.DateTimePicker datePick_Validade;
        private System.Windows.Forms.TextBox txt_Lote;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_Confirmar;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_Quantidade;
    }
}