using System;
using System.Collections.Generic;

namespace StreamServiceDataAccessLibrary.Models;

public partial class MetaDataType
{
    public byte MetaDataTypeId { get; set; }

    public string Description { get; set; } = null!;

    public string? SqldataType { get; set; }

    public string ArchiveDataType { get; set; } = null!;
}
