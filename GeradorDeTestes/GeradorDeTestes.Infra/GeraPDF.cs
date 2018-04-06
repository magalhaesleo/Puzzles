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
        private Teste _teste;
        private List<Resposta> gabarito;
        public Teste Teste { get { return this._teste; } set {this._teste = value; } }

        public List<Resposta> Gabarito { get => gabarito; set => gabarito = value; }

        public GeraPDF(Teste teste, List<Resposta> gabarito)
        {
            Teste = teste;
            Gabarito = gabarito;
        }
        public void TesteToPDF (string path)
        {
            //PdfPTable[] tables = new PdfPTable[2];
            //tables[0] = booksToTable();
            //tables[1] = rentsToTable();
            createDocument(path);
        }

        public void GeraGabarito(string path)
        {
            Document doc = new Document(PageSize.A4);//criando e estipulando o tipo da folha usada
            doc.SetMargins(40, 40, 40, 80);//estibulando o espaçamento das margens que queremos
            doc.AddCreationDate();//adicionando as configuracoes

            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));
            doc.Open();

            foreach (var paragrafoAtual in GabaritoToPDF())
            {
                doc.Add(paragrafoAtual);
            }

            doc.Close();
        }

        private List<Paragraph> GabaritoToPDF()
        {
            List<Paragraph> ListParagrafosGabarito = new List<Paragraph>();
            var subTitleFont = FontFactory.GetFont("Arial", 14, Font.BOLD);
            var bodyFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);
            Paragraph paragraphGabarito = new Paragraph(string.Format("Gabarito do Teste - {0}", Teste.Nome), subTitleFont);
            paragraphGabarito.Alignment = Element.ALIGN_CENTER;
            ListParagrafosGabarito.Add(paragraphGabarito);

            foreach (var item in gabarito)
            {
                paragraphGabarito = new Paragraph("", bodyFont);
                paragraphGabarito.Alignment = Element.ALIGN_JUSTIFIED;
                paragraphGabarito.Add(String.Format("\n{0} - {1}", item.Numero, item.Letra));
                ListParagrafosGabarito.Add(paragraphGabarito);
            }

            return ListParagrafosGabarito;
        }

        //public void booksToPDF(string path)
        //{
        //    PdfPTable[] tables = new PdfPTable[1];
        //    tables[0] = booksToTable();
        //    createDocument(tables, path);
        //}


        private void createDocument(string path)
        {
           
            Document doc = new Document(PageSize.A4);//criando e estipulando o tipo da folha usada
            doc.SetMargins(40, 40, 40, 80);//estibulando o espaçamento das margens que queremos
            doc.AddCreationDate();//adicionando as configuracoes

            //Cofiguração das fontes
            var titleFont = FontFactory.GetFont("Arial", 18, Font.BOLD);
            var subTitleFont = FontFactory.GetFont("Arial", 14, Font.BOLD);
            //var boldTableFont = FontFactory.GetFont("Arial", 12, Font.BOLD);
            //var endingMessageFont = FontFactory.GetFont("Arial", 10, Font.ITALIC);
            var bodyFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);

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


            texto = "\n{0}ª Série";
            texto += "\nDisciplina: {1}";
            texto += "\nMatéria: {2}";

            texto = String.Format(texto, Teste.Questoes[0].Materia.Serie.Numero, Teste.Questoes[0].Materia.Disciplina.Nome, Teste.Materia.Nome);

            p.Add(texto);
            doc.Add(p);

            Paragraph titulo = new Paragraph(Teste.Nome, titleFont);
            titulo.Alignment = Element.ALIGN_CENTER;
            doc.Add(titulo);

            //Espaço em Branco
            doc.Add(new Paragraph("\n", bodyFont));

            //Questões
            for (int x = 0; x < Teste.Questoes.Count; x++)
            {
                var questao = Teste.Questoes[x];
                doc.Add(new Paragraph(string.Format("Questão {0}:  ", x + 1), subTitleFont));

                //Enunciado
                p = new Paragraph(questao.Enunciado, bodyFont);

                p.Alignment = Element.ALIGN_JUSTIFIED;
                doc.Add(p);

                //Espaço em Branco
                doc.Add(new Paragraph("\n", bodyFont));

                //Reposta
                foreach (Alternativa alternativa in questao.Alternativas)
                {
                    doc.Add(new Paragraph(string.Format("({0})  {1}", alternativa.Letra, alternativa.Enunciado), bodyFont));
                }
                //Espaço em Branco
                doc.Add(new Paragraph("\n", bodyFont));
            }


            doc.NewPage();

            var listParagrafosGabaritos = GabaritoToPDF();

            foreach (var paragrafoAtual in listParagrafosGabaritos)
            {
                doc.Add(paragrafoAtual);
            }

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

