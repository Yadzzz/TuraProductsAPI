using System;
using System.Collections.Generic;

namespace StreamServiceDataAccessLibrary.Models;

public partial class DocumentType
{
    public Guid TypeId { get; set; }

    public string? TypeName { get; set; }

    public byte TypeOfType { get; set; }

    public string? PrincipalObjectId { get; set; }

    public Guid? SearchId { get; set; }

    public DateTime? ExpiringDateTime { get; set; }

    public Guid? PermissionsId { get; set; }

    public int? Revision { get; set; }

    public virtual ICollection<ArchiveDdlScript> ArchiveDdlScripts { get; } = new List<ArchiveDdlScript>();

    public virtual ICollection<ArchiveFieldMapping> ArchiveFieldMappings { get; } = new List<ArchiveFieldMapping>();

    public virtual ICollection<RelDocumentTypeMetaDataName> RelDocumentTypeMetaDataNames { get; } = new List<RelDocumentTypeMetaDataName>();
}
