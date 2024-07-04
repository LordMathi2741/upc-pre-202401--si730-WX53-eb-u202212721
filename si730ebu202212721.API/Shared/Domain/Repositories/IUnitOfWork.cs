namespace si730ebu202212721.API.Shared.Domain.Repositories;

/**
 * Interface IUnitOfWork
 * <summary>
 *    - Interface for Unit of Work pattern
 *     - This interface is used to define the contract for the Unit of Work pattern
 * </summary>
 *
 * <remarks>
 *   - Author: U202212721 Mathias Jave Diaz
 *   - Version: 1.0.0
 * </remarks>
 */
public interface IUnitOfWork
{
  
    Task CompleteAsync();
}