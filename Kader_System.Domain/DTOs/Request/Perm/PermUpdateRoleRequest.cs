﻿namespace Kader_System.Domain.Dtos.Request.Perm;

public class PermUpdateRoleRequest : PermCreateRoleRequest
{
    public string Id { get; set; } = string.Empty;
}
