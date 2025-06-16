using CleanArchitectureTemplate.Application.Dtos;
using CleanArchitectureTemplate.Application.Interfaces;

namespace CleanArchitectureTemplate.Application.UseCases.Cars.Commands;

public class UpdateCarCommand
{
    private readonly ICarRepository _repo;

    public UpdateCarCommand(ICarRepository repo) => _repo = repo;

    public async Task<bool> ExecuteAsync(int id, CarDto dto)
    {
        var car = await _repo.GetByIdAsync(id);
        if (car is null) return false;

        car.Make = dto.Make;
        car.Model = dto.Model;
        car.Year = dto.Year;
        car.Color = dto.Color;

        await _repo.UpdateAsync(car);
        return true;
    }
}