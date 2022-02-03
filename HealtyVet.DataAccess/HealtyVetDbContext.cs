using HealtyVet.ApplicationLogic.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealtyVet.DataAccess
{
    public class HealtyVetDbContext : DbContext
    {
        public HealtyVetDbContext(DbContextOptions<HealtyVetDbContext> options) : base(options)
        {
        }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<PetOwner> PetOwners { get; set; }
        public DbSet<Servicii> Services { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

    }
    }
