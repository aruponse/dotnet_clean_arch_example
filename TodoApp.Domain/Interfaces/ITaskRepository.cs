// TodoApp.Domain/Interfaces/ITaskRepository.cs
using TodoApp.Domain.Entities;

namespace TodoApp.Domain.Interfaces;

public interface ITaskRepository
{
    Task<Tarea> GetByIdAsync(int id);
    Task<IEnumerable<Tarea>> GetAllAsync();
    Task AddAsync(Tarea task);
    Task UpdateAsync(Tarea task);
    Task DeleteAsync(int id);
}