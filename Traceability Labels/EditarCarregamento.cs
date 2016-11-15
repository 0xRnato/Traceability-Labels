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
    public partial class EditarCarregamento : Form
    {
        SqlConnection connection;
        SqlConnection connection2;
        SqlCommand command;
        SqlCommand command2;
        SqlDataAdapter adapter;
        DataSet dataSet;
        DataTable table;
        SqlDataReader reader;
        bool flag;

        public EditarCarregamento()
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
            try
            {
                cbox_Carregamento.DataSource = null;
                cbox_Carregamento.Items.Clear();
                command = new SqlCommand("select id,codigo from carregamento where estagio=0", connection);
                adapter = new SqlDataAdapter(command);
                table = new DataTable();
                adapter.Fill(table);
                cbox_Carregamento.DataSource = table;
                cbox_Carregamento.DisplayMember = table.Columns[1].ToString();
                cbox_Carregamento.ValueMember = table.Columns[0].ToString();
                cbox_Carregamento.SelectedIndex = -1;
                if (connection.State == ConnectionState.Open)
                    connection.Close();
                flag = true;
                lbox_Paletes.Items.Clear();
                gbox_ProdutosAdd.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void rbtn_Impresso_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                cbox_Carregamento.DataSource = null;
                cbox_Carregamento.Items.Clear();
                command = new SqlCommand("select id,codigo from carregamento where estagio=1", connection);
                adapter = new SqlDataAdapter(command);
                table = new DataTable();
                adapter.Fill(table);
                cbox_Carregamento.DataSource = table;
                cbox_Carregamento.DisplayMember = table.Columns[1].ToString();
                cbox_Carregamento.ValueMember = table.Columns[0].ToString();
                cbox_Carregamento.SelectedIndex = -1;
                if (connection.State == ConnectionState.Open)
                    connection.Close();
                flag = true;
                lbox_Paletes.Items.Clear();
                gbox_ProdutosAdd.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void rbtn_Conferido_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                cbox_Carregamento.DataSource = null;
                cbox_Carregamento.Items.Clear();
                command = new SqlCommand("select id,codigo from carregamento where estagio=2", connection);
                adapter = new SqlDataAdapter(command);
                table = new DataTable();
                adapter.Fill(table);
                cbox_Carregamento.DataSource = table;
                cbox_Carregamento.DisplayMember = table.Columns[1].ToString();
                cbox_Carregamento.ValueMember = table.Columns[0].ToString();
                cbox_Carregamento.SelectedIndex = -1;
                if (connection.State == ConnectionState.Open)
                    connection.Close();
                flag = true;
                lbox_Paletes.Items.Clear();
                gbox_ProdutosAdd.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void btn_Deletar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbox_Carregamento.SelectedIndex >= 0)
                {
                    DialogResult result = MessageBox.Show("Quer mesmo deletar este carregamento?", "ATENÇÃO!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (result == DialogResult.Yes)
                    {
                        int carregamento, palete;
                        carregamento = Convert.ToInt32(cbox_Carregamento.SelectedValue);

                        command = new SqlCommand("select pl.id from palete pl join carregamento cr on cr.id=pl.carregamento_id where carregamento_id=@carregamento_id", connection);
                        command.Parameters.AddWithValue("@carregamento_id", cbox_Carregamento.SelectedValue);
                        connection.Open();
                        reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            palete = reader.GetInt32(0);

                            command2 = new SqlCommand("delete cp from caixasPalete cp join palete pl on pl.id=cp.palete_id join carregamento cr on cr.id=pl.carregamento_id where cr.id=@carregamento_id", connection2);
                            command2.Parameters.AddWithValue("@carregamento_id", carregamento);
                            connection2.Open();
                            command2.ExecuteNonQuery();
                            connection2.Close();

                            command2 = new SqlCommand("delete cx from caixa cx join caixasPalete cp on cp.caixa_id=cx.id join palete pl on pl.id=cp.palete_id where pl.id=@palete_id", connection2);
                            command2.Parameters.AddWithValue("@palete_id", palete);
                            connection2.Open();
                            command2.ExecuteNonQuery();
                            connection2.Close();

                            command2 = new SqlCommand("delete from palete where id=@id", connection2);
                            command2.Parameters.AddWithValue("@id", palete);
                            connection2.Open();
                            command2.ExecuteNonQuery();
                            connection2.Close();
                        }
                        reader.Close();

                        command = new SqlCommand("delete from carregamento where id=@id", connection);
                        command.Parameters.AddWithValue("@id", carregamento);
                        command.ExecuteNonQuery();
                        connection.Close();

                        MessageBox.Show("O carregamento foi deletado com sucesso.", "Concluído.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cbox_Carregamento.SelectedIndex = -1;
                        rbtn_Gerado.Checked = true;
                        rbtn_Impresso.Checked = true;
                        rbtn_Gerado.Checked = true;
                    }
                    else
                    {
                        MessageBox.Show("Selecione um carregamento!!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void cbox_Carregamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (flag && cbox_Carregamento.SelectedIndex >= 0)
                {
                    gbox_ProdutosAdd.Enabled = true;

                    command = new SqlCommand("select palete.id,produto.nome from palete join caixasPalete on palete.id = caixasPalete.palete_id join caixa on caixa.id = caixasPalete.caixa_id join produto on produto.id = caixa.produto_id where palete.carregamento_id=@carregamento_id group by palete.id, produto.nome", connection);
                    command.Parameters.AddWithValue("@carregamento_id", cbox_Carregamento.SelectedValue);

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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void btn_Done_Click(object sender, EventArgs e)
        {

        }
    }
}
