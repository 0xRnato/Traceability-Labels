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
    public partial class EditarUsuario : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter;
        DataSet dataSet;
        DataTable table;
        SqlDataReader reader;
        bool flag;

        public EditarUsuario()
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

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show(this, "Confirme se você quer mesmo deletar este usuário.", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    command = new SqlCommand("delete from users where id=@id", connection);
                    command.Parameters.AddWithValue("@id", Convert.ToInt32(cbox_Usuarios.SelectedValue));
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Usuário deletado com sucesso!");
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

        private void EditarUsuario_Load(object sender, EventArgs e)
        {
            UpdateBox();
            flag = true;
        }

        private void UpdateBox()
        {
            try
            {
                cbox_Usuarios.Items.Clear();
                command = new SqlCommand("select id,usuario from users", connection);
                adapter = new SqlDataAdapter(command);
                table = new DataTable();
                adapter.Fill(table);
                cbox_Usuarios.DataSource = table;
                cbox_Usuarios.DisplayMember = table.Columns[1].ToString();
                cbox_Usuarios.ValueMember = table.Columns[0].ToString();
                cbox_Usuarios.SelectedIndex = -1;
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

        private void cbox_Usuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag == true)
            {
                try
                {
                    command = new SqlCommand("select usuario,senha,adm from users where id=@id", connection);
                    command.Parameters.AddWithValue("@id", Convert.ToInt32(cbox_Usuarios.SelectedValue));
                    connection.Open();
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        txt_User.Text = reader.GetString(0);
                        txt_Senha.Text = reader.GetInt32(1).ToString();
                        txt_Confirmar.Text = reader.GetInt32(1).ToString();
                        cbox_Tipo.SelectedIndex = Convert.ToInt32(reader.GetValue(2));
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

                command = new SqlCommand("update users set usuario=@usuario,senha=@senha,adm=@adm where id=@id", connection);
                command.Parameters.AddWithValue("@usuario", txt_User.Text);
                command.Parameters.AddWithValue("@senha", senha);
                command.Parameters.AddWithValue("@adm", cbox_Tipo.SelectedIndex);
                command.Parameters.AddWithValue("@id", Convert.ToInt32(cbox_Usuarios.SelectedValue));
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Usuário editado com sucesso!");
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
