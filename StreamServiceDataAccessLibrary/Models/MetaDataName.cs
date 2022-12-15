using System;
using System.Collections.Generic;

namespace StreamServiceDataAccessLibrary.Models;

public partial class MetaDataName
{
    public Guid? TypeId { get; set; }

    public Guid MetaDataNameId { get; set; }

    public string MetaDataName1 { get; set; } = null!;

    public byte? Datatype { get; set; }

    public byte? MultipleValues { get; set; }

    public byte? Required { get; set; }

    public string? Source { get; set; }

    public string? SourceTable { get; set; }

    public string? SourceColumn { get; set; }

    public int? UseMask { get; set; }

    public virtual ICollection<ArchiveFieldMapping> ArchiveFieldMappings { get; } = new List<ArchiveFieldMapping>();

    public virtual ICollection<RelDocumentTypeMetaDataName> RelDocumentTypeMetaDataNames { get; } = new List<RelDocumentTypeMetaDataName>();
}
