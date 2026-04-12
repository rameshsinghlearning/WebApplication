using System;
using System.Collections.Generic;

namespace StarInfotechAPI.Models;

public partial class User
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? MobileNo { get; set; }

    public string? Email { get; set; }

    public int? RoleId { get; set; }

    public bool IsActive { get; set; }

    public DateTime AddedDate { get; set; }

    public int? AddedById { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedById { get; set; }

    public virtual User? AddedBy { get; set; }

    public virtual ICollection<User> InverseAddedBy { get; set; } = new List<User>();

    public virtual ICollection<User> InverseModifiedBy { get; set; } = new List<User>();

    public virtual User? ModifiedBy { get; set; }

    public virtual Role? Role { get; set; }
}
