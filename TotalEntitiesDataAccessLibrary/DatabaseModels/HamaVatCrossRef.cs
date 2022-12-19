using System;
using System.Collections.Generic;

namespace TotalEntitiesDataAccessLibrary.DatabaseModels;

public partial class HamaVatCrossRef
{
    public string? VatTypeId { get; set; }

    public string? VatCode { get; set; }

    public string? VatCountryCode { get; set; }
}
