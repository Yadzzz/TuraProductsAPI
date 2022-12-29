﻿using System;
using System.Collections.Generic;

namespace IntranetDataAccessLibrary.Models;

public partial class AspNetUserLogin
{
    public string LoginProvider { get; set; } = null!;

    public string ProviderKey { get; set; } = null!;

    public string UserId { get; set; } = null!;
}
