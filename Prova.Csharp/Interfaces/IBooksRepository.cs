using Prova.Csharp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prova.Csharp.Interfaces
{
    public interface IPessoasRepository
    {
        Pessoa GetById(Guid id);
        IEnumerable<Pessoa> GetAll();
        Pessoa Create(Pessoa pessoa);
    }
}
