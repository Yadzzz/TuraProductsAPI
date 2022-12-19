using System;
using System.Collections.Generic;

namespace TotalEntitiesDataAccessLibrary.Models;

public partial class LitiumProductsDescription
{
    public string VariantId { get; set; } = null!;

    public string? BaseId { get; set; }

    public string? Gtin { get; set; }

    public int? ActivityCode { get; set; }

    public string? ManufacturerItemNo { get; set; }

    public string? Brand { get; set; }

    public string? SeItemName { get; set; }

    public string? SeItemText { get; set; }

    public string? NoItemName { get; set; }

    public string? NoItemText { get; set; }

    public string? DkItemName { get; set; }

    public string? DkItemText { get; set; }

    public string? FiItemName { get; set; }

    public string? FiItemText { get; set; }

    public string? EnItemName { get; set; }

    public string? EnItemText { get; set; }
}
