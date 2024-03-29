﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Traceability_Labels
{
    public partial class ListarProduto : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter;
        DataSet dataSet;

        public ListarProduto()
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

        private void ListarProduto_Load(object sender, EventArgs e)
        {
            try
            {
                dataGrid.Rows.Clear();
                command = new SqlCommand("select id as ID,nome as NOME,gtin as GTIN, embalagem as 'TARA EMB', caixa as 'TARA CX', validade as 'VIDA ÚTIL' from produto", connection);
                adapter = new SqlDataAdapter(command);
                connection.Open();
                adapter.Fill(dataSet,"produtos");
                connection.Close();
                dataGrid.DataSource = dataSet;
                dataGrid.DataMember = "produtos";
                dataGrid.Columns[0].Width = 50;
                dataGrid.Columns[1].Width = 170;
                dataGrid.Columns[2].Width = 100;
                dataGrid.Columns[3].Width = 70;
                dataGrid.Columns[4].Width = 70;
                dataGrid.Columns[5].Width = 50;
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
}
