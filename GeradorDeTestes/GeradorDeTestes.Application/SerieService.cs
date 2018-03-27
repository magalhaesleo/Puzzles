using GeradorDeTestes.Domain.Entidades;
using GeradorDeTestes.Infra.Data;
using System;
using System.Collections.Generic;

namespace GeradorDeTestes.Applications
{
    public class SerieService
    {
        private SerieDAO _serieDAO;

        public SerieService()
        {
            _serieDAO = new SerieDAO();
        }

        public Serie AdicionarSerie(Serie serie)
        {            
            try
            {
                _serieDAO.Add(serie);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return serie;
        }

        public Serie AtualizarSerie(Serie serie)
        {
            try
            {
                _serieDAO.Editar(serie);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return serie;
        }

        public Serie ExcluirSerie(Serie serie)
        {
            try
            {
                _serieDAO.Excluir(serie);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }

            return serie;
        }
                
       public List<Serie> SelecionarTodasSeries()
        {
            try
            {
                return _serieDAO.GetAll();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
