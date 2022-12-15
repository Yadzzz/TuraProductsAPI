using System;
using System.Collections.Generic;

namespace StreamServiceDataAccessLibrary.Models;

public partial class RelDocumentTypeMetaDataName
{
    public Guid DocumentTypeId { get; set; }

    public Guid MetaDataNameId { get; set; }

    public string? FlatTableName { get; set; }

    public int? FlatColumnNo { get; set; }

    public string? FlatColumnName { get; set; }

    public int? FlatSearchable { get; set; }

    public virtual DocumentType DocumentType { get; set; } = null!;

    public virtual MetaDataName MetaDataName { get; set; } = null!;
}
