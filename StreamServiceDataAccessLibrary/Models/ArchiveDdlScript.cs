using System;
using System.Collections.Generic;

namespace StreamServiceDataAccessLibrary.Models;

/// <summary>
/// Maps the fields in the archive META_% tables to metadata in METADATANAME
/// </summary>
public partial class ArchiveDdlScript
{
    /// <summary>
    /// Job Number
    /// </summary>
    public int JobNo { get; set; }

    /// <summary>
    /// Sequence number for the sql statement in the job
    /// </summary>
    public int SeqNo { get; set; }

    /// <summary>
    /// Creation timestamp for the job
    /// </summary>
    public DateTime CreationDate { get; set; }

    /// <summary>
    /// Document type in DOCUMENTTYPE
    /// </summary>
    public Guid TypeId { get; set; }

    public string ArchiveTable { get; set; } = null!;

    /// <summary>
    /// SQL statement
    /// </summary>
    public string SqlStatement { get; set; } = null!;

    public virtual DocumentType Type { get; set; } = null!;
}
