using CleanArchitectureTemplate.Application.Dtos;
using CleanArchitectureTemplate.Application.Interfaces;

namespace CleanArchitectureTemplate.Application.UseCases.Cars.Queries;

public class GetAllCarsQuery
{
    private readonly ICarRepository _carRepo;

    public GetAllCarsQuery(ICarRepository carRepo) => _carRepo = carRepo;

    public async Task<List<CarDto>> ExecuteAsync()
    {
        var cars = await _carRepo.GetAllAsync();
        return cars.Select(c => new CarDto
        {
            Id = c.Id,
            Make = c.Make,
            Model = c.Model,
            Year = c.Year,
            Color = c.Color
        }).ToList();
    }
}