using CleanArchitectureTemplate.Application.Interfaces;
using CleanArchitectureTemplate.Domain.Entities;
using CleanArchitectureTemplate.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureTemplate.Infrastructure.Repositories;

public class CarRepository : ICarRepository
{
    private readonly DatabaseContext _context;
    public CarRepository(DatabaseContext context) => _context = context;

    public async Task<IEnumerable<Car>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Cars.ToListAsync(cancellationToken);
    }

    public async Task<Car?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Cars.FindAsync(id, cancellationToken);
    }

    public async Task AddAsync(Car car, CancellationToken cancellationToken = default)
    {
        _context.Cars.Add(car);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Car car, CancellationToken cancellationToken = default)
    {
        _context.Cars.Update(car);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var car = await _context.Cars.FindAsync(id, cancellationToken);
        if (car is not null)
        {
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
