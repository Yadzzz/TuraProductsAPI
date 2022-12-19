using System;
using System.Collections.Generic;

namespace TotalEntitiesDataAccessLibrary.Models;

public partial class Item
{
    public byte[] Timestamp { get; set; } = null!;

    public string No { get; set; } = null!;

    public string No2 { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string SearchDescription { get; set; } = null!;

    public string Description2 { get; set; } = null!;

    public string BaseUnitOfMeasure { get; set; } = null!;

    public int PriceUnitConversion { get; set; }

    public decimal UnitPrice { get; set; }

    public string ItemDiscGroup { get; set; } = null!;

    public string VendorNo { get; set; } = null!;

    public string VendorItemNo { get; set; } = null!;

    public decimal GrossWeight { get; set; }

    public decimal NetWeight { get; set; }

    public decimal UnitsPerParcel { get; set; }

    public decimal UnitVolume { get; set; }

    public string CountryRegionOfOriginCode { get; set; } = null!;

    public string TaxGroupCode { get; set; } = null!;

    public decimal OrderMultiple { get; set; }

    public string ItemCategoryCode { get; set; } = null!;

    public string ProductGroupCode { get; set; } = null!;

    public string PrimaryEanCode { get; set; } = null!;

    public string? ItemFeeCode { get; set; }

    public byte? NotDivisibleUnit { get; set; }

    public string? ManufacturerCode { get; set; }

    public string? CommonItemNo { get; set; }

    public string? ActivityCode { get; set; }

    public string? VendorName { get; set; }

    public string? Choice { get; set; }

    public string? ReplacementItem { get; set; }

    public DateTime? DateCreated { get; set; }

    public string? VatProdPostingGroup { get; set; }

    public byte? InternetCode { get; set; }

    public string? PrevActivityCode { get; set; }

    public string? ReplacesItemNo { get; set; }

    public int? EnovaId { get; set; }

    public int? ParentEnovaId { get; set; }

    public int? ChildEnovaId { get; set; }

    public DateTime? LastDateTimeModified { get; set; }
}
