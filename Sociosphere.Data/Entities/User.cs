using System;
using System.Collections.Generic;

namespace Sociosphere.Data.Entities;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string Role { get; set; } = null!;

    public virtual ICollection<Allotment> Allotments { get; set; } = new List<Allotment>();

    public virtual ICollection<Announcement> Announcements { get; set; } = new List<Announcement>();

    public virtual ICollection<Complaint> Complaints { get; set; } = new List<Complaint>();
}
