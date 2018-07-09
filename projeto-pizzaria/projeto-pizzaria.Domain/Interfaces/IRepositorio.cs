﻿using projeto_pizzaria.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Domain.Interfaces
{
    public interface IRepositorio<T> where T : Entidade
    {
        int Adicionar(T entidade);
        void Editar(T entidade);
        void Excluir(T entidade);
        List<T> GetAll();
    }
}