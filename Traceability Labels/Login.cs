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
    public partial class Login : Form
    {
        SqlConnection connection;
        SqlCommand command;
        DataSet dataSet;
        SqlDataReader reader;

        public Login()
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
            Application.Exit();
        }

        private void btn_Enter_Click(object sender, EventArgs e)
        {
            int serverSenha;
            bool flag = false, serverAdm = false;

            try
            {
                command = new SqlCommand("select senha,adm from users where usuario=@usuario", connection);
                command.Parameters.AddWithValue("@usuario", txt_User.Text);
                connection.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    serverSenha = reader.GetInt32(0);
                    serverAdm = reader.GetBoolean(1);
                    if (serverSenha == Convert.ToInt32(txt_Senha.Text))
                    {
                        flag = true;
                    }
                }
                reader.Close();
                connection.Close();
                if (flag)
                {
                    MessageBox.Show("Login realizado com sucesso.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Home form = new Home(serverAdm);

                    if (serverAdm)
                        form.lbl_User.Text = "USUÁRIO: " + txt_User.Text + " TIPO: Administrador";
                    else
                        form.lbl_User.Text = "USUÁRIO: " + txt_User.Text + " TIPO: Normal";

                    Global.user = txt_User.Text;

                    Hide();
                    form.Show();
                }
                else
                    MessageBox.Show("O usuario e senha está errado ou não cadastrado.","Erro ao tentar logar no sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
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

        private void Login_Load(object sender, EventArgs e)
        {
            txt_User.Text = "";
            txt_Senha.Text = "";
        }
    }
}
