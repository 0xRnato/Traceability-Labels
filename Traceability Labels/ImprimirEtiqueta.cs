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
        SqlConnection connection2;
        SqlCommand command2;
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
            connection2 = new SqlConnection(Global.connectionString);
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
            {
                rbtn_Conferido.Enabled = false;
                rbtn_Impresso.Enabled = false;
                btn_2Via.Enabled = false;
            }
        }

        private void cbox_Carregamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag && cbox_Carregamentos.SelectedIndex >= 0)
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

                if (lbox_Paletes.Items.Count > 0)
                    btn_Done.Enabled = true;
                else
                    btn_Done.Enabled = false;
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

                    command = new SqlCommand("update palete set estagio=1, userImpresso=@user,dataImpresso=@data where id=@id", connection);
                    command.Parameters.AddWithValue("@id", palete_id);
                    command.Parameters.AddWithValue("@user", Global.user);
                    command.Parameters.AddWithValue("@data", DateTime.Today);
                    connection.Open();
                    command.ExecuteNonQuery();
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
                    int caixa_id = 0;

                    command = new SqlCommand("select cx.id, cx.cod1, cx.cod2, cx.cod3, cx.sscc from caixa cx join caixasPalete cp on cx.id=cp.caixa_id join palete p on p.id=cp.palete_id where p.id=@palete_id", connection);
                    command.Parameters.AddWithValue("@palete_id", palete_id);

                    connection.Open();
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        caixa_id = reader.GetInt32(0);
                        cod1 = reader.GetValue(1).ToString();
                        cod2 = reader.GetValue(2).ToString();
                        cod3 = reader.GetValue(3).ToString();
                        sscc = reader.GetValue(4).ToString();
                    }
                    reader.Close();
                    connection.Close();

                    command = new SqlCommand("update cx set cx.estagio=1 ,cx.dataImpresso=@data, cx.userImpresso=@user from caixa cx join caixasPalete cp on cp.caixa_id=cx.id where cx.id=@id", connection);
                    command.Parameters.AddWithValue("@id", caixa_id);
                    command.Parameters.AddWithValue("@user", Global.user);
                    command.Parameters.AddWithValue("@data", DateTime.Today);
                    connection.Open();
                    command.ExecuteNonQuery();
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

                        PrintLabel.Palete(gtin, fabricacao, validade, lote, nome, registroProcessador, sscc, (embalagem * quantidade).ToString(), (caixa * quantidade).ToString(), palete.ToString(), stretch.ToString(), cantoneira.ToString(), cod1.ToString(), cod2.ToString(), cod3.ToString(), quantidade.ToString(), false);
                    }
                    reader.Close();
                    connection.Close();

                    command = new SqlCommand("update palete set estagio=1, dataImpresso=@data,userImpresso=@user where id=@id", connection);
                    command.Parameters.AddWithValue("@id", palete_id);
                    command.Parameters.AddWithValue("@user", Global.user);
                    command.Parameters.AddWithValue("@data", DateTime.Today);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    //CAIXAS

                    cod1 = "";
                    cod2 = "";
                    cod3 = "";
                    sscc = "";
                    int caixa_id = 0;

                    command = new SqlCommand("select cx.id, cx.cod1, cx.cod2, cx.cod3, cx.sscc from caixa cx join caixasPalete cp on cx.id=cp.caixa_id join palete p on p.id=cp.palete_id where p.id=@palete_id", connection);
                    command.Parameters.AddWithValue("@palete_id", palete_id);

                    connection.Open();
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        caixa_id = reader.GetInt32(0);
                        cod1 = reader.GetValue(1).ToString();
                        cod2 = reader.GetValue(2).ToString();
                        cod3 = reader.GetValue(3).ToString();
                        sscc = reader.GetValue(4).ToString();

                        PrintLabel.Caixa(gtin, fabricacao, validade, lote.ToString(), nome, registroProcessador, sscc, embalagem.ToString(), caixa.ToString(), cod1, cod2, cod3, false);

                        command2 = new SqlCommand("update cx set cx.estagio=1,cx.dataImpresso=@data,cx.userImpresso=@user from caixa cx join caixasPalete cp on cp.caixa_id=cx.id where cx.id=@id", connection2);
                        command2.Parameters.AddWithValue("@id", caixa_id);
                        command.Parameters.AddWithValue("@user", Global.user);
                        command.Parameters.AddWithValue("@data", DateTime.Today);
                        connection2.Open();
                        command2.ExecuteNonQuery();
                        connection2.Close();
                    }
                    reader.Close();
                    connection.Close();
                }
                command = new SqlCommand("update carregamento set estagio=1,userImpresso=@user,dataImpresso=@data where id=@id", connection);
                command.Parameters.AddWithValue("@id", cbox_Carregamentos.SelectedValue);
                command.Parameters.AddWithValue("@user", Global.user);
                command.Parameters.AddWithValue("@data", DateTime.Today);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Fim do processo!!");
                Close();
            }
        }

        private void rbtn_Gerado_CheckedChanged(object sender, EventArgs e)
        {
            cbox_Carregamentos.DataSource = null;
            cbox_Carregamentos.Items.Clear();
            command = new SqlCommand("select id,codigo from carregamento where estagio=0", connection);
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
            lbox_Paletes.Items.Clear();
            lbox_Caixas.Items.Clear();
            btn_Done.Enabled = false;
        }

        private void rbtn_Impresso_CheckedChanged(object sender, EventArgs e)
        {
            cbox_Carregamentos.DataSource = null;
            cbox_Carregamentos.Items.Clear();
            command = new SqlCommand("select id,codigo from carregamento where estagio=1", connection);
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
            lbox_Paletes.Items.Clear();
            lbox_Caixas.Items.Clear();
            btn_Done.Enabled = false;
        }

        private void rbtn_Conferido_CheckedChanged(object sender, EventArgs e)
        {
            cbox_Carregamentos.DataSource = null;
            cbox_Carregamentos.Items.Clear();
            command = new SqlCommand("select id,codigo from carregamento where estagio=2", connection);
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
            lbox_Paletes.Items.Clear();
            lbox_Caixas.Items.Clear();
            btn_Done.Enabled = false;
        }
    }
}
