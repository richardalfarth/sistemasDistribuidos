using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FDP.API.Domain;
using System.Threading.Tasks;
using Project.Repository;

namespace FDP.API.WebAPI.Controllers
{
    [Route("/folhaSalarial")]
    [ApiController]
    public class FolhaSalarialController : ControllerBase
    {
        private readonly IMapper _mapper;
        public readonly IProjectRepository _repo;

        public FolhaSalarialController(IProjectRepository repo,
                              IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("GetFolhaSalarial")]
        public async Task<IActionResult> GetFolhaSalarial()
        {
            try
            {
                var folhaSalarial = await _repo.GetAllFolhaSalarialAsync();
                var results = _mapper.Map<FolhaSalariaDto[]>(folhaSalarial);

                return Ok(folhaSalarial);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }
        }

        [HttpPost("CalcularFolhaSalarial")]
        public async Task<IActionResult> CalcularFolhaSalarial(string cpf, int horasTrabalhadas) 
        {
            try
            {
                var folhaSalarial = await _repo.CalcularFolhaSalarial(cpf,horasTrabalhadas);
               // var results = _mapper.Map<FolhaSalariaDto>(folhaSalarial);
                return Ok(folhaSalarial);
            }
            catch (System.Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }
        }

        [HttpGet("{FolhaSalarialId}")]
        public async Task<IActionResult> Get(int FolhaSalarialId)
        {
            try
            {
                var folhaSalarial = await _repo.GetFolhaSalarialAsyncById(FolhaSalarialId);
                var results = _mapper.Map<FolhaSalariaDto>(folhaSalarial);

                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(FolhaSalariaDto model)
        {
            try
            {
                var folhaSalaria = _mapper.Map<FolhaSalarial>(model);
                _repo.Add(folhaSalaria);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/FolhaSalarial/", _mapper.Map<FolhaSalariaDto>(folhaSalaria));
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
        public async Task<IActionResult> Put(FolhaSalariaDto model)
        {
            try
            {
                if (!model.Codigo.HasValue) return BadRequest("Please insert the Id in Json, to place the Put");
                var FolhaSalarial = await _repo.GetFolhaSalarialAsyncById(model.Codigo.Value);
                if (FolhaSalarial == null) return NotFound();

                _mapper.Map(model, FolhaSalarial);

                _repo.Update(FolhaSalarial);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/FolhaSalarial/{model.Codigo.Value}", _mapper.Map<FolhaSalariaDto>(FolhaSalarial));
                }
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou " + ex.Message);
            }

            return BadRequest();
        }

        [HttpDelete("{FolhaSalarialId}")]
        public async Task<IActionResult> Delete(int FolhaSalarialId)
        {
            try
            {
                var FolhaSalarial = await _repo.GetFolhaSalarialAsyncById(FolhaSalarialId);
                if (FolhaSalarial == null) return NotFound();

                _repo.Delete(FolhaSalarial);

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