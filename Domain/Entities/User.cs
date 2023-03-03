using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class User : BaseEntity
{
    public string? UserName { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public string? Image { get; set; }

    public virtual ICollection<Purcharse> Purcharses { get; } = new List<Purcharse>();

    public virtual ICollection<Sale> Sales { get; } = new List<Sale>();

    public virtual ICollection<UserRole> UserRoles { get; } = new List<UserRole>();

    public virtual ICollection<UsersBranchOffice> UsersBranchOffices { get; } = new List<UsersBranchOffice>();
}
