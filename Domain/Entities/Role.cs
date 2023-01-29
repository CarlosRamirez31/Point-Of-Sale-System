using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Role
{
    public int RoleId { get; set; }

    public string? Description { get; set; }

    public int? State { get; set; }

    public virtual ICollection<MenuRole> MenuRoles { get; } = new List<MenuRole>();

    public virtual ICollection<UserRole> UserRoles { get; } = new List<UserRole>();
}
