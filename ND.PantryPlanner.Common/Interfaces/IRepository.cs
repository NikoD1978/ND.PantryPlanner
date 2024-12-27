using System.Collections.ObjectModel;

namespace ND.PantryPlanner.Common.Interfaces
{
  /// <summary>
  /// Interface for all data acquisition repositories in this project
  /// </summary>
  public interface IRepository<TEntity>
  {
    /// <summary>
    /// Gets all results of the repository
    /// </summary>
    ObservableCollection<TEntity> Get();

    /// <summary>
    /// Gets a single result by its ID
    /// </summary>
    TEntity? Get(int id);

    /// <summary>
    /// Adds a new object to the repository
    /// </summary>
    public void Add(TEntity entity);
  }
}
