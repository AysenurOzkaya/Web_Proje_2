﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Web_Proje_2.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Web_ProgramlamaEntities : DbContext
    {
        public Web_ProgramlamaEntities()
            : base("name=Web_ProgramlamaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BahceMalzemeleri> BahceMalzemeleris { get; set; }
        public virtual DbSet<BahceMalzemeUrun> BahceMalzemeUruns { get; set; }
        public virtual DbSet<Bitki> Bitkis { get; set; }
        public virtual DbSet<BitkiCin> BitkiCins { get; set; }
        public virtual DbSet<BitkiTur> BitkiTurs { get; set; }
        public virtual DbSet<BitkiUretim> BitkiUretims { get; set; }
        public virtual DbSet<BitkiUretim_HamMadde> BitkiUretim_HamMadde { get; set; }
        public virtual DbSet<Calisan> Calisans { get; set; }
        public virtual DbSet<HamMadde> HamMaddes { get; set; }
        public virtual DbSet<HamMadde_SatinAlma> HamMadde_SatinAlma { get; set; }
        public virtual DbSet<MiktarCin> MiktarCins { get; set; }
        public virtual DbSet<Musteri> Musteris { get; set; }
        public virtual DbSet<Sepet> Sepets { get; set; }
        public virtual DbSet<Sipari> Siparis { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Tedarikci> Tedarikcis { get; set; }
    }
}
