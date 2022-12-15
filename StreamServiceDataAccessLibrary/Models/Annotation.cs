using System;
using System.Collections.Generic;

namespace StreamServiceDataAccessLibrary.Models;

/// <summary>
/// Holds the annotations made on a document by a user
/// </summary>
public partial class Annotation
{
    /// <summary>
    /// Synthetic key
    /// </summary>
    public Guid AnnotationId { get; set; }

    /// <summary>
    /// PartID is the reference to the document in question
    /// </summary>
    public Guid PartId { get; set; }

    /// <summary>
    /// The user or role that wrote the annotation
    /// </summary>
    public string PrincipalObjectId { get; set; } = null!;

    public string? Annotation1 { get; set; }

    /// <summary>
    /// When the annotation was made
    /// </summary>
    public DateTime CreationDateTime { get; set; }

    /// <summary>
    /// Can be used as time for when a deletion script should clean up
    /// </summary>
    public DateTime? ExpiringDateTime { get; set; }
}
