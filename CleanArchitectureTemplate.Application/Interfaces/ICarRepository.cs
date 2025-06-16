using CleanArchitectureTemplate.Domain.Entities;

namespace CleanArchitectureTemplate.Application.Interfaces;

public interface ICarRepository
{
    Task<IEnumerable<Car>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Car?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task AddAsync(Car car, CancellationToken cancellationToken = default);
    Task UpdateAsync(Car car, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
}