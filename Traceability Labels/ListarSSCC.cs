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
    public partial class ListarSSCC : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter;
        DataSet dataSet;

        public ListarSSCC()
        {
            InitializeComponent();

            dataSet = new DataSet();
            connection = new SqlConnection(Global.connectionString);
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao conectar com o servidor: " + ex.Message, "ERRO!!");
            }
            finally
            {
                connection.Close();
            }
        }

        private void ListarSSCC_Load(object sender, EventArgs e)
        {
            try
            {
                dataGrid.Rows.Clear();
                command = new SqlCommand("select id as ID, digitoExtencao as Extensão, licencaGS1 as GS1,serial as Serial, digitoVerificador as Verificador, tipo as Tipo, dataExpedicao as Saída from sscc", connection);
                adapter = new SqlDataAdapter(command);
                connection.Open();
                adapter.Fill(dataSet,"SSCC");
                connection.Close();
                dataGrid.DataSource = dataSet;
                dataGrid.DataMember = "SSCC";
                dataGrid.Columns[0].Width = 50;
                dataGrid.Columns[1].Width = 70;
                dataGrid.Columns[2].Width = 80;
                dataGrid.Columns[3].Width = 70;
                dataGrid.Columns[4].Width = 70;
                dataGrid.Columns[5].Width = 80;
                dataGrid.Columns[6].Width = 70;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "ERRO!");
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
    }
}
