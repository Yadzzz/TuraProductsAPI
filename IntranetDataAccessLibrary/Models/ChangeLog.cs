using System;
using System.Collections.Generic;

namespace IntranetDataAccessLibrary.Models;

public partial class ChangeLog
{
    public int Id { get; set; }

    public string? Message { get; set; }

    public string LoggedInUser { get; set; } = null!;

    public string? Employee { get; set; }

    public DateTime LoggedAt { get; set; }

    public string Type { get; set; } = null!;

    public int OwnerId { get; set; }
}
