namespace ND.PantryPlanner.EntityLayer.Enums
{
  /// <summary>
  /// Enum for the location of an item
  /// </summary>
  public enum LocationType
  {
    /// <summary>
    /// No location
    /// </summary>
    None = 0,

    /// <summary>
    /// Item is store in the kitchen pantry
    /// </summary>
    Pantry = 10,

    /// <summary>
    /// Item is stored in the bathroom
    /// </summary>
    Bathroom = 20,

    /// <summary>
    /// Item is stored in the refrigerator
    /// </summary>
    Refrigerator = 30,

    /// <summary>
    /// Item is stored in the freezer
    /// </summary>
    Freezer = 40,

    /// <summary>
    /// Item is stored in another location
    /// </summary>
    Other = 50
  }
}
