﻿using System;
using System.Collections.Generic;

namespace VVPSMSV1.API.SSO.Domain.Models;

public partial class MicroSoftConfiguration
{
    public int Id { get; set; }

    public string DomainName { get; set; } = null!;

    public string DomainCode { get; set; } = null!;

    public string ClientId { get; set; } = null!;

    public string ClientSecretCode { get; set; } = null!;

    public string GrantType { get; set; } = null!;

    public string RedirectUrl { get; set; } = null!;

    public string ScopeUrl { get; set; } = null!;

    public string TokenUrl { get; set; } = null!;

    public string GraphUrl { get; set; } = null!;

    public bool? ActiveYn { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? UpdateBy { get; set; }

    public DateTime? UpdateDate { get; set; }
}
