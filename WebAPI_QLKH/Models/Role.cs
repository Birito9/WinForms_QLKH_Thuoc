﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace WebAPI_QLKH.Models;

public partial class Role
{
    public string RoleID { get; set; }

    public string RoleName { get; set; }

    public virtual ICollection<Role_Permission> Role_Permission { get; set; } = new List<Role_Permission>();

    public virtual ICollection<TaiKhoan> TaiKhoan { get; set; } = new List<TaiKhoan>();
}