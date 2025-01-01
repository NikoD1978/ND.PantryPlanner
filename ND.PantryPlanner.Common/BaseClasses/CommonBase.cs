using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ND.PantryPlanner.Common.BaseClasses
{
  /// <summary>
  /// Common base class for all base classes in the project
  /// 
  /// Could be made with much less code by using the CommunityToolkit.Mvvm NuGet package,
  /// but in this project I wanted to implement these things myself without the help of toolkits.
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
    /// Is raised when the property of a bound UI element changes its value.
    /// [CallerMemberName] is used to get the name of the property that is calling this method (on compile time).
    /// </summary>
    public virtual void OnPropertyChanged([CallerMemberName] string property = null!)
    {
      this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
    }
  }
}
