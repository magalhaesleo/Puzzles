﻿using CsvHelper;
using GeradorDeTestes.Domain.Entidades;
using GeradorDeTestes.Infra.CSV;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeTestes.Infra.Exportação
{
    public class ExportarTesteParaArquivo : ExportarParaArquivo<Teste>
    {

        public override void GerarCSV(Teste teste, string path)
        {
            using (StreamWriter writer = new StreamWriter(path, false, Encoding.UTF8))
            {
                CsvWriter csvWriter = new CsvWriter(writer);
                csvWriter.Configuration.Delimiter = ";";


                dynamic testeHeader = new ExpandoObject();
                testeHeader.Id = teste.Id;
                testeHeader.Nome = teste.Nome;
                testeHeader.Serie = teste.Questoes[0].Materia.Serie.Numero;
                testeHeader.Disciplina = teste.Questoes[0].Materia.Disciplina.Nome;
                testeHeader.Materia = teste.Materia.Nome;
                testeHeader.DataGeracao = teste.DataGeracao;
                csvWriter.WriteRecord(testeHeader);
                csvWriter.NextRecord();
                csvWriter.NextRecord();

                //Escrevendo cabeçalho de Questão
                csvWriter.WriteField("Id Questão");
                csvWriter.WriteField("Bimestre");
                csvWriter.WriteField("Enunciado");
                csvWriter.WriteField("A");
                csvWriter.WriteField("B");
                csvWriter.WriteField("C");
                csvWriter.WriteField("D");
                csvWriter.WriteField("E");
                csvWriter.WriteField("Gabarito");
                csvWriter.NextRecord();

                dynamic questoes = new ExpandoObject();
                foreach (Questao questao in teste.Questoes)
                {
                    questoes.Id = questao.Id;

                    questoes.Bimestre = questao.Bimestre;

                    questoes.Enunciado = questao.Enunciado;

                    string[] arrayAlternativas = { "", "", "", "", "" };
                    char AlternativaCorreta = '\0';
                    for (int i = 0; i < questao.Alternativas.Count; i++)
                    {
                        arrayAlternativas[i] = questao.Alternativas[i].Enunciado;
                        if (questao.Alternativas[i].Correta)
                            AlternativaCorreta = questao.Alternativas[i].Letra;
                    }

                    questoes.AlternativaA = arrayAlternativas[0];
                    questoes.AlternativaB = arrayAlternativas[1];
                    questoes.AlternativaC = arrayAlternativas[2];
                    questoes.AlternativaD = arrayAlternativas[3];
                    questoes.AlternativaE = arrayAlternativas[4];

                    questoes.Gabarito = AlternativaCorreta;

                    csvWriter.WriteRecord(questoes);
                    csvWriter.NextRecord();
                }
            }
        }

        public void GerarPDF(Teste teste, List<Resposta> listaRespostas, string path)
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

            texto = String.Format(texto, teste.Questoes[0].Materia.Serie.Numero, teste.Questoes[0].Materia.Disciplina.Nome, teste.Materia.Nome);

            p.Add(texto);
            doc.Add(p);

            Paragraph titulo = new Paragraph(teste.Nome, titleFont);
            titulo.Alignment = Element.ALIGN_CENTER;
            doc.Add(titulo);

            //Espaço em Branco
            doc.Add(new Paragraph("\n", bodyFont));

            //Questões
            for (int x = 0; x < teste.Questoes.Count; x++)
            {
                var questao = teste.Questoes[x];
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

            var listParagrafosGabaritos = GeraListaParagrafosGabarito(teste, listaRespostas);

            foreach (var paragrafoAtual in listParagrafosGabaritos)
            {
                doc.Add(paragrafoAtual);
            }

            doc.Close();
        }

        public void GabaritoToPDF(Teste teste, List<Resposta> listaRespostas, string path)
        {
            Document doc = new Document(PageSize.A4);//criando e estipulando o tipo da folha usada
            doc.SetMargins(40, 40, 40, 80);//estibulando o espaçamento das margens que queremos
            doc.AddCreationDate();//adicionando as configuracoes

            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));
            doc.Open();

            foreach (var paragrafoAtual in GeraListaParagrafosGabarito(teste, listaRespostas))
            {
                doc.Add(paragrafoAtual);
            }

            doc.Close();
        }

        private List<Paragraph> GeraListaParagrafosGabarito(Teste teste, List<Resposta> gabarito)
        {
            List<Paragraph> ListParagrafosGabarito = new List<Paragraph>();
            var subTitleFont = FontFactory.GetFont("Arial", 14, Font.BOLD);
            var bodyFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);
            Paragraph paragraphGabarito = new Paragraph(string.Format("Gabarito do Teste - {0}", teste.Nome), subTitleFont);
            paragraphGabarito.Alignment = Element.ALIGN_CENTER;

            ListParagrafosGabarito.Add(paragraphGabarito);

            foreach (Resposta item in gabarito)
            {
                paragraphGabarito = new Paragraph("", bodyFont);
                paragraphGabarito.Alignment = Element.ALIGN_JUSTIFIED;
                paragraphGabarito.Add(String.Format("\n{0} - {1}", item.Numero, item.Letra));
                ListParagrafosGabarito.Add(paragraphGabarito);
            }

            return ListParagrafosGabarito;
        }

    }
}
