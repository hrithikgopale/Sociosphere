using System;
using System.Collections.Generic;

namespace Sociosphere.Data.Entities;

public partial class Complaint
{
    public int ComplaintId { get; set; }

    public int UserId { get; set; }

    public int FlatId { get; set; }

    public string ComplaintText { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime UpdatedAt { get; set; }

    public virtual Flat Flat { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
