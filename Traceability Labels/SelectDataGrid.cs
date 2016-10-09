using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Traceability_Labels
{
    public partial class SelectDataGrid : Form
    {
        public SelectDataGrid()
        {
            InitializeComponent();
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Imprimir_Click(object sender, EventArgs e)
        {
            if (lbox_Itens.SelectedIndex < 0)
                MessageBox.Show("Selecione uma opção.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                if (lbox_Itens.SelectedIndex == 0)
                    DialogResult = DialogResult.OK;
                else if (lbox_Itens.SelectedIndex == 1)
                    DialogResult = DialogResult.Yes;
                else if (lbox_Itens.SelectedIndex == 2)
                    DialogResult = DialogResult.Retry;
                else
                    DialogResult = DialogResult.Cancel;
            }
        }
    }
}
