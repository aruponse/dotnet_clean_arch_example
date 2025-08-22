// TodoApp.Domain/Entities/Task.cs
namespace TodoApp.Domain.Entities;

public class Tarea
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
    public DateTime CreatedAt { get; set; }

    // Validación de reglas de negocio
    public void Validate()
    {
        if (string.IsNullOrWhiteSpace(Title))
            throw new ArgumentException("El título no puede estar vacío.");
        if (Title.Length > 100)
            throw new ArgumentException("El título no puede exceder los 100 caracteres.");
    }
}