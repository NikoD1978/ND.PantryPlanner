using System.ComponentModel;

namespace ND.PantryPlanner.Common.BaseClasses
{
  /// <summary>
  /// Common base class for all base classes in the project
  /// </summary>
  public abstract class CommonBase : INotifyPropertyChanged
  {
    public CommonBase()
    {
      Init();
    }

    /// <summary>
    /// Initializes the properties of this class
    /// </summary>
    public virtual void Init()
    {
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// Is raised when the property of a bound UI element changes its value
    /// </summary>
    /// <param name="property">Property that is watched for changes</param>
    public virtual void RaisePropertyChanged(string property)
    {
      this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
    }
  }
}
