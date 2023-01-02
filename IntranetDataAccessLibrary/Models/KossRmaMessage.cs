using System;
using System.Collections.Generic;

namespace IntranetDataAccessLibrary.Models;

public partial class KossRmaMessage
{
    public int Id { get; set; }

    public string Message { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<KossRma> KossRmas { get; } = new List<KossRma>();
}
