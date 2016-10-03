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
            }
        }

        private void rbtn_Gerado_CheckedChanged(object sender, EventArgs e)
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
        }

        private void rbtn_Impresso_CheckedChanged(object sender, EventArgs e)
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
        }

        private void rbtn_Conferido_CheckedChanged(object sender, EventArgs e)
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
        }

        private void btn_Deletar_Click(object sender, EventArgs e)
        {
            if(cbox_Carregamento.SelectedIndex <= 0)
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
            }
            else
            {
                MessageBox.Show("Selexio um carregamento!!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
