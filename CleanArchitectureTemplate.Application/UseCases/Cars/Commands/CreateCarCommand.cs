using CleanArchitectureTemplate.Application.Dtos;
using CleanArchitectureTemplate.Application.Interfaces;
using CleanArchitectureTemplate.Domain.Entities;

namespace CleanArchitectureTemplate.Application.UseCases.Cars.Commands;

public class CreateCarCommand
{
    private readonly ICarRepository _repo;

    public CreateCarCommand(ICarRepository repo) => _repo = repo;

    public async Task<int> ExecuteAsync(CarDto dto)
    {
        var car = new Car
        {
            Id = dto.Id,
            Make = dto.Make,
            Model = dto.Model,
            Year = dto.Year,
            Color = dto.Color
        };

        await _repo.AddAsync(car);
        return car.Id;
    }
}