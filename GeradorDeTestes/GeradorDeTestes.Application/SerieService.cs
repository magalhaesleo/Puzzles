﻿using GeradorDeTestes.Application.IoC;
using GeradorDeTestes.Domain.Entidades;
using GeradorDeTestes.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace GeradorDeTestes.Applications
{
    public class SerieService : IService<Serie>
    {

        public int Adicionar(Serie serie)
        {
            try
            {
                validarExistenciaSerie(serie);
                return IOCRepository.SerieRepository.Add(serie);
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
                IOCRepository.SerieRepository.Editar(serie);
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
                List<Materia> listaMateria = IOCRepository.MateriaRepository.GetAll();
                foreach (Materia materia in listaMateria)
                {
                    if (serie.Id == materia.Serie.Id)
                    {
                        throw new Exception("Não foi possivel excluir, a serie está sendo utilizada!");
                    }
                }
                IOCRepository.SerieRepository.Excluir(serie);
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
                return IOCRepository.SerieRepository.GetAll();
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
