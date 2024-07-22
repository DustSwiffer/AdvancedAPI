using System.Linq.Expressions;

namespace AdvancedAPI.Data.Repositories.Interfaces;

/// <summary>
/// Repository base class.
/// </summary>
public interface IBaseRepository<T>
    where T : class
{
    /// <summary>
    /// Gets all <see cref="T"/>
    /// </summary>
    Task<IEnumerable<T>> GetAllAsync();

    /// <summary>
    /// Gets <see cref="T"/> by id.
    /// </summary>
    Task<T> GetByIdAsync(object id);

    /// <summary>
    /// finds <see cref="T"/>
    /// </summary>
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

    /// <summary>
    /// Adds <see cref="T"/> to the database.
    /// </summary>
    Task AddAsync(T entity);

    /// <summary>
    /// Updates <see cref="T"/> in the database.
    /// </summary>
    void Update(T entity);

    /// <summary>
    /// Deletes <see cref="T"/> from the database.
    /// </summary>
    void Delete(T entity);

    /// <summary>
    /// Saves the changes to the database.
    /// </summary>
    Task SaveAsync();
}