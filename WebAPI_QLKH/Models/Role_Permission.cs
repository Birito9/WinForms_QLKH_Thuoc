﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace WebAPI_QLKH.Models;

public partial class Role_Permission
{
    public string RoleID { get; set; }

    public string PermissionID { get; set; }

    public string Description { get; set; }

    public virtual Permission Permission { get; set; }

    public virtual Role Role { get; set; }
}