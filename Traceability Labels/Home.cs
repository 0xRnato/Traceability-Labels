using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Traceability_Labels
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void cadastrarProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastrarProduto form = new CadastrarProduto();
            form.ShowDialog();
        }

        private void deletarProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeletarProduto form = new DeletarProduto();
            form.ShowDialog();
        }

        private void listarProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListarProduto form = new ListarProduto();
            form.ShowDialog();
        }

        private void listaDeSSCCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListarSSCC form = new ListarSSCC();
            form.ShowDialog();
        }

        private void caixaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EtiquetaCaixa form = new EtiquetaCaixa();
            form.ShowDialog();
        }

        private void paleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EtiquetaPalete form = new EtiquetaPalete();
            form.ShowDialog();
        }
    }

    class Global
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=logistica;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    }
}
