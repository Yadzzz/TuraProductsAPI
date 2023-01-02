using System;
using System.Collections.Generic;

namespace IntranetDataAccessLibrary.Models;

public partial class KossHeadphoneModel
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool Disabled { get; set; }

    public virtual ICollection<KossRma> KossRmas { get; } = new List<KossRma>();
}
