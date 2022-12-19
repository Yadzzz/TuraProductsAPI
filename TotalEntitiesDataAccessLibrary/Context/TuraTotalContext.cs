using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TotalEntitiesDataAccessLibrary.Models;

namespace TotalEntitiesDataAccessLibrary.Context;

public partial class TuraTotalContext : DbContext
{
    public TuraTotalContext()
    {
    }

    public TuraTotalContext(DbContextOptions<TuraTotalContext> options)
        : base(options)
    {
    }

   
    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<ItemTranslation> ItemTranslations { get; set; }

    public virtual DbSet<SalesCrMemoHeader> SalesCrMemoHeaders { get; set; }

    public virtual DbSet<SalesCrMemoLine> SalesCrMemoLines { get; set; }

    public virtual DbSet<SalesInvoiceHeader> SalesInvoiceHeaders { get; set; }

    public virtual DbSet<SalesInvoiceLine> SalesInvoiceLines { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();

        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("TotalEntities"));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Finnish_Swedish_100_CS_AS");

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.No).HasName("Item$0");

            entity.ToTable("Item");

            entity.Property(e => e.No)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("No_");
            entity.Property(e => e.ActivityCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Activity Code");
            entity.Property(e => e.BaseUnitOfMeasure)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Base Unit of Measure");
            entity.Property(e => e.ChildEnovaId).HasColumnName("ChildEnovaID");
            entity.Property(e => e.Choice)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.CommonItemNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Common Item No_");
            entity.Property(e => e.CountryRegionOfOriginCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Country_Region of Origin Code");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("Date Created");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Description2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Description 2");
            entity.Property(e => e.EnovaId).HasColumnName("EnovaID");
            entity.Property(e => e.GrossWeight)
                .HasColumnType("decimal(38, 20)")
                .HasColumnName("Gross Weight");
            entity.Property(e => e.ItemCategoryCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Item Category Code");
            entity.Property(e => e.ItemDiscGroup)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("Item Disc_ Group");
            entity.Property(e => e.ItemFeeCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Item Fee Code");
            entity.Property(e => e.LastDateTimeModified)
                .HasColumnType("datetime")
                .HasColumnName("Last DateTime Modified");
            entity.Property(e => e.ManufacturerCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Manufacturer Code");
            entity.Property(e => e.NetWeight)
                .HasColumnType("decimal(38, 20)")
                .HasColumnName("Net Weight");
            entity.Property(e => e.No2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("No_ 2");
            entity.Property(e => e.NotDivisibleUnit).HasColumnName("Not Divisible Unit");
            entity.Property(e => e.OrderMultiple)
                .HasColumnType("decimal(38, 20)")
                .HasColumnName("Order Multiple");
            entity.Property(e => e.ParentEnovaId).HasColumnName("ParentEnovaID");
            entity.Property(e => e.PrevActivityCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Prev Activity Code");
            entity.Property(e => e.PriceUnitConversion).HasColumnName("Price Unit Conversion");
            entity.Property(e => e.PrimaryEanCode)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("Primary EAN Code");
            entity.Property(e => e.ProductGroupCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Product Group Code");
            entity.Property(e => e.ReplacementItem)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Replacement Item");
            entity.Property(e => e.ReplacesItemNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Replaces Item No_");
            entity.Property(e => e.SearchDescription)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Search Description");
            entity.Property(e => e.TaxGroupCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Tax Group Code");
            entity.Property(e => e.Timestamp)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("timestamp");
            entity.Property(e => e.UnitPrice)
                .HasColumnType("decimal(38, 20)")
                .HasColumnName("Unit Price");
            entity.Property(e => e.UnitVolume)
                .HasColumnType("decimal(38, 20)")
                .HasColumnName("Unit Volume");
            entity.Property(e => e.UnitsPerParcel)
                .HasColumnType("decimal(38, 20)")
                .HasColumnName("Units per Parcel");
            entity.Property(e => e.VatProdPostingGroup)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("VAT Prod_ Posting Group");
            entity.Property(e => e.VendorItemNo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Vendor Item No_");
            entity.Property(e => e.VendorName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Vendor Name");
            entity.Property(e => e.VendorNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Vendor No_");
        });

        modelBuilder.Entity<ItemTranslation>(entity =>
        {
            entity.HasKey(e => new { e.ItemNo, e.VariantCode, e.LanguageCode }).HasName("Item Translation$0");

            entity.ToTable("Item Translation");

            entity.Property(e => e.ItemNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Item No_");
            entity.Property(e => e.VariantCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Variant Code");
            entity.Property(e => e.LanguageCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Language Code");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Description2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Description 2");
            entity.Property(e => e.Timestamp)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("timestamp");
        });

        modelBuilder.Entity<SalesCrMemoHeader>(entity =>
        {
            entity.HasKey(e => e.No).HasName("Sales Cr_Memo Header$0");

            entity.ToTable("Sales Cr_Memo Header");

            entity.Property(e => e.No)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("No_");
            entity.Property(e => e.Amount).HasColumnType("decimal(38, 20)");
            entity.Property(e => e.AmountInclVat)
                .HasColumnType("decimal(38, 20)")
                .HasColumnName("AmountInclVAT");
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DueDate).HasColumnType("datetime");
            entity.Property(e => e.PostingDate)
                .HasColumnType("datetime")
                .HasColumnName("Posting Date");
            entity.Property(e => e.ReturnOrderNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Return Order No_");
            entity.Property(e => e.SellToCustomerNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Sell-to Customer No_");
            entity.Property(e => e.Timestamp)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("timestamp");
            entity.Property(e => e.YourOrderNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.YourReference)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SalesCrMemoLine>(entity =>
        {
            entity.HasKey(e => new { e.DocumentNo, e.LineNo }).HasName("Sales Cr_Memo Line$0");

            entity.ToTable("Sales Cr_Memo Line");

            entity.Property(e => e.DocumentNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Document No_");
            entity.Property(e => e.LineNo).HasColumnName("Line No_");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Description2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Description 2");
            entity.Property(e => e.ItemCategoryCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Item Category Code");
            entity.Property(e => e.No)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("No_");
            entity.Property(e => e.OrderQuantity)
                .HasColumnType("decimal(38, 20)")
                .HasColumnName("Order Quantity");
            entity.Property(e => e.Quantity).HasColumnType("decimal(38, 20)");
            entity.Property(e => e.Timestamp)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("timestamp");
            entity.Property(e => e.UnitPrice)
                .HasColumnType("decimal(38, 20)")
                .HasColumnName("Unit Price");
            entity.Property(e => e.YourOrderNo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Your Order No_");
        });

        modelBuilder.Entity<SalesInvoiceHeader>(entity =>
        {
            entity.HasKey(e => e.No).HasName("Sales Invoice Header$0");

            entity.ToTable("Sales Invoice Header");

            entity.Property(e => e.No)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("No_");
            entity.Property(e => e.Amount).HasColumnType("decimal(38, 20)");
            entity.Property(e => e.AmountInclVat)
                .HasColumnType("decimal(38, 20)")
                .HasColumnName("AmountInclVAT");
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DueDate).HasColumnType("datetime");
            entity.Property(e => e.OrderDate)
                .HasColumnType("datetime")
                .HasColumnName("Order Date");
            entity.Property(e => e.OrderNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Order No_");
            entity.Property(e => e.PostingDate)
                .HasColumnType("datetime")
                .HasColumnName("Posting Date");
            entity.Property(e => e.SellToCustomerNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Sell-to Customer No_");
            entity.Property(e => e.YourOrderNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.YourReference)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
