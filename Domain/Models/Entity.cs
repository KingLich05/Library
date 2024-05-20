namespace sultan.Domain.Models;

/// <summary>
/// Базовый абстрактный класс сущности.
/// </summary>
public abstract class Entity
{
    /// <summary>
    /// Уникальный Идентификатор.
    /// </summary>
    public int Id { get; set; }
}