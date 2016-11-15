using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using pre_pesagem;

namespace Traceability_Labels
{
    public partial class Rastrear : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter;
        DataSet dataSet;
        DataTable table;

        public Rastrear()
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

        private void Lock()
        {
            txt_Carregamento.Enabled = false;
            txt_Gtin.Enabled = false;
            txt_SSCC.Enabled = false;
            cbox_Produtos.Enabled = false;
            cbox_Usuario.Enabled = false;
            date_Conferido.Enabled = false;
            date_Gerado.Enabled = false;
            date_Impresso.Enabled = false;
            btn_Pesqusiar.Enabled = false;
        }

        private void rbtn_Carregamento_CheckedChanged(object sender, EventArgs e)
        {
            Lock();
            txt_Carregamento.Enabled = true;
            txt_Carregamento.Focus();
            btn_Pesqusiar.Enabled = true;
        }



        private void rbtn_Produto_CheckedChanged(object sender, EventArgs e)
        {
            Lock();
            cbox_Produtos.Enabled = true;
            cbox_Produtos.Focus();
            btn_Pesqusiar.Enabled = true;
        }

        private void rbtn_Gtin_CheckedChanged(object sender, EventArgs e)
        {
            Lock();
            txt_Gtin.Enabled = true;
            txt_Gtin.Focus();
            btn_Pesqusiar.Enabled = true;
        }

        private void rbtn_SSCC_CheckedChanged(object sender, EventArgs e)
        {
            Lock();
            txt_SSCC.Enabled = true;
            txt_SSCC.Focus();
            btn_Pesqusiar.Enabled = true;
        }

        private void rbtn_Usuario_CheckedChanged(object sender, EventArgs e)
        {
            Lock();
            cbox_Usuario.Enabled = true;
            cbox_Usuario.Focus();
            btn_Pesqusiar.Enabled = true;
        }

        private void rbtn_DataGerado_CheckedChanged(object sender, EventArgs e)
        {
            Lock();
            date_Gerado.Enabled = true;
            date_Gerado.Focus();
            btn_Pesqusiar.Enabled = true;
        }

        private void rbtn_DataImpresso_CheckedChanged(object sender, EventArgs e)
        {
            Lock();
            date_Impresso.Enabled = true;
            date_Impresso.Focus();
            btn_Pesqusiar.Enabled = true;
        }

        private void rbtn_DataConferido_CheckedChanged(object sender, EventArgs e)
        {
            Lock();
            date_Conferido.Enabled = true;
            date_Conferido.Focus();
            btn_Pesqusiar.Enabled = true;
        }

        private void btn_Pesqusiar_Click(object sender, EventArgs e)
        {
            try
            {
                RelatorioAgrupado form = new RelatorioAgrupado();
                DialogResult result = form.ShowDialog();

                //AGRUPADO
                if (result == DialogResult.Yes)
                {
                    if (rbtn_Carregamento.Checked && txt_Carregamento.Text != "")
                    {
                        //CARREGAMENTO
                        command = new SqlCommand("select codigo as 'Código',expedicao as 'Data Expedição',userGerado as 'Gerado por',dataGerado as 'Data Gerado',userImpresso as 'Impresso por',dataImpresso as 'Data Impresso',userConferido as 'Conferido por',dataConferido as 'Data Conferência' from carregamento where codigo=@codigo group by id,codigo,expedicao,userGerado,dataGerado,userImpresso,dataImpresso,userConferido,dataConferido", connection);
                        command.Parameters.AddWithValue("@codigo", txt_Carregamento.Text);
                        adapter = new SqlDataAdapter(command);
                        connection.Open();
                        adapter.Fill(dataSet, "carregamento");
                        connection.Close();
                        grid_Carregamentos.DataSource = dataSet;
                        grid_Carregamentos.DataMember = "carregamento";

                        //PALETE
                        command = new SqlCommand("select pr.nome as 'Produto', pl.sscc as 'SSCC', pl.palete as 'Tara do Palete', pl.quantidade as 'Quantidade',pl.userGerado as 'Gerado por',pl.dataGerado as 'Data Gerado',pl.userImpresso as 'Impresso por',pl.dataImpresso as 'Data Impresso',pl.userConferido as 'Conferido por',pl.dataConferido as 'Data Conferência' from palete pl join caixasPalete cp on pl.id = cp.palete_id join carregamento cr on cr.id = pl.carregamento_id join caixa cx on cx.id = cp.caixa_id join produto pr on pr.id = cx.produto_id where cr.codigo=@codigo group by pl.id,pl.sscc, pr.nome, pl.palete, pl.quantidade,pl.userGerado,pl.dataGerado,pl.userImpresso,pl.dataImpresso,pl.userConferido,pl.dataConferido", connection);
                        command.Parameters.AddWithValue("@codigo", txt_Carregamento.Text);
                        adapter = new SqlDataAdapter(command);
                        dataSet = new DataSet();
                        connection.Open();
                        adapter.Fill(dataSet, "palete");
                        connection.Close();
                        grid_Paletes.DataSource = dataSet;
                        grid_Paletes.DataMember = "palete";

                        //CAIXA
                        command = new SqlCommand("select pr.nome as 'Produto', cx.lote as 'Lote', cx.fabricacao as 'Fabricação', cx.validade as 'Vailidade', cx.userGerado as 'Gerado por',cx.dataGerado as 'Data Gerado',cx.userImpresso as 'Impresso por',cx.dataImpresso as 'Data Impresso',cx.userConferido as 'Conferido por',cx.dataConferido as 'Data Conferência', count(cx.lote) as 'Quantidade' from palete pl join caixasPalete cp on pl.id = cp.palete_id join carregamento cr on cr.id = pl.carregamento_id join caixa cx on cx.id = cp.caixa_id join produto pr on pr.id = cx.produto_id where cr.codigo = @codigo group by pr.nome, cx.lote, cx.fabricacao, cx.validade, cx.userGerado, cx.dataGerado, cx.userImpresso, cx.dataImpresso, cx.userConferido, cx.dataConferido", connection);
                        command.Parameters.AddWithValue("@codigo", txt_Carregamento.Text);
                        adapter = new SqlDataAdapter(command);
                        dataSet = new DataSet();
                        connection.Open();
                        adapter.Fill(dataSet, "caixa");
                        connection.Close();
                        grid_Caixas.DataSource = dataSet;
                        grid_Caixas.DataMember = "caixa";
                    }
                    else if (rbtn_DataConferido.Checked && date_Conferido.Value != null)
                    {
                        //CARREGAMENTO
                        command = new SqlCommand("select cr.codigo as 'Código',cr.expedicao as 'Data Expedição',cr.userGerado as 'Gerado por',cr.dataGerado as 'Data Gerado',cr.userImpresso as 'Impresso por',cr.dataImpresso as 'Data Impresso',cr.userConferido as 'Conferido por',cr.dataConferido as 'Data Conferência' from carregamento cr join palete pl on pl.carregamento_id=cr.id join caixasPalete cp on cp.palete_id=pl.id join caixa cx on cx.id=cp.caixa_id join produto pr on pr.id=cx.produto_id where cr.dataConferido=@data group by cr.id,cr.codigo,cr.expedicao,cr.userGerado,cr.dataGerado,cr.userImpresso,cr.dataImpresso,cr.userConferido,cr.dataConferido", connection);
                        command.Parameters.AddWithValue("@data", date_Conferido.Value.ToString("dd/MM/yyyy"));
                        adapter = new SqlDataAdapter(command);
                        connection.Open();
                        adapter.Fill(dataSet, "carregamento");
                        connection.Close();
                        grid_Carregamentos.DataSource = dataSet;
                        grid_Carregamentos.DataMember = "carregamento";

                        //PALETE
                        command = new SqlCommand("select pr.nome as 'Produto', pl.sscc as 'SSCC', pl.palete as 'Tara do Palete', pl.quantidade as 'Quantidade',pl.userGerado as 'Gerado por',pl.dataGerado as 'Data Gerado',pl.userImpresso as 'Impresso por',pl.dataImpresso as 'Data Impresso',pl.userConferido as 'Conferido por',pl.dataConferido as 'Data Conferência' from palete pl join caixasPalete cp on pl.id = cp.palete_id join carregamento cr on cr.id = pl.carregamento_id join caixa cx on cx.id = cp.caixa_id join produto pr on pr.id = cx.produto_id where pl.dataConferido=@data group by pl.id ,pl.sscc, pr.nome, pl.palete, pl.quantidade,pl.userGerado,pl.dataGerado,pl.userImpresso,pl.dataImpresso,pl.userConferido,pl.dataConferido", connection);
                        command.Parameters.AddWithValue("@data", date_Conferido.Value.ToString("dd/MM/yyyy"));
                        adapter = new SqlDataAdapter(command);
                        dataSet = new DataSet();
                        connection.Open();
                        adapter.Fill(dataSet, "palete");
                        connection.Close();
                        grid_Paletes.DataSource = dataSet;
                        grid_Paletes.DataMember = "palete";

                        //CAIXA
                        command = new SqlCommand("select pr.nome as 'Produto', cx.lote as 'Lote', cx.fabricacao as 'Fabricação', cx.validade as 'Vailidade', cx.userGerado as 'Gerado por',cx.dataGerado as 'Data Gerado',cx.userImpresso as 'Impresso por',cx.dataImpresso as 'Data Impresso',cx.userConferido as 'Conferido por',cx.dataConferido as 'Data Conferência', count(cx.lote) as 'Quantidade' from palete pl join caixasPalete cp on pl.id = cp.palete_id join carregamento cr on cr.id = pl.carregamento_id join caixa cx on cx.id = cp.caixa_id join produto pr on pr.id = cx.produto_id where cx.dataConferido = @data group by cx.id ,cx.sscc, pr.nome, cx.fabricacao, cx.validade, cx.lote, cx.userGerado, cx.dataGerado, cx.userImpresso, cx.dataImpresso, cx.userConferido, cx.dataConferido", connection);
                        command.Parameters.AddWithValue("@data", date_Conferido.Value.ToString("dd/MM/yyyy"));
                        adapter = new SqlDataAdapter(command);
                        dataSet = new DataSet();
                        connection.Open();
                        adapter.Fill(dataSet, "caixa");
                        connection.Close();
                        grid_Caixas.DataSource = dataSet;
                        grid_Caixas.DataMember = "caixa";
                    }
                    else if (rbtn_DataGerado.Checked && date_Gerado.Value != null)
                    {
                        //CARREGAMENTO
                        command = new SqlCommand("select cr.codigo as 'Código',cr.expedicao as 'Data Expedição',cr.userGerado as 'Gerado por',cr.dataGerado as 'Data Gerado',cr.userImpresso as 'Impresso por',cr.dataImpresso as 'Data Impresso',cr.userConferido as 'Conferido por',cr.dataConferido as 'Data Conferência' from carregamento cr join palete pl on pl.carregamento_id=cr.id join caixasPalete cp on cp.palete_id=pl.id join caixa cx on cx.id=cp.caixa_id join produto pr on pr.id=cx.produto_id where cr.dataGerado=@data group by cr.id,cr.codigo,cr.expedicao,cr.userGerado,cr.dataGerado,cr.userImpresso,cr.dataImpresso,cr.userConferido,cr.dataConferido", connection);
                        command.Parameters.AddWithValue("@data", date_Gerado.Value.ToString("dd/MM/yyyy"));
                        adapter = new SqlDataAdapter(command);
                        connection.Open();
                        adapter.Fill(dataSet, "carregamento");
                        connection.Close();
                        grid_Carregamentos.DataSource = dataSet;
                        grid_Carregamentos.DataMember = "carregamento";

                        //PALETE
                        command = new SqlCommand("select pr.nome as 'Produto', pl.sscc as 'SSCC', pl.palete as 'Tara do Palete', pl.quantidade as 'Quantidade',pl.userGerado as 'Gerado por',pl.dataGerado as 'Data Gerado',pl.userImpresso as 'Impresso por',pl.dataImpresso as 'Data Impresso',pl.userConferido as 'Conferido por',pl.dataConferido as 'Data Conferência' from palete pl join caixasPalete cp on pl.id = cp.palete_id join carregamento cr on cr.id = pl.carregamento_id join caixa cx on cx.id = cp.caixa_id join produto pr on pr.id = cx.produto_id where pl.dataGerado=@data group by pl.id ,pl.sscc, pr.nome, pl.palete, pl.quantidade,pl.userGerado,pl.dataGerado,pl.userImpresso,pl.dataImpresso,pl.userConferido,pl.dataConferido", connection);
                        command.Parameters.AddWithValue("@data", date_Gerado.Value.ToString("dd/MM/yyyy"));
                        adapter = new SqlDataAdapter(command);
                        dataSet = new DataSet();
                        connection.Open();
                        adapter.Fill(dataSet, "palete");
                        connection.Close();
                        grid_Paletes.DataSource = dataSet;
                        grid_Paletes.DataMember = "palete";

                        //CAIXA
                        command = new SqlCommand("select pr.nome as 'Produto', cx.lote as 'Lote', cx.fabricacao as 'Fabricação', cx.validade as 'Vailidade', cx.userGerado as 'Gerado por',cx.dataGerado as 'Data Gerado',cx.userImpresso as 'Impresso por',cx.dataImpresso as 'Data Impresso',cx.userConferido as 'Conferido por',cx.dataConferido as 'Data Conferência', count(cx.lote) as 'Quantidade' from palete pl join caixasPalete cp on pl.id = cp.palete_id join carregamento cr on cr.id = pl.carregamento_id join caixa cx on cx.id = cp.caixa_id join produto pr on pr.id = cx.produto_id where cx.dataGerado = @data group by cx.id ,cx.sscc, pr.nome, cx.fabricacao, cx.validade, cx.lote, cx.userGerado, cx.dataGerado, cx.userImpresso, cx.dataImpresso, cx.userConferido, cx.dataConferido", connection);
                        command.Parameters.AddWithValue("@data", date_Gerado.Value.ToString("dd/MM/yyyy"));
                        adapter = new SqlDataAdapter(command);
                        dataSet = new DataSet();
                        connection.Open();
                        adapter.Fill(dataSet, "caixa");
                        connection.Close();
                        grid_Caixas.DataSource = dataSet;
                        grid_Caixas.DataMember = "caixa";
                    }
                    else if (rbtn_DataImpresso.Checked && date_Impresso.Value != null)
                    {
                        //CARREGAMENTO
                        command = new SqlCommand("select cr.codigo as 'Código',cr.expedicao as 'Data Expedição',cr.userGerado as 'Gerado por',cr.dataGerado as 'Data Gerado',cr.userImpresso as 'Impresso por',cr.dataImpresso as 'Data Impresso',cr.userConferido as 'Conferido por',cr.dataConferido as 'Data Conferência' from carregamento cr join palete pl on pl.carregamento_id=cr.id join caixasPalete cp on cp.palete_id=pl.id join caixa cx on cx.id=cp.caixa_id join produto pr on pr.id=cx.produto_id where cr.dataImpresso=@data group by cr.id,cr.codigo,cr.expedicao,cr.userGerado,cr.dataGerado,cr.userImpresso,cr.dataImpresso,cr.userConferido,cr.dataConferido", connection);
                        command.Parameters.AddWithValue("@data", date_Impresso.Value.ToString("dd/MM/yyyy"));
                        adapter = new SqlDataAdapter(command);
                        connection.Open();
                        adapter.Fill(dataSet, "carregamento");
                        connection.Close();
                        grid_Carregamentos.DataSource = dataSet;
                        grid_Carregamentos.DataMember = "carregamento";

                        //PALETE
                        command = new SqlCommand("select pr.nome as 'Produto', pl.sscc as 'SSCC', pl.palete as 'Tara do Palete', pl.quantidade as 'Quantidade',pl.userGerado as 'Gerado por',pl.dataGerado as 'Data Gerado',pl.userImpresso as 'Impresso por',pl.dataImpresso as 'Data Impresso',pl.userConferido as 'Conferido por',pl.dataConferido as 'Data Conferência' from palete pl join caixasPalete cp on pl.id = cp.palete_id join carregamento cr on cr.id = pl.carregamento_id join caixa cx on cx.id = cp.caixa_id join produto pr on pr.id = cx.produto_id where pl.dataImpresso=@data group by pl.id ,pl.sscc, pr.nome, pl.palete, pl.quantidade,pl.userGerado,pl.dataGerado,pl.userImpresso,pl.dataImpresso,pl.userConferido,pl.dataConferido", connection);
                        command.Parameters.AddWithValue("@data", date_Impresso.Value.ToString("dd/MM/yyyy"));
                        adapter = new SqlDataAdapter(command);
                        dataSet = new DataSet();
                        connection.Open();
                        adapter.Fill(dataSet, "palete");
                        connection.Close();
                        grid_Paletes.DataSource = dataSet;
                        grid_Paletes.DataMember = "palete";

                        //CAIXA
                        command = new SqlCommand("select pr.nome as 'Produto', cx.lote as 'Lote', cx.fabricacao as 'Fabricação', cx.validade as 'Vailidade', cx.userGerado as 'Gerado por',cx.dataGerado as 'Data Gerado',cx.userImpresso as 'Impresso por',cx.dataImpresso as 'Data Impresso',cx.userConferido as 'Conferido por',cx.dataConferido as 'Data Conferência', count(cx.lote) as 'Quantidade' from palete pl join caixasPalete cp on pl.id = cp.palete_id join carregamento cr on cr.id = pl.carregamento_id join caixa cx on cx.id = cp.caixa_id join produto pr on pr.id = cx.produto_id where cx.dataImpresso = @data group by cx.id ,cx.sscc, pr.nome, cx.fabricacao, cx.validade, cx.lote, cx.userGerado, cx.dataGerado, cx.userImpresso, cx.dataImpresso, cx.userConferido, cx.dataConferido", connection);
                        command.Parameters.AddWithValue("@data", date_Impresso.Value.ToString("dd/MM/yyyy"));
                        adapter = new SqlDataAdapter(command);
                        dataSet = new DataSet();
                        connection.Open();
                        adapter.Fill(dataSet, "caixa");
                        connection.Close();
                        grid_Caixas.DataSource = dataSet;
                        grid_Caixas.DataMember = "caixa";
                    }
                    else if (rbtn_Gtin.Checked && txt_Gtin.Text != "")
                    {
                        //CARREGAMENTO
                        command = new SqlCommand("select cr.codigo as 'Código',cr.expedicao as 'Data Expedição',cr.userGerado as 'Gerado por',cr.dataGerado as 'Data Gerado',cr.userImpresso as 'Impresso por',cr.dataImpresso as 'Data Impresso',cr.userConferido as 'Conferido por',cr.dataConferido as 'Data Conferência' from carregamento cr join palete pl on pl.carregamento_id=cr.id join caixasPalete cp on cp.palete_id=pl.id join caixa cx on cx.id=cp.caixa_id join produto pr on pr.id=cx.produto_id where pr.gtin=@gtin group by cr.id,cr.codigo,cr.expedicao,cr.userGerado,cr.dataGerado,cr.userImpresso,cr.dataImpresso,cr.userConferido,cr.dataConferido", connection);
                        command.Parameters.AddWithValue("@gtin", txt_Gtin.Text);
                        adapter = new SqlDataAdapter(command);
                        connection.Open();
                        adapter.Fill(dataSet, "carregamento");
                        connection.Close();
                        grid_Carregamentos.DataSource = dataSet;
                        grid_Carregamentos.DataMember = "carregamento";

                        //PALETE
                        command = new SqlCommand("select pr.nome as 'Produto', pl.sscc as 'SSCC', pl.palete as 'Tara do Palete', pl.quantidade as 'Quantidade',pl.userGerado as 'Gerado por',pl.dataGerado as 'Data Gerado',pl.userImpresso as 'Impresso por',pl.dataImpresso as 'Data Impresso',pl.userConferido as 'Conferido por',pl.dataConferido as 'Data Conferência' from palete pl join caixasPalete cp on pl.id = cp.palete_id join carregamento cr on cr.id = pl.carregamento_id join caixa cx on cx.id = cp.caixa_id join produto pr on pr.id = cx.produto_id where pr.gtin=@gtin group by pl.id ,pl.sscc, pr.nome, pl.palete, pl.quantidade,pl.userGerado,pl.dataGerado,pl.userImpresso,pl.dataImpresso,pl.userConferido,pl.dataConferido", connection);
                        command.Parameters.AddWithValue("@gtin", txt_Gtin.Text);
                        adapter = new SqlDataAdapter(command);
                        dataSet = new DataSet();
                        connection.Open();
                        adapter.Fill(dataSet, "palete");
                        connection.Close();
                        grid_Paletes.DataSource = dataSet;
                        grid_Paletes.DataMember = "palete";

                        //CAIXA
                        command = new SqlCommand("select pr.nome as 'Produto', cx.lote as 'Lote', cx.fabricacao as 'Fabricação', cx.validade as 'Vailidade', cx.userGerado as 'Gerado por',cx.dataGerado as 'Data Gerado',cx.userImpresso as 'Impresso por',cx.dataImpresso as 'Data Impresso',cx.userConferido as 'Conferido por',cx.dataConferido as 'Data Conferência', count(cx.lote) as 'Quantidade' from palete pl join caixasPalete cp on pl.id = cp.palete_id join carregamento cr on cr.id = pl.carregamento_id join caixa cx on cx.id = cp.caixa_id join produto pr on pr.id = cx.produto_id where pr.gtin=@gtin by cx.id ,cx.sscc, pr.nome, cx.fabricacao, cx.validade, cx.lote, cx.userGerado, cx.dataGerado, cx.userImpresso, cx.dataImpresso, cx.userConferido, cx.dataConferido", connection);
                        command.Parameters.AddWithValue("@gtin", txt_Gtin.Text);
                        adapter = new SqlDataAdapter(command);
                        dataSet = new DataSet();
                        connection.Open();
                        adapter.Fill(dataSet, "caixa");
                        connection.Close();
                        grid_Caixas.DataSource = dataSet;
                        grid_Caixas.DataMember = "caixa";
                    }
                    else if (rbtn_Produto.Checked && cbox_Produtos.SelectedIndex >= 0)
                    {
                        //CARREGAMENTO
                        command = new SqlCommand("select cr.codigo as 'Código',cr.expedicao as 'Data Expedição',cr.userGerado as 'Gerado por',cr.dataGerado as 'Data Gerado',cr.userImpresso as 'Impresso por',cr.dataImpresso as 'Data Impresso',cr.userConferido as 'Conferido por',cr.dataConferido as 'Data Conferência' from carregamento cr join palete pl on pl.carregamento_id=cr.id join caixasPalete cp on cp.palete_id=pl.id join caixa cx on cx.id=cp.caixa_id join produto pr on pr.id=cx.produto_id where pr.id=@id group by cr.id,cr.codigo,cr.expedicao,cr.userGerado,cr.dataGerado,cr.userImpresso,cr.dataImpresso,cr.userConferido,cr.dataConferido", connection);
                        command.Parameters.AddWithValue("@id", cbox_Produtos.SelectedValue);
                        adapter = new SqlDataAdapter(command);
                        connection.Open();
                        adapter.Fill(dataSet, "carregamento");
                        connection.Close();
                        grid_Carregamentos.DataSource = dataSet;
                        grid_Carregamentos.DataMember = "carregamento";

                        //PALETE
                        command = new SqlCommand("select pr.nome as 'Produto', pl.sscc as 'SSCC', pl.palete as 'Tara do Palete', pl.quantidade as 'Quantidade',pl.userGerado as 'Gerado por',pl.dataGerado as 'Data Gerado',pl.userImpresso as 'Impresso por',pl.dataImpresso as 'Data Impresso',pl.userConferido as 'Conferido por',pl.dataConferido as 'Data Conferência' from palete pl join caixasPalete cp on pl.id = cp.palete_id join carregamento cr on cr.id = pl.carregamento_id join caixa cx on cx.id = cp.caixa_id join produto pr on pr.id = cx.produto_id where pr.id=@id group by pl.id ,pl.sscc, pr.nome, pl.palete, pl.quantidade,pl.userGerado,pl.dataGerado,pl.userImpresso,pl.dataImpresso,pl.userConferido,pl.dataConferido", connection);
                        command.Parameters.AddWithValue("@id", cbox_Produtos.SelectedValue);
                        adapter = new SqlDataAdapter(command);
                        dataSet = new DataSet();
                        connection.Open();
                        adapter.Fill(dataSet, "palete");
                        connection.Close();
                        grid_Paletes.DataSource = dataSet;
                        grid_Paletes.DataMember = "palete";

                        //CAIXA
                        command = new SqlCommand("select pr.nome as 'Produto', cx.lote as 'Lote', cx.fabricacao as 'Fabricação', cx.validade as 'Vailidade', cx.userGerado as 'Gerado por',cx.dataGerado as 'Data Gerado',cx.userImpresso as 'Impresso por',cx.dataImpresso as 'Data Impresso',cx.userConferido as 'Conferido por',cx.dataConferido as 'Data Conferência', count(cx.lote) as 'Quantidade' from palete pl join caixasPalete cp on pl.id = cp.palete_id join carregamento cr on cr.id = pl.carregamento_id join caixa cx on cx.id = cp.caixa_id join produto pr on pr.id = cx.produto_id where pr.id = @id group by cx.id ,cx.sscc, pr.nome, cx.fabricacao, cx.validade, cx.lote, cx.userGerado, cx.dataGerado, cx.userImpresso, cx.dataImpresso, cx.userConferido, cx.dataConferido", connection);
                        command.Parameters.AddWithValue("@id", cbox_Produtos.SelectedValue);
                        adapter = new SqlDataAdapter(command);
                        dataSet = new DataSet();
                        connection.Open();
                        adapter.Fill(dataSet, "caixa");
                        connection.Close();
                        grid_Caixas.DataSource = dataSet;
                        grid_Caixas.DataMember = "caixa";
                    }
                    else if (rbtn_SSCC.Checked && txt_SSCC.Text != "")
                    {
                        //CARREGAMENTO
                        command = new SqlCommand("select cr.codigo as 'Código',cr.expedicao as 'Data Expedição',cr.userGerado as 'Gerado por',cr.dataGerado as 'Data Gerado',cr.userImpresso as 'Impresso por',cr.dataImpresso as 'Data Impresso',cr.userConferido as 'Conferido por',cr.dataConferido as 'Data Conferência' from carregamento cr join palete pl on pl.carregamento_id=cr.id join caixasPalete cp on cp.palete_id=pl.id join caixa cx on cx.id=cp.caixa_id join produto pr on pr.id=cx.produto_id where pl.sscc=@sscc or cx.sscc=@sscc group by cr.id,cr.codigo,cr.expedicao,cr.userGerado,cr.dataGerado,cr.userImpresso,cr.dataImpresso,cr.userConferido,cr.dataConferido", connection);
                        command.Parameters.AddWithValue("@sscc", txt_SSCC.Text);
                        adapter = new SqlDataAdapter(command);
                        connection.Open();
                        adapter.Fill(dataSet, "carregamento");
                        connection.Close();
                        grid_Carregamentos.DataSource = dataSet;
                        grid_Carregamentos.DataMember = "carregamento";

                        //PALETE
                        command = new SqlCommand("select pr.nome as 'Produto', pl.sscc as 'SSCC', pl.palete as 'Tara do Palete', pl.quantidade as 'Quantidade',pl.userGerado as 'Gerado por',pl.dataGerado as 'Data Gerado',pl.userImpresso as 'Impresso por',pl.dataImpresso as 'Data Impresso',pl.userConferido as 'Conferido por',pl.dataConferido as 'Data Conferência' from palete pl join caixasPalete cp on pl.id = cp.palete_id join carregamento cr on cr.id = pl.carregamento_id join caixa cx on cx.id = cp.caixa_id join produto pr on pr.id = cx.produto_id where pl.sscc=@sscc or cx.sscc=@sscc group by pl.id ,pl.sscc, pr.nome, pl.palete, pl.quantidade,pl.userGerado,pl.dataGerado,pl.userImpresso,pl.dataImpresso,pl.userConferido,pl.dataConferido", connection);
                        command.Parameters.AddWithValue("@sscc", txt_SSCC.Text);
                        adapter = new SqlDataAdapter(command);
                        dataSet = new DataSet();
                        connection.Open();
                        adapter.Fill(dataSet, "palete");
                        connection.Close();
                        grid_Paletes.DataSource = dataSet;
                        grid_Paletes.DataMember = "palete";

                        //CAIXA
                        command = new SqlCommand("select pr.nome as 'Produto', cx.lote as 'Lote', cx.fabricacao as 'Fabricação', cx.validade as 'Vailidade', cx.userGerado as 'Gerado por',cx.dataGerado as 'Data Gerado',cx.userImpresso as 'Impresso por',cx.dataImpresso as 'Data Impresso',cx.userConferido as 'Conferido por',cx.dataConferido as 'Data Conferência', count(cx.lote) as 'Quantidade' from palete pl join caixasPalete cp on pl.id = cp.palete_id join carregamento cr on cr.id = pl.carregamento_id join caixa cx on cx.id = cp.caixa_id join produto pr on pr.id = cx.produto_id where pl.sscc=@sscc or cx.sscc=@sscc group by cx.id ,cx.sscc, pr.nome, cx.fabricacao, cx.validade, cx.lote, cx.userGerado, cx.dataGerado, cx.userImpresso, cx.dataImpresso, cx.userConferido, cx.dataConferido", connection);
                        command.Parameters.AddWithValue("@sscc", txt_SSCC.Text);
                        adapter = new SqlDataAdapter(command);
                        dataSet = new DataSet();
                        connection.Open();
                        adapter.Fill(dataSet, "caixa");
                        connection.Close();
                        grid_Caixas.DataSource = dataSet;
                        grid_Caixas.DataMember = "caixa";
                    }
                    else if (rbtn_Usuario.Checked && cbox_Usuario.SelectedIndex >= 0)
                    {
                        //CARREGAMENTO
                        command = new SqlCommand("select cr.codigo as 'Código',cr.expedicao as 'Data Expedição',cr.userGerado as 'Gerado por',cr.dataGerado as 'Data Gerado',cr.userImpresso as 'Impresso por',cr.dataImpresso as 'Data Impresso',cr.userConferido as 'Conferido por',cr.dataConferido as 'Data Conferência' from carregamento cr join palete pl on pl.carregamento_id=cr.id join caixasPalete cp on cp.palete_id=pl.id join caixa cx on cx.id=cp.caixa_id join produto pr on pr.id=cx.produto_id where cr.userGerado=@user or cr.userImpresso=@user or cr.userConferido=@user group by cr.id,cr.codigo,cr.expedicao,cr.userGerado,cr.dataGerado,cr.userImpresso,cr.dataImpresso,cr.userConferido,cr.dataConferido", connection);
                        command.Parameters.AddWithValue("@user", cbox_Usuario.Text);
                        adapter = new SqlDataAdapter(command);
                        connection.Open();
                        adapter.Fill(dataSet, "carregamento");
                        connection.Close();
                        grid_Carregamentos.DataSource = dataSet;
                        grid_Carregamentos.DataMember = "carregamento";

                        //PALETE
                        command = new SqlCommand("select pr.nome as 'Produto', pl.sscc as 'SSCC', pl.palete as 'Tara do Palete', pl.quantidade as 'Quantidade',pl.userGerado as 'Gerado por',pl.dataGerado as 'Data Gerado',pl.userImpresso as 'Impresso por',pl.dataImpresso as 'Data Impresso',pl.userConferido as 'Conferido por',pl.dataConferido as 'Data Conferência' from palete pl join caixasPalete cp on pl.id = cp.palete_id join carregamento cr on cr.id = pl.carregamento_id join caixa cx on cx.id = cp.caixa_id join produto pr on pr.id = cx.produto_id where pl.userGerado=@user or pl.userImpresso=@user or pl.userConferido=@user group by pl.id ,pl.sscc, pr.nome, pl.palete, pl.quantidade,pl.userGerado,pl.dataGerado,pl.userImpresso,pl.dataImpresso,pl.userConferido,pl.dataConferido", connection);
                        command.Parameters.AddWithValue("@user", cbox_Usuario.Text);
                        adapter = new SqlDataAdapter(command);
                        dataSet = new DataSet();
                        connection.Open();
                        adapter.Fill(dataSet, "palete");
                        connection.Close();
                        grid_Paletes.DataSource = dataSet;
                        grid_Paletes.DataMember = "palete";

                        //CAIXA
                        command = new SqlCommand("select pr.nome as 'Produto', cx.lote as 'Lote', cx.fabricacao as 'Fabricação', cx.validade as 'Vailidade', cx.userGerado as 'Gerado por',cx.dataGerado as 'Data Gerado',cx.userImpresso as 'Impresso por',cx.dataImpresso as 'Data Impresso',cx.userConferido as 'Conferido por',cx.dataConferido as 'Data Conferência', count(cx.lote) as 'Quantidade' from palete pl join caixasPalete cp on pl.id = cp.palete_id join carregamento cr on cr.id = pl.carregamento_id join caixa cx on cx.id = cp.caixa_id join produto pr on pr.id = cx.produto_id where cx.userGerado=@user or cx.userImpresso=@user or cx.userConferido=@user group by cx.id ,cx.sscc, pr.nome, cx.fabricacao, cx.validade, cx.lote, cx.userGerado, cx.dataGerado, cx.userImpresso, cx.dataImpresso, cx.userConferido, cx.dataConferido", connection);
                        command.Parameters.AddWithValue("@user", cbox_Usuario.Text);
                        adapter = new SqlDataAdapter(command);
                        dataSet = new DataSet();
                        connection.Open();
                        adapter.Fill(dataSet, "caixa");
                        connection.Close();
                        grid_Caixas.DataSource = dataSet;
                        grid_Caixas.DataMember = "caixa";
                    }
                    else
                    {
                        throw new Exception("Não foi possível fazer a pesquisa, algum campo ficou em branco.");
                    }
                    gbox_Resultado.Enabled = true;
                    btn_Imprimir.Enabled = true;
                }

                //SEPARADO
                else if (result == DialogResult.No)
                {
                    if (rbtn_Carregamento.Checked && txt_Carregamento.Text != "")
                    {
                        //CARREGAMENTO
                        command = new SqlCommand("select codigo as 'Código',expedicao as 'Data Expedição',userGerado as 'Gerado por',dataGerado as 'Data Gerado',userImpresso as 'Impresso por',dataImpresso as 'Data Impresso',userConferido as 'Conferido por',dataConferido as 'Data Conferência' from carregamento where codigo=@codigo group by id,codigo,expedicao,userGerado,dataGerado,userImpresso,dataImpresso,userConferido,dataConferido", connection);
                        command.Parameters.AddWithValue("@codigo", txt_Carregamento.Text);
                        adapter = new SqlDataAdapter(command);
                        connection.Open();
                        adapter.Fill(dataSet, "carregamento");
                        connection.Close();
                        grid_Carregamentos.DataSource = dataSet;
                        grid_Carregamentos.DataMember = "carregamento";

                        //PALETE
                        command = new SqlCommand("select pr.nome as 'Produto', pl.sscc as 'SSCC', pl.palete as 'Tara do Palete', pl.quantidade as 'Quantidade',pl.userGerado as 'Gerado por',pl.dataGerado as 'Data Gerado',pl.userImpresso as 'Impresso por',pl.dataImpresso as 'Data Impresso',pl.userConferido as 'Conferido por',pl.dataConferido as 'Data Conferência' from palete pl join caixasPalete cp on pl.id = cp.palete_id join carregamento cr on cr.id = pl.carregamento_id join caixa cx on cx.id = cp.caixa_id join produto pr on pr.id = cx.produto_id where cr.codigo=@codigo group by pl.id,pl.sscc, pr.nome, pl.palete, pl.quantidade,pl.userGerado,pl.dataGerado,pl.userImpresso,pl.dataImpresso,pl.userConferido,pl.dataConferido", connection);
                        command.Parameters.AddWithValue("@codigo", txt_Carregamento.Text);
                        adapter = new SqlDataAdapter(command);
                        dataSet = new DataSet();
                        connection.Open();
                        adapter.Fill(dataSet, "palete");
                        connection.Close();
                        grid_Paletes.DataSource = dataSet;
                        grid_Paletes.DataMember = "palete";

                        //CAIXA
                        command = new SqlCommand("select pr.nome as 'Produto', cx.sscc as 'SSCC', cx.fabricacao as 'Fabricação', cx.validade as 'Vailidade', cx.lote as 'Lote', cx.userGerado as 'Gerado por',cx.dataGerado as 'Data Gerado',cx.userImpresso as 'Impresso por',cx.dataImpresso as 'Data Impresso',cx.userConferido as 'Conferido por',cx.dataConferido as 'Data Conferência' from palete pl join caixasPalete cp on pl.id = cp.palete_id join carregamento cr on cr.id = pl.carregamento_id join caixa cx on cx.id = cp.caixa_id join produto pr on pr.id = cx.produto_id where cr.codigo = @codigo group by cx.id, cx.sscc, pr.nome, cx.fabricacao, cx.validade, cx.lote, cx.userGerado, cx.dataGerado, cx.userImpresso, cx.dataImpresso, cx.userConferido, cx.dataConferido", connection);
                        command.Parameters.AddWithValue("@codigo", txt_Carregamento.Text);
                        adapter = new SqlDataAdapter(command);
                        dataSet = new DataSet();
                        connection.Open();
                        adapter.Fill(dataSet, "caixa");
                        connection.Close();
                        grid_Caixas.DataSource = dataSet;
                        grid_Caixas.DataMember = "caixa";
                    }
                    else if (rbtn_DataConferido.Checked && date_Conferido.Value != null)
                    {
                        //CARREGAMENTO
                        command = new SqlCommand("select cr.codigo as 'Código',cr.expedicao as 'Data Expedição',cr.userGerado as 'Gerado por',cr.dataGerado as 'Data Gerado',cr.userImpresso as 'Impresso por',cr.dataImpresso as 'Data Impresso',cr.userConferido as 'Conferido por',cr.dataConferido as 'Data Conferência' from carregamento cr join palete pl on pl.carregamento_id=cr.id join caixasPalete cp on cp.palete_id=pl.id join caixa cx on cx.id=cp.caixa_id join produto pr on pr.id=cx.produto_id where cr.dataConferido=@data group by cr.id,cr.codigo,cr.expedicao,cr.userGerado,cr.dataGerado,cr.userImpresso,cr.dataImpresso,cr.userConferido,cr.dataConferido", connection);
                        command.Parameters.AddWithValue("@data", date_Conferido.Value.ToString("dd/MM/yyyy"));
                        adapter = new SqlDataAdapter(command);
                        connection.Open();
                        adapter.Fill(dataSet, "carregamento");
                        connection.Close();
                        grid_Carregamentos.DataSource = dataSet;
                        grid_Carregamentos.DataMember = "carregamento";

                        //PALETE
                        command = new SqlCommand("select pr.nome as 'Produto', pl.sscc as 'SSCC', pl.palete as 'Tara do Palete', pl.quantidade as 'Quantidade',pl.userGerado as 'Gerado por',pl.dataGerado as 'Data Gerado',pl.userImpresso as 'Impresso por',pl.dataImpresso as 'Data Impresso',pl.userConferido as 'Conferido por',pl.dataConferido as 'Data Conferência' from palete pl join caixasPalete cp on pl.id = cp.palete_id join carregamento cr on cr.id = pl.carregamento_id join caixa cx on cx.id = cp.caixa_id join produto pr on pr.id = cx.produto_id where pl.dataConferido=@data group by pl.id ,pl.sscc, pr.nome, pl.palete, pl.quantidade,pl.userGerado,pl.dataGerado,pl.userImpresso,pl.dataImpresso,pl.userConferido,pl.dataConferido", connection);
                        command.Parameters.AddWithValue("@data", date_Conferido.Value.ToString("dd/MM/yyyy"));
                        adapter = new SqlDataAdapter(command);
                        dataSet = new DataSet();
                        connection.Open();
                        adapter.Fill(dataSet, "palete");
                        connection.Close();
                        grid_Paletes.DataSource = dataSet;
                        grid_Paletes.DataMember = "palete";

                        //CAIXA
                        command = new SqlCommand("select pr.nome as 'Produto', cx.sscc as 'SSCC', cx.fabricacao as 'Fabricação', cx.validade as 'Vailidade', cx.lote as 'Lote', cx.userGerado as 'Gerado por',cx.dataGerado as 'Data Gerado',cx.userImpresso as 'Impresso por',cx.dataImpresso as 'Data Impresso',cx.userConferido as 'Conferido por',cx.dataConferido as 'Data Conferência' from palete pl join caixasPalete cp on pl.id = cp.palete_id join carregamento cr on cr.id = pl.carregamento_id join caixa cx on cx.id = cp.caixa_id join produto pr on pr.id = cx.produto_id where cx.dataConferido = @data group by cx.id ,cx.sscc, pr.nome, cx.fabricacao, cx.validade, cx.lote, cx.userGerado, cx.dataGerado, cx.userImpresso, cx.dataImpresso, cx.userConferido, cx.dataConferido", connection);
                        command.Parameters.AddWithValue("@data", date_Conferido.Value.ToString("dd/MM/yyyy"));
                        adapter = new SqlDataAdapter(command);
                        dataSet = new DataSet();
                        connection.Open();
                        adapter.Fill(dataSet, "caixa");
                        connection.Close();
                        grid_Caixas.DataSource = dataSet;
                        grid_Caixas.DataMember = "caixa";
                    }
                    else if (rbtn_DataGerado.Checked && date_Gerado.Value != null)
                    {
                        //CARREGAMENTO
                        command = new SqlCommand("select cr.codigo as 'Código',cr.expedicao as 'Data Expedição',cr.userGerado as 'Gerado por',cr.dataGerado as 'Data Gerado',cr.userImpresso as 'Impresso por',cr.dataImpresso as 'Data Impresso',cr.userConferido as 'Conferido por',cr.dataConferido as 'Data Conferência' from carregamento cr join palete pl on pl.carregamento_id=cr.id join caixasPalete cp on cp.palete_id=pl.id join caixa cx on cx.id=cp.caixa_id join produto pr on pr.id=cx.produto_id where cr.dataGerado=@data group by cr.id,cr.codigo,cr.expedicao,cr.userGerado,cr.dataGerado,cr.userImpresso,cr.dataImpresso,cr.userConferido,cr.dataConferido", connection);
                        command.Parameters.AddWithValue("@data", date_Gerado.Value.ToString("dd/MM/yyyy"));
                        adapter = new SqlDataAdapter(command);
                        connection.Open();
                        adapter.Fill(dataSet, "carregamento");
                        connection.Close();
                        grid_Carregamentos.DataSource = dataSet;
                        grid_Carregamentos.DataMember = "carregamento";

                        //PALETE
                        command = new SqlCommand("select pr.nome as 'Produto', pl.sscc as 'SSCC', pl.palete as 'Tara do Palete', pl.quantidade as 'Quantidade',pl.userGerado as 'Gerado por',pl.dataGerado as 'Data Gerado',pl.userImpresso as 'Impresso por',pl.dataImpresso as 'Data Impresso',pl.userConferido as 'Conferido por',pl.dataConferido as 'Data Conferência' from palete pl join caixasPalete cp on pl.id = cp.palete_id join carregamento cr on cr.id = pl.carregamento_id join caixa cx on cx.id = cp.caixa_id join produto pr on pr.id = cx.produto_id where pl.dataGerado=@data group by pl.id ,pl.sscc, pr.nome, pl.palete, pl.quantidade,pl.userGerado,pl.dataGerado,pl.userImpresso,pl.dataImpresso,pl.userConferido,pl.dataConferido", connection);
                        command.Parameters.AddWithValue("@data", date_Gerado.Value.ToString("dd/MM/yyyy"));
                        adapter = new SqlDataAdapter(command);
                        dataSet = new DataSet();
                        connection.Open();
                        adapter.Fill(dataSet, "palete");
                        connection.Close();
                        grid_Paletes.DataSource = dataSet;
                        grid_Paletes.DataMember = "palete";

                        //CAIXA
                        command = new SqlCommand("select pr.nome as 'Produto', cx.sscc as 'SSCC', cx.fabricacao as 'Fabricação', cx.validade as 'Vailidade', cx.lote as 'Lote', cx.userGerado as 'Gerado por',cx.dataGerado as 'Data Gerado',cx.userImpresso as 'Impresso por',cx.dataImpresso as 'Data Impresso',cx.userConferido as 'Conferido por',cx.dataConferido as 'Data Conferência' from palete pl join caixasPalete cp on pl.id = cp.palete_id join carregamento cr on cr.id = pl.carregamento_id join caixa cx on cx.id = cp.caixa_id join produto pr on pr.id = cx.produto_id where cx.dataGerado = @data group by cx.id ,cx.sscc, pr.nome, cx.fabricacao, cx.validade, cx.lote, cx.userGerado, cx.dataGerado, cx.userImpresso, cx.dataImpresso, cx.userConferido, cx.dataConferido", connection);
                        command.Parameters.AddWithValue("@data", date_Gerado.Value.ToString("dd/MM/yyyy"));
                        adapter = new SqlDataAdapter(command);
                        dataSet = new DataSet();
                        connection.Open();
                        adapter.Fill(dataSet, "caixa");
                        connection.Close();
                        grid_Caixas.DataSource = dataSet;
                        grid_Caixas.DataMember = "caixa";
                    }
                    else if (rbtn_DataImpresso.Checked && date_Impresso.Value != null)
                    {
                        //CARREGAMENTO
                        command = new SqlCommand("select cr.codigo as 'Código',cr.expedicao as 'Data Expedição',cr.userGerado as 'Gerado por',cr.dataGerado as 'Data Gerado',cr.userImpresso as 'Impresso por',cr.dataImpresso as 'Data Impresso',cr.userConferido as 'Conferido por',cr.dataConferido as 'Data Conferência' from carregamento cr join palete pl on pl.carregamento_id=cr.id join caixasPalete cp on cp.palete_id=pl.id join caixa cx on cx.id=cp.caixa_id join produto pr on pr.id=cx.produto_id where cr.dataImpresso=@data group by cr.id,cr.codigo,cr.expedicao,cr.userGerado,cr.dataGerado,cr.userImpresso,cr.dataImpresso,cr.userConferido,cr.dataConferido", connection);
                        command.Parameters.AddWithValue("@data", date_Impresso.Value.ToString("dd/MM/yyyy"));
                        adapter = new SqlDataAdapter(command);
                        connection.Open();
                        adapter.Fill(dataSet, "carregamento");
                        connection.Close();
                        grid_Carregamentos.DataSource = dataSet;
                        grid_Carregamentos.DataMember = "carregamento";

                        //PALETE
                        command = new SqlCommand("select pr.nome as 'Produto', pl.sscc as 'SSCC', pl.palete as 'Tara do Palete', pl.quantidade as 'Quantidade',pl.userGerado as 'Gerado por',pl.dataGerado as 'Data Gerado',pl.userImpresso as 'Impresso por',pl.dataImpresso as 'Data Impresso',pl.userConferido as 'Conferido por',pl.dataConferido as 'Data Conferência' from palete pl join caixasPalete cp on pl.id = cp.palete_id join carregamento cr on cr.id = pl.carregamento_id join caixa cx on cx.id = cp.caixa_id join produto pr on pr.id = cx.produto_id where pl.dataImpresso=@data group by pl.id ,pl.sscc, pr.nome, pl.palete, pl.quantidade,pl.userGerado,pl.dataGerado,pl.userImpresso,pl.dataImpresso,pl.userConferido,pl.dataConferido", connection);
                        command.Parameters.AddWithValue("@data", date_Impresso.Value.ToString("dd/MM/yyyy"));
                        adapter = new SqlDataAdapter(command);
                        dataSet = new DataSet();
                        connection.Open();
                        adapter.Fill(dataSet, "palete");
                        connection.Close();
                        grid_Paletes.DataSource = dataSet;
                        grid_Paletes.DataMember = "palete";

                        //CAIXA
                        command = new SqlCommand("select pr.nome as 'Produto', cx.sscc as 'SSCC', cx.fabricacao as 'Fabricação', cx.validade as 'Vailidade', cx.lote as 'Lote', cx.userGerado as 'Gerado por',cx.dataGerado as 'Data Gerado',cx.userImpresso as 'Impresso por',cx.dataImpresso as 'Data Impresso',cx.userConferido as 'Conferido por',cx.dataConferido as 'Data Conferência' from palete pl join caixasPalete cp on pl.id = cp.palete_id join carregamento cr on cr.id = pl.carregamento_id join caixa cx on cx.id = cp.caixa_id join produto pr on pr.id = cx.produto_id where cx.dataImpresso = @data group by cx.id ,cx.sscc, pr.nome, cx.fabricacao, cx.validade, cx.lote, cx.userGerado, cx.dataGerado, cx.userImpresso, cx.dataImpresso, cx.userConferido, cx.dataConferido", connection);
                        command.Parameters.AddWithValue("@data", date_Impresso.Value.ToString("dd/MM/yyyy"));
                        adapter = new SqlDataAdapter(command);
                        dataSet = new DataSet();
                        connection.Open();
                        adapter.Fill(dataSet, "caixa");
                        connection.Close();
                        grid_Caixas.DataSource = dataSet;
                        grid_Caixas.DataMember = "caixa";
                    }
                    else if (rbtn_Gtin.Checked && txt_Gtin.Text != "")
                    {
                        //CARREGAMENTO
                        command = new SqlCommand("select cr.codigo as 'Código',cr.expedicao as 'Data Expedição',cr.userGerado as 'Gerado por',cr.dataGerado as 'Data Gerado',cr.userImpresso as 'Impresso por',cr.dataImpresso as 'Data Impresso',cr.userConferido as 'Conferido por',cr.dataConferido as 'Data Conferência' from carregamento cr join palete pl on pl.carregamento_id=cr.id join caixasPalete cp on cp.palete_id=pl.id join caixa cx on cx.id=cp.caixa_id join produto pr on pr.id=cx.produto_id where pr.gtin=@gtin group by cr.id,cr.codigo,cr.expedicao,cr.userGerado,cr.dataGerado,cr.userImpresso,cr.dataImpresso,cr.userConferido,cr.dataConferido", connection);
                        command.Parameters.AddWithValue("@gtin", txt_Gtin.Text);
                        adapter = new SqlDataAdapter(command);
                        connection.Open();
                        adapter.Fill(dataSet, "carregamento");
                        connection.Close();
                        grid_Carregamentos.DataSource = dataSet;
                        grid_Carregamentos.DataMember = "carregamento";

                        //PALETE
                        command = new SqlCommand("select pr.nome as 'Produto', pl.sscc as 'SSCC', pl.palete as 'Tara do Palete', pl.quantidade as 'Quantidade',pl.userGerado as 'Gerado por',pl.dataGerado as 'Data Gerado',pl.userImpresso as 'Impresso por',pl.dataImpresso as 'Data Impresso',pl.userConferido as 'Conferido por',pl.dataConferido as 'Data Conferência' from palete pl join caixasPalete cp on pl.id = cp.palete_id join carregamento cr on cr.id = pl.carregamento_id join caixa cx on cx.id = cp.caixa_id join produto pr on pr.id = cx.produto_id where pr.gtin=@gtin group by pl.id ,pl.sscc, pr.nome, pl.palete, pl.quantidade,pl.userGerado,pl.dataGerado,pl.userImpresso,pl.dataImpresso,pl.userConferido,pl.dataConferido", connection);
                        command.Parameters.AddWithValue("@gtin", txt_Gtin.Text);
                        adapter = new SqlDataAdapter(command);
                        dataSet = new DataSet();
                        connection.Open();
                        adapter.Fill(dataSet, "palete");
                        connection.Close();
                        grid_Paletes.DataSource = dataSet;
                        grid_Paletes.DataMember = "palete";

                        //CAIXA
                        command = new SqlCommand("select pr.nome as 'Produto', cx.sscc as 'SSCC', cx.fabricacao as 'Fabricação', cx.validade as 'Vailidade', cx.lote as 'Lote', cx.userGerado as 'Gerado por',cx.dataGerado as 'Data Gerado',cx.userImpresso as 'Impresso por',cx.dataImpresso as 'Data Impresso',cx.userConferido as 'Conferido por',cx.dataConferido as 'Data Conferência' from palete pl join caixasPalete cp on pl.id = cp.palete_id join carregamento cr on cr.id = pl.carregamento_id join caixa cx on cx.id = cp.caixa_id join produto pr on pr.id = cx.produto_id where pr.gtin=@gtin by cx.id ,cx.sscc, pr.nome, cx.fabricacao, cx.validade, cx.lote, cx.userGerado, cx.dataGerado, cx.userImpresso, cx.dataImpresso, cx.userConferido, cx.dataConferido", connection);
                        command.Parameters.AddWithValue("@gtin", txt_Gtin.Text);
                        adapter = new SqlDataAdapter(command);
                        dataSet = new DataSet();
                        connection.Open();
                        adapter.Fill(dataSet, "caixa");
                        connection.Close();
                        grid_Caixas.DataSource = dataSet;
                        grid_Caixas.DataMember = "caixa";
                    }
                    else if (rbtn_Produto.Checked && cbox_Produtos.SelectedIndex >= 0)
                    {
                        //CARREGAMENTO
                        command = new SqlCommand("select cr.codigo as 'Código',cr.expedicao as 'Data Expedição',cr.userGerado as 'Gerado por',cr.dataGerado as 'Data Gerado',cr.userImpresso as 'Impresso por',cr.dataImpresso as 'Data Impresso',cr.userConferido as 'Conferido por',cr.dataConferido as 'Data Conferência' from carregamento cr join palete pl on pl.carregamento_id=cr.id join caixasPalete cp on cp.palete_id=pl.id join caixa cx on cx.id=cp.caixa_id join produto pr on pr.id=cx.produto_id where pr.id=@id group by cr.id,cr.codigo,cr.expedicao,cr.userGerado,cr.dataGerado,cr.userImpresso,cr.dataImpresso,cr.userConferido,cr.dataConferido", connection);
                        command.Parameters.AddWithValue("@id", cbox_Produtos.SelectedValue);
                        adapter = new SqlDataAdapter(command);
                        connection.Open();
                        adapter.Fill(dataSet, "carregamento");
                        connection.Close();
                        grid_Carregamentos.DataSource = dataSet;
                        grid_Carregamentos.DataMember = "carregamento";

                        //PALETE
                        command = new SqlCommand("select pr.nome as 'Produto', pl.sscc as 'SSCC', pl.palete as 'Tara do Palete', pl.quantidade as 'Quantidade',pl.userGerado as 'Gerado por',pl.dataGerado as 'Data Gerado',pl.userImpresso as 'Impresso por',pl.dataImpresso as 'Data Impresso',pl.userConferido as 'Conferido por',pl.dataConferido as 'Data Conferência' from palete pl join caixasPalete cp on pl.id = cp.palete_id join carregamento cr on cr.id = pl.carregamento_id join caixa cx on cx.id = cp.caixa_id join produto pr on pr.id = cx.produto_id where pr.id=@id group by pl.id ,pl.sscc, pr.nome, pl.palete, pl.quantidade,pl.userGerado,pl.dataGerado,pl.userImpresso,pl.dataImpresso,pl.userConferido,pl.dataConferido", connection);
                        command.Parameters.AddWithValue("@id", cbox_Produtos.SelectedValue);
                        adapter = new SqlDataAdapter(command);
                        dataSet = new DataSet();
                        connection.Open();
                        adapter.Fill(dataSet, "palete");
                        connection.Close();
                        grid_Paletes.DataSource = dataSet;
                        grid_Paletes.DataMember = "palete";

                        //CAIXA
                        command = new SqlCommand("select pr.nome as 'Produto', cx.sscc as 'SSCC', cx.fabricacao as 'Fabricação', cx.validade as 'Vailidade', cx.lote as 'Lote', cx.userGerado as 'Gerado por',cx.dataGerado as 'Data Gerado',cx.userImpresso as 'Impresso por',cx.dataImpresso as 'Data Impresso',cx.userConferido as 'Conferido por',cx.dataConferido as 'Data Conferência' from palete pl join caixasPalete cp on pl.id = cp.palete_id join carregamento cr on cr.id = pl.carregamento_id join caixa cx on cx.id = cp.caixa_id join produto pr on pr.id = cx.produto_id where pr.id = @id group by cx.id ,cx.sscc, pr.nome, cx.fabricacao, cx.validade, cx.lote, cx.userGerado, cx.dataGerado, cx.userImpresso, cx.dataImpresso, cx.userConferido, cx.dataConferido", connection);
                        command.Parameters.AddWithValue("@id", cbox_Produtos.SelectedValue);
                        adapter = new SqlDataAdapter(command);
                        dataSet = new DataSet();
                        connection.Open();
                        adapter.Fill(dataSet, "caixa");
                        connection.Close();
                        grid_Caixas.DataSource = dataSet;
                        grid_Caixas.DataMember = "caixa";
                    }
                    else if (rbtn_SSCC.Checked && txt_SSCC.Text != "")
                    {
                        //CARREGAMENTO
                        command = new SqlCommand("select cr.codigo as 'Código',cr.expedicao as 'Data Expedição',cr.userGerado as 'Gerado por',cr.dataGerado as 'Data Gerado',cr.userImpresso as 'Impresso por',cr.dataImpresso as 'Data Impresso',cr.userConferido as 'Conferido por',cr.dataConferido as 'Data Conferência' from carregamento cr join palete pl on pl.carregamento_id=cr.id join caixasPalete cp on cp.palete_id=pl.id join caixa cx on cx.id=cp.caixa_id join produto pr on pr.id=cx.produto_id where pl.sscc=@sscc or cx.sscc=@sscc group by cr.id,cr.codigo,cr.expedicao,cr.userGerado,cr.dataGerado,cr.userImpresso,cr.dataImpresso,cr.userConferido,cr.dataConferido", connection);
                        command.Parameters.AddWithValue("@sscc", txt_SSCC.Text);
                        adapter = new SqlDataAdapter(command);
                        connection.Open();
                        adapter.Fill(dataSet, "carregamento");
                        connection.Close();
                        grid_Carregamentos.DataSource = dataSet;
                        grid_Carregamentos.DataMember = "carregamento";

                        //PALETE
                        command = new SqlCommand("select pr.nome as 'Produto', pl.sscc as 'SSCC', pl.palete as 'Tara do Palete', pl.quantidade as 'Quantidade',pl.userGerado as 'Gerado por',pl.dataGerado as 'Data Gerado',pl.userImpresso as 'Impresso por',pl.dataImpresso as 'Data Impresso',pl.userConferido as 'Conferido por',pl.dataConferido as 'Data Conferência' from palete pl join caixasPalete cp on pl.id = cp.palete_id join carregamento cr on cr.id = pl.carregamento_id join caixa cx on cx.id = cp.caixa_id join produto pr on pr.id = cx.produto_id where pl.sscc=@sscc or cx.sscc=@sscc group by pl.id ,pl.sscc, pr.nome, pl.palete, pl.quantidade,pl.userGerado,pl.dataGerado,pl.userImpresso,pl.dataImpresso,pl.userConferido,pl.dataConferido", connection);
                        command.Parameters.AddWithValue("@sscc", txt_SSCC.Text);
                        adapter = new SqlDataAdapter(command);
                        dataSet = new DataSet();
                        connection.Open();
                        adapter.Fill(dataSet, "palete");
                        connection.Close();
                        grid_Paletes.DataSource = dataSet;
                        grid_Paletes.DataMember = "palete";

                        //CAIXA
                        command = new SqlCommand("select pr.nome as 'Produto', cx.sscc as 'SSCC', cx.fabricacao as 'Fabricação', cx.validade as 'Vailidade', cx.lote as 'Lote', cx.userGerado as 'Gerado por',cx.dataGerado as 'Data Gerado',cx.userImpresso as 'Impresso por',cx.dataImpresso as 'Data Impresso',cx.userConferido as 'Conferido por',cx.dataConferido as 'Data Conferência' from palete pl join caixasPalete cp on pl.id = cp.palete_id join carregamento cr on cr.id = pl.carregamento_id join caixa cx on cx.id = cp.caixa_id join produto pr on pr.id = cx.produto_id where pl.sscc=@sscc or cx.sscc=@sscc group by cx.id ,cx.sscc, pr.nome, cx.fabricacao, cx.validade, cx.lote, cx.userGerado, cx.dataGerado, cx.userImpresso, cx.dataImpresso, cx.userConferido, cx.dataConferido", connection);
                        command.Parameters.AddWithValue("@sscc", txt_SSCC.Text);
                        adapter = new SqlDataAdapter(command);
                        dataSet = new DataSet();
                        connection.Open();
                        adapter.Fill(dataSet, "caixa");
                        connection.Close();
                        grid_Caixas.DataSource = dataSet;
                        grid_Caixas.DataMember = "caixa";
                    }
                    else if (rbtn_Usuario.Checked && cbox_Usuario.SelectedIndex >= 0)
                    {
                        //CARREGAMENTO
                        command = new SqlCommand("select cr.codigo as 'Código',cr.expedicao as 'Data Expedição',cr.userGerado as 'Gerado por',cr.dataGerado as 'Data Gerado',cr.userImpresso as 'Impresso por',cr.dataImpresso as 'Data Impresso',cr.userConferido as 'Conferido por',cr.dataConferido as 'Data Conferência' from carregamento cr join palete pl on pl.carregamento_id=cr.id join caixasPalete cp on cp.palete_id=pl.id join caixa cx on cx.id=cp.caixa_id join produto pr on pr.id=cx.produto_id where cr.userGerado=@user or cr.userImpresso=@user or cr.userConferido=@user group by cr.id,cr.codigo,cr.expedicao,cr.userGerado,cr.dataGerado,cr.userImpresso,cr.dataImpresso,cr.userConferido,cr.dataConferido", connection);
                        command.Parameters.AddWithValue("@user", cbox_Usuario.Text);
                        adapter = new SqlDataAdapter(command);
                        connection.Open();
                        adapter.Fill(dataSet, "carregamento");
                        connection.Close();
                        grid_Carregamentos.DataSource = dataSet;
                        grid_Carregamentos.DataMember = "carregamento";

                        //PALETE
                        command = new SqlCommand("select pr.nome as 'Produto', pl.sscc as 'SSCC', pl.palete as 'Tara do Palete', pl.quantidade as 'Quantidade',pl.userGerado as 'Gerado por',pl.dataGerado as 'Data Gerado',pl.userImpresso as 'Impresso por',pl.dataImpresso as 'Data Impresso',pl.userConferido as 'Conferido por',pl.dataConferido as 'Data Conferência' from palete pl join caixasPalete cp on pl.id = cp.palete_id join carregamento cr on cr.id = pl.carregamento_id join caixa cx on cx.id = cp.caixa_id join produto pr on pr.id = cx.produto_id where pl.userGerado=@user or pl.userImpresso=@user or pl.userConferido=@user group by pl.id ,pl.sscc, pr.nome, pl.palete, pl.quantidade,pl.userGerado,pl.dataGerado,pl.userImpresso,pl.dataImpresso,pl.userConferido,pl.dataConferido", connection);
                        command.Parameters.AddWithValue("@user", cbox_Usuario.Text);
                        adapter = new SqlDataAdapter(command);
                        dataSet = new DataSet();
                        connection.Open();
                        adapter.Fill(dataSet, "palete");
                        connection.Close();
                        grid_Paletes.DataSource = dataSet;
                        grid_Paletes.DataMember = "palete";

                        //CAIXA
                        command = new SqlCommand("select pr.nome as 'Produto', cx.sscc as 'SSCC', cx.fabricacao as 'Fabricação', cx.validade as 'Vailidade', cx.lote as 'Lote', cx.userGerado as 'Gerado por',cx.dataGerado as 'Data Gerado',cx.userImpresso as 'Impresso por',cx.dataImpresso as 'Data Impresso',cx.userConferido as 'Conferido por',cx.dataConferido as 'Data Conferência' from palete pl join caixasPalete cp on pl.id = cp.palete_id join carregamento cr on cr.id = pl.carregamento_id join caixa cx on cx.id = cp.caixa_id join produto pr on pr.id = cx.produto_id where cx.userGerado=@user or cx.userImpresso=@user or cx.userConferido=@user group by cx.id ,cx.sscc, pr.nome, cx.fabricacao, cx.validade, cx.lote, cx.userGerado, cx.dataGerado, cx.userImpresso, cx.dataImpresso, cx.userConferido, cx.dataConferido", connection);
                        command.Parameters.AddWithValue("@user", cbox_Usuario.Text);
                        adapter = new SqlDataAdapter(command);
                        dataSet = new DataSet();
                        connection.Open();
                        adapter.Fill(dataSet, "caixa");
                        connection.Close();
                        grid_Caixas.DataSource = dataSet;
                        grid_Caixas.DataMember = "caixa";
                    }
                    else
                    {
                        throw new Exception("Não foi possível fazer a pesquisa, algum campo ficou em branco.");
                    }
                    gbox_Resultado.Enabled = true;
                    btn_Imprimir.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void btn_Imprimir_Click(object sender, EventArgs e)
        {
            SelectDataGrid form = new SelectDataGrid();
            DialogResult result = form.ShowDialog();
            if (result == DialogResult.OK)
                printRelatorio.Print(grid_Carregamentos);
            else if (result == DialogResult.Yes)
                printRelatorio.Print(grid_Paletes);
            else if (result == DialogResult.Retry)
                printRelatorio.Print(grid_Caixas);
            else
                MessageBox.Show("Erro desconhecido, favor contatar o desenvolvedor do software.", "ERRO!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Rastrear_Load(object sender, EventArgs e)
        {
            UpdateBox();
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
                cbox_Produtos.SelectedIndex = -1;

                cbox_Usuario.Items.Clear();
                command = new SqlCommand("select id,usuario from users", connection);
                adapter = new SqlDataAdapter(command);
                table = new DataTable();
                adapter.Fill(table);
                cbox_Usuario.DataSource = table;
                cbox_Usuario.DisplayMember = table.Columns[1].ToString();
                cbox_Usuario.ValueMember = table.Columns[0].ToString();
                cbox_Usuario.SelectedIndex = -1;
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
