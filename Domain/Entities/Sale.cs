using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Sale : BaseEntity
{
    public int? ClientId { get; set; }

    public int? UserId { get; set; }

    public DateTime? SaleDate { get; set; }

    public decimal? Tax { get; set; }

    public decimal? Total { get; set; }

    public virtual Client? Client { get; set; }

    public virtual ICollection<SaleDetail> SaleDetails { get; } = new List<SaleDetail>();

    public virtual User? User { get; set; }
}
