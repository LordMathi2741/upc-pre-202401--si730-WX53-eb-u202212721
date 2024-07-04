using Microsoft.EntityFrameworkCore;
using si730ebu202212721.API.Shared.Domain.Repositories;
using si730ebu202212721.API.Shared.Infrastructure.Persistence.EFC.Configuration;
namespace si730ebu202212721.API.Shared.Infrastructure.Persistence.EFC.Repositories;

/**
 * BaseRepository<TEntity> class
 * <summary>
 *      -  BaseRepository<TEntity> class is a generic class that implements IBaseRepository<TEntity> interface.
 *      - It is a base class for all repositories in the application.
 *      - It provides basic CRUD operations for the entities.
 *      - Follow the repository pattern.
 * </summary>
 * <typeparam name="TEntity">Entity type</typeparam>
 * <remarks>
 *     - Author : U202212721 Mathias Jave Diaz
 *     -Version : 1.0.0
 * </remarks>
 */
public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly AppDbContext Context;
    
    protected BaseRepository(AppDbContext context) => Context = context;
    
    public async Task AddAsync(TEntity entity) => await Context.Set<TEntity>().AddAsync(entity);

    public async Task<TEntity?> FindByIdAsync(int id) => await Context.Set<TEntity>().FindAsync(id);

    public void Update(TEntity entity) => Context.Set<TEntity>().Update(entity);

    public void Remove(TEntity entity) => Context.Set<TEntity>().Remove(entity);

    public async Task<IEnumerable<TEntity>> ListAsync() => await Context.Set<TEntity>().ToListAsync();
    
}
