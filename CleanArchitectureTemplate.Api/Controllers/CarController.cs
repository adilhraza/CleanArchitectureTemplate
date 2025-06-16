using CleanArchitectureTemplate.Application.Dtos;
using CleanArchitectureTemplate.Application.Interfaces;
using CleanArchitectureTemplate.Application.UseCases.Cars.Commands;
using CleanArchitectureTemplate.Application.UseCases.Cars.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureTemplate.Api.Controllers;

public class CarController : BaseApiController
{
    private readonly ICarRepository _repo;

    public CarController(ICarRepository repo) => _repo = repo;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllCarsQuery(_repo);
        var result = await query.ExecuteAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var query = new GetCarByIdQuery(_repo);
        var car = await query.ExecuteAsync(id);
        return car is null ? NotFound() : Ok(car);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CarDto dto)
    {
        var command = new CreateCarCommand(_repo);
        var newCarId = await command.ExecuteAsync(dto);
        return CreatedAtAction(nameof(Get), new { id = newCarId }, dto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] CarDto dto)
    {
        var command = new UpdateCarCommand(_repo);
        var updated = await command.ExecuteAsync(id, dto);
        return updated ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteCarCommand(_repo);
        await command.ExecuteAsync(id);
        return NoContent();
    }

}