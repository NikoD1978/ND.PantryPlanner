namespace ND.PantryPlanner.MAUI.ViewsPartial;

public partial class HeaderView : ContentView
{
  public HeaderView()
  {
    InitializeComponent();

    ViewTitle = "View Title";
    ViewDescription = "View Description";
    this.BindingContext = this;
  }

  /// <summary>
  /// The title of the view
  /// </summary>
  public string ViewTitle
  {
    get { return (string)GetValue(ViewTitleProperty); }
    set { SetValue(ViewTitleProperty, value); }
  }

  /// <summary>
  /// Bindable property for the view title
  /// </summary>
  public static readonly BindableProperty ViewTitleProperty =
  BindableProperty.Create("ViewTitle", typeof(string), typeof(HeaderView), string.Empty);

  /// <summary>
  /// The description of the view
  /// </summary>
  public string ViewDescription
  {
    get { return (string)GetValue(ViewDescriptionProperty); }
    set { SetValue(ViewDescriptionProperty, value); }
  }

  /// <summary>
  /// Bindable property for the view description
  /// </summary>
  public static readonly BindableProperty ViewDescriptionProperty =
  BindableProperty.Create("ViewDescription", typeof(string), typeof(HeaderView), string.Empty);
}