﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PanelBoard.Membership.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PanelBoard.Membership
{
    public class AaaDbContext
       : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;


        public AaaDbContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    _connectionString,
                    b => b.MigrationsAssembly(_migrationAssemblyName)
                    );
            }

            base.OnConfiguring(optionsBuilder);
        }
    }
}
