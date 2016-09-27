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
        private static string taraPalete;
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
                //PrintPreviewDialog printPreview = new PrintPreviewDialog();
                //printDoc.PrintPage += Print_PrintPageCaixa;
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
            Font barcode = new Font("IDAHC39M Code 39 Barcode", 10);
            Font verdana11 = new Font("Verdana", 11);
            Font verdana13 = new Font("Verdana", 13);
            Font verdana8 = new Font("Verdana", 8);
            Pen blackPen = new Pen(Color.Black, 2);

            g.DrawRectangle(blackPen, 0, 0, 600, 342);

            g.DrawLine(blackPen, 0, 30, 600, 30);
            g.DrawLine(blackPen, 0, 70, 600, 70);
            g.DrawLine(blackPen, 0, 110, 600, 110);
            g.DrawLine(blackPen, 0, 150, 600, 150);
            g.DrawLine(blackPen, 160, 110, 160, 30);
            g.DrawLine(blackPen, 325, 110, 325, 30);

            g.DrawString("OF COMÉRCIO DE PRODUTOS ALIMENTÍCIOS LTDA", verdana8, Brushes.Black, 150, 10);
            g.DrawString("GTIN", verdana8, Brushes.Black, 50, 35);
            g.DrawString(gtin, verdana8, Brushes.Black, 20, 50);
            g.DrawString("SELL BY/Data de Validade", verdana8, Brushes.Black, 165, 75);
            g.DrawString(validade, verdana8, Brushes.Black, 215, 90);
            g.DrawString("PROD.DATE/Data de Prod.", verdana8, Brushes.Black, 5, 75);
            g.DrawString(fabricacao, verdana8, Brushes.Black, 50, 90);
            g.DrawString("BATCH/Lote", verdana8, Brushes.Black, 420, 75);
            g.DrawString(lote, verdana8, Brushes.Black, 445, 90);
            g.DrawString("Produto", verdana8, Brushes.Black, 220, 35);
            g.DrawString(produto, verdana8, Brushes.Black, 180, 50);
            g.DrawString("PROCESSADOR #/Nº Registro Processador", verdana8, Brushes.Black, 330, 35);
            g.DrawString(registroProcessador, verdana8, Brushes.Black, 425, 50);
            g.DrawString("SSCC - Código de Série da Unidade Logística", verdana8, Brushes.Black, 175, 115);
            g.DrawString(sscc, verdana8, Brushes.Black, 235, 130);
            g.DrawString("Packaging Tare / Tara da Embalagem = " + taraEmbalagem + " Kg", verdana8, Brushes.Black, 310, 250);
            g.DrawString("Box Tare / Tara da Caixa = " + taraCaixa + " Kg", verdana8, Brushes.Black, 310, 270);
            g.DrawString("Total Tare / Tara Total = " + (Convert.ToDecimal(taraCaixa) + Convert.ToDecimal(taraEmbalagem)) + " Kg", verdana8, Brushes.Black, 310, 290);

            g.DrawString(cod1, barcode, Brushes.Black, 20, 160);
            g.DrawString(cod2, barcode, Brushes.Black, 20, 220);
            g.DrawString(cod3, barcode, Brushes.Black, 20, 280);
        }

        public static void Palete(string tmp_gtin, string tmp_fabricacao, string tmp_validade, string tmp_lote, string tmp_produto, string tmp_registroProcessador, string tmp_sscc, string tmp_taraEmbalagem, string tmp_taraCaixa, string tmp_taraPalete, string tmp_taraStrech, string tmp_TaraCantoneira, string tmp_cod1, string tmp_cod2, string tmp_cod3, string tmp_Quantidade)
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
            taraPalete = tmp_taraPalete;
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
            Font barcode = new Font("IDAHC39M Code 39 Barcode", 10);
            Font verdana11 = new Font("Verdana", 11);
            Font verdana13 = new Font("Verdana", 13);
            Font verdana8 = new Font("Verdana", 8);
            Pen blackPen = new Pen(Color.Black, 2);
            string totalTare = ((Convert.ToDecimal(taraCaixa) + Convert.ToDecimal(taraEmbalagem) + Convert.ToDecimal(taraStrech) + Convert.ToDecimal(taraCantoneira) + Convert.ToDecimal(taraPalete))).ToString();

            g.DrawRectangle(blackPen, 0, 0, 600, 342);

            g.DrawLine(blackPen, 0, 30, 600, 30);
            g.DrawLine(blackPen, 0, 70, 600, 70);
            g.DrawLine(blackPen, 0, 110, 600, 110);
            g.DrawLine(blackPen, 0, 150, 600, 150);
            g.DrawLine(blackPen, 160, 110, 160, 30);
            g.DrawLine(blackPen, 325, 150, 325, 30);

            g.DrawString("OF COMÉRCIO DE PRODUTOS ALIMENTÍCIOS LTDA", verdana8, Brushes.Black, 150, 10);
            g.DrawString("GTIN", verdana8, Brushes.Black, 50, 35);
            g.DrawString(gtin, verdana8, Brushes.Black, 20, 50);
            g.DrawString("SELL BY/Data de Validade", verdana8, Brushes.Black, 165, 75);
            g.DrawString(validade, verdana8, Brushes.Black, 215, 90);
            g.DrawString("PROD.DATE/Data de Prod.", verdana8, Brushes.Black, 5, 75);
            g.DrawString(fabricacao, verdana8, Brushes.Black, 50, 90);
            g.DrawString("BATCH/Lote", verdana8, Brushes.Black, 420, 75);
            g.DrawString(lote, verdana8, Brushes.Black, 445, 90);
            g.DrawString("Produto", verdana8, Brushes.Black, 220, 35);
            g.DrawString(produto, verdana8, Brushes.Black, 180, 50);
            g.DrawString("PROCESSADOR #/Nº Registro Processador", verdana8, Brushes.Black, 340, 115);
            g.DrawString(registroProcessador, verdana8, Brushes.Black, 435, 130);
            g.DrawString("SSCC - Código de Série da Unidade Logística", verdana8, Brushes.Black, 35, 115);
            g.DrawString(sscc, verdana8, Brushes.Black, 95, 130);
            g.DrawString("COUNT/Quantidade", verdana8, Brushes.Black, 405, 35);
            g.DrawString(quantidade, verdana8, Brushes.Black, 450, 50);

            g.DrawString("Packaging Tare / Tara da Embalagem = " + taraEmbalagem + " Kg", verdana8, Brushes.Black, 300, 220);
            g.DrawString("Box Tare / Tara da Caixa = " + taraCaixa + " Kg", verdana8, Brushes.Black, 300, 240);
            g.DrawString("Pallet Tare / Tara do palete = " + taraPalete + " Kg", verdana8, Brushes.Black, 300, 260);
            g.DrawString("Strech Tare / Tara do Strech = " + taraStrech + " Kg", verdana8, Brushes.Black, 300, 280);
            g.DrawString("Corner Tare / Tara da Cantoneira = " + taraCantoneira + " Kg", verdana8, Brushes.Black, 300, 300);
            g.DrawString("Total Tare / Tara Total = " + totalTare + " Kg", verdana8, Brushes.Black, 300, 320);

            g.DrawString(cod1, barcode, Brushes.Black, 20, 160);
            g.DrawString(cod2, barcode, Brushes.Black, 20, 220);
            g.DrawString(cod3, barcode, Brushes.Black, 20, 280);
        }
    }
}