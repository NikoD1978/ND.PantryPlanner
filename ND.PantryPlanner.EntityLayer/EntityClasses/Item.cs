using ND.PantryPlanner.Common.BaseClasses;
using ND.PantryPlanner.EntityLayer.Enums;

namespace ND.PantryPlanner.EntityLayer.EntityClasses
{
  public class Item : EntityBase
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
    public int Id
    {
      get { return _id; }
      set
      {
        _id = value;
        OnPropertyChanged(nameof(_id));
      }
    }

    public string Name
    {
      get { return _name; }
      set
      {
        _name = value;
        OnPropertyChanged(nameof(_name));
      }
    }

    public string Description
    {
      get { return _description; }
      set
      {
        _description = value;
        OnPropertyChanged(nameof(_description));
      }
    }

    public ItemType ItemType
    {
      get { return _itemType; }
      set
      {
        _itemType = value;
        OnPropertyChanged(nameof(_itemType));
      }
    }

    public LocationType LocationType
    {
      get { return _locationType; }
      set
      {
        _locationType = value;
        OnPropertyChanged(nameof(_locationType));
      }
    }

    public int Quantity
    {
      get { return _quantity; }
      set
      {
        _quantity = value;
        OnPropertyChanged(nameof(_quantity));
      }
    }

    public DateTime? ExpirationDate
    {
      get { return _expirationDate; }
      set
      {
        _expirationDate = value;
        OnPropertyChanged(nameof(_expirationDate));
      }
    }

    public bool HasToBeRefrigerated
    {
      get { return _hasToBeRefrigerated; }
      set
      {
        _hasToBeRefrigerated = value;
        OnPropertyChanged(nameof(_hasToBeRefrigerated));
      }
    }

    public string? ImagePath
    {
      get { return _imagePath; }
      set
      {
        _imagePath = value;
        OnPropertyChanged(nameof(_imagePath));
      }
    }
    #endregion
  }
}
