﻿using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeTestes.Infra.CSV
{
    public static class CSVExtension
    {
        /// <summary>
        /// Gera uma string serializada em csv de qualquer objeto não estático.
        /// </summary>
        /// <param name="objs"></param>
        /// <returns>String in CSV format</returns>
        public static string Serialize<T>(this IList<T> objs)
        {
            using (StreamWriter writer = new StreamWriter(@"Produto.csv"))
            {
                CsvWriter csvWriter = new CsvWriter(writer);
                csvWriter.WriteRecords(objs);
            }
            return objs.ToString();
        }
        /// <summary>
        /// Converte um arquivo csv para uma lista de objetos
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objs"></param>
        /// <returns></returns>
        public static IList<T> Deserialize<T>(this IList<T> objs)
        {
            using (var reader = new StreamReader(@"Produto.csv"))
            {
                var csvReader = new CsvReader(reader);
                return csvReader.GetRecords<T>().ToList();
            }
        }
    }
}
