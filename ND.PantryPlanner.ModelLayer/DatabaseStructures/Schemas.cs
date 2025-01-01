namespace ND.PantryPlanner.ModelLayer.DatabaseStructures.Schemas
{
  public static class Schemas
  {
    /// <summary>
    /// Database schema for the pantry planner
    /// </summary>
    public const string DatabaseSchema = @"
      CREATE TABLE IF NOT EXISTS ND_ITEMS (
        ITEM_ID INTEGER PRIMARY KEY AUTOINCREMENT,
        ITEM_NAME TEXT NOT NULL,
        ITEM_DESCRIPTION TEXT,
        ITEM_ITEM_TYPE INTEGER NOT NULL,
        ITEM_LOCATION_TYPE INTEGER NOT NULL,
        ITEM_QUANTITY INTEGER NOT NULL,
        ITEM_EXPIRATION_DATE TEXT,
        ITEM_HAS_TO_BE_REFRIGERATED HasToBeRefrigerated INTEGER NOT NULL,
        ITEM_IMAGE_PATH TEXT
      );";
  }
}
