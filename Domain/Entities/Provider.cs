using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Provider : BaseEntity
{
    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int DocumentTypeId { get; set; }

    public string DocumentNumber { get; set; } = null!;

    public string? Address { get; set; }

    public string Phone { get; set; } = null!;

    public virtual DocumentType DocumentType { get; set; } = null!;

    public virtual ICollection<Product> Products { get; } = new List<Product>();

    public virtual ICollection<Purcharse> Purcharses { get; } = new List<Purcharse>();
}
