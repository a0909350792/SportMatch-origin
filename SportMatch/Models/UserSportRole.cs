using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportMatch.Models;

public partial class UserSportRole
{
    public int Usrid { get; set; }

    public int UserId { get; set; }

    public int SportId { get; set; }

    public int RoleId { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual Sport Sport { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
