using System;
using System.Collections.Generic;

namespace Sociosphere.Data.Entities;

public partial class Announcement
{
    public int AnnouncementId { get; set; }

    public string Title { get; set; } = null!;

    public string Message { get; set; } = null!;

    public DateTime PostedDate { get; set; }

    public bool IsActive { get; set; }

    public int PostedBy { get; set; }

    public virtual User PostedByNavigation { get; set; } = null!;
}
