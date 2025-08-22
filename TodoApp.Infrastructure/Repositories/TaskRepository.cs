// TodoApp.Infrastructure/Repositories/TaskRepository.cs
using Microsoft.EntityFrameworkCore;
using TodoApp.Domain.Entities;
using TodoApp.Domain.Interfaces;
using TodoApp.Infrastructure.Persistence;

namespace TodoApp.Infrastructure.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly AppDbContext _context;

    public TaskRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Tarea> GetByIdAsync(int id)
    {
        return await _context.Tasks.FindAsync(id) ?? throw new Exception("Tarea no encontrada.");
    }

    public async Task<IEnumerable<Tarea>> GetAllAsync()
    {
        return await _context.Tasks.ToListAsync();
    }

    public async Task AddAsync(Tarea task)
    {
        await _context.Tasks.AddAsync(task);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Tarea task)
    {
        _context.Tasks.Update(task);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var task = await GetByIdAsync(id);
        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();
    }
}