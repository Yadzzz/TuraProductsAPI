using System;
using System.Collections.Generic;

namespace TotalEntitiesDataAccessLibrary.Models;

public partial class GetItemDescEngWeb
{
    public string TuraItemNo { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public string VendorItemNo { get; set; } = null!;

    public string Eancode { get; set; } = null!;

    public string? ManufacturerCode { get; set; }

    public string? WebCat1 { get; set; }

    public string? WebCat2 { get; set; }

    public string? WebCat3 { get; set; }

    public string? ProductDescriptionEng { get; set; }
}
