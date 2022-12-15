using System;
using System.Collections.Generic;

namespace StreamServiceDataAccessLibrary.Models;

/// <summary>
/// The version of the database schema
/// </summary>
public partial class SchemaVersion
{
    /// <summary>
    /// primary key, the name of the schema
    /// </summary>
    public string SchemaVersionId { get; set; } = null!;

    /// <summary>
    /// The version of the schema, connected to the platform version, clients check this before they start
    /// </summary>
    public int Version { get; set; }

    /// <summary>
    /// The major version of the schema, follows the service pack, clients check this before they start
    /// </summary>
    public int Major { get; set; }

    /// <summary>
    /// The revision of the schema, on any change this is stepped up, clients do not check this before start 
    /// </summary>
    public int Revision { get; set; }

    /// <summary>
    /// Build is the build where this schema was sent out with
    /// </summary>
    public string? Build { get; set; }

    /// <summary>
    /// An informative text
    /// </summary>
    public string Description { get; set; } = null!;

    /// <summary>
    /// When this row was inserted
    /// </summary>
    public DateTime CreationDate { get; set; }
}
