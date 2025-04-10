﻿using System;
using System.Collections.Generic;

namespace SportMatch.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? Name { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int? GenderId { get; set; }

    public DateOnly? Birthday { get; set; }

    public string Email { get; set; } = null!;

    public string? Mobile { get; set; }

    public int? AreaId { get; set; }

    public string? UserPic { get; set; }

    public string? UserMemo { get; set; }

    public DateTime CreatedAt { get; set; }

    public string Invited { get; set; } = null!;

    public int Identity { get; set; }

    public int? GuiCode { get; set; }

    public virtual ICollection<Apply> Applies { get; set; } = new List<Apply>();

    public virtual Area? Area { get; set; }

    public virtual ICollection<DeliveryInfo> DeliveryInfos { get; set; } = new List<DeliveryInfo>();

    public virtual ICollection<Favorite> FavoriteMyFavorite3s { get; set; } = new List<Favorite>();

    public virtual ICollection<Favorite> FavoriteUsers { get; set; } = new List<Favorite>();

    public virtual Gender? Gender { get; set; }

    public virtual ICollection<JoinInformation> JoinInformations { get; set; } = new List<JoinInformation>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<TeamMemberMapping> TeamMemberMappings { get; set; } = new List<TeamMemberMapping>();

    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();

    public virtual ICollection<UserSportRole> UserSportRoles { get; set; } = new List<UserSportRole>();

    public virtual ICollection<VenueRent> VenueRents { get; set; } = new List<VenueRent>();
}
