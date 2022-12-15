using System;
using System.Collections.Generic;

namespace StreamServiceDataAccessLibrary.Models;

/// <summary>
/// Maps the fields in the archive META_% tables to metadata in METADATANAME
/// </summary>
public partial class ArchiveFieldMapping
{
    /// <summary>
    /// Archive table name for the collector data
    /// </summary>
    public string ArchiveTable { get; set; } = null!;

    /// <summary>
    /// Archive column order (Field ID is not included)
    /// </summary>
    public int ArchiveColumnNo { get; set; }

    /// <summary>
    /// Foreign key to column DOCUMENTTYPE.TYPEID
    /// </summary>
    public Guid TypeId { get; set; }

    /// <summary>
    /// Archive column name for the collector data
    /// </summary>
    public string ArchiveColumnName { get; set; } = null!;

    /// <summary>
    /// Foreign key to column METADATANAME.METADATANAMEID
    /// </summary>
    public Guid MetaDataNameId { get; set; }

    /// <summary>
    /// Set to 1 if the field should be searchable from Streamstudio, else set to 0 (e.g. BLOB fields)
    /// </summary>
    public int Searchable { get; set; }

    public virtual MetaDataName MetaDataName { get; set; } = null!;

    public virtual DocumentType Type { get; set; } = null!;
}
