using GeradorDeTestes.Domain.Entidades;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeTestes.Infra
{
    public class GeraPDF
    {
        public void TesteToPDF(Teste teste, List<Resposta> gabarito, string path)
        {
            //PdfPTable[] tables = new PdfPTable[2];
            //tables[0] = booksToTable();
            //tables[1] = rentsToTable();
            createDocument(teste, path);
        }

        public void GabaritoToPDF(string path, List<Resposta> gabarito)
        {

        }

        //public void booksToPDF(string path)
        //{
        //    PdfPTable[] tables = new PdfPTable[1];
        //    tables[0] = booksToTable();
        //    createDocument(tables, path);
        //}


        private void createDocument(Teste teste, string path)
        {
            Document doc = new Document(PageSize.A4);//criando e estipulando o tipo da folha usada
            doc.SetMargins(40, 40, 40, 80);//estibulando o espaçamento das margens que queremos
            doc.AddCreationDate();//adicionando as configuracoes

            //criando o arquivo pdf embranco, passando como parametro a variavel doc criada acima e a variavel path 
            //tambem criada acima.
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));

            doc.Open();


            //criando a variavel para paragrafo
            Paragraph paragrafo = new Paragraph("", new Font(Font.NORMAL, 14));
            //etipulando o alinhamneto
            paragrafo.Alignment = Element.ALIGN_LEFT; //Alinhamento Justificado
                                                      //adicioando texto

            //AQUI ONDE VAMOS ADICIONAR A VARIAVEL DO TIPO "Font"
            paragrafo.Font = new Font(Font.NORMAL, 14, (int)System.Drawing.FontStyle.Regular);

            string texto = "Nome: _______________________________________________________________________";
            texto += "\nData: ____/____/________";

            Chunk glue = new Chunk(new VerticalPositionMark());
            Paragraph p = new Paragraph(texto);
            p.Add(new Chunk(glue));
            p.Add("Nota: ____");


            texto = "\n1ª Série (substituir com variável)";
            texto += "\nDisciplina: (substituir com variável)";
            texto += "\nMatéria: (substituir com variável)";

            p.Add(texto);
            doc.Add(p);



            //texto += booksToString();
            //texto += rentsToString();

            //fechando documento para que seja salva as alteraçoes.

            //adicionando outro paragrafo com o texto, para que seja feita a quebra de pagina.
            paragrafo = new Paragraph("", new Font(Font.NORMAL, 14));
            paragrafo.Alignment = Element.ALIGN_JUSTIFIED; //Alinhamento Justificado
            paragrafo.Font = new Font(Font.NORMAL, 14, (int)System.Drawing.FontStyle.Regular);
            paragrafo.Add(texto);
            //doc.Add(paragrafo);

            Paragraph paragrafoDireita = new Paragraph("", new Font(Font.NORMAL, 14));
            paragrafoDireita.Alignment = Element.ALIGN_RIGHT;

            string textoDireita = "Nota:";
            //paragrafoDireita.Add(textoDireita);
            //doc.Add(paragrafoDireita);


            /*
            Chunk glue = new Chunk(new VerticalPositionMark());
            Paragraph p = new Paragraph("Nome:");
            p.Add(new Chunk(glue));
            p.Add("Nota:");
            doc.Add(p);

            glue = new Chunk(new VerticalPositionMark());
            p = new Paragraph("Matéria:");
            p.Add(new Chunk(glue));
            //p.Add("");
            doc.Add(p);

            glue = new Chunk(new VerticalPositionMark());
            p = new Paragraph("Disciplina:");
            p.Add(new Chunk(glue));
            p.Add("Série:");
            doc.Add(p);
            */


            //for (int i = 0; i < tables.Length; i++)
            //{
            //    doc.Add(tables[i]);
            //}

            doc.Close();
            //Abrindo o arquivo após cria-lo.
            System.Diagnostics.Process.Start(path);

        }

        //public string booksToString()
        //{
        //    //return _bookDAO.GetAll().ToString();

        //    string books = "Book List:\n";

        //    foreach (var item in _bookDAO.GetAll())
        //    {
        //        books += "\n\nId: " + item.Id
        //            + " - Title: " + item.Title
        //            + " - Theme: " + item.Theme
        //            + " - Author: " + item.Author
        //            + " - Volume: " + item.Volume
        //            + " - Publish Date: " + item.PublishDate
        //            + " - Is Available: " + item.IsAvailable;
        //    }

        //    return books;

        //}

        //public PdfPTable booksToTable()
        //{
        //    float[] widths = new float[] { 40f, 180f, 70f, 110f, 55f, 90f, 70f };

        //    PdfPTable table = new PdfPTable(7);
        //    PdfPCell cell = new PdfPCell(new Phrase("Book List"));
        //    cell.Colspan = 7;
        //    cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right   
        //    table.AddCell(cell);
        //    table.SetWidths(widths);
        //    table.TotalWidth = 550f;
        //    table.LockedWidth = true;

        //    table.SpacingBefore = 20f;
        //    table.SpacingAfter = 20f;

        //    table.AddCell("ID");
        //    table.AddCell("Title");
        //    table.AddCell("Theme");
        //    table.AddCell("Author");
        //    table.AddCell("Volume");
        //    table.AddCell("Publish Date");
        //    table.AddCell("Available");

        //    foreach (var item in _bookDAO.GetAll())
        //    {
        //        table.AddCell(item.Id.ToString());
        //        table.AddCell(item.Title);
        //        table.AddCell(item.Theme);
        //        table.AddCell(item.Author);
        //        table.AddCell(item.Volume.ToString());
        //        table.AddCell(item.PublishDate.ToString());
        //        table.AddCell(item.IsAvailable.ToString());
        //    }

        //    return table;

        //}

    }
}

