using CleanArchitectureTemplate.Application.Dtos;
using CleanArchitectureTemplate.Application.Interfaces;

namespace CleanArchitectureTemplate.Application.UseCases.Cars.Queries;

public class GetCarByIdQuery
{
    private readonly ICarRepository _repo;

    public GetCarByIdQuery(ICarRepository repo) => _repo = repo;

    public async Task<CarDto?> ExecuteAsync(int id)
    {
        var car = await _repo.GetByIdAsync(id);
        if (car is null) return null;

        return new CarDto
        {
            Id = car.Id,
            Make = car.Make,
            Model = car.Model,
            Year = car.Year,
            Color = car.Color
        };
    }
}