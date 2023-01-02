using System;
using System.Collections.Generic;

namespace IntranetDataAccessLibrary.Models;

public partial class InfoMessage
{
    public int Id { get; set; }

    public string? Header { get; set; }

    public string? Message { get; set; }

    public string? FontColor { get; set; }

    public string? BackgroundColor { get; set; }

    public bool? Active { get; set; }

    public DateTime Updated { get; set; }
}
