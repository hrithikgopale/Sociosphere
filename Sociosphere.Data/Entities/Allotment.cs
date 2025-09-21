using System;
using System.Collections.Generic;

namespace Sociosphere.Data.Entities;

public partial class Allotment
{
    public int AllotmentId { get; set; }

    public int AllotedTo { get; set; }

    public int FlatId { get; set; }

    public DateTime MoveInDate { get; set; }

    public DateTime? MoveOutDate { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual User AllotedToNavigation { get; set; } = null!;

    public virtual Flat Flat { get; set; } = null!;
}
