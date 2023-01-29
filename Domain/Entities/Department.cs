using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string Name { get; set; } = null!;

    public int State { get; set; }

    public virtual ICollection<Province> Provinces { get; } = new List<Province>();
}
