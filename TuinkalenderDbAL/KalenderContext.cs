﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using TuinkalenderBL;

namespace TuinkalenderDA
{
    public class KalenderContext : DbContext
    {
        //toegevoegd om de naam van de database aan te passen
        public KalenderContext() : base("Tuinkalender")
        {

        }

        public DbSet<Groente> Groenten { get; set; }
        public DbSet<Klus> Klussen { get; set; }

        public DbSet<Moestuin> Moestuinen { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           // modelBuilder.Entity<Groente>().Map(m => m.MapInheritedProperties());
           // modelBuilder.Entity<Klus>().Map(m => m.MapInheritedProperties());
        }
    }
}
