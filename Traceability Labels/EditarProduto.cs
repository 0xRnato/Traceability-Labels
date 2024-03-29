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
    public partial class EditarProduto : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter;
        DataSet dataSet;
        DataTable table;
        SqlDataReader reader;
        bool flag;

        public EditarProduto()
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
            flag = false;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DeletarProduto_Load(object sender, EventArgs e)
        {
            UpdateBox();
            cbox_Produtos.SelectedIndex = -1;
            flag = true;
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show(this,"Confirme se você quer mesmo deletar este produto.", "ATENÇÃO", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if(confirm == DialogResult.Yes)
            {
                try
                {
                    command = new SqlCommand("delete from produto where id=@id", connection);
                    command.Parameters.AddWithValue("@id", Convert.ToInt32(cbox_Produtos.SelectedValue));
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Produto deletado com sucesso!");
                    Hide();
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

        private void UpdateBox()
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
            if (flag == true)
            {
                try
                {
                    command = new SqlCommand("select nome,gtin,embalagem,caixa,validade from produto where id=@id", connection);
                    command.Parameters.AddWithValue("@id", Convert.ToInt32(cbox_Produtos.SelectedValue));
                    connection.Open();
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        txt_Nome.Text = reader.GetString(0);
                        txt_GTIN.Text = reader.GetString(1);
                        txt_Embalagem.Text = reader.GetDecimal(2).ToString();
                        txt_Caixa.Text = reader.GetDecimal(3).ToString();
                        txt_Validade.Text = reader.GetInt32(4).ToString();
                    }
                    reader.Close();
                    connection.Close();
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

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                double embalagem, caixa;
                int validade;

                if (txt_Nome.Text == "" || txt_Nome.Text == null)
                    throw new Exception("O nome não pode ser vazio.");
                if (txt_GTIN.Text == "" || txt_GTIN.Text == null)
                    throw new Exception("O GTIN não pode ser vazio.");
                bool testEmbalagem = double.TryParse(txt_Embalagem.Text, out embalagem);
                if (!testEmbalagem)
                    throw new Exception("A tara da embalagem esta em um formato incorreto!");
                bool testCaixa = double.TryParse(txt_Caixa.Text, out caixa);
                if (!testCaixa)
                    throw new Exception("A tara da caixa esta em um formato incorreto!");
                bool testValidade = int.TryParse(txt_Validade.Text, out validade);
                if (!testValidade)
                    throw new Exception("A vida útil esta em um formato incorreto!");

                command = new SqlCommand("update produto set nome=@nome,gtin=@gtin,embalagem=@embalagem,caixa=@caixa,validade=@validade where id=@id", connection);
                command.Parameters.AddWithValue("@nome", txt_Nome.Text);
                command.Parameters.AddWithValue("@gtin", txt_GTIN.Text);
                command.Parameters.AddWithValue("@embalagem", embalagem.ToString());
                command.Parameters.AddWithValue("@caixa", caixa.ToString());
                command.Parameters.AddWithValue("@validade", validade.ToString());
                command.Parameters.AddWithValue("@id", Convert.ToInt32(cbox_Produtos.SelectedValue));
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Produto editado com sucesso!");
                Hide();
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
