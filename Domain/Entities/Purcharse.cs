using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Purcharse : BaseEntity
{
    public int? ProviderId { get; set; }

    public int? UserId { get; set; }

    public DateTime? PurcharseDate { get; set; }

    public decimal? Tax { get; set; }

    public decimal? Total { get; set; }

    public virtual Provider? Provider { get; set; }

    public virtual ICollection<PurcharseDetail> PurcharseDetails { get; } = new List<PurcharseDetail>();

    public virtual User? User { get; set; }
}
