namespace si730ebu202212721.API.Shared.Domain.Repositories;

/**
 * Base repository interface
 * <summary>
 *   -  This interface defines the basic CRUD operations for a repository.
 *   -  It is used to define the contract for the repositories.
 *   - Follow open close principle
 * </summary>
 * <remarks>
 *    - Author: U202212721 Mathias Jave Diaz
 *    - Version: 1.0.0
 * </remarks>
 */
public interface IBaseRepository<TEntity>
{
    Task AddAsync(TEntity entity);
    Task<TEntity?> FindByIdAsync(int id);
    void Update(TEntity entity);
    void Remove(TEntity entity);
    Task<IEnumerable<TEntity>> ListAsync();
}