using ND.PantryPlanner.Common.BaseClasses;
using ND.PantryPlanner.ModelLayer.Enums;

namespace ND.PantryPlanner.ModelLayer.Models
{
  /// <summary>
  /// Represents an item in the pantry
  /// </summary>
  public class Item : ModelBase
  {
    #region Private Fields
    private int _id;
    private string _name = string.Empty;
    private string _description = string.Empty;
    private ItemType _itemType = ItemType.None;
    private LocationType _locationType = LocationType.None;
    private int _quantity;
    private DateTime? _expirationDate;
    private bool _hasToBeRefrigerated;
    private string _imagePath = string.Empty;
    #endregion

    #region Public Properties
    /// <summary>
    /// The unique identifier for the item in the database
    /// </summary>
    public int Id
    {
      get { return _id; }
      set
      {
        if (_id == value) return;

        _id = value;
        OnPropertyChanged();
      }
    }

    /// <summary>
    /// The name of the item
    /// </summary>
    public string Name
    {
      get { return _name; }
      set
      {
        if (_name == value) return;

        _name = value;
        OnPropertyChanged();
      }
    }

    /// <summary>
    /// A description of the item
    /// </summary>
    public string Description
    {
      get { return _description; }
      set
      {
        if (_description == value) return;

        _description = value;
        OnPropertyChanged();
      }
    }

    /// <summary>
    /// The type of item. Valid values are defined in the ItemType enum.
    /// </summary>
    public ItemType ItemType
    {
      get { return _itemType; }
      set
      {
        if (_itemType == value) return;

        _itemType = value;
        OnPropertyChanged();
      }
    }

    public string ItemTypeString
    {
      get 
      {
        return ItemType.ToString(); 
      }
      set
      {
        if (value == null)
        {
          value = "None";
        }

        ItemType = (ItemType)Enum.Parse(typeof(ItemType), value);
        OnPropertyChanged();
      }
    }

    /// <summary>
    /// The location type of the item. Valid values are defined in the LocationType enum.
    /// </summary>
    public LocationType LocationType
    {
      get { return _locationType; }
      set
      {
        if (_locationType == value) return;

        _locationType = value;
        OnPropertyChanged();
      }
    }

    /// <summary>
    /// The quantity of the item
    /// </summary>
    public int Quantity
    {
      get { return _quantity; }
      set
      {
        if (_quantity == value) return;

        _quantity = value;
        OnPropertyChanged();
      }
    }

    /// <summary>
    /// The expiration date of the item, if it has one
    /// </summary>
    public DateTime? ExpirationDate
    {
      get { return _expirationDate; }
      set
      {
        if (_expirationDate == value) return;

        _expirationDate = value;
        OnPropertyChanged();
      }
    }

    /// <summary>
    /// Indicates whether the item has an expiration date
    /// </summary>
    public bool HasExpirationDate => ExpirationDate.HasValue;

    /// <summary>
    /// Indicates whether the item has to be refrigerated
    /// </summary>
    public bool HasToBeRefrigerated
    {
      get { return _hasToBeRefrigerated; }
      set
      {
        if (_hasToBeRefrigerated == value) return;

        _hasToBeRefrigerated = value;
        OnPropertyChanged();
      }
    }

    /// <summary>
    /// The path to the image file showing the item
    /// </summary>
    public string ImagePath
    {
      get { return _imagePath; }
      set
      {
        if (_imagePath == value) return;

        _imagePath = value;
        OnPropertyChanged();
      }
    }
    #endregion
  }
}
