using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Traceability_Labels
{
    public partial class GerarUser : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter;
        DataTable table;

        public GerarUser()
        {
            InitializeComponent();
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

        private void GerarUser_Load(object sender, EventArgs e)
        {
            try
            {
                cbox_Usuarios.Items.Clear();
                command = new SqlCommand("select usuario,senha from users", connection);
                adapter = new SqlDataAdapter(command);
                table = new DataTable();
                adapter.Fill(table);
                cbox_Usuarios.DataSource = table;
                cbox_Usuarios.DisplayMember = table.Columns[0].ToString();
                cbox_Usuarios.ValueMember = table.Columns[1].ToString();
                cbox_Usuarios.SelectedIndex = -1;
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

        private void btn_Gerar_Click(object sender, EventArgs e)
        {
            try
            {
                Stream stream;
                saveDialog.Filter = "All files (*.*)|*.*";
                saveDialog.FilterIndex = 1;
                saveDialog.RestoreDirectory = true;
                saveDialog.FileName = "user.file";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    if ((stream = saveDialog.OpenFile()) != null)
                    {
                        StreamWriter writer = new StreamWriter(stream);
                        writer.WriteLine(cbox_Usuarios.Text);
                        writer.Write(cbox_Usuarios.SelectedValue);
                        writer.Close();
                        stream.Close();
                        MessageBox.Show("Chave gerado com sucesso.", "Ateção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
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

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
