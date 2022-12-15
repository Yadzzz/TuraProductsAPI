using System;
using System.Collections.Generic;

namespace StreamServiceDataAccessLibrary.Models;

public partial class ErrorMessage
{
    public int ErrNum { get; set; }

    public string ErrMsg { get; set; } = null!;

    public string ErrLang { get; set; } = null!;
}
