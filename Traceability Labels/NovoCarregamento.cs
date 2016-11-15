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
    public partial class NovoCarregamento : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter;
        DataSet dataSet;
        DataTable table;
        SqlDataReader reader;

        string codigo;
        string expedicao;
        int vidaUltil;

        public NovoCarregamento()
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
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Avancar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Codigo.Text == "")
                    throw new Exception("Digite o código do carregamento.");

                codigo = txt_Codigo.Text;
                expedicao = date_Expedicao.Value.ToString("yyyyMMdd");

                cbox_Produtos.Items.Clear();
                command = new SqlCommand("select id,nome from produto", connection);
                adapter = new SqlDataAdapter(command);
                table = new DataTable();
                adapter.Fill(table);
                cbox_Produtos.DataSource = table;
                cbox_Produtos.DisplayMember = table.Columns[1].ToString();
                cbox_Produtos.ValueMember = table.Columns[0].ToString();
                cbox_Produtos.SelectedIndex = -1;

                if (connection.State == ConnectionState.Open)
                    connection.Close();

                command = new SqlCommand("select stretch,cantoneira from paletePadrao where id=1", connection);
                connection.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    txt_Stretch.Text = reader.GetValue(0).ToString();
                    txt_Cantoneira.Text = reader.GetValue(1).ToString();
                }
                reader.Close();
                connection.Close();

                gbox_AddProduto.Enabled = true;
                gbox_ProdutosAdd.Enabled = true;
                cbox_Produtos.Focus();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void cbox_Produtos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gbox_AddProduto.Enabled && cbox_Produtos.SelectedIndex >= 0)
            {
                try
                {
                    command = new SqlCommand("select nome,gtin,embalagem,caixa,validade from produto where id=@id", connection);
                    command.Parameters.AddWithValue("@id", Convert.ToInt32(cbox_Produtos.SelectedValue));
                    connection.Open();
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        txt_Nome.Text = reader.GetValue(0).ToString();
                        txt_GTIN.Text = reader.GetValue(1).ToString();
                        txt_Embalagem.Text = reader.GetValue(2).ToString();
                        txt_Caixa.Text = reader.GetValue(3).ToString();
                        vidaUltil = Convert.ToInt32(reader.GetValue(4));
                    }
                    reader.Close();
                    connection.Close();
                    btn_Add.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
        }

        private void date_Fabricacao_Leave(object sender, EventArgs e)
        {
            date_Validade.Value = date_Fabricacao.Value.AddDays(vidaUltil);
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                int quantidade;
                decimal taraPalete;

                bool testQuantidade = int.TryParse(txt_Quantidade.Text, out quantidade);
                if (!testQuantidade)
                    throw new Exception("A quantidade está em um formato incorreto!");
                bool testPalete = decimal.TryParse(txt_Palete.Text, out taraPalete);
                if (!testPalete)
                    throw new Exception("A tara do palete está em um formato incorreto!");
                if (txt_Lote.Text == "")
                    throw new Exception("Você se esqueceu de digitar o lote.");

                var item = txt_Quantidade.Text + " - " + txt_Nome.Text + " - " + txt_Lote.Text;
                lbox_Produtos.Items.Add(item);

                dataGrid.Rows.Add();
                dataGrid.Rows[dataGrid.Rows.Count - 1].Cells[0].Value = cbox_Produtos.SelectedValue;
                dataGrid.Rows[dataGrid.Rows.Count - 1].Cells[1].Value = txt_Nome.Text;
                dataGrid.Rows[dataGrid.Rows.Count - 1].Cells[2].Value = txt_GTIN.Text;
                dataGrid.Rows[dataGrid.Rows.Count - 1].Cells[3].Value = quantidade.ToString();
                dataGrid.Rows[dataGrid.Rows.Count - 1].Cells[4].Value = date_Fabricacao.Value.ToString("yyyyMMdd");
                dataGrid.Rows[dataGrid.Rows.Count - 1].Cells[5].Value = date_Validade.Value.ToString("yyyyMMdd");
                dataGrid.Rows[dataGrid.Rows.Count - 1].Cells[6].Value = txt_Lote.Text;
                dataGrid.Rows[dataGrid.Rows.Count - 1].Cells[7].Value = txt_Embalagem.Text;
                dataGrid.Rows[dataGrid.Rows.Count - 1].Cells[8].Value = txt_Caixa.Text;
                dataGrid.Rows[dataGrid.Rows.Count - 1].Cells[9].Value = txt_Palete.Text;
                dataGrid.Rows[dataGrid.Rows.Count - 1].Cells[10].Value = txt_Stretch.Text;
                dataGrid.Rows[dataGrid.Rows.Count - 1].Cells[11].Value = txt_Cantoneira.Text;

                btn_Remover.Enabled = true;
                btn_Done.Enabled = true;

                btn_Add.Enabled = false;
                cbox_Produtos.SelectedIndex = -1;
                txt_Nome.Text = "";
                txt_GTIN.Text = "";
                txt_Quantidade.Text = "";
                date_Fabricacao.Value = DateTime.Today;
                date_Validade.Value = DateTime.Today;
                txt_Lote.Text = "";
                txt_Embalagem.Text = "";
                txt_Caixa.Text = "";
                txt_Palete.Text = "";
                cbox_Produtos.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void btn_Remover_Click(object sender, EventArgs e)
        {
            dataGrid.Rows.RemoveAt(lbox_Produtos.SelectedIndex);
            lbox_Produtos.Items.RemoveAt(lbox_Produtos.SelectedIndex);
            lbox_Produtos.SelectedIndex = -1;
            if (lbox_Produtos.Items.Count <= 0)
            {
                btn_Remover.Enabled = false;
                btn_Done.Enabled = false;
            }
        }

        private void btn_Done_Click(object sender, EventArgs e)
        {
            try
            {
                int id_Carregamento;

                //CARREGAMENTO
                command = new SqlCommand("insert into carregamento (codigo,expedicao,userGerado,dataGerado,estagio) values(@codigo,@expedicao,@userGerado,@dataGerado,0) select scope_identity()", connection);
                command.Parameters.AddWithValue("@codigo", codigo);
                command.Parameters.AddWithValue("@expedicao", expedicao);
                command.Parameters.AddWithValue("@userGerado", Global.user);
                command.Parameters.AddWithValue("@dataGerado", DateTime.Today.ToString("yyyyMMdd"));
                connection.Open();
                id_Carregamento = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();

                //PALETE
                for (int i = 0; i < lbox_Produtos.Items.Count; i++)
                {
                    int estagio, id_Produto, quantidade, id_Palete, id_Caixa;
                    string cod1, cod2, cod3, sscc, processador, gtin, nome, lote;
                    decimal embalagem, caixa, palete, stretch, cantoneira;
                    string fabricacao, validade, fabricacaoCod, validadeCod;

                    id_Produto = Convert.ToInt32(dataGrid.Rows[i].Cells[0].Value);
                    nome = dataGrid.Rows[i].Cells[1].Value.ToString();
                    gtin = dataGrid.Rows[i].Cells[2].Value.ToString();
                    quantidade = Convert.ToInt32(dataGrid.Rows[i].Cells[3].Value);

                    fabricacao = dataGrid.Rows[i].Cells[4].Value.ToString();
                    validade = dataGrid.Rows[i].Cells[5].Value.ToString();

                    int ano, mes, dia;
                    string data;

                    data = dataGrid.Rows[i].Cells[4].Value.ToString();
                    ano = int.Parse(data[0].ToString() + data[1].ToString() + data[2].ToString() + data[3].ToString());
                    mes = int.Parse(data[4].ToString() + data[5].ToString());
                    dia = int.Parse(data[6].ToString() + data[7].ToString());

                    fabricacaoCod = new DateTime(ano, mes, dia).ToString("yyMMdd");

                    data = dataGrid.Rows[i].Cells[5].Value.ToString();
                    ano = int.Parse(data[0].ToString() + data[1].ToString() + data[2].ToString() + data[3].ToString());
                    mes = int.Parse(data[4].ToString() + data[5].ToString());
                    dia = int.Parse(data[6].ToString() + data[7].ToString());

                    validadeCod = new DateTime(ano, mes, dia).ToString("yyMMdd");

                    lote = dataGrid.Rows[i].Cells[6].Value.ToString();
                    embalagem = Convert.ToDecimal(dataGrid.Rows[i].Cells[7].Value);
                    caixa = Convert.ToDecimal(dataGrid.Rows[i].Cells[8].Value);
                    palete = Convert.ToDecimal(dataGrid.Rows[i].Cells[9].Value);
                    stretch = Convert.ToDecimal(dataGrid.Rows[i].Cells[10].Value);
                    cantoneira = Convert.ToDecimal(dataGrid.Rows[i].Cells[11].Value);
                    estagio = 0;
                    processador = Global.regProcessadorGlobal;
                    sscc = Global.NextSSCC("PALETE");

                    cod1 = "*02" + gtin + "15" + validadeCod.Replace("/", "") + "11" + fabricacaoCod.Replace("/", "") + "37" + quantidade + "*";
                    cod2 = "*7030" + processador + "10" + lote + "*";
                    cod3 = "*00" + sscc + "*";

                    command = new SqlCommand("insert into palete (carregamento_id,sscc,palete,stretch,cantoneira,cod1,cod2,cod3,quantidade,userGerado,dataGerado,estagio) values(@carregamento_id,@sscc,@palete,@stretch,@cantoneira,@cod1,@cod2,@cod3,@quantidade,@userGerado,@dataGerado,@estagio) select scope_identity()", connection);
                    command.Parameters.AddWithValue("@carregamento_id", id_Carregamento);
                    command.Parameters.AddWithValue("@sscc", sscc);
                    command.Parameters.AddWithValue("@palete", palete);
                    command.Parameters.AddWithValue("@stretch", stretch);
                    command.Parameters.AddWithValue("@cantoneira", cantoneira);
                    command.Parameters.AddWithValue("@cod1", cod1);
                    command.Parameters.AddWithValue("@cod2", cod2);
                    command.Parameters.AddWithValue("@cod3", cod3);
                    command.Parameters.AddWithValue("@quantidade", quantidade);
                    command.Parameters.AddWithValue("@userGerado", Global.user);
                    command.Parameters.AddWithValue("@dataGerado", DateTime.Today.ToString("yyyyMMdd"));
                    command.Parameters.AddWithValue("@estagio", estagio);

                    connection.Open();
                    id_Palete = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();

                    //CAIXA
                    for (int j = 0; j < quantidade; j++)
                    {
                        sscc = Global.NextSSCC("CAIXA");
                        cod1 = "*01" + gtin + "15" + validadeCod.Replace("/", "") + "11" + fabricacaoCod.Replace("/", "") + "*";
                        cod2 = "*7030" + processador + "10" + lote + "*";
                        cod3 = "*00" + sscc + "*";

                        command = new SqlCommand("insert into caixa (produto_id,fabricacao,validade,lote,registroProcessador,sscc,cod1,cod2,cod3,userGerado,dataGerado,estagio) values (@produto_id,@fabricacao,@validade,@lote,@registroProcessador,@sscc,@cod1,@cod2,@cod3,@userGerado,@dataGerado,@estagio) select scope_identity()", connection);
                        command.Parameters.AddWithValue("@produto_id", id_Produto);
                        command.Parameters.AddWithValue("@fabricacao", fabricacao);
                        command.Parameters.AddWithValue("@validade", validade);
                        command.Parameters.AddWithValue("@lote", lote);
                        command.Parameters.AddWithValue("@registroProcessador", processador);
                        command.Parameters.AddWithValue("@sscc", sscc);
                        command.Parameters.AddWithValue("@cod1", cod1);
                        command.Parameters.AddWithValue("@cod2", cod2);
                        command.Parameters.AddWithValue("@cod3", cod3);
                        command.Parameters.AddWithValue("@userGerado", Global.user);
                        command.Parameters.AddWithValue("@dataGerado", DateTime.Today.ToString("yyyyMMdd"));
                        command.Parameters.AddWithValue("@estagio", estagio);

                        connection.Open();
                        id_Caixa = Convert.ToInt32(command.ExecuteScalar());
                        connection.Close();

                        //LIGAÇÃO ENTRE PALETE E CAIXA
                        command = new SqlCommand("insert into caixasPalete (caixa_id,palete_id) values (@caixa_id,@palete_id)", connection);
                        command.Parameters.AddWithValue("@caixa_id", id_Caixa);
                        command.Parameters.AddWithValue("@palete_id", id_Palete);

                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                MessageBox.Show("O carregamento foi gerado com sucesso e está pronto para ser impresso.", "Fim", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
    }
}
