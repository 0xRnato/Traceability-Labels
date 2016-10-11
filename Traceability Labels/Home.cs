using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Printing;

namespace Traceability_Labels
{
    public partial class Home : Form
    {
        public Home(bool adm)
        {
            InitializeComponent();
            PrinterSettings settings = new PrinterSettings();
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                settings.PrinterName = printer;
                if (settings.IsDefaultPrinter)
                    Global.printerName = printer;
            }
            lbl_Printer.Text += Global.printerName;

            if (!adm)
            {
                menu_CadastrarProduto.Enabled = false;
                menu_EditarProduto.Enabled = false;
                menu_GerarEtiquetas.Enabled = false;
                menu_Rastrear.Enabled = false;
                menu_CadastrarUsuario.Enabled = false;
                menu_EditarUsuario.Enabled = false;
                menu_Leitor.Enabled = false;
                Global.adm = false;
            }
            else
                Global.adm = true;
        }

        private void Home_Activated(object sender, EventArgs e)
        {
            lbl_Printer.Text = "IMPRESSORA: " + Global.printerName;
        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void menu_Sair_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Deseja mesmo sair?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                Application.Exit();
        }

        private void menu_Sobre_Click(object sender, EventArgs e)
        {
            Sobre form = new Sobre();
            form.ShowDialog();
        }

        private void menu_Impressoras_Click(object sender, EventArgs e)
        {
            Printers form = new Printers();
            form.ShowDialog();
        }

        private void menu_CadastrarUsuario_Click(object sender, EventArgs e)
        {
            CadastrarUsuario form = new CadastrarUsuario();
            form.ShowDialog();
        }

        private void menu_EditarUsuario_Click(object sender, EventArgs e)
        {
            EditarUsuario form = new EditarUsuario();
            form.ShowDialog();
        }

        private void menu_ImprimirEtiquetas_Click(object sender, EventArgs e)
        {
            ImprimirEtiqueta form = new ImprimirEtiqueta();
            form.ShowDialog();
        }

        private void menu_Rastrear_Click(object sender, EventArgs e)
        {
            Rastrear form = new Rastrear();
            form.ShowDialog();
        }

        private void menu_CadastrarProduto_Click(object sender, EventArgs e)
        {
            CadastrarProduto form = new CadastrarProduto();
            form.ShowDialog();
        }

        private void menu_EditarProduto_Click(object sender, EventArgs e)
        {
            EditarProduto form = new EditarProduto();
            form.ShowDialog();
        }

        private void menu_ListarProdutos_Click(object sender, EventArgs e)
        {
            ListarProduto form = new ListarProduto();
            form.ShowDialog();
        }

        private void novoCarregamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NovoCarregamento form = new NovoCarregamento();
            form.ShowDialog();
        }

        private void editarCarregamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditarCarregamento form = new EditarCarregamento();
            form.ShowDialog();
        }

        private void gerarChaveDeUsuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GerarUser form = new GerarUser();
            form.ShowDialog();
        }

        private void salvarCarregamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalvarCarregamento form = new SalvarCarregamento();
            form.ShowDialog();
        }
    }

    class Global
    {
        private static SqlConnection connection;
        private static SqlCommand command;
        private static SqlDataReader reader;
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RastreabilidadeLogistica;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static string gs1Global = "78975224";
        public static string regProcessadorGlobal = "99999999";
        public static string printerName;
        public static string user;
        public static bool adm;

        public static string NextSSCC(string tipo)
        {
            string sscc = "";

            connection = new SqlConnection(connectionString);
            try
            {
                //Verifica se tem dados na tabela SSCC
                command = new SqlCommand("select count(*) from sscc", connection);
                int count = 0;
                connection.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    count = reader.GetInt32(0);
                }
                reader.Close();
                connection.Close();

                //Caso seja o primeiro registro;
                if (count == 0)
                {
                    string digitoExtencao = "0", licencaGS1 = gs1Global, serial = "0000001", digitoVerificador = CheckDigitSSCC(digitoExtencao, licencaGS1, serial);
                    DateTime data = DateTime.Today;

                    sscc = digitoExtencao + licencaGS1 + serial + digitoVerificador;
                    //if (sscc.Length < 18)
                    //    throw new Exception("O código SSCC esta incompleto.");

                    command = new SqlCommand("insert into sscc (digitoExtencao,licencaGS1,serial,digitoVerificador, tipo, dataEmissao) values (@digitoExtencao,@licencaGS1,@serial,@digitoVerificador, @tipo, @dataEmissao)", connection);
                    command.Parameters.AddWithValue("@digitoExtencao", digitoExtencao);
                    command.Parameters.AddWithValue("@licencaGS1", licencaGS1);
                    command.Parameters.AddWithValue("@serial", serial);
                    command.Parameters.AddWithValue("@digitoVerificador", digitoVerificador);
                    command.Parameters.AddWithValue("@tipo", tipo);
                    command.Parameters.AddWithValue("@dataEmissao", data);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

                //Caso ja tenha sido gerado algum codigo antes;
                else
                {
                    string serial = "", digitoExtencao = "", licencaGS1 = gs1Global;
                    command = new SqlCommand("select top 1 serial,digitoExtencao from sscc order by id desc", connection);
                    connection.Open();
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        serial = reader.GetString(0);
                        digitoExtencao = reader.GetString(1);
                    }
                    reader.Close();
                    connection.Close();

                    if (int.Parse(serial) >= 9999999)
                    {
                        serial = "0000001";
                        digitoExtencao = (int.Parse(digitoExtencao) + 1).ToString();
                    }
                    else
                    {
                        serial = (int.Parse(serial) + 1).ToString();
                        if (serial.Length < 7)
                        {
                            string tmp = "";
                            for (int i = 7 - serial.Length; i > 0; i--)
                            {
                                tmp += "0";
                            }
                            serial = tmp + serial;
                        }
                    }

                    string digitoVerificador = CheckDigitSSCC(digitoExtencao, licencaGS1, serial);
                    DateTime data = DateTime.Today;

                    sscc = digitoExtencao + licencaGS1 + serial + digitoVerificador;
                    //if (sscc.Length < 18)
                    //    throw new Exception("O código SSCC esta incompleto.");

                    command = new SqlCommand("insert into sscc (digitoExtencao,licencaGS1,serial,digitoVerificador, tipo, dataEmissao) values (@digitoExtencao,@licencaGS1,@serial,@digitoVerificador, @tipo, @dataEmissao)", connection);
                    command.Parameters.AddWithValue("@digitoExtencao", digitoExtencao);
                    command.Parameters.AddWithValue("@licencaGS1", licencaGS1);
                    command.Parameters.AddWithValue("@serial", serial);
                    command.Parameters.AddWithValue("@digitoVerificador", digitoVerificador);
                    command.Parameters.AddWithValue("@tipo", tipo);
                    command.Parameters.AddWithValue("@dataEmissao", data);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "ERRO!!!");
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return sscc;
        }

        private static string CheckDigitSSCC(string digitoExtencao, string licencaGS1, string serial)
        {
            int checkDigit = 0;
            string sscc17 = digitoExtencao + licencaGS1 + serial;

            char[] tmp;

            for (int i = 0; i < sscc17.Length; i++)
            {
                if ((i + 1) % 2 == 0)
                {
                    checkDigit += Convert.ToInt32(sscc17[i]);
                }
                else
                {
                    checkDigit += Convert.ToInt32(sscc17[i] * 3);
                }
            }

            tmp = checkDigit.ToString().ToCharArray();
            tmp[tmp.Length - 1] = '0';
            tmp[tmp.Length - 2] = char.Parse((int.Parse(tmp[tmp.Length - 2].ToString()) + 1).ToString());
            string tmp2 = new string(tmp);
            checkDigit = int.Parse(tmp2) - checkDigit;

            if (checkDigit.ToString().Length > 1)
                return checkDigit.ToString()[checkDigit.ToString().Length - 1].ToString();

            return checkDigit.ToString();
        }
    }
}
