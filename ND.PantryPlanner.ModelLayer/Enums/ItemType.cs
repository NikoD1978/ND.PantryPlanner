namespace ND.PantryPlanner.ModelLayer.Enums
{
  /// <summary>
  /// Enum for the type of item
  /// </summary>
  public enum ItemType
  {
    /// <summary>
    /// No type
    /// </summary>
    None = 0,

    /// <summary>
    /// Item can be consumed as food
    /// </summary>
    Food = 10,

    /// <summary>
    /// Item is used as cleaning supply
    /// </summary>
    CleaningSupply = 20,

    /// <summary>
    /// Item is used for cosmetic purposes
    /// </summary>
    Cosmetic = 30,

    /// <summary>
    /// Item is used as medicine
    /// </summary>
    Medicine = 40,

    /// <summary>
    /// Item is used for other purposes
    /// </summary>
    Other = 50
  }
}
