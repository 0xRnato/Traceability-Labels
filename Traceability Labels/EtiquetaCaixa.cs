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
    public partial class EtiquetaCaixa : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter;
        DataSet dataSet;
        DataTable table;
        SqlDataReader reader;

        public EtiquetaCaixa()
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
                MessageBox.Show("Erro ao se conectar com o servidor: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void EtiquetaCaixa_Load(object sender, EventArgs e)
        {
            try
            {
                cbox_Produtos.Items.Clear();
                command = new SqlCommand("select id,nome from produto", connection);
                adapter = new SqlDataAdapter(command);
                table = new DataTable();
                adapter.Fill(table);
                cbox_Produtos.DataSource = table;
                cbox_Produtos.DisplayMember = table.Columns[1].ToString();
                cbox_Produtos.ValueMember = table.Columns[0].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "ERRO!");
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void btn_Confirmar_Click(object sender, EventArgs e)
        {
            string cod1 = "", cod2 = "", cod3 = "";
            string gtin = "", fabricacao, validade, registroProcessador, sscc;
            
            fabricacao = string.Format("{0:yy/MM/dd}", datePick_Fabricacao.Value);
            validade = string.Format("{0:yy/MM/dd}", datePick_Validade.Value);
            registroProcessador = Global.regProcessadorGlobal;
            sscc = Global.NextSSCC("CAIXA");

            try
            {
                command = new SqlCommand("select gtin from produto where id=@id", connection);
                command.Parameters.AddWithValue("@id", cbox_Produtos.SelectedValue);
                connection.Open();
                reader = command.ExecuteReader();
                while(reader.Read())
                {
                    gtin = reader.GetString(0);
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }

            cod1 += "(01)" + gtin;
            cod1 += "(15)" + validade.Replace("/", "");
            cod1 += "(11)" + fabricacao.Replace("/", "");
            cod2 += "(7030)" + registroProcessador;
            cod2 += "(10)" + txt_Lote.Text;
            cod3 += "(00)" + sscc;
        }
    }
}
