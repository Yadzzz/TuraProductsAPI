using System;
using System.Collections.Generic;

namespace TotalEntitiesDataAccessLibrary.DatabaseModels;

public partial class Specialkunder
{
    public int Id { get; set; }

    public string? CustomerNo { get; set; }

    public string? Info { get; set; }

    public string? SsmaTimeStamp { get; set; }
}
