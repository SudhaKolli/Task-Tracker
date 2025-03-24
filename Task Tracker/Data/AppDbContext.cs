﻿using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Task_Tracker.Models;

namespace Task_Tracker.Data
{
    public class AppDbContext :DbContext
    {
        public DbSet<TaskModel> Products { get; set; }
        protected readonly IConfiguration Configuration;
        public AppDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
    }
}
