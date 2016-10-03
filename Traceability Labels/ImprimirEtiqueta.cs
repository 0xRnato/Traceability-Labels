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
    public partial class ImprimirEtiqueta : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter;
        DataSet dataSet;
        DataTable table;
        SqlDataReader reader;
        bool flag;

        public ImprimirEtiqueta()
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
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
                flag = false;
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ImprimirEtiqueta_Load(object sender, EventArgs e)
        {
            if (!Global.adm)
                btn_2Via.Enabled = false;

            cbox_Carregamentos.Items.Clear();
            command = new SqlCommand("select id,codigo from carregamento", connection);
            adapter = new SqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);
            cbox_Carregamentos.DataSource = table;
            cbox_Carregamentos.DisplayMember = table.Columns[1].ToString();
            cbox_Carregamentos.ValueMember = table.Columns[0].ToString();
            cbox_Carregamentos.SelectedIndex = -1;
            if (connection.State == ConnectionState.Open)
                connection.Close();
            flag = true;
        }

        private void cbox_Carregamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag)
            {
                command = new SqlCommand("select palete.id,produto.nome from palete join caixasPalete on palete.id = caixasPalete.palete_id join caixa on caixa.id = caixasPalete.caixa_id join produto on produto.id = caixa.produto_id where palete.carregamento_id=@carregamento_id group by palete.id, produto.nome", connection);
                command.Parameters.AddWithValue("@carregamento_id", cbox_Carregamentos.SelectedValue);

                connection.Open();
                reader = command.ExecuteReader();
                lbox_Paletes.Items.Clear();
                while (reader.Read())
                {
                    var item = reader.GetValue(0).ToString() + " - " + reader.GetValue(1).ToString();
                    lbox_Paletes.Items.Add(item);
                }
                reader.Close();
                connection.Close();
                if (cbox_Carregamentos.SelectedIndex != -1)
                    btn_Done.Enabled = true;
            }
        }

        private void lbox_Paletes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag && lbox_Paletes.SelectedItem != null)
            {
                string[] tmp = lbox_Paletes.SelectedItem.ToString().Split('-');
                lbox_Caixas.Items.Clear();

                command = new SqlCommand("select c.id,c.sscc from caixa c join caixasPalete cp on cp.caixa_id=c.id where cp.palete_id=@palete_id", connection);
                command.Parameters.AddWithValue("@palete_id", tmp[0].ToString());

                connection.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var item = reader.GetValue(0).ToString() + " - " + reader.GetValue(1).ToString();
                    lbox_Caixas.Items.Add(item);
                }
                reader.Close();
                connection.Close();
            }
        }

        private void btn_2Via_Click(object sender, EventArgs e)
        {
            if (lbox_Paletes.SelectedIndex >= 0 || lbox_Caixas.SelectedIndex >= 0)
            {
                DialogResult result = MessageBox.Show("Para imprimir o palete selecionado, clique em: SIM\nPara imprimir a caixa selecionada, clique em: NÃO\nPara cancelar, clique em: CANCELAR.", "Atenção!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string cod1 = "", cod2 = "", cod3 = "", gtin = "", nome = "", fabricacao = "", validade = "", registroProcessador = "", sscc = "", lote = "";
                    decimal embalagem = 0, caixa = 0, palete = 0, stretch = 0, cantoneira = 0;
                    int quantidade = 0, palete_id = 0;
                    string[] tmp = lbox_Paletes.SelectedItem.ToString().Split('-');

                    command = new SqlCommand("select p.cod1, p.cod2, p.cod3, p.sscc, p.palete, p.stretch, p.cantoneira, p.quantidade, pr.gtin, cx.fabricacao, cx.validade, cx.registroProcessador, cx.lote, pr.nome, pr.embalagem, pr.caixa, p.id from palete p join caixasPalete cp on p.id = cp.palete_id join caixa cx on cx.id = cp.caixa_id join produto pr on pr.id = cx.produto_id where p.id = @palete_id group by p.id, p.cod1, p.cod2, p.cod3, p.sscc, p.palete, p.stretch, p.cantoneira, p.quantidade, pr.gtin, cx.fabricacao, cx.validade, cx.registroProcessador, cx.lote, pr.nome, pr.embalagem, pr.caixa", connection);
                    command.Parameters.AddWithValue("@palete_id", tmp[0]);

                    connection.Open();
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        cod1 = reader.GetValue(0).ToString();
                        cod2 = reader.GetValue(1).ToString();
                        cod3 = reader.GetValue(2).ToString();
                        sscc = reader.GetValue(3).ToString();
                        palete = Convert.ToDecimal(reader.GetValue(4));
                        stretch = Convert.ToDecimal(reader.GetValue(5));
                        cantoneira = Convert.ToDecimal(reader.GetValue(6));
                        quantidade = Convert.ToInt32(reader.GetValue(7));
                        gtin = reader.GetValue(8).ToString();
                        fabricacao = reader.GetValue(9).ToString();
                        validade = reader.GetValue(10).ToString();
                        registroProcessador = reader.GetValue(11).ToString();
                        lote = reader.GetValue(12).ToString();
                        nome = reader.GetValue(13).ToString();
                        embalagem = Convert.ToDecimal(reader.GetValue(14));
                        caixa = Convert.ToDecimal(reader.GetValue(15));
                        palete_id = Convert.ToInt32(reader.GetValue(16));
                    }
                    reader.Close();
                    connection.Close();

                    PrintLabel.Palete(gtin, fabricacao, validade, lote, nome, registroProcessador, sscc, (embalagem * quantidade).ToString(), (caixa * quantidade).ToString(), palete.ToString(), stretch.ToString(), cantoneira.ToString(), cod1.ToString(), cod2.ToString(), cod3.ToString(), quantidade.ToString(), true);
                }
                else if (result == DialogResult.No)
                {
                    string cod1 = "", cod2 = "", cod3 = "", gtin = "", nome = "", fabricacao = "", validade = "", registroProcessador = "", sscc = "", lote = "";
                    decimal embalagem = 0, caixa = 0, palete = 0, stretch = 0, cantoneira = 0;
                    int quantidade = 0, palete_id = 0;
                    string[] tmp = lbox_Paletes.SelectedItem.ToString().Split('-');

                    command = new SqlCommand("select p.cod1, p.cod2, p.cod3, p.sscc, p.palete, p.stretch, p.cantoneira, p.quantidade, pr.gtin, cx.fabricacao, cx.validade, cx.registroProcessador, cx.lote, pr.nome, pr.embalagem, pr.caixa, p.id from palete p join caixasPalete cp on p.id = cp.palete_id join caixa cx on cx.id = cp.caixa_id join produto pr on pr.id = cx.produto_id where p.id = @palete_id group by p.id, p.cod1, p.cod2, p.cod3, p.sscc, p.palete, p.stretch, p.cantoneira, p.quantidade, pr.gtin, cx.fabricacao, cx.validade, cx.registroProcessador, cx.lote, pr.nome, pr.embalagem, pr.caixa", connection);
                    command.Parameters.AddWithValue("@palete_id", tmp[0]);

                    connection.Open();
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        cod1 = reader.GetValue(0).ToString();
                        cod2 = reader.GetValue(1).ToString();
                        cod3 = reader.GetValue(2).ToString();
                        sscc = reader.GetValue(3).ToString();
                        palete = Convert.ToDecimal(reader.GetValue(4));
                        stretch = Convert.ToDecimal(reader.GetValue(5));
                        cantoneira = Convert.ToDecimal(reader.GetValue(6));
                        quantidade = Convert.ToInt32(reader.GetValue(7));
                        gtin = reader.GetValue(8).ToString();
                        fabricacao = reader.GetValue(9).ToString();
                        validade = reader.GetValue(10).ToString();
                        registroProcessador = reader.GetValue(11).ToString();
                        lote = reader.GetValue(12).ToString();
                        nome = reader.GetValue(13).ToString();
                        embalagem = Convert.ToDecimal(reader.GetValue(14));
                        caixa = Convert.ToDecimal(reader.GetValue(15));
                        palete_id = Convert.ToInt32(reader.GetValue(16));
                    }
                    reader.Close();
                    connection.Close();

                    cod1 = "";
                    cod2 = "";
                    cod3 = "";
                    sscc = "";

                    command = new SqlCommand("select cx.cod1, cx.cod2, cx.cod3, cx.sscc from caixa cx join caixasPalete cp on cx.id=cp.caixa_id join palete p on p.id=cp.palete_id where p.id=@palete_id", connection);
                    command.Parameters.AddWithValue("@palete_id", palete_id);

                    connection.Open();
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        cod1 = reader.GetValue(0).ToString();
                        cod2 = reader.GetValue(1).ToString();
                        cod3 = reader.GetValue(2).ToString();
                        sscc = reader.GetValue(3).ToString();
                    }
                    reader.Close();
                    connection.Close();

                    PrintLabel.Caixa(gtin, fabricacao, validade, lote.ToString(), nome, registroProcessador, sscc, embalagem.ToString(), caixa.ToString(), cod1, cod2, cod3, true);
                }
            }
            else
                MessageBox.Show("Selecione um palete ou caixa para gerar uma 2ª via.", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btn_Done_Click(object sender, EventArgs e)
        {
            if (cbox_Carregamentos.SelectedItem != null)
            {
                if (lbox_Paletes.SelectedIndex >= 0)
                    lbox_Paletes.SelectedIndex = -1;

                //PALETE
                for (int i = 0; i < lbox_Paletes.Items.Count; i++)
                {
                    lbox_Paletes.SelectedIndex++;

                    string cod1 = "", cod2 = "", cod3 = "", gtin = "", nome = "", fabricacao = "", validade = "", registroProcessador = "", sscc = "", lote = "";
                    decimal embalagem = 0, caixa = 0, palete = 0, stretch = 0, cantoneira = 0;
                    int quantidade = 0, palete_id = 0;
                    string[] tmp = lbox_Paletes.SelectedItem.ToString().Split('-');

                    command = new SqlCommand("select p.cod1, p.cod2, p.cod3, p.sscc, p.palete, p.stretch, p.cantoneira, p.quantidade, pr.gtin, cx.fabricacao, cx.validade, cx.registroProcessador, cx.lote, pr.nome, pr.embalagem, pr.caixa, p.id from palete p join caixasPalete cp on p.id = cp.palete_id join caixa cx on cx.id = cp.caixa_id join produto pr on pr.id = cx.produto_id where p.id = @palete_id group by p.id, p.cod1, p.cod2, p.cod3, p.sscc, p.palete, p.stretch, p.cantoneira, p.quantidade, pr.gtin, cx.fabricacao, cx.validade, cx.registroProcessador, cx.lote, pr.nome, pr.embalagem, pr.caixa", connection);
                    command.Parameters.AddWithValue("@palete_id", tmp[0]);

                    connection.Open();
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        cod1 = reader.GetValue(0).ToString();
                        cod2 = reader.GetValue(1).ToString();
                        cod3 = reader.GetValue(2).ToString();
                        sscc = reader.GetValue(3).ToString();
                        palete = Convert.ToDecimal(reader.GetValue(4));
                        stretch = Convert.ToDecimal(reader.GetValue(5));
                        cantoneira = Convert.ToDecimal(reader.GetValue(6));
                        quantidade = Convert.ToInt32(reader.GetValue(7));
                        gtin = reader.GetValue(8).ToString();
                        fabricacao = reader.GetValue(9).ToString();
                        validade = reader.GetValue(10).ToString();
                        registroProcessador = reader.GetValue(11).ToString();
                        lote = reader.GetValue(12).ToString();
                        nome = reader.GetValue(13).ToString();
                        embalagem = Convert.ToDecimal(reader.GetValue(14));
                        caixa = Convert.ToDecimal(reader.GetValue(15));
                        palete_id = Convert.ToInt32(reader.GetValue(16));
                    }
                    reader.Close();
                    connection.Close();

                    PrintLabel.Palete(gtin, fabricacao, validade, lote, nome, registroProcessador, sscc, (embalagem * quantidade).ToString(), (caixa * quantidade).ToString(), palete.ToString(), stretch.ToString(), cantoneira.ToString(), cod1.ToString(), cod2.ToString(), cod3.ToString(), quantidade.ToString(), false);

                    //CAIXAS
                    for (int j = 0; j < quantidade; j++)
                    {
                        cod1 = "";
                        cod2 = "";
                        cod3 = "";
                        sscc = "";

                        command = new SqlCommand("select cx.cod1, cx.cod2, cx.cod3, cx.sscc from caixa cx join caixasPalete cp on cx.id=cp.caixa_id join palete p on p.id=cp.palete_id where p.id=@palete_id", connection);
                        command.Parameters.AddWithValue("@palete_id", palete_id);

                        connection.Open();
                        reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            cod1 = reader.GetValue(0).ToString();
                            cod2 = reader.GetValue(1).ToString();
                            cod3 = reader.GetValue(2).ToString();
                            sscc = reader.GetValue(3).ToString();
                        }
                        reader.Close();
                        connection.Close();

                        PrintLabel.Caixa(gtin, fabricacao, validade, lote.ToString(), nome, registroProcessador, sscc, embalagem.ToString(), caixa.ToString(), cod1, cod2, cod3, false);
                    }
                }
                MessageBox.Show("Fim do processo!!");
            }
        }
    }
}
