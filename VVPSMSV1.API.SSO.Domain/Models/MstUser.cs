using System;
using System.Collections.Generic;

namespace VVPSMSV1.API.SSO.Domain.Models;

public partial class MstUser
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Userpassword { get; set; } = null!;

    public string UserGivenName { get; set; } = null!;

    public string UserSurname { get; set; } = null!;

    public string? UserPhone { get; set; }

    public int RoleId { get; set; }

    public string UserLoginType { get; set; } = null!;

    public int Enforce2Fa { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? LastloginAt { get; set; }

    public string? Useremail { get; set; }

    public virtual MstUserRole Role { get; set; } = null!;
}
