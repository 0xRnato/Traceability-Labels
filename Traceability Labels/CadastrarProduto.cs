using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Traceability_Labels
{
    public partial class CadastrarProduto : Form
    {
        SqlConnection connection;
        SqlCommand command;
        DataSet dataSet;

        public CadastrarProduto()
        {
            InitializeComponent();

            dataSet = new DataSet();
            connection = new SqlConnection(Global.connectionString);
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao conectar com o servidor: " + ex.Message, "ERRO!!!");
            }
            finally
            {
                connection.Close();
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                double embalagem, caixa;
                bool testEmbalagem = double.TryParse(txt_Embalagem.Text, out embalagem);
                if (!testEmbalagem)
                    throw new Exception("A tara da embalagem esta em um formato incorreto!");
                bool testCaixa = double.TryParse(txt_Caixa.Text, out caixa);
                if (!testCaixa)
                    throw new Exception("A tara da caixa esta em um formato incorreto!");

                command = new SqlCommand("insert into produto (nome,gtin,embalagem,caixa) values (@nome,@gtin,@embalagem,@caixa)", connection);
                command.Parameters.AddWithValue("@nome", txt_Nome.Text.ToString());
                command.Parameters.AddWithValue("@gtin", txt_GTIN.Text.ToString());
                command.Parameters.AddWithValue("@embalagem", embalagem.ToString());
                command.Parameters.AddWithValue("@caixa", caixa.ToString());
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Produto cadastrado com sucesso!");
                txt_Nome.Text = "";
                txt_GTIN.Text = "";
                txt_Embalagem.Text = "";
                txt_Caixa.Text = "";
                txt_Nome.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO!!!");
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
    }
}
