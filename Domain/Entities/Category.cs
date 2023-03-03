using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Category : BaseEntity
{

    public string? Name { get; set; }

    public string? Description { get; set; }


    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
