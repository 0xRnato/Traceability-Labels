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
        SqlDataAdapter adapter;
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
                command = new SqlCommand("insert into produto (nome,gtin) values (@nome,@gtin)", connection);
                command.Parameters.AddWithValue("@nome", txt_Nome.Text.ToString());
                command.Parameters.AddWithValue("@gtin", txt_GTIN.Text.ToString());
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Produto cadastrado com sucesso!");
                txt_Nome.Text = "";
                txt_GTIN.Text = "";
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
