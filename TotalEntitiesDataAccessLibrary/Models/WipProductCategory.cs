using System;
using System.Collections.Generic;

namespace TotalEntitiesDataAccessLibrary.Models;

public partial class WipProductCategory
{
    public int EnovaId { get; set; }

    public string? Identifier { get; set; }

    public string? ExternalIdentifier { get; set; }

    public DateTime? Modified { get; set; }

    public string? NameSv { get; set; }

    public string? NameEn { get; set; }

    public string? NameNo { get; set; }

    public string? NameFi { get; set; }

    public string? NameDk { get; set; }

    public byte[] Ts { get; set; } = null!;

    public long? Tsnumber { get; set; }

    public bool? IsDeleted { get; set; }
}
