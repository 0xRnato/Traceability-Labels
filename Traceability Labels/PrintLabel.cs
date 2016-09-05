using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Printing;
using System.Drawing;
using System.Windows.Forms;

namespace Traceability_Labels
{
    class PrintLabel
    {
        private static string gtin;
        private static string fabricacao;
        private static string validade;
        private static string lote;
        private static string produto;
        private static string registroProcessador;
        private static string sscc;
        private static string taraEmbalagem;
        private static string taraCaixa;
        private static string taraStrech;
        private static string taraCantoneira;
        private static string cod1;
        private static string cod2;
        private static string cod3;
        private static string quantidade;

        public static void Caixa(string tmp_gtin, string tmp_fabricacao, string tmp_validade, string tmp_lote, string tmp_produto, string tmp_registroProcessador, string tmp_sscc, string tmp_taraEmbalagem, string tmp_taraCaixa, string tmp_cod1, string tmp_cod2, string tmp_cod3)
        {
            gtin = tmp_gtin;
            fabricacao = tmp_fabricacao;
            validade = tmp_validade;
            lote = tmp_lote;
            produto = tmp_produto;
            registroProcessador = tmp_registroProcessador;
            sscc = tmp_sscc;
            taraEmbalagem = tmp_taraEmbalagem;
            taraCaixa = tmp_taraCaixa;
            cod1 = tmp_cod1;
            cod2 = tmp_cod2;
            cod3 = tmp_cod3;

            using (PrintDocument printDoc = new PrintDocument())
            {
                //printDoc.PrintPage += Print_PrintPage;
                //printPreview.Document = printDoc;
                //printPreview.ShowDialog();
                printDoc.PrinterSettings.PrinterName = Global.printerName;
                printDoc.PrintPage += new PrintPageEventHandler(Print_PrintPageCaixa);
                printDoc.Print();

            }
        }

        private static void Print_PrintPageCaixa(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font barcode = new Font("IDAHC39M Code 39 Barcode", 7.7F);
            Font verdana11 = new Font("Verdana", 11);
            Font verdana13 = new Font("Verdana", 13);
            Font verdana8 = new Font("Verdana", 8);
            Pen blackPen = new Pen(Color.Black, 2);

            g.DrawRectangle(blackPen, 0, 0, 430, 640);
            g.DrawString("OF COMÉRCIO DE PRODUTOS ALIMENTÍCIOS LDTA", verdana11, Brushes.Black, 10, 10);
            g.DrawLine(blackPen, 0, 40, 430, 40);
            g.DrawString("GTIN", verdana11, Brushes.Black, 200, 45);
            g.DrawString(gtin, verdana13, Brushes.Black, 130, 65);
            g.DrawLine(blackPen, 0, 90, 430, 90);
            g.DrawString("SELL BY/Data de Validade", verdana11, Brushes.Black, 5, 100);
            g.DrawString(validade, verdana13, Brushes.Black, 65, 125);
            g.DrawString("PROD.DATE/Data de Prod.", verdana11, Brushes.Black, 220, 100);
            g.DrawString(fabricacao, verdana13, Brushes.Black, 265, 125);
            g.DrawLine(blackPen, 215, 90, 215, 230);
            g.DrawLine(blackPen, 0, 160, 430, 160);
            g.DrawLine(blackPen, 0, 230, 430, 230);
            g.DrawString("BATCH/Lote", verdana11, Brushes.Black, 60, 170);
            g.DrawString(lote, verdana13, Brushes.Black, 85, 195);
            g.DrawString("Produto", verdana11, Brushes.Black, 290, 170);
            g.DrawString(produto, verdana13, Brushes.Black, 215, 195);
            g.DrawString("PROCESSADOR #/Nº Registro Processador", verdana11, Brushes.Black, 50, 240);
            g.DrawString(registroProcessador, verdana13, Brushes.Black, 150, 265);
            g.DrawLine(blackPen, 0, 300, 430, 300);
            g.DrawString("SSCC - Código de Série da Unidade Logística", verdana11, Brushes.Black, 40, 310);
            g.DrawString(sscc, verdana13, Brushes.Black, 115, 335);
            g.DrawLine(blackPen, 0, 370, 430, 370);
            g.DrawString("Packaging Tare / Tara da Embalagem = " + taraEmbalagem + " Kg", verdana8, Brushes.Black, 15, 380);
            g.DrawString("Box Tare / Tara da Caixa = " + taraCaixa + " Kg", verdana8, Brushes.Black, 15, 400);
            g.DrawString("Total Tare / Tara Total = " + (Convert.ToDecimal(taraCaixa) + Convert.ToDecimal(taraEmbalagem)) + " Kg", verdana8, Brushes.Black, 15, 420);
            g.DrawLine(blackPen, 0, 445, 430, 445);
            g.DrawString(cod1, barcode, Brushes.Black, 15, 460);
            g.DrawString(cod2, barcode, Brushes.Black, 108, 520);
            g.DrawString(cod3, barcode, Brushes.Black, 105, 580);
        }

        public static void Palete(string tmp_gtin, string tmp_fabricacao, string tmp_validade, string tmp_lote, string tmp_produto, string tmp_registroProcessador, string tmp_sscc, string tmp_taraEmbalagem, string tmp_taraCaixa, string tmp_taraStrech, string tmp_TaraCantoneira, string tmp_cod1, string tmp_cod2, string tmp_cod3, string tmp_Quantidade)
        {
            gtin = tmp_gtin;
            fabricacao = tmp_fabricacao;
            validade = tmp_validade;
            lote = tmp_lote;
            produto = tmp_produto;
            registroProcessador = tmp_registroProcessador;
            sscc = tmp_sscc;
            taraEmbalagem = tmp_taraEmbalagem;
            taraCaixa = tmp_taraCaixa;
            taraStrech = tmp_taraStrech;
            taraCantoneira = tmp_TaraCantoneira;
            cod1 = tmp_cod1;
            cod2 = tmp_cod2;
            cod3 = tmp_cod3;
            quantidade = tmp_Quantidade;

            using (PrintDocument printDoc = new PrintDocument())
            {
                //PrintPreviewDialog printPreview = new PrintPreviewDialog();
                //printDoc.PrintPage += Print_PrintPagePalete;
                //printPreview.Document = printDoc;
                //printPreview.ShowDialog();
                printDoc.PrinterSettings.PrinterName = Global.printerName;
                printDoc.PrintPage += new PrintPageEventHandler(Print_PrintPagePalete);
                printDoc.Print();

            }
        }

        private static void Print_PrintPagePalete(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font barcode = new Font("IDAHC39M Code 39 Barcode", 7.7F);
            Font verdana11 = new Font("Verdana", 11);
            Font verdana13 = new Font("Verdana", 13);
            Font verdana8 = new Font("Verdana", 8);
            Pen blackPen = new Pen(Color.Black, 2);

            g.DrawRectangle(blackPen, 0, 0, 430, 650);
            g.DrawString("OF COMÉRCIO DE PRODUTOS ALIMENTÍCIOS LDTA", verdana11, Brushes.Black, 10, 10);
            g.DrawLine(blackPen, 0, 40, 430, 40);
            g.DrawString("CONTENT/Conteúdo", verdana11, Brushes.Black, 25, 45);
            g.DrawString(gtin, verdana13, Brushes.Black, 25, 65);
            g.DrawString("COUNT/Quantidade", verdana11, Brushes.Black, 30, 100);
            g.DrawString(quantidade, verdana13, Brushes.Black, 90, 125);
            g.DrawLine(blackPen, 0, 95, 430, 95);
            g.DrawString("SELL BY/Data de Validade", verdana11, Brushes.Black, 220, 45);
            g.DrawString(validade, verdana13, Brushes.Black, 265, 65);
            g.DrawString("PROD.DATE/Data de Prod.", verdana11, Brushes.Black, 220, 100);
            g.DrawString(fabricacao, verdana13, Brushes.Black, 265, 125);
            g.DrawLine(blackPen, 215, 40, 215, 230);
            g.DrawLine(blackPen, 0, 160, 430, 160);
            g.DrawLine(blackPen, 0, 230, 430, 230);
            g.DrawString("BATCH/Lote", verdana11, Brushes.Black, 60, 170);
            g.DrawString(lote, verdana13, Brushes.Black, 85, 195);
            g.DrawString("Produto", verdana11, Brushes.Black, 290, 170);
            g.DrawString(produto, verdana13, Brushes.Black, 215, 195);
            g.DrawString("PROCESSADOR #/Nº Registro Processador", verdana11, Brushes.Black, 50, 240);
            g.DrawString(registroProcessador, verdana13, Brushes.Black, 150, 265);
            g.DrawLine(blackPen, 0, 300, 430, 300);
            g.DrawString("SSCC - Código de Série da Unidade Logística", verdana11, Brushes.Black, 40, 310);
            g.DrawString(sscc, verdana13, Brushes.Black, 115, 335);
            g.DrawLine(blackPen, 0, 370, 430, 370);
            g.DrawString("Packaging Tare / Tara da Embalagem = " + taraEmbalagem + " Kg", verdana8, Brushes.Black, 15, 380);
            g.DrawString("Box Tare / Tara da Caixa = " + taraCaixa + " Kg", verdana8, Brushes.Black, 15, 400);
            g.DrawString("Strech Tare / Tara do Strech = " + taraStrech + " Kg", verdana8, Brushes.Black, 15, 420);
            g.DrawString("Corner Tare / Tara da Cantoneira = " + taraCantoneira + " Kg", verdana8, Brushes.Black, 15, 440);
            string totalTare = ((Convert.ToDecimal(taraCaixa) + Convert.ToDecimal(taraEmbalagem) + Convert.ToDecimal(taraStrech) + Convert.ToDecimal(taraCantoneira))).ToString();
            g.DrawString("Total Tare / Tara Total = " + totalTare + " Kg", verdana8, Brushes.Black, 15, 460);
            g.DrawLine(blackPen, 0, 485, 430, 485);
            g.DrawString(cod1, barcode, Brushes.Black, 15, 500);
            g.DrawString(cod2, barcode, Brushes.Black, 125, 550);
            g.DrawString(cod3, barcode, Brushes.Black, 105, 600);
        }
    }
}