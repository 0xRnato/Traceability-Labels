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

        public static void Caixa(string tmp_gtin, string tmp_fabricacao, string tmp_validade, string tmp_lote, string tmp_produto, string tmp_registroProcessador, string tmp_sscc, string tmp_taraEmbalagem, string tmp_taraCaixa, string tmp_cod1, string tmp_cod2, string tmp_cod3, bool rePrint)
        {
            gtin = tmp_gtin;
            fabricacao = tmp_fabricacao;
            validade = tmp_validade;
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
                if (rePrint)
                {
                    PrintPreviewDialog printPreview = new PrintPreviewDialog();
                    printDoc.PrintPage += Print_PrintPageCaixa;
                    printPreview.Document = printDoc;
                    printPreview.ShowDialog();
                }
                else
                {
                    printDoc.PrinterSettings.PrinterName = Global.printerName;
                    printDoc.PrintPage += new PrintPageEventHandler(Print_PrintPageCaixa);
                    printDoc.Print();
                }
            }
        }

        private static void Print_PrintPageCaixa(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font barcode = new Font("IDAHC39M Code 39 Barcode", 10);
            Font verdana11 = new Font("Verdana", 11);
            Font verdana13 = new Font("Verdana", 13);
            Font verdana8 = new Font("Verdana", 8);
            Font verdana5 = new Font("Verdana", 5.5F);
            Pen blackPen = new Pen(Color.Black, 2);

            g.DrawRectangle(blackPen, 0, 30, 600, 342);

            g.DrawLine(blackPen, 0, 60, 600, 60);//Horizontal 1
            g.DrawLine(blackPen, 0, 90, 600, 90);//Horizontal 2
            g.DrawLine(blackPen, 0, 120, 600, 120);//Horizontal 3
            g.DrawLine(blackPen, 0, 150, 600, 150);//Horizontal 4
            g.DrawLine(blackPen, 160, 120, 160, 60);//Vertical 1
            g.DrawLine(blackPen, 325, 120, 325, 60);//vertical 2

            g.DrawString("OF COMÉRCIO DE PRODUTOS ALIMENTÍCIOS LTDA", verdana8, Brushes.Black, 150, 40);
            g.DrawString("GTIN", verdana5, Brushes.Black, 75, 65);
            g.DrawString(gtin, verdana5, Brushes.Black, 50, 75);
            g.DrawString("SELL BY/Data de Validade", verdana5, Brushes.Black, 185, 95);
            g.DrawString(Convert.ToDateTime(validade).ToString("dd/MM/yy"), verdana5, Brushes.Black, 220, 105);
            g.DrawString("PROD.DATE/Data de Prod.", verdana5, Brushes.Black, 30, 95);
            g.DrawString(Convert.ToDateTime(fabricacao).ToString("dd/MM/yy"), verdana5, Brushes.Black, 60, 105);
            g.DrawString("BATCH/Lote", verdana5, Brushes.Black, 430, 95);
            g.DrawString(lote, verdana5, Brushes.Black, 445, 105);
            g.DrawString("Produto", verdana5, Brushes.Black, 220, 65);
            g.DrawString(produto, verdana5, Brushes.Black, 200, 75);
            g.DrawString("PROCESSADOR #/Nº Registro Processador", verdana5, Brushes.Black, 370, 65);
            g.DrawString(registroProcessador, verdana5, Brushes.Black, 435, 75);
            g.DrawString("SSCC - Código de Série da Unidade Logística", verdana5, Brushes.Black, 195, 125);
            g.DrawString(sscc, verdana5, Brushes.Black, 250, 135);
            g.DrawString("Packaging Tare / Tara da Embalagem = " + taraEmbalagem + " Kg", verdana8, Brushes.Black, 310, 250);
            g.DrawString("Box Tare / Tara da Caixa = " + taraCaixa + " Kg", verdana8, Brushes.Black, 310, 270);
            g.DrawString("Total Tare / Tara Total = " + (Convert.ToDecimal(taraCaixa) + Convert.ToDecimal(taraEmbalagem)) + " Kg", verdana8, Brushes.Black, 310, 290);

            g.DrawString(cod1, barcode, Brushes.Black, 20, 160);
            g.DrawString(cod2, barcode, Brushes.Black, 20, 220);
            g.DrawString(cod3, barcode, Brushes.Black, 20, 280);
        }

        public static void Palete(string tmp_gtin, string tmp_fabricacao, string tmp_validade, string tmp_lote, string tmp_produto, string tmp_registroProcessador, string tmp_sscc, string tmp_taraEmbalagem, string tmp_taraCaixa, string tmp_taraPalete, string tmp_taraStrech, string tmp_TaraCantoneira, string tmp_cod1, string tmp_cod2, string tmp_cod3, string tmp_Quantidade, bool rePrint)
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
                if (rePrint)
                {
                    PrintPreviewDialog printPreview = new PrintPreviewDialog();
                    printDoc.PrintPage += Print_PrintPagePalete;
                    printPreview.Document = printDoc;
                    printPreview.ShowDialog();
                }
                else
                {
                    printDoc.PrinterSettings.PrinterName = Global.printerName;
                    printDoc.PrintPage += new PrintPageEventHandler(Print_PrintPagePalete);
                    printDoc.Print();
                }
            }
        }

        private static void Print_PrintPagePalete(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font barcode = new Font("IDAHC39M Code 39 Barcode", 10);
            Font verdana11 = new Font("Verdana", 11);
            Font verdana13 = new Font("Verdana", 13);
            Font verdana8 = new Font("Verdana", 8);
            Font verdana5 = new Font("Verdana", 5.5F);
            Pen blackPen = new Pen(Color.Black, 2);
            string totalTare = ((Convert.ToDecimal(taraCaixa) + Convert.ToDecimal(taraEmbalagem) + Convert.ToDecimal(taraStrech) + Convert.ToDecimal(taraCantoneira) + Convert.ToDecimal(taraPalete))).ToString();

            g.DrawRectangle(blackPen, 0, 30, 600, 342);

            g.DrawLine(blackPen, 0, 60, 600, 60);//Horizontal 1
            g.DrawLine(blackPen, 0, 90, 600, 90);//Horizontal 2
            g.DrawLine(blackPen, 0, 120, 600, 120);//Horizontal 3
            g.DrawLine(blackPen, 0, 150, 600, 150);//Horizontal 4
            g.DrawLine(blackPen, 160, 120, 160, 60);//Vertical 1
            g.DrawLine(blackPen, 325, 150, 325, 60);//vertical 2

            g.DrawString("OF COMÉRCIO DE PRODUTOS ALIMENTÍCIOS LTDA", verdana8, Brushes.Black, 150, 40);
            g.DrawString("GTIN", verdana5, Brushes.Black, 75, 65);
            g.DrawString(gtin, verdana5, Brushes.Black, 50, 75);
            g.DrawString("SELL BY/Data de Validade", verdana5, Brushes.Black, 185, 95);
            g.DrawString(Convert.ToDateTime(validade).ToString("dd/MM/yy"), verdana5, Brushes.Black, 220, 105);
            g.DrawString("PROD.DATE/Data de Prod.", verdana5, Brushes.Black, 30, 95);
            g.DrawString(Convert.ToDateTime(fabricacao).ToString("dd/MM/yy"), verdana5, Brushes.Black, 60, 105);
            g.DrawString("BATCH/Lote", verdana5, Brushes.Black, 430, 95);
            g.DrawString(lote, verdana5, Brushes.Black, 445, 105);
            g.DrawString("Produto", verdana5, Brushes.Black, 220, 65);
            g.DrawString(produto, verdana5, Brushes.Black, 200, 75);
            g.DrawString("PROCESSADOR #/Nº Registro Processador", verdana5, Brushes.Black, 370, 125);
            g.DrawString(registroProcessador, verdana5, Brushes.Black, 435, 135);
            g.DrawString("SSCC - Código de Série da Unidade Logística", verdana5, Brushes.Black, 65, 125);
            g.DrawString(sscc, verdana5, Brushes.Black, 115, 135);
            g.DrawString("COUNT/Quantidade", verdana5, Brushes.Black, 415, 65);
            g.DrawString(quantidade, verdana5, Brushes.Black, 450, 75);

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