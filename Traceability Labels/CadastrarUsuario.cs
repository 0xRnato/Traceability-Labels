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
    public partial class CadastrarUsuario : Form
    {
        SqlConnection connection;
        SqlCommand command;
        DataSet dataSet;

        public CadastrarUsuario()
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

        private void btn_Enter_Click(object sender, EventArgs e)
        {
            try
            {
                int senha, confirmar;

                if (txt_User.Text == "" || txt_User.Text == null)
                    throw new Exception("O usuário não pode ser vazio.");
                bool testSenha = int.TryParse(txt_Senha.Text, out senha);
                if (!testSenha)
                    throw new Exception("A senha está em um formato incorreto!");
                bool testConfirmar = int.TryParse(txt_Confirmar.Text, out confirmar);
                if (!testConfirmar)
                    throw new Exception("A confirmação da senha está em um formato incorreto!");
                if (senha != confirmar)
                    throw new Exception("As senhas não estão iguais.");

                command = new SqlCommand("insert into users (usuario,senha,adm) values (@usuario,@senha,@adm)", connection);
                command.Parameters.AddWithValue("@usuario", txt_User.Text.ToString());
                command.Parameters.AddWithValue("@senha", senha);
                if (cbox_Tipo.SelectedItem.ToString() == "Administrador")
                    command.Parameters.AddWithValue("@adm", "1");
                else if (cbox_Tipo.SelectedItem.ToString() == "Normal")
                    command.Parameters.AddWithValue("@adm", "0");
                else
                    throw new Exception("Tipo de usuário seleciodado está incorreto.");
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Usuário cadastrado com sucesso!");
                txt_User.Text = "";
                txt_Senha.Text = "";
                txt_Confirmar.Text = "";
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
