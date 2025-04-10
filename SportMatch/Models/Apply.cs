﻿using System;
using System.Collections.Generic;

namespace SportMatch.Models;

public partial class Apply
{
    public int ApplyId { get; set; }

    public int UserId { get; set; }

    public int TeamId { get; set; }

    public string Status { get; set; } = null!;

    public string? Memo { get; set; }

    public string? Type { get; set; }

    public virtual Team Team { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
