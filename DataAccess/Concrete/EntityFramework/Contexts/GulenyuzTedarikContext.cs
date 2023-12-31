﻿using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Contexts;

public class GulenyuzTedarikContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=GulenyuzTedarik;Integrated Security=True");
    }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Driver> Drivers { get; set; }
    public DbSet<Operation> Operations { get; set; }
    public DbSet<Application> Applications { get; set; }
    public DbSet<ApplicationCar> ApplicationCars { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
}
