using Prova.Csharp.Data;
using Prova.Csharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prova.Csharp.Repository
{
    public class PessoasRepository : IPessoasRepository
    {
        private readonly DataContext _context;

        public PessoasRepository(DataContext context)
        {
            _context = context;
        }

        public Pessoa Create(Pessoa pessoa)
        {
            pessoa.Id = Guid.NewGuid();

            if (string.IsNullOrEmpty(pessoa.Name))
                throw new ArgumentNullException(nameof(Pessoa.Name), "O nome do livro é obrigatório");

            _context.Pessoas.Add(pessoa);
            _context.SaveChanges();

            return pessoa;
        }
        
        public IEnumerable<Pessoa> GetAll() => _context.Pessoas.ToList();

        public Pessoa GetById(Guid id)
        {
            return _context.Pessoas.FirstOrDefault(x => x.Id == id);
        }
    }
}
