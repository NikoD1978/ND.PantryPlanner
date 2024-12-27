using System.Collections.ObjectModel;

namespace ND.PantryPlanner.Common.Interfaces
{
  /// <summary>
  /// Interface for all data acquisition repositories in this project
  /// </summary>
  /// <typeparam name="TEntity"></typeparam>
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
  }
}
