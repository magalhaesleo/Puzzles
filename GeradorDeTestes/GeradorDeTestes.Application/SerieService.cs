using GeradorDeTestes.Domain.Entidades;
using GeradorDeTestes.Domain.Interfaces;
using GeradorDeTestes.Infra.Data;
using System;
using System.Collections.Generic;

namespace GeradorDeTestes.Applications
{
    public class SerieService : IService<Serie>
    {
        private SerieDAO _serieDAO;
        private MateriaDAO _materiaDAO;

        public SerieService()
        {
            _serieDAO = new SerieDAO();
            _materiaDAO = new MateriaDAO();
        }

        public int Adicionar(Serie serie)
        {
            try
            {
                validarExistenciaSerie(serie);
                return _serieDAO.Add(serie);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Editar(Serie serie)
        {
            try
            {
                _serieDAO.Editar(serie);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Excluir(Serie serie)
        {
            try
            {
                List<Materia> listaMateria = _materiaDAO.GetAll();
                foreach (Materia materia in listaMateria)
                {
                    if (serie.Id == materia.Serie.Id)
                    {
                        throw new Exception("Não foi possivel excluir, a serie está sendo utilizada!");
                    }
                }
                _serieDAO.Excluir(serie);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Serie> GetAll()
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

        private void validarExistenciaSerie(Serie serie)
        {
            var listSeries = GetAll();

            foreach (var serieListada in listSeries)
            {
                if (serieListada.Numero == serie.Numero)
                {
                    throw new Exception("A série já esta cadastrada no banco de dados");
                }
            }
        }
    }
}
