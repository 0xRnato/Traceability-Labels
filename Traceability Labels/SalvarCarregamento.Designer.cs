namespace Traceability_Labels
{
    partial class SalvarCarregamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalvarCarregamento));
            this.btn_Abrir = new System.Windows.Forms.Button();
            this.dialog = new System.Windows.Forms.OpenFileDialog();
            this.tab_Main = new System.Windows.Forms.TabControl();
            this.page_Paletes = new System.Windows.Forms.TabPage();
            this.grid_Paletes = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.page_Caixas = new System.Windows.Forms.TabPage();
            this.grid_Caixas = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_Sync = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.tab_Main.SuspendLayout();
            this.page_Paletes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_Paletes)).BeginInit();
            this.page_Caixas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_Caixas)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Abrir
            // 
            resources.ApplyResources(this.btn_Abrir, "btn_Abrir");
            this.btn_Abrir.Name = "btn_Abrir";
            this.btn_Abrir.UseVisualStyleBackColor = true;
            this.btn_Abrir.Click += new System.EventHandler(this.btn_Abrir_Click);
            // 
            // dialog
            // 
            this.dialog.FileName = "dialog";
            // 
            // tab_Main
            // 
            this.tab_Main.Controls.Add(this.page_Paletes);
            this.tab_Main.Controls.Add(this.page_Caixas);
            resources.ApplyResources(this.tab_Main, "tab_Main");
            this.tab_Main.Name = "tab_Main";
            this.tab_Main.SelectedIndex = 0;
            // 
            // page_Paletes
            // 
            this.page_Paletes.Controls.Add(this.grid_Paletes);
            resources.ApplyResources(this.page_Paletes, "page_Paletes");
            this.page_Paletes.Name = "page_Paletes";
            this.page_Paletes.UseVisualStyleBackColor = true;
            // 
            // grid_Paletes
            // 
            this.grid_Paletes.AllowUserToAddRows = false;
            this.grid_Paletes.AllowUserToDeleteRows = false;
            this.grid_Paletes.AllowUserToOrderColumns = true;
            this.grid_Paletes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_Paletes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            resources.ApplyResources(this.grid_Paletes, "grid_Paletes");
            this.grid_Paletes.Name = "grid_Paletes";
            this.grid_Paletes.ReadOnly = true;
            // 
            // Column1
            // 
            resources.ApplyResources(this.Column1, "Column1");
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            resources.ApplyResources(this.Column2, "Column2");
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            resources.ApplyResources(this.Column3, "Column3");
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // page_Caixas
            // 
            this.page_Caixas.Controls.Add(this.grid_Caixas);
            resources.ApplyResources(this.page_Caixas, "page_Caixas");
            this.page_Caixas.Name = "page_Caixas";
            this.page_Caixas.UseVisualStyleBackColor = true;
            // 
            // grid_Caixas
            // 
            this.grid_Caixas.AllowUserToAddRows = false;
            this.grid_Caixas.AllowUserToDeleteRows = false;
            this.grid_Caixas.AllowUserToOrderColumns = true;
            this.grid_Caixas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_Caixas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column5,
            this.Column6});
            resources.ApplyResources(this.grid_Caixas, "grid_Caixas");
            this.grid_Caixas.Name = "grid_Caixas";
            this.grid_Caixas.ReadOnly = true;
            // 
            // Column4
            // 
            resources.ApplyResources(this.Column4, "Column4");
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            resources.ApplyResources(this.Column5, "Column5");
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            resources.ApplyResources(this.Column6, "Column6");
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // btn_Sync
            // 
            this.btn_Sync.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btn_Sync, "btn_Sync");
            this.btn_Sync.Name = "btn_Sync";
            this.btn_Sync.UseVisualStyleBackColor = true;
            this.btn_Sync.Click += new System.EventHandler(this.btn_Sync_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btn_Cancel, "btn_Cancel");
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // SalvarCarregamento
            // 
            this.AcceptButton = this.btn_Abrir;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.CancelButton = this.btn_Cancel;
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Sync);
            this.Controls.Add(this.tab_Main);
            this.Controls.Add(this.btn_Abrir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SalvarCarregamento";
            this.tab_Main.ResumeLayout(false);
            this.page_Paletes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_Paletes)).EndInit();
            this.page_Caixas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_Caixas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Abrir;
        private System.Windows.Forms.OpenFileDialog dialog;
        private System.Windows.Forms.TabControl tab_Main;
        private System.Windows.Forms.TabPage page_Paletes;
        private System.Windows.Forms.TabPage page_Caixas;
        private System.Windows.Forms.Button btn_Sync;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.DataGridView grid_Paletes;
        private System.Windows.Forms.DataGridView grid_Caixas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}