using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Domain;
using Project.Domain.Implementations;
using Project.Repository;
using Project.WebAPI.Dtos;
using System.Threading.Tasks;

namespace Project.WebAPI.Controllers
{
    [Route("/empresa")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IMapper _mapper;
        public readonly IProjectRepository _repo;

        public EmpresaController(IProjectRepository repo,
                              IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("GetEmpresas")]
        public async Task<IActionResult> GetEmpresa()
        {
            try
            {
                var users = await _repo.GetAllEmpresaAsync();
                var results = _mapper.Map<EmpresaDto[]>(users);

                return Ok(results);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }
        }

        [HttpGet("{EmpresaId}")]
        public async Task<IActionResult> Get(int EmpresaId)
        {
            try
            {
                var user = await _repo.GetEmpresaAsyncById(EmpresaId);
                var results = _mapper.Map<EmpresaDto>(user);

                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }
        }

        // POST
        /// <summary>
        /// Create a new Empresa.
        /// </summary>
        /// <remarks>
        /// Example:
        ///
        ///     POST /Empresa
        ///     {
        ///        "NomeFantasia": "Darth Vader",
        ///        "CNPJ": "76360437000106",
        ///        "UF": "24",
        ///     }
        ///     
        ///
        /// </remarks>

        [HttpPost]
        public async Task<IActionResult> Post(EmpresaDto model)
        {
            try
            {
                if (!ValidaCNPJ.IsCnpj(model.CNPJ)) return NotFound("CNPJ Inválido");
                var evento = _mapper.Map<Empresa>(model);
                _repo.Add(evento);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/Empresa/", _mapper.Map<EmpresaDto>(evento));
                }
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Banco Dados Falhou {ex.Message}");
            }

            return BadRequest();
        }

        // PUT
        /// <summary>
        /// Put a Empresa.
        /// To find out what is the Id, user the GetAllEmpresasByUserId controller, then it will list all your employees
        /// </summary>
        /// <remarks>
        /// Example:
        ///
        ///     PUT /Empresa
        ///     {
        ///        "Id": "8",
        ///        "NomeFantasia": "Darth Vader",
        ///        "CNPJ": "76360437000106",
        ///        "UF": "24",
        ///     }
        ///     
        ///
        /// </remarks>


        [HttpPut]
        public async Task<IActionResult> Put(EmpresaDto model)
        {
            try
            {
                if (!model.Id.HasValue) return BadRequest("Please insert the Id in Json, to place the Put");
                if (!ValidaCNPJ.IsCnpj(model.CNPJ)) return NotFound("CNPJ Inválido");
                var Empresa = await _repo.GetEmpresaAsyncById(model.Id.Value);
                if (Empresa == null) return NotFound();

                _mapper.Map(model, Empresa);

                _repo.Update(Empresa);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/Empresa/{model.Id.Value}", _mapper.Map<EmpresaDto>(Empresa));
                }
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou " + ex.Message);
            }

            return BadRequest();
        }

        [HttpDelete("{EmpresaId}")]
        public async Task<IActionResult> Delete(int EmpresaId)
        {
            try
            {
                var Empresa = await _repo.GetEmpresaAsyncById(EmpresaId);
                if (Empresa == null) return NotFound();

                _repo.Delete(Empresa);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }

            return BadRequest();
        }
    }
}