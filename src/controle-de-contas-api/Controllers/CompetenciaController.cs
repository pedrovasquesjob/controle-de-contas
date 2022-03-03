using controle_de_contas_api.DTOs;
using controle_de_contas_api.Service;
using Microsoft.AspNetCore.Mvc;

namespace controle_de_contas_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompetenciaController : ControllerBase
{
    private readonly CompetenciaService _competencia;

    public CompetenciaController(CompetenciaService competencia)
    {
        _competencia = competencia;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
        => Ok(await _competencia.GetAllAsync());

    [HttpGet("{competencia}")]
    public async Task<IActionResult> GetByCompetencia(string competencia)
        => Ok(await _competencia.GetByCompetencia(competencia));

    [HttpPost]
    public async Task<IActionResult> Post(CompetenciaDTO dto)
    {
        try
        {
            await _competencia.CreateAsync(dto);
            return Ok(new { message = "Competência inserida com sucesso" });
        }
        catch(Exception e)
        {
            return BadRequest(new { message = $"Erro ao inserir a competência: {e.Message}" });
        }
    }

    [HttpPut]
    public async Task<IActionResult> Put(CompetenciaDTO dto)
    {
        try
        {
            await _competencia.UpdateAsync(dto);
            return Ok(new { message = "Competência alterada com sucesso" });
        }
        catch(Exception e)
        {
            return BadRequest(new { message = $"Erro ao alterar a competência: {e.Message}" });
        }
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(string id)
    {
        try
        {
            await _competencia.RemoveAsync(id);
            return Ok(new { message = "Competência removida com sucesso" });
        }
        catch(Exception e)
        {
            return BadRequest(new { message = $"Erro ao remover a competência: {e.Message}" });
        }
    }
}