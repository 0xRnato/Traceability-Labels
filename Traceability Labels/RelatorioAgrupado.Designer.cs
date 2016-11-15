namespace Traceability_Labels
{
    partial class RelatorioAgrupado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RelatorioAgrupado));
            this.btn_Agrupado = new System.Windows.Forms.Button();
            this.btn_Separado = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Agrupado
            // 
            this.btn_Agrupado.Location = new System.Drawing.Point(115, 53);
            this.btn_Agrupado.Name = "btn_Agrupado";
            this.btn_Agrupado.Size = new System.Drawing.Size(75, 23);
            this.btn_Agrupado.TabIndex = 1;
            this.btn_Agrupado.Text = "Agrupado";
            this.btn_Agrupado.UseVisualStyleBackColor = true;
            this.btn_Agrupado.Click += new System.EventHandler(this.btn_Agrupado_Click);
            // 
            // btn_Separado
            // 
            this.btn_Separado.Location = new System.Drawing.Point(34, 53);
            this.btn_Separado.Name = "btn_Separado";
            this.btn_Separado.Size = new System.Drawing.Size(75, 23);
            this.btn_Separado.TabIndex = 0;
            this.btn_Separado.Text = "Separado";
            this.btn_Separado.UseVisualStyleBackColor = true;
            this.btn_Separado.Click += new System.EventHandler(this.btn_Separado_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(196, 53);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 2;
            this.btn_Cancel.Text = "Cancelar";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(299, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Deseja gerar o relatório separado ou agrupado?";
            // 
            // RelatorioAgrupado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(328, 87);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Separado);
            this.Controls.Add(this.btn_Agrupado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RelatorioAgrupado";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Atenção!";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Agrupado;
        private System.Windows.Forms.Button btn_Separado;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label label1;
    }
}