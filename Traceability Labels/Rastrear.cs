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
    public partial class Rastrear : Form
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

        public Rastrear()
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
                {
                    btn_Done.Enabled = true;
                    btn_Carregamento.Enabled = true;
                }
                else
                {
                    btn_Done.Enabled = false;
                    btn_Carregamento.Enabled = false;
                }
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
                btn_Palete.Enabled = true;
            }
            else
            {
                btn_Palete.Enabled = false;
            }
        }

        private void lbox_Caixas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag && lbox_Caixas.SelectedItem != null)
            {
                btn_Caixa.Enabled = true;
            }
            else
            {
                btn_Caixa.Enabled = false;
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Carregamento_Click(object sender, EventArgs e)
        {
            if (cbox_Carregamentos.SelectedIndex >= 0)
            {
                string codigo = "", expedicao = "", userGerado = "", dataGerado = "", userImpressao = "", dataImpressao = "", userConferido = "", dataConferido = "";

                command = new SqlCommand("select codigo, expedicao, userGerado, dataGerado, userImpresso, dataImpresso, userConferido, dataConferido from carregamento where id=@id", connection);
                command.Parameters.AddWithValue("@id", cbox_Carregamentos.SelectedValue);
                connection.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    codigo = reader.GetValue(0).ToString();
                    expedicao = reader.GetDateTime(1).ToString("dd/MM/yy");
                    userGerado = reader.GetValue(2).ToString();
                    if (!reader.IsDBNull(3))
                        dataGerado = reader.GetDateTime(3).ToString("dd/MM/yy");
                    userImpressao = reader.GetValue(4).ToString();
                    if (!reader.IsDBNull(5))
                        dataImpressao = reader.GetDateTime(5).ToString("dd/MM/yy");
                    userConferido = reader.GetValue(6).ToString();
                    if (!reader.IsDBNull(7))
                        dataConferido = reader.GetDateTime(7).ToString("dd/MM/yy");
                }
                reader.Close();
                connection.Close();

                dg1.Rows.Add();
                dg1.Rows[0].Cells[0].Value = "Código:";
                dg1.Rows[0].Cells[1].Value = codigo;
                dg1.Rows.Add();
                dg1.Rows[1].Cells[0].Value = "Expedição:";
                dg1.Rows[1].Cells[1].Value = expedicao;
                dg1.Rows.Add();
                dg1.Rows[2].Cells[0].Value = "Gerado por:";
                dg1.Rows[2].Cells[1].Value = userGerado;
                dg1.Rows.Add();
                dg1.Rows[3].Cells[0].Value = "Data:";
                dg1.Rows[3].Cells[1].Value = dataGerado;
                dg1.Rows.Add();
                dg1.Rows[4].Cells[0].Value = "Impresso por:";
                dg1.Rows[4].Cells[1].Value = userImpressao;
                dg1.Rows.Add();
                dg1.Rows[5].Cells[0].Value = "Data:";
                dg1.Rows[5].Cells[1].Value = dataImpressao;
                dg1.Rows.Add();
                dg1.Rows[6].Cells[0].Value = "Conferido por:";
                dg1.Rows[6].Cells[1].Value = userConferido;
                dg1.Rows.Add();
                dg1.Rows[7].Cells[0].Value = "Data:";
                dg1.Rows[7].Cells[1].Value = dataConferido;

                dg1.Columns[0].Width = 100;
            }
        }

        private void btn_Palete_Click(object sender, EventArgs e)
        {
            if (lbox_Paletes.SelectedIndex >= 0 && lbox_Paletes.SelectedItem != null)
            {

            }
        }

        private void btn_Caixa_Click(object sender, EventArgs e)
        {
            if (lbox_Caixas.SelectedIndex >= 0 && lbox_Caixas.SelectedItem != null)
            {

            }
        }
    }
}
