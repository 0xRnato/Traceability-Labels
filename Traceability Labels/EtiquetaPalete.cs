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
    public partial class EtiquetaPalete : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter;
        DataSet dataSet;
        DataTable table;
        SqlDataReader reader;

        public EtiquetaPalete()
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

        private void EtiquetaPalete_Load(object sender, EventArgs e)
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
            Close();
        }

        private void btn_Confirmar_Click(object sender, EventArgs e)
        {
            try
            {
                string cod1 = "", cod2 = "", cod3 = "";
                string gtin = "", produto = "", fabricacao, validade, registroProcessador, sscc, embalagem = "", caixa = "";
                double palete, strech, cantoneira;

                bool testPalete = double.TryParse(txt_Palete.Text, out palete);
                if (!testPalete)
                    throw new Exception("A tara do palete esta em um formato incorreto!");
                bool testStrech = double.TryParse(txt_Strech.Text, out strech);
                if (!testStrech)
                    throw new Exception("A tara do strech esta em um formato incorreto!");
                bool testCantoneira = double.TryParse(txt_Cantoneira.Text, out cantoneira);
                if (!testCantoneira)
                    throw new Exception("A tara da cantoneira esta em um formato incorreto!");
                
                fabricacao = string.Format("{0:yy/MM/dd}", datePick_Fabricacao.Value);
                validade = string.Format("{0:yy/MM/dd}", datePick_Validade.Value);
                registroProcessador = Global.regProcessadorGlobal;
                sscc = Global.NextSSCC("PALETE");

                command = new SqlCommand("select gtin,nome,embalagem,caixa from produto where id=@id", connection);
                command.Parameters.AddWithValue("@id", cbox_Produtos.SelectedValue);
                connection.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    gtin = reader.GetString(0);
                    produto = reader.GetString(1);
                    embalagem = reader.GetDecimal(2).ToString();
                    caixa = reader.GetDecimal(3).ToString();
                }
                reader.Close();
                connection.Close();

                cod1 = "02" + gtin + "15" + validade.Replace("/", "") + "11" + fabricacao.Replace("/", "") + "37" + txt_Quantidade.Text;
                cod2 = "7030" + registroProcessador + "10" + txt_Lote.Text;
                cod3 = "00" + sscc;

                PrintLabel.Palete(gtin, fabricacao, validade, txt_Lote.Text, produto, registroProcessador, sscc, embalagem, caixa, palete.ToString(), strech.ToString(), cantoneira.ToString(), cod1, cod2, cod3, txt_Quantidade.Text,false);
                MessageBox.Show("Processo finalizado!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
                Hide();
            }
        }
    }
}
