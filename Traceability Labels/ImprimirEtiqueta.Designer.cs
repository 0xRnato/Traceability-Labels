namespace Traceability_Labels
{
    partial class ImprimirEtiqueta
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbox_Carregamentos = new System.Windows.Forms.ComboBox();
            this.lbox_Paletes = new System.Windows.Forms.ListBox();
            this.lbox_Caixas = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Done = new System.Windows.Forms.Button();
            this.btn_2Via = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "CARREGAMENTOS:";
            // 
            // cbox_Carregamentos
            // 
            this.cbox_Carregamentos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_Carregamentos.FormattingEnabled = true;
            this.cbox_Carregamentos.Location = new System.Drawing.Point(127, 12);
            this.cbox_Carregamentos.Name = "cbox_Carregamentos";
            this.cbox_Carregamentos.Size = new System.Drawing.Size(278, 21);
            this.cbox_Carregamentos.TabIndex = 1;
            this.cbox_Carregamentos.SelectedIndexChanged += new System.EventHandler(this.cbox_Carregamentos_SelectedIndexChanged);
            // 
            // lbox_Paletes
            // 
            this.lbox_Paletes.FormattingEnabled = true;
            this.lbox_Paletes.Location = new System.Drawing.Point(16, 72);
            this.lbox_Paletes.Name = "lbox_Paletes";
            this.lbox_Paletes.Size = new System.Drawing.Size(180, 264);
            this.lbox_Paletes.TabIndex = 2;
            this.lbox_Paletes.SelectedIndexChanged += new System.EventHandler(this.lbox_Paletes_SelectedIndexChanged);
            // 
            // lbox_Caixas
            // 
            this.lbox_Caixas.FormattingEnabled = true;
            this.lbox_Caixas.Location = new System.Drawing.Point(202, 72);
            this.lbox_Caixas.Name = "lbox_Caixas";
            this.lbox_Caixas.Size = new System.Drawing.Size(203, 264);
            this.lbox_Caixas.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "PALETES:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(202, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "CAIXAS:";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(300, 342);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(102, 23);
            this.btn_Cancel.TabIndex = 25;
            this.btn_Cancel.Text = "CANCELAR";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Done
            // 
            this.btn_Done.Enabled = false;
            this.btn_Done.Location = new System.Drawing.Point(192, 342);
            this.btn_Done.Name = "btn_Done";
            this.btn_Done.Size = new System.Drawing.Size(102, 23);
            this.btn_Done.TabIndex = 24;
            this.btn_Done.Text = "FINALIZAR";
            this.btn_Done.UseVisualStyleBackColor = true;
            this.btn_Done.Click += new System.EventHandler(this.btn_Done_Click);
            // 
            // btn_2Via
            // 
            this.btn_2Via.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_2Via.Location = new System.Drawing.Point(84, 342);
            this.btn_2Via.Name = "btn_2Via";
            this.btn_2Via.Size = new System.Drawing.Size(102, 23);
            this.btn_2Via.TabIndex = 26;
            this.btn_2Via.Text = "2ª Via";
            this.btn_2Via.UseVisualStyleBackColor = true;
            this.btn_2Via.Click += new System.EventHandler(this.btn_2Via_Click);
            // 
            // ImprimirEtiqueta
            // 
            this.AcceptButton = this.btn_Done;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(420, 372);
            this.ControlBox = false;
            this.Controls.Add(this.btn_2Via);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Done);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbox_Caixas);
            this.Controls.Add(this.lbox_Paletes);
            this.Controls.Add(this.cbox_Carregamentos);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImprimirEtiqueta";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Imprimi etiqueta";
            this.Load += new System.EventHandler(this.ImprimirEtiqueta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbox_Carregamentos;
        private System.Windows.Forms.ListBox lbox_Paletes;
        private System.Windows.Forms.ListBox lbox_Caixas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Done;
        private System.Windows.Forms.Button btn_2Via;
    }
}