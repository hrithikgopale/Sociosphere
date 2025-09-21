using System;
using System.Collections.Generic;

namespace Sociosphere.Data.Entities;

public partial class Bill
{
    public int BillId { get; set; }

    public string BillTitle { get; set; } = null!;

    public int FlatId { get; set; }

    public double BillAmount { get; set; }

    public string Month { get; set; } = null!;

    public double? PaidAmount { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Flat Flat { get; set; } = null!;
}
