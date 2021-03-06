﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ws_banco_tabajara.Domain.Base;

namespace ws_banco_tabajara.Application.Interfaces
{
    public interface IServico<T>  where T:Entidade
    {
        T Adicionar(T entidade);
        bool Editar(T entidade);
        bool Excluir(long id);
        IQueryable<T> BuscarTodos();
        T Buscar(long id);
    }
}
