using CleanArchitectureTemplate.Application.Interfaces;

namespace CleanArchitectureTemplate.Application.UseCases.Cars.Commands;

public class DeleteCarCommand
{
    private readonly ICarRepository _repo;
    public DeleteCarCommand(ICarRepository repo) => _repo = repo;
    public async Task<bool> ExecuteAsync(int id)
    {
        var car = await _repo.GetByIdAsync(id);
        if (car is null) return false;
        await _repo.DeleteAsync(id);
        return true;
    }
}