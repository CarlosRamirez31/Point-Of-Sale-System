﻿using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class District
{
    public int DistrictId { get; set; }

    public int ProvinceId { get; set; }

    public string Name { get; set; } = null!;

    public int State { get; set; }

    public virtual ICollection<BranchOffice> BranchOffices { get; } = new List<BranchOffice>();

    public virtual ICollection<Business> Businesses { get; } = new List<Business>();

    public virtual Province Province { get; set; } = null!;
}
