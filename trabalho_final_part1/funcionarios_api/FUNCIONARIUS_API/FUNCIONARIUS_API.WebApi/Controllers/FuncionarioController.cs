using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FUNCIONARIUS_API.Domain;
using FUNCIONARIUS_API.Domain.Implementations;
using FUNCIONARIUS_API.Repository;
using FUNCIONARIUS_API.WebAPI.Dtos;
using System;
using System.Threading.Tasks;

namespace FUNCIONARIUS_API.WebAPI.Controllers
{
    [Route("/funcionarios")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IMapper _mapper;
        public readonly IProjectRepository _repo;

        public FuncionarioController(IProjectRepository repo,
                              IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("GetFuncionario")]
        public async Task<IActionResult> GetFuncionario()
        {
            try
            {
                var funcionarios = await _repo.GetAllFuncionarioAsync();
                var results = _mapper.Map<FuncionarioDto[]>(funcionarios);

                return Ok(results);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }
        }

        [HttpGet("GetFuncionarioByCargo")]
        public async Task<IActionResult> GetFuncionarioByCargo(CargoFuncionario cargo)
        {
            try
            {
                var funcionarios = await _repo.GetFuncionariosAsyncByCargo(cargo);
                var results = _mapper.Map<FuncionarioDto[]>(funcionarios);

                return Ok(results);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }
        }
        [HttpGet("GetFuncionarioByCPF")]
        public async Task<IActionResult> GetFuncionarioByCPF(String cpf)
        {
            try
            {
                if(FuncionarioValidation.ValidarCPFFuncionario(cpf) != ""){
                    return this.StatusCode(StatusCodes.Status404NotFound, $"CPF não é válido");
                }
                var funcionarios = await _repo.GetFuncionariosAsyncByCpf(cpf);
                var results = _mapper.Map<FuncionarioDto>(funcionarios);
                
                return Ok(results);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }
        }

        [HttpGet("{FuncionarioId}")]
        public async Task<IActionResult> Get(int FuncionarioId)
        {
            try
            {
                var funcionarios = await _repo.GetFuncionarioAsyncById(FuncionarioId);
                var results = _mapper.Map<FuncionarioDto>(funcionarios);

                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(FuncionarioDto model)
        {
            try
            {
                var funcionario = _mapper.Map<Funcionario>(model);
                _repo.Add(funcionario);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/Funcionario/", _mapper.Map<FuncionarioDto>(funcionario));
                }
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Banco Dados Falhou {ex.Message}");
            }

            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put(FuncionarioDto model)
        {
            try
            {
                if (!model.Codigo.HasValue) return BadRequest("Please insert the Id in Json, to place the Put");
                var Funcionario = await _repo.GetFuncionarioAsyncById(model.Codigo.Value);
                if (Funcionario == null) return NotFound();

                _mapper.Map(model, Funcionario);

                _repo.Update(Funcionario);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/Funcionario/{model.Codigo.Value}", _mapper.Map<FuncionarioDto>(Funcionario));
                }
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou " + ex.Message);
            }

            return BadRequest();
        }

        [HttpDelete("{FuncionarioId}")]
        public async Task<IActionResult> Delete(int FuncionarioId)
        {
            try
            {
                var Funcionario = await _repo.GetFuncionarioAsyncById(FuncionarioId);
                if (Funcionario == null) return NotFound();

                _repo.Delete(Funcionario);

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