using DockerLab.Interface;
using DockerLab.Service;
using Microsoft.AspNetCore.Mvc;

namespace DockerLab.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HeatSolverController : ControllerBase
{
    private IHeatSolverService _service;

    public HeatSolverController(IHeatSolverService heatSolverService)
    {
        _service = heatSolverService;
    }

    [HttpPost]
    public async Task<ActionResult> UpdateSettings([FromBody] DataDto data)
    {
        await _service.UpdateSettings(data);

        return Ok();
    }

    [HttpGet("IsParallel/{isParallel}")]
    public async Task<ActionResult<double[][][]>> GetTemperature(bool isParallel)
    {
        var result = await _service.CalculateTemperature(isParallel);

        if (result is null)
        {
            return BadRequest("The stability condition is not satisfied");
        }

        return Ok(result);
    }
}
