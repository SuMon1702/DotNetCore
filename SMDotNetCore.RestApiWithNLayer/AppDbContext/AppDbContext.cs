﻿using Microsoft.EntityFrameworkCore;
using SMDotNetCore.RestApiWithNLayer.Model;


namespace SMDotNetCore.RestApiWithNLayer.AppDbContext;

internal class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
    }

    public DbSet<MovieModel> Movies { get; set; }


}
