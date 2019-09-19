﻿using Autofac;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace PanelBoard.Membership
{
    public class MembershipModule
         : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssembly;

        public MembershipModule(IConfiguration configuration, string connectionStringName, string migrationAssembly)
        {
            _connectionString = configuration.GetConnectionString(connectionStringName);
            _migrationAssembly = migrationAssembly;
        }

        protected override void Load(ContainerBuilder builder)
        {


            builder.RegisterType<AaaDbContext>()
                   .WithParameter("connectionString", _connectionString)
                   .WithParameter("migrationAssemblyName", _migrationAssembly)
                   .InstancePerLifetimeScope();



            base.Load(builder);
        }
    }
}
