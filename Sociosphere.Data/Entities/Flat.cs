using System;
using System.Collections.Generic;

namespace Sociosphere.Data.Entities;

public partial class Flat
{
    public int FlatId { get; set; }

    public string FlatNumber { get; set; } = null!;

    public int FloorNumber { get; set; }

    public string BlockNumber { get; set; } = null!;

    public string Type { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<Allotment> Allotments { get; set; } = new List<Allotment>();

    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();

    public virtual ICollection<Complaint> Complaints { get; set; } = new List<Complaint>();

    public virtual ICollection<Visitor> Visitors { get; set; } = new List<Visitor>();
}
