using System;
using System.Collections.Generic;

namespace TotalEntitiesDataAccessLibrary.DatabaseModels;

public partial class ItemTranslation
{
    public byte[] Timestamp { get; set; } = null!;

    public string ItemNo { get; set; } = null!;

    public string VariantCode { get; set; } = null!;

    public string LanguageCode { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Description2 { get; set; } = null!;
}
