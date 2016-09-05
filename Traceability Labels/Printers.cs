using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace Traceability_Labels
{
    public partial class Printers : Form
    {
        public Printers()
        {
            InitializeComponent();
        }

        private void Printers_Load(object sender, EventArgs e)
        {
            foreach (var printer in PrinterSettings.InstalledPrinters)
            {
                var item = printer;
                cbox_Printers.Items.Add(item);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            Global.printerName = cbox_Printers.SelectedItem.ToString();
            MessageBox.Show("Impressora selecionada com sucesso!");
            Hide();
        }
    }
}
