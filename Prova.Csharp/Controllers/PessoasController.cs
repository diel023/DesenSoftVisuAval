using Microsoft.AspNetCore.Mvc;
using Prova.Csharp.Data;
using Prova.Csharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prova.Csharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        readonly IPessoasRepository _repository;

        public PessoasController(IPessoasRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var pessoas = _repository.GetAll();

                return Ok(pessoas);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    ex.Message
                });
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var pessoa = _repository.GetById(id);

                if (pessoa == null)
                    return NotFound();

                return Ok(pessoa);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    ex.Message
                });
            }

        }

        [HttpPost]
        public IActionResult Post([FromServices] DataContext context, [FromBody] Pessoa model)
        {
            try
            {
                var pessoa = _repository.Create(model);

                return Created($"api/pessoas/{pessoa.Id}", pessoa);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new
                {
                    ex.Message,
                    ex.ParamName
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    ex.Message
                });
            }
        }
    }
}
