using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace Traceability_Labels
{
    public partial class SalvarCarregamento : Form
    {
        List<string[]> items;
        SqlConnection connection;
        SqlCommand command;
        DataSet dataSet;

        public SalvarCarregamento()
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

            btn_Sync.Enabled = false;
        }

        private void btn_Abrir_Click(object sender, EventArgs e)
        {
            try
            {
                items = new List<string[]>();
                Stream stream;
                dialog.Filter = "All files (*.*)|*.*";
                dialog.FilterIndex = 2;
                dialog.RestoreDirectory = true;
                dialog.FileName = "carregamento.file";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    if ((stream = dialog.OpenFile()) != null)
                    {
                        StreamReader reader = new StreamReader(stream);
                        string s;
                        while ((s = reader.ReadLine()) != null)
                        {
                            string[] item = s.Split(';');
                            items.Add(item);
                        }
                        reader.Close();
                        stream.Close();
                        btn_Sync.Enabled = true;
                        UpdateGrid();
                        MessageBox.Show("Arquivo lido com sucesso.", "Ateção", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void UpdateGrid()
        {
            grid_Paletes.Rows.Clear();
            grid_Caixas.Rows.Clear();

            foreach (string[] item in items)
            {
                if (item.Length == 6)
                {
                    if (item[3] == "caixa")
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(grid_Caixas);
                        row.Cells[0].Value = item[0];
                        row.Cells[1].Value = item[1];
                        row.Cells[2].Value = item[2];
                        grid_Caixas.Rows.Add(row);
                    }
                    else if (item[3] == "palete")
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(grid_Paletes);
                        row.Cells[0].Value = item[0];
                        row.Cells[1].Value = item[1];
                        row.Cells[2].Value = item[2];
                        grid_Paletes.Rows.Add(row);
                    }
                }
            }
            grid_Caixas.Refresh();
            grid_Caixas.Refresh();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Sync_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (string[] item in items)
                {
                    if (item[3] == "caixa")
                    {
                        string[] data = item[5].Split('/');
                        command = new SqlCommand("update caixa set dataConferido=@data, userConferido=@user where cod3=@cod3", connection);
                        command.Parameters.AddWithValue("@cod3", item[2].Insert(0, "*").Insert(item[2].Length + 1, "*"));
                        command.Parameters.AddWithValue("@user", item[4]);
                        command.Parameters.AddWithValue("@data", new DateTime(Convert.ToInt32(data[2]), Convert.ToInt32(data[1]), Convert.ToInt32(data[0])));
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                    else if (item[3] == "palete")
                    {
                        string[] data = item[5].Split('/');
                        command = new SqlCommand("update palete set dataConferido=@data, userConferido=@user where cod3=@cod3", connection);
                        command.Parameters.AddWithValue("@cod3", item[2].Insert(0, "*").Insert(item[2].Length + 1, "*"));
                        command.Parameters.AddWithValue("@user", item[4]);
                        command.Parameters.AddWithValue("@data", new DateTime(Convert.ToInt32(data[2]),Convert.ToInt32(data[1]),Convert.ToInt32(data[0])));
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                    else
                        throw new Exception("Tipo não identificado.");

                    MessageBox.Show("Dados sincronizados com sucesso!","Atenção",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
    }
}
