using System;
using System.Collections.Generic;

namespace Sociosphere.Data.Entities;

public partial class Visitor
{
    public int VisitorId { get; set; }

    public int FlatId { get; set; }

    public string VisitorName { get; set; } = null!;

    public string VisitorPhone { get; set; } = null!;

    public string PersonToMeet { get; set; } = null!;

    public DateTime InTime { get; set; }

    public DateTime? OutTime { get; set; }

    public string Status { get; set; } = null!;

    public virtual Flat Flat { get; set; } = null!;
}
