using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Traceability_Labels
{
    public partial class RelatorioAgrupado : Form
    {
        public RelatorioAgrupado()
        {
            InitializeComponent();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Agrupado_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        private void btn_Separado_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }
    }
}
