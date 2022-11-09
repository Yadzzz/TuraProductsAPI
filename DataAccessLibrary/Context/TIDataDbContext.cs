using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DataAccessLibrary.Models;
using Microsoft.Extensions.Configuration;

namespace DataAccessLibrary.Context
{
    public partial class TIDataDbContext : DbContext
    {
        public TIDataDbContext()
        {
        }

        public TIDataDbContext(DbContextOptions<TIDataDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GetItemDescDanWeb> GetItemDescDanWebs { get; set; } = null!;
        public virtual DbSet<GetItemDescEngWeb> GetItemDescEngWebs { get; set; } = null!;
        public virtual DbSet<GetItemDescFinWeb> GetItemDescFinWebs { get; set; } = null!;
        public virtual DbSet<GetItemDescNorWeb> GetItemDescNorWebs { get; set; } = null!;
        public virtual DbSet<GetItemDescSweWeb> GetItemDescSweWebs { get; set; } = null!;
        public virtual DbSet<TiLitProductDescription> TiLitProductDescriptions { get; set; } = null!;
        public virtual DbSet<TiNavActivityCode> TiNavActivityCodes { get; set; } = null!;
        public virtual DbSet<TiNavCustItemgroup> TiNavCustItemgroups { get; set; } = null!;
        public virtual DbSet<TiNavCustomer> TiNavCustomers { get; set; } = null!;
        public virtual DbSet<TiNavCustomerItemDiscountGroup> TiNavCustomerItemDiscountGroups { get; set; } = null!;
        public virtual DbSet<TiNavGeneralLedgerSetup> TiNavGeneralLedgerSetups { get; set; } = null!;
        public virtual DbSet<TiNavItem> TiNavItems { get; set; } = null!;
        public virtual DbSet<TiNavItemCategory> TiNavItemCategories { get; set; } = null!;
        public virtual DbSet<TiNavItemCrossReference> TiNavItemCrossReferences { get; set; } = null!;
        public virtual DbSet<TiNavItemEnvironmentalReporting> TiNavItemEnvironmentalReportings { get; set; } = null!;
        public virtual DbSet<TiNavItemFee> TiNavItemFees { get; set; } = null!;
        public virtual DbSet<TiNavItemFee1> TiNavItemFees1 { get; set; } = null!;
        public virtual DbSet<TiNavItemFeePrice> TiNavItemFeePrices { get; set; } = null!;
        public virtual DbSet<TiNavItemFeeTranslation> TiNavItemFeeTranslations { get; set; } = null!;
        public virtual DbSet<TiNavItemLedgerEntry> TiNavItemLedgerEntries { get; set; } = null!;
        public virtual DbSet<TiNavItemSubstitution> TiNavItemSubstitutions { get; set; } = null!;
        public virtual DbSet<TiNavItemTranslation> TiNavItemTranslations { get; set; } = null!;
        public virtual DbSet<TiNavItemUnitOfMeasure> TiNavItemUnitOfMeasures { get; set; } = null!;
        public virtual DbSet<TiNavManufacturer> TiNavManufacturers { get; set; } = null!;
        public virtual DbSet<TiNavPrisexportSetup> TiNavPrisexportSetups { get; set; } = null!;
        public virtual DbSet<TiNavProductGroup> TiNavProductGroups { get; set; } = null!;
        public virtual DbSet<TiNavPurchaseLine> TiNavPurchaseLines { get; set; } = null!;
        public virtual DbSet<TiNavQtyTmp> TiNavQtyTmps { get; set; } = null!;
        public virtual DbSet<TiNavReservationEntry> TiNavReservationEntries { get; set; } = null!;
        public virtual DbSet<TiNavSalesLine> TiNavSalesLines { get; set; } = null!;
        public virtual DbSet<TiNavSalesLineDiscount> TiNavSalesLineDiscounts { get; set; } = null!;
        public virtual DbSet<TiNavSalesPrice> TiNavSalesPrices { get; set; } = null!;
        public virtual DbSet<TiNavVatPostingSetup> TiNavVatPostingSetups { get; set; } = null!;
        public virtual DbSet<TiNavVendor> TiNavVendors { get; set; } = null!;
        public virtual DbSet<TiNavWipProductCategory> TiNavWipProductCategories { get; set; } = null!;
        public virtual DbSet<ViewTempPrisListExport> ViewTempPrisListExports { get; set; } = null!;
        public virtual DbSet<ViewTempPrisListExportCdon> ViewTempPrisListExportCdons { get; set; } = null!;
        public virtual DbSet<ViewTempPrisListExportElk> ViewTempPrisListExportElks { get; set; } = null!;
        public virtual DbSet<ViewTempPrisListExportElkFeed> ViewTempPrisListExportElkFeeds { get; set; } = null!;
        public virtual DbSet<ViewTempPrisListExportElkPlife> ViewTempPrisListExportElkPlives { get; set; } = null!;
        public virtual DbSet<ViewTempPrisListExportElkPrice> ViewTempPrisListExportElkPrices { get; set; } = null!;
        public virtual DbSet<ViewTempPrisListExportFilter> ViewTempPrisListExportFilters { get; set; } = null!;
        public virtual DbSet<ViewTempPrisListExportHr> ViewTempPrisListExportHrs { get; set; } = null!;
        public virtual DbSet<ViewTempPrisListExportHrsFilter> ViewTempPrisListExportHrsFilters { get; set; } = null!;
        public virtual DbSet<ViewTempPrisListExportQty> ViewTempPrisListExportQties { get; set; } = null!;
        public virtual DbSet<ViewTempPrisListExportSingle> ViewTempPrisListExportSingles { get; set; } = null!;
        public virtual DbSet<ViewTempPrisListExportSsr> ViewTempPrisListExportSsrs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();
            
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Data Source=LAPTOP-V6EKNDRG\\SQLEXPRESS;Initial Catalog=TI;Integrated Security=True;");
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("Default"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Finnish_Swedish_100_CS_AS");

            modelBuilder.Entity<GetItemDescDanWeb>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GetItemDescDanWeb");

                entity.Property(e => e.Eancode)
                    .HasMaxLength(13)
                    .HasColumnName("EANCode");

                entity.Property(e => e.ManufacturerCode).HasMaxLength(10);

                entity.Property(e => e.ProductDescriptionDan).HasColumnName("ProductDescriptionDAN");

                entity.Property(e => e.TuraItemNo).HasMaxLength(20);

                entity.Property(e => e.VendorItemNo).HasMaxLength(20);

                entity.Property(e => e.WebCat1).HasMaxLength(250);

                entity.Property(e => e.WebCat2).HasMaxLength(250);

                entity.Property(e => e.WebCat3).HasMaxLength(250);
            });

            modelBuilder.Entity<GetItemDescEngWeb>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GetItemDescEngWeb");

                entity.Property(e => e.Eancode)
                    .HasMaxLength(13)
                    .HasColumnName("EANCode");

                entity.Property(e => e.ManufacturerCode).HasMaxLength(10);

                entity.Property(e => e.ProductDescriptionEng).HasColumnName("ProductDescriptionENG");

                entity.Property(e => e.TuraItemNo).HasMaxLength(20);

                entity.Property(e => e.VendorItemNo).HasMaxLength(20);

                entity.Property(e => e.WebCat1).HasMaxLength(250);

                entity.Property(e => e.WebCat2).HasMaxLength(250);

                entity.Property(e => e.WebCat3).HasMaxLength(250);
            });

            modelBuilder.Entity<GetItemDescFinWeb>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GetItemDescFinWeb");

                entity.Property(e => e.Eancode)
                    .HasMaxLength(13)
                    .HasColumnName("EANCode");

                entity.Property(e => e.ManufacturerCode).HasMaxLength(10);

                entity.Property(e => e.ProductDescriptionFin).HasColumnName("ProductDescriptionFIN");

                entity.Property(e => e.TuraItemNo).HasMaxLength(20);

                entity.Property(e => e.VendorItemNo).HasMaxLength(20);

                entity.Property(e => e.WebCat1).HasMaxLength(250);

                entity.Property(e => e.WebCat2).HasMaxLength(250);

                entity.Property(e => e.WebCat3).HasMaxLength(250);
            });

            modelBuilder.Entity<GetItemDescNorWeb>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GetItemDescNorWeb");

                entity.Property(e => e.Eancode)
                    .HasMaxLength(13)
                    .HasColumnName("EANCode");

                entity.Property(e => e.ManufacturerCode).HasMaxLength(10);

                entity.Property(e => e.ProductDescriptionNor).HasColumnName("ProductDescriptionNOR");

                entity.Property(e => e.TuraItemNo).HasMaxLength(20);

                entity.Property(e => e.VendorItemNo).HasMaxLength(20);

                entity.Property(e => e.WebCat1).HasMaxLength(250);

                entity.Property(e => e.WebCat2).HasMaxLength(250);

                entity.Property(e => e.WebCat3).HasMaxLength(250);
            });

            modelBuilder.Entity<GetItemDescSweWeb>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GetItemDescSweWeb");

                entity.Property(e => e.Eancode)
                    .HasMaxLength(13)
                    .HasColumnName("EANCode");

                entity.Property(e => e.ManufacturerCode).HasMaxLength(10);

                entity.Property(e => e.ProductDescriptionSwe).HasColumnName("ProductDescriptionSWE");

                entity.Property(e => e.TuraItemNo).HasMaxLength(20);

                entity.Property(e => e.VendorItemNo).HasMaxLength(20);

                entity.Property(e => e.WebCat1).HasMaxLength(250);

                entity.Property(e => e.WebCat2).HasMaxLength(250);

                entity.Property(e => e.WebCat3).HasMaxLength(250);
            });

            modelBuilder.Entity<TiLitProductDescription>(entity =>
            {
                entity.HasKey(e => e.VariantId)
                    .HasName("PK_LitiumProductsDescription");

                entity.ToTable("TI LIT$ProductDescription");

                entity.Property(e => e.VariantId)
                    .HasMaxLength(100)
                    .HasColumnName("Variant-ID");

                entity.Property(e => e.BaseId)
                    .HasMaxLength(100)
                    .HasColumnName("Base-ID");

                entity.Property(e => e.Brand).HasMaxLength(50);

                entity.Property(e => e.DkItemName).HasColumnName("DK_ItemName");

                entity.Property(e => e.DkItemText).HasColumnName("DK_ItemText");

                entity.Property(e => e.EnItemName).HasColumnName("EN_ItemName");

                entity.Property(e => e.EnItemText).HasColumnName("EN_ItemText");

                entity.Property(e => e.FiItemName).HasColumnName("FI_ItemName");

                entity.Property(e => e.FiItemText).HasColumnName("FI_ItemText");

                entity.Property(e => e.Gtin)
                    .HasMaxLength(50)
                    .HasColumnName("GTIN");

                entity.Property(e => e.ManufacturerItemNo).HasMaxLength(50);

                entity.Property(e => e.NoItemName).HasColumnName("NO_ItemName");

                entity.Property(e => e.NoItemText).HasColumnName("NO_ItemText");

                entity.Property(e => e.SeItemName).HasColumnName("SE_ItemName");

                entity.Property(e => e.SeItemText).HasColumnName("SE_ItemText");
            });

            modelBuilder.Entity<TiNavActivityCode>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("TI NAV$Activity Code$0");

                entity.ToTable("TI NAV$Activity Code");

                entity.Property(e => e.Code).HasMaxLength(10);

                entity.Property(e => e.ActivityCodeForNegInventor)
                    .HasMaxLength(10)
                    .HasColumnName("Activity code for neg inventor");

                entity.Property(e => e.ActivityCodeForPosInventor)
                    .HasMaxLength(10)
                    .HasColumnName("Activity code for pos inventor");

                entity.Property(e => e.Description).HasMaxLength(30);

                entity.Property(e => e.InsuffInvNotAllowedOnSol).HasColumnName("Insuff inv not allowed on SOL");

                entity.Property(e => e.LocationFilter)
                    .HasMaxLength(20)
                    .HasColumnName("Location Filter");

                entity.Property(e => e.ReturnNotAllowed).HasColumnName("Return not allowed");

                entity.Property(e => e.SoloDeliveryCode)
                    .HasMaxLength(50)
                    .HasColumnName("SOLO Delivery Code");

                entity.Property(e => e.StandardtextForActivitycode)
                    .HasMaxLength(10)
                    .HasColumnName("Standardtext for activitycode");

                entity.Property(e => e.StatusPriceFile).HasMaxLength(30);

                entity.Property(e => e.Timestamp)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("timestamp");
            });

            modelBuilder.Entity<TiNavCustItemgroup>(entity =>
            {
                entity.HasKey(e => new { e.CustomerNo, e.CustomerChain, e.ItemNo })
                    .HasName("TI NAV$Cust_ Itemgroup$0");

                entity.ToTable("TI NAV$Cust_ Itemgroup");

                entity.Property(e => e.CustomerNo)
                    .HasMaxLength(20)
                    .HasColumnName("Customer no");

                entity.Property(e => e.CustomerChain)
                    .HasMaxLength(10)
                    .HasColumnName("Customer Chain");

                entity.Property(e => e.ItemNo)
                    .HasMaxLength(20)
                    .HasColumnName("Item no");

                entity.Property(e => e.Description).HasMaxLength(30);

                entity.Property(e => e.ItemGroupNo)
                    .HasMaxLength(10)
                    .HasColumnName("Item Group No");

                entity.Property(e => e.Manufacturer).HasMaxLength(35);

                entity.Property(e => e.Timestamp)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("timestamp");
            });

            modelBuilder.Entity<TiNavCustomer>(entity =>
            {
                entity.HasKey(e => e.No)
                    .HasName("TI NAV$Customer$0");

                entity.ToTable("TI NAV$Customer");

                entity.Property(e => e.No)
                    .HasMaxLength(20)
                    .HasColumnName("No_");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Address2)
                    .HasMaxLength(50)
                    .HasColumnName("Address 2");

                entity.Property(e => e.AllowLineDisc).HasColumnName("Allow Line Disc_");

                entity.Property(e => e.Amount).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.ApplicationMethod).HasColumnName("Application Method");

                entity.Property(e => e.AshTaxOnChemicals).HasColumnName("ASH Tax on chemicals");

                entity.Property(e => e.BaseCalendarCode)
                    .HasMaxLength(10)
                    .HasColumnName("Base Calendar Code");

                entity.Property(e => e.BillToCustomerNo)
                    .HasMaxLength(20)
                    .HasColumnName("Bill-to Customer No_");

                entity.Property(e => e.BlockPaymentTolerance).HasColumnName("Block Payment Tolerance");

                entity.Property(e => e.BudgetedAmount)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Budgeted Amount");

                entity.Property(e => e.CashFlowPaymentTermsCode)
                    .HasMaxLength(10)
                    .HasColumnName("Cash Flow Payment Terms Code");

                entity.Property(e => e.ChainName)
                    .HasMaxLength(10)
                    .HasColumnName("Chain Name");

                entity.Property(e => e.Choice).HasMaxLength(30);

                entity.Property(e => e.City).HasMaxLength(30);

                entity.Property(e => e.CollectionMethod)
                    .HasMaxLength(20)
                    .HasColumnName("Collection Method");

                entity.Property(e => e.CombineShipments).HasColumnName("Combine Shipments");

                entity.Property(e => e.Contact).HasMaxLength(50);

                entity.Property(e => e.ContactGraphId)
                    .HasMaxLength(250)
                    .HasColumnName("Contact Graph Id");

                entity.Property(e => e.ContactId).HasColumnName("Contact ID");

                entity.Property(e => e.ContactType).HasColumnName("Contact Type");

                entity.Property(e => e.CopySellToAddrToQteFrom).HasColumnName("Copy Sell-to Addr_ to Qte From");

                entity.Property(e => e.CountryRegionCode)
                    .HasMaxLength(10)
                    .HasColumnName("Country_Region Code");

                entity.Property(e => e.County).HasMaxLength(30);

                entity.Property(e => e.CreditLimitLcy)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Credit Limit (LCY)");

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(10)
                    .HasColumnName("Currency Code");

                entity.Property(e => e.CurrencyId).HasColumnName("Currency Id");

                entity.Property(e => e.CustomerDiscGroup)
                    .HasMaxLength(20)
                    .HasColumnName("Customer Disc_ Group");

                entity.Property(e => e.CustomerPostingGroup)
                    .HasMaxLength(20)
                    .HasColumnName("Customer Posting Group");

                entity.Property(e => e.CustomerPriceGroup)
                    .HasMaxLength(10)
                    .HasColumnName("Customer Price Group");

                entity.Property(e => e.DelayedPayments).HasColumnName("Delayed payments");

                entity.Property(e => e.DocumentSendingProfile)
                    .HasMaxLength(20)
                    .HasColumnName("Document Sending Profile");

                entity.Property(e => e.EMail)
                    .HasMaxLength(80)
                    .HasColumnName("E-Mail");

                entity.Property(e => e.Eancode)
                    .HasMaxLength(25)
                    .HasColumnName("EANCode");

                entity.Property(e => e.FaxNo)
                    .HasMaxLength(30)
                    .HasColumnName("Fax No_");

                entity.Property(e => e.FeeCustomerGroupCode)
                    .HasMaxLength(10)
                    .HasColumnName("Fee Customer Group Code");

                entity.Property(e => e.FeeInclInPrice).HasColumnName("Fee incl_ in Price");

                entity.Property(e => e.FeeZeroPrice).HasColumnName("Fee Zero Price");

                entity.Property(e => e.FilterItemGroup).HasMaxLength(250);

                entity.Property(e => e.FinChargeTermsCode)
                    .HasMaxLength(10)
                    .HasColumnName("Fin_ Charge Terms Code");

                entity.Property(e => e.GenBusPostingGroup)
                    .HasMaxLength(20)
                    .HasColumnName("Gen_ Bus_ Posting Group");

                entity.Property(e => e.Gln)
                    .HasMaxLength(13)
                    .HasColumnName("GLN");

                entity.Property(e => e.GlobalDimension1Code)
                    .HasMaxLength(20)
                    .HasColumnName("Global Dimension 1 Code");

                entity.Property(e => e.GlobalDimension2Code)
                    .HasMaxLength(20)
                    .HasColumnName("Global Dimension 2 Code");

                entity.Property(e => e.HomePage)
                    .HasMaxLength(80)
                    .HasColumnName("Home Page");

                entity.Property(e => e.IcPartnerCode)
                    .HasMaxLength(20)
                    .HasColumnName("IC Partner Code");

                entity.Property(e => e.IgnoreInvoiceRounding).HasColumnName("Ignore invoice rounding");

                entity.Property(e => e.InvoiceCopies).HasColumnName("Invoice Copies");

                entity.Property(e => e.InvoiceDiscCode)
                    .HasMaxLength(20)
                    .HasColumnName("Invoice Disc_ Code");

                entity.Property(e => e.InvoiceEMail)
                    .HasMaxLength(80)
                    .HasColumnName("Invoice E-Mail");

                entity.Property(e => e.InvoiceType).HasColumnName("Invoice Type");

                entity.Property(e => e.LanguageCode)
                    .HasMaxLength(10)
                    .HasColumnName("Language Code");

                entity.Property(e => e.LastDateModified)
                    .HasColumnType("datetime")
                    .HasColumnName("Last Date Modified");

                entity.Property(e => e.LastDateTimeModified)
                    .HasColumnType("datetime")
                    .HasColumnName("Last DateTime Modified");

                entity.Property(e => e.LastModifiedDateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Last Modified Date Time");

                entity.Property(e => e.LastStatementNo).HasColumnName("Last Statement No_");

                entity.Property(e => e.LocationCode)
                    .HasMaxLength(10)
                    .HasColumnName("Location Code");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Name2)
                    .HasMaxLength(50)
                    .HasColumnName("Name 2");

                entity.Property(e => e.NoPartlyDelivery).HasColumnName("No partly delivery");

                entity.Property(e => e.NoSeries)
                    .HasMaxLength(20)
                    .HasColumnName("No_ Series");

                entity.Property(e => e.NoSummationPick).HasColumnName("No summation pick");

                entity.Property(e => e.Ob10Elkjöp)
                    .HasMaxLength(30)
                    .HasColumnName("OB10 Elkjöp");

                entity.Property(e => e.Ob10Tura)
                    .HasMaxLength(30)
                    .HasColumnName("OB10 Tura");

                entity.Property(e => e.OrderFreightCode)
                    .HasMaxLength(20)
                    .HasColumnName("Order Freight Code");

                entity.Property(e => e.Ordertype).HasMaxLength(10);

                entity.Property(e => e.OurAccountNo)
                    .HasMaxLength(20)
                    .HasColumnName("Our Account No_");

                entity.Property(e => e.PartnerType).HasColumnName("Partner Type");

                entity.Property(e => e.PaymentMethodCode)
                    .HasMaxLength(10)
                    .HasColumnName("Payment Method Code");

                entity.Property(e => e.PaymentMethodId).HasColumnName("Payment Method Id");

                entity.Property(e => e.PaymentTermsCode)
                    .HasMaxLength(10)
                    .HasColumnName("Payment Terms Code");

                entity.Property(e => e.PaymentTermsId).HasColumnName("Payment Terms Id");

                entity.Property(e => e.PebApprovalStatus).HasColumnName("PEB Approval Status");

                entity.Property(e => e.PebAutoGiroType).HasColumnName("PEB Auto Giro Type");

                entity.Property(e => e.PebBankGiroNo)
                    .HasMaxLength(30)
                    .HasColumnName("PEB Bank Giro No_");

                entity.Property(e => e.PebDocumentCode)
                    .HasMaxLength(10)
                    .HasColumnName("PEB Document Code");

                entity.Property(e => e.PebPlusGiroNo)
                    .HasMaxLength(20)
                    .HasColumnName("PEB Plus Giro No_");

                entity.Property(e => e.PebRegistrationNo)
                    .HasMaxLength(20)
                    .HasColumnName("PEB Registration No_");

                entity.Property(e => e.PebShipToCode)
                    .HasMaxLength(10)
                    .HasColumnName("PEB Ship-to Code");

                entity.Property(e => e.PhoneNo)
                    .HasMaxLength(30)
                    .HasColumnName("Phone No_");

                entity.Property(e => e.Picture).HasColumnType("image");

                entity.Property(e => e.PlaceOfExport)
                    .HasMaxLength(20)
                    .HasColumnName("Place of Export");

                entity.Property(e => e.PostCode)
                    .HasMaxLength(20)
                    .HasColumnName("Post Code");

                entity.Property(e => e.PreferredBankAccountCode)
                    .HasMaxLength(20)
                    .HasColumnName("Preferred Bank Account Code");

                entity.Property(e => e.Prepayment)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Prepayment _");

                entity.Property(e => e.PricelistInterval).HasColumnName("Pricelist Interval");

                entity.Property(e => e.PricesIncludingVat).HasColumnName("Prices Including VAT");

                entity.Property(e => e.PrimaryContactNo)
                    .HasMaxLength(20)
                    .HasColumnName("Primary Contact No_");

                entity.Property(e => e.PrintStatements).HasColumnName("Print Statements");

                entity.Property(e => e.PrivacyBlocked).HasColumnName("Privacy Blocked");

                entity.Property(e => e.ReminderTermsCode)
                    .HasMaxLength(10)
                    .HasColumnName("Reminder Terms Code");

                entity.Property(e => e.ResponsibilityCenter)
                    .HasMaxLength(10)
                    .HasColumnName("Responsibility Center");

                entity.Property(e => e.SalespersonCode)
                    .HasMaxLength(20)
                    .HasColumnName("Salesperson Code");

                entity.Property(e => e.SearchName)
                    .HasMaxLength(50)
                    .HasColumnName("Search Name");

                entity.Property(e => e.ServiceZoneCode)
                    .HasMaxLength(10)
                    .HasColumnName("Service Zone Code");

                entity.Property(e => e.ShipmentMethodCode)
                    .HasMaxLength(10)
                    .HasColumnName("Shipment Method Code");

                entity.Property(e => e.ShipmentMethodId).HasColumnName("Shipment Method Id");

                entity.Property(e => e.ShippingAdvice).HasColumnName("Shipping Advice");

                entity.Property(e => e.ShippingAgentCode)
                    .HasMaxLength(10)
                    .HasColumnName("Shipping Agent Code");

                entity.Property(e => e.ShippingAgentServiceCode)
                    .HasMaxLength(10)
                    .HasColumnName("Shipping Agent Service Code");

                entity.Property(e => e.ShippingTime)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("Shipping Time");

                entity.Property(e => e.StatisticsGroup).HasColumnName("Statistics Group");

                entity.Property(e => e.TaxAreaCode)
                    .HasMaxLength(20)
                    .HasColumnName("Tax Area Code");

                entity.Property(e => e.TaxAreaId).HasColumnName("Tax Area ID");

                entity.Property(e => e.TaxLiable).HasColumnName("Tax Liable");

                entity.Property(e => e.TelexAnswerBack)
                    .HasMaxLength(20)
                    .HasColumnName("Telex Answer Back");

                entity.Property(e => e.TelexNo)
                    .HasMaxLength(20)
                    .HasColumnName("Telex No_");

                entity.Property(e => e.TerritoryCode)
                    .HasMaxLength(10)
                    .HasColumnName("Territory Code");

                entity.Property(e => e.ThresholdPaymentDelayDays)
                    .HasMaxLength(50)
                    .HasColumnName("Threshold payment delay days");

                entity.Property(e => e.Timestamp)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("timestamp");

                entity.Property(e => e.ValidateEuVatRegNo).HasColumnName("Validate EU Vat Reg_ No_");

                entity.Property(e => e.VatBusPostingGroup)
                    .HasMaxLength(20)
                    .HasColumnName("VAT Bus_ Posting Group");

                entity.Property(e => e.VatRegistrationNo)
                    .HasMaxLength(20)
                    .HasColumnName("VAT Registration No_");

                entity.Property(e => e.WebShop).HasColumnName("Web Shop");

                entity.Property(e => e.WebshopAdminEmail).HasMaxLength(80);

                entity.Property(e => e.WebshopAdminName).HasMaxLength(80);

                entity.Property(e => e.WebshopAdminPhone).HasMaxLength(30);
            });

            modelBuilder.Entity<TiNavCustomerItemDiscountGroup>(entity =>
            {
                entity.HasKey(e => new { e.No, e.Code })
                    .HasName("TI NAV$Customer Item Discount Group$0");

                entity.ToTable("TI NAV$Customer Item Discount Group");

                entity.Property(e => e.No)
                    .HasMaxLength(20)
                    .HasColumnName("No_");

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.Timestamp)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("timestamp");
            });

            modelBuilder.Entity<TiNavGeneralLedgerSetup>(entity =>
            {
                entity.HasKey(e => e.PrimaryKey)
                    .HasName("TI NAV$General Ledger Setup$0");

                entity.ToTable("TI NAV$General Ledger Setup");

                entity.Property(e => e.PrimaryKey)
                    .HasMaxLength(10)
                    .HasColumnName("Primary Key");

                entity.Property(e => e.AccSchedForBalanceSheet)
                    .HasMaxLength(10)
                    .HasColumnName("Acc_ Sched_ for Balance Sheet");

                entity.Property(e => e.AccSchedForCashFlowStmt)
                    .HasMaxLength(10)
                    .HasColumnName("Acc_ Sched_ for Cash Flow Stmt");

                entity.Property(e => e.AccSchedForIncomeStmt)
                    .HasMaxLength(10)
                    .HasColumnName("Acc_ Sched_ for Income Stmt_");

                entity.Property(e => e.AccSchedForRetainedEarn)
                    .HasMaxLength(10)
                    .HasColumnName("Acc_ Sched_ for Retained Earn_");

                entity.Property(e => e.ActivateForeignCurrencyPost).HasColumnName("Activate Foreign Currency Post");

                entity.Property(e => e.AdaptMainMenuToPermissions).HasColumnName("Adapt Main Menu to Permissions");

                entity.Property(e => e.AdditionalReportingCurrency)
                    .HasMaxLength(10)
                    .HasColumnName("Additional Reporting Currency");

                entity.Property(e => e.AdjustForPaymentDisc).HasColumnName("Adjust for Payment Disc_");

                entity.Property(e => e.AllowGLAccDeletionBefore)
                    .HasColumnType("datetime")
                    .HasColumnName("Allow G_L Acc_ Deletion Before");

                entity.Property(e => e.AllowPostingFrom)
                    .HasColumnType("datetime")
                    .HasColumnName("Allow Posting From");

                entity.Property(e => e.AllowPostingTo)
                    .HasColumnType("datetime")
                    .HasColumnName("Allow Posting To");

                entity.Property(e => e.AmountDecimalPlaces)
                    .HasMaxLength(5)
                    .HasColumnName("Amount Decimal Places");

                entity.Property(e => e.AmountRoundingPrecision)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Amount Rounding Precision");

                entity.Property(e => e.ApplnRoundingPrecision)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Appln_ Rounding Precision");

                entity.Property(e => e.AutoTransferForeighnEntry).HasColumnName("Auto Transfer foreighn entry");

                entity.Property(e => e.BankAccountNos)
                    .HasMaxLength(20)
                    .HasColumnName("Bank Account Nos_");

                entity.Property(e => e.BillToSellToVatCalc).HasColumnName("Bill-to_Sell-to VAT Calc_");

                entity.Property(e => e.CheckGLAccountUsage).HasColumnName("Check G_L Account Usage");

                entity.Property(e => e.CheckPrinterQue).HasColumnName("Check Printer Que");

                entity.Property(e => e.CurrencyDeviationAccount)
                    .HasMaxLength(10)
                    .HasColumnName("Currency Deviation Account");

                entity.Property(e => e.DocumentCompanyAddress).HasColumnName("Document Company Address");

                entity.Property(e => e.DocumentFootData).HasColumnName("Document Foot Data");

                entity.Property(e => e.DocumentFootHeadline).HasColumnName("Document Foot Headline");

                entity.Property(e => e.EmuCurrency).HasColumnName("EMU Currency");

                entity.Property(e => e.GeneralDocumentLanguage)
                    .HasMaxLength(10)
                    .HasColumnName("General Document Language");

                entity.Property(e => e.GlobalDimension1Code)
                    .HasMaxLength(20)
                    .HasColumnName("Global Dimension 1 Code");

                entity.Property(e => e.GlobalDimension2Code)
                    .HasMaxLength(20)
                    .HasColumnName("Global Dimension 2 Code");

                entity.Property(e => e.InvRoundingPrecisionLcy)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Inv_ Rounding Precision (LCY)");

                entity.Property(e => e.InvRoundingTypeLcy).HasColumnName("Inv_ Rounding Type (LCY)");

                entity.Property(e => e.LastIcTransactionNo).HasColumnName("Last IC Transaction No_");

                entity.Property(e => e.LcyCode)
                    .HasMaxLength(10)
                    .HasColumnName("LCY Code");

                entity.Property(e => e.LocalAddressFormat).HasColumnName("Local Address Format");

                entity.Property(e => e.LocalContAddrFormat).HasColumnName("Local Cont_ Addr_ Format");

                entity.Property(e => e.LocalCurrencyDescription)
                    .HasMaxLength(60)
                    .HasColumnName("Local Currency Description");

                entity.Property(e => e.LocalCurrencySymbol)
                    .HasMaxLength(10)
                    .HasColumnName("Local Currency Symbol");

                entity.Property(e => e.MarkCrMemosAsCorrections).HasColumnName("Mark Cr_ Memos as Corrections");

                entity.Property(e => e.MaxPaymentToleranceAmount)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Max_ Payment Tolerance Amount");

                entity.Property(e => e.MaxVatDifferenceAllowed)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Max_ VAT Difference Allowed");

                entity.Property(e => e.NoBalanceAccountNo)
                    .HasMaxLength(10)
                    .HasColumnName("NO Balance Account No");

                entity.Property(e => e.NoDateCheck).HasColumnName("No date check");

                entity.Property(e => e.NoGLPostingNos)
                    .HasMaxLength(10)
                    .HasColumnName("NO G_L Posting nos_");

                entity.Property(e => e.NoPostingCompany)
                    .HasMaxLength(30)
                    .HasColumnName("NO Posting Company");

                entity.Property(e => e.PaymentDiscountGracePeriod)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("Payment Discount Grace Period");

                entity.Property(e => e.PaymentTolerance)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Payment Tolerance _");

                entity.Property(e => e.PaymentTolerancePosting).HasColumnName("Payment Tolerance Posting");

                entity.Property(e => e.PaymentToleranceWarning).HasColumnName("Payment Tolerance Warning");

                entity.Property(e => e.PayrollTransImportFormat)
                    .HasMaxLength(20)
                    .HasColumnName("Payroll Trans_ Import Format");

                entity.Property(e => e.PmtDiscExclVat).HasColumnName("Pmt_ Disc_ Excl_ VAT");

                entity.Property(e => e.PmtDiscTolerancePosting).HasColumnName("Pmt_ Disc_ Tolerance Posting");

                entity.Property(e => e.PmtDiscToleranceWarning).HasColumnName("Pmt_ Disc_ Tolerance Warning");

                entity.Property(e => e.PrepaymentUnrealizedVat).HasColumnName("Prepayment Unrealized VAT");

                entity.Property(e => e.PrintVatSpecificationInLcy).HasColumnName("Print VAT specification in LCY");

                entity.Property(e => e.RegisterTime).HasColumnName("Register Time");

                entity.Property(e => e.ShortcutDimension1Code)
                    .HasMaxLength(20)
                    .HasColumnName("Shortcut Dimension 1 Code");

                entity.Property(e => e.ShortcutDimension2Code)
                    .HasMaxLength(20)
                    .HasColumnName("Shortcut Dimension 2 Code");

                entity.Property(e => e.ShortcutDimension3Code)
                    .HasMaxLength(20)
                    .HasColumnName("Shortcut Dimension 3 Code");

                entity.Property(e => e.ShortcutDimension4Code)
                    .HasMaxLength(20)
                    .HasColumnName("Shortcut Dimension 4 Code");

                entity.Property(e => e.ShortcutDimension5Code)
                    .HasMaxLength(20)
                    .HasColumnName("Shortcut Dimension 5 Code");

                entity.Property(e => e.ShortcutDimension6Code)
                    .HasMaxLength(20)
                    .HasColumnName("Shortcut Dimension 6 Code");

                entity.Property(e => e.ShortcutDimension7Code)
                    .HasMaxLength(20)
                    .HasColumnName("Shortcut Dimension 7 Code");

                entity.Property(e => e.ShortcutDimension8Code)
                    .HasMaxLength(20)
                    .HasColumnName("Shortcut Dimension 8 Code");

                entity.Property(e => e.ShowAmounts).HasColumnName("Show Amounts");

                entity.Property(e => e.SummarizeGLEntries).HasColumnName("Summarize G_L Entries");

                entity.Property(e => e.Timestamp)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("timestamp");

                entity.Property(e => e.UnitAmountDecimalPlaces)
                    .HasMaxLength(5)
                    .HasColumnName("Unit-Amount Decimal Places");

                entity.Property(e => e.UnitAmountRoundingPrecision)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Unit-Amount Rounding Precision");

                entity.Property(e => e.UnrealizedVat).HasColumnName("Unrealized VAT");

                entity.Property(e => e.UseLegacyGLEntryLocking).HasColumnName("Use Legacy G_L Entry Locking");

                entity.Property(e => e.VatExchangeRateAdjustment).HasColumnName("VAT Exchange Rate Adjustment");

                entity.Property(e => e.VatRegNoValidationUrl)
                    .HasMaxLength(250)
                    .HasColumnName("VAT Reg_ No_ Validation URL");

                entity.Property(e => e.VatRoundingType).HasColumnName("VAT Rounding Type");

                entity.Property(e => e.VatTolerance)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("VAT Tolerance _");
            });

            modelBuilder.Entity<TiNavItem>(entity =>
            {
                entity.HasKey(e => e.No)
                    .HasName("TI NAV$Item$0");

                entity.ToTable("TI NAV$Item");

                entity.Property(e => e.No)
                    .HasMaxLength(20)
                    .HasColumnName("No_");

                entity.Property(e => e.ActivityCode)
                    .HasMaxLength(10)
                    .HasColumnName("Activity Code");

                entity.Property(e => e.AllowInvoiceDisc).HasColumnName("Allow Invoice Disc_");

                entity.Property(e => e.AllowOnlineAdjustment).HasColumnName("Allow Online Adjustment");

                entity.Property(e => e.AlternativeItemNo)
                    .HasMaxLength(20)
                    .HasColumnName("Alternative Item No_");

                entity.Property(e => e.ApplicationWkshUserId)
                    .HasMaxLength(128)
                    .HasColumnName("Application Wksh_ User ID");

                entity.Property(e => e.AssemblyPolicy).HasColumnName("Assembly Policy");

                entity.Property(e => e.AutomaticExtTexts).HasColumnName("Automatic Ext_ Texts");

                entity.Property(e => e.AvailableQtyToPromise)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Available Qty_ to Promise");

                entity.Property(e => e.BaseUnitOfMeasure)
                    .HasMaxLength(10)
                    .HasColumnName("Base Unit of Measure");

                entity.Property(e => e.BaseunitForElkjop)
                    .HasMaxLength(10)
                    .HasColumnName("Baseunit for Elkjop");

                entity.Property(e => e.BaseunitForInnerCarton)
                    .HasMaxLength(10)
                    .HasColumnName("Baseunit for Inner carton");

                entity.Property(e => e.BaseunitForMasterCarton)
                    .HasMaxLength(10)
                    .HasColumnName("Baseunit for Master carton");

                entity.Property(e => e.BaseunitForPallet)
                    .HasMaxLength(10)
                    .HasColumnName("Baseunit for Pallet");

                entity.Property(e => e.BlockReason)
                    .HasMaxLength(250)
                    .HasColumnName("Block Reason");

                entity.Property(e => e.BudgetProfit)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Budget Profit");

                entity.Property(e => e.BudgetQuantity)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Budget Quantity");

                entity.Property(e => e.BudgetedAmount)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Budgeted Amount");

                entity.Property(e => e.Choice).HasMaxLength(30);

                entity.Property(e => e.CommissionGroup).HasColumnName("Commission Group");

                entity.Property(e => e.CommonItemNo)
                    .HasMaxLength(20)
                    .HasColumnName("Common Item No_");

                entity.Property(e => e.CostIsAdjusted).HasColumnName("Cost is Adjusted");

                entity.Property(e => e.CostingMethod).HasColumnName("Costing Method");

                entity.Property(e => e.CountryRegionOfOriginCode)
                    .HasMaxLength(10)
                    .HasColumnName("Country_Region of Origin Code");

                entity.Property(e => e.CountryRegionPurchasedCode)
                    .HasMaxLength(10)
                    .HasColumnName("Country_Region Purchased Code");

                entity.Property(e => e.CreatedFromNonstockItem).HasColumnName("Created From Nonstock Item");

                entity.Property(e => e.DampenerPeriod)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("Dampener Period");

                entity.Property(e => e.DampenerQuantity)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Dampener Quantity");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("Date Created");

                entity.Property(e => e.DefaultDeferralTemplateCode)
                    .HasMaxLength(10)
                    .HasColumnName("Default Deferral Template Code");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Description2)
                    .HasMaxLength(50)
                    .HasColumnName("Description 2");

                entity.Property(e => e.DiscreteOrderQuantity).HasColumnName("Discrete Order Quantity");

                entity.Property(e => e.DoNotExportToAstro).HasColumnName("Do not export to Astro");

                entity.Property(e => e.DoNotExportToSolo).HasColumnName("Do not export to SOLO");

                entity.Property(e => e.Durability).HasMaxLength(10);

                entity.Property(e => e.DutyCode)
                    .HasMaxLength(10)
                    .HasColumnName("Duty Code");

                entity.Property(e => e.DutyDue)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Duty Due _");

                entity.Property(e => e.DutyUnitConversion)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Duty Unit Conversion");

                entity.Property(e => e.ExcludeInPriceFile).HasColumnName("Exclude in PriceFile");

                entity.Property(e => e.ExpectedDeliveryDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Expected Delivery Date");

                entity.Property(e => e.ExpirationCalculation)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("Expiration Calculation");

                entity.Property(e => e.FlushingMethod).HasColumnName("Flushing Method");

                entity.Property(e => e.FreightType)
                    .HasMaxLength(10)
                    .HasColumnName("Freight Type");

                entity.Property(e => e.GenProdPostingGroup)
                    .HasMaxLength(20)
                    .HasColumnName("Gen_ Prod_ Posting Group");

                entity.Property(e => e.GlobalDimension1Code)
                    .HasMaxLength(20)
                    .HasColumnName("Global Dimension 1 Code");

                entity.Property(e => e.GlobalDimension2Code)
                    .HasMaxLength(20)
                    .HasColumnName("Global Dimension 2 Code");

                entity.Property(e => e.GrossWeight)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Gross Weight");

                entity.Property(e => e.Gtin)
                    .HasMaxLength(14)
                    .HasColumnName("GTIN");

                entity.Property(e => e.IncludeInventory).HasColumnName("Include Inventory");

                entity.Property(e => e.IndirectCost)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Indirect Cost _");

                entity.Property(e => e.InventoryPostingGroup)
                    .HasMaxLength(20)
                    .HasColumnName("Inventory Posting Group");

                entity.Property(e => e.InventoryValueZero).HasColumnName("Inventory Value Zero");

                entity.Property(e => e.ItemCategoryCode)
                    .HasMaxLength(20)
                    .HasColumnName("Item Category Code");

                entity.Property(e => e.ItemDiscGroup)
                    .HasMaxLength(20)
                    .HasColumnName("Item Disc_ Group");

                entity.Property(e => e.ItemFeeCode)
                    .HasMaxLength(10)
                    .HasColumnName("Item Fee Code");

                entity.Property(e => e.ItemTrackingCode)
                    .HasMaxLength(10)
                    .HasColumnName("Item Tracking Code");

                entity.Property(e => e.ItemType).HasColumnName("Item Type");

                entity.Property(e => e.LastCalculated)
                    .HasColumnType("datetime")
                    .HasColumnName("Last Calculated");

                entity.Property(e => e.LastCountingPeriodUpdate)
                    .HasColumnType("datetime")
                    .HasColumnName("Last Counting Period Update");

                entity.Property(e => e.LastDateModified)
                    .HasColumnType("datetime")
                    .HasColumnName("Last Date Modified");

                entity.Property(e => e.LastDateTimeModified)
                    .HasColumnType("datetime")
                    .HasColumnName("Last DateTime Modified");

                entity.Property(e => e.LastDirectCost)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Last Direct Cost");

                entity.Property(e => e.LastTimeModified)
                    .HasColumnType("datetime")
                    .HasColumnName("Last Time Modified");

                entity.Property(e => e.LastUnitCostCalcDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Last Unit Cost Calc_ Date");

                entity.Property(e => e.LeadTimeCalculation)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("Lead Time Calculation");

                entity.Property(e => e.LotAccumulationPeriod)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("Lot Accumulation Period");

                entity.Property(e => e.LotNos)
                    .HasMaxLength(20)
                    .HasColumnName("Lot Nos_");

                entity.Property(e => e.LotSize)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Lot Size");

                entity.Property(e => e.LowLevelCode).HasColumnName("Low-Level Code");

                entity.Property(e => e.ManufacturerCode)
                    .HasMaxLength(10)
                    .HasColumnName("Manufacturer Code");

                entity.Property(e => e.ManufacturingPolicy).HasColumnName("Manufacturing Policy");

                entity.Property(e => e.MaximumInventory)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Maximum Inventory");

                entity.Property(e => e.MaximumOrderQuantity)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Maximum Order Quantity");

                entity.Property(e => e.MinimumOrderQuantity)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Minimum Order Quantity");

                entity.Property(e => e.NetWeight)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Net Weight");

                entity.Property(e => e.NextCountingEndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Next Counting End Date");

                entity.Property(e => e.NextCountingStartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Next Counting Start Date");

                entity.Property(e => e.No2)
                    .HasMaxLength(20)
                    .HasColumnName("No_ 2");

                entity.Property(e => e.NoSeries)
                    .HasMaxLength(20)
                    .HasColumnName("No_ Series");

                entity.Property(e => e.NoTariffNo)
                    .HasMaxLength(10)
                    .HasColumnName("NO Tariff No_");

                entity.Property(e => e.NotDivisibleUnit).HasColumnName("Not Divisible Unit");

                entity.Property(e => e.OrderMultiple)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Order Multiple");

                entity.Property(e => e.OrderTrackingPolicy).HasColumnName("Order Tracking Policy");

                entity.Property(e => e.OverflowLevel)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Overflow Level");

                entity.Property(e => e.OverheadRate)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Overhead Rate");

                entity.Property(e => e.PackageType)
                    .HasMaxLength(10)
                    .HasColumnName("Package Type");

                entity.Property(e => e.PhysInvtCountingPeriodCode)
                    .HasMaxLength(10)
                    .HasColumnName("Phys Invt Counting Period Code");

                entity.Property(e => e.PickZone)
                    .HasMaxLength(10)
                    .HasColumnName("Pick Zone");

                entity.Property(e => e.PreventNegativeInventory).HasColumnName("Prevent Negative Inventory");

                entity.Property(e => e.PriceIncludesVat).HasColumnName("Price Includes VAT");

                entity.Property(e => e.PriceProfitCalculation).HasColumnName("Price_Profit Calculation");

                entity.Property(e => e.PriceUnitConversion).HasColumnName("Price Unit Conversion");

                entity.Property(e => e.PrimaryEanCode)
                    .HasMaxLength(13)
                    .HasColumnName("Primary EAN Code");

                entity.Property(e => e.ProductGroupCode)
                    .HasMaxLength(10)
                    .HasColumnName("Product Group Code");

                entity.Property(e => e.ProductionBomNo)
                    .HasMaxLength(20)
                    .HasColumnName("Production BOM No_");

                entity.Property(e => e.Profit)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Profit _");

                entity.Property(e => e.PurchUnitOfMeasure)
                    .HasMaxLength(10)
                    .HasColumnName("Purch_ Unit of Measure");

                entity.Property(e => e.PutAwayTemplateCode)
                    .HasMaxLength(10)
                    .HasColumnName("Put-away Template Code");

                entity.Property(e => e.PutAwayUnitOfMeasureCode)
                    .HasMaxLength(10)
                    .HasColumnName("Put-away Unit of Measure Code");

                entity.Property(e => e.ReorderPoint)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Reorder Point");

                entity.Property(e => e.ReorderQuantity)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Reorder Quantity");

                entity.Property(e => e.ReorderingPolicy).HasColumnName("Reordering Policy");

                entity.Property(e => e.ReplacesItemNo)
                    .HasMaxLength(20)
                    .HasColumnName("Replaces Item No_");

                entity.Property(e => e.ReplenishmentSystem).HasColumnName("Replenishment System");

                entity.Property(e => e.ReschedulingPeriod)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("Rescheduling Period");

                entity.Property(e => e.RolledUpCapOverheadCost)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Rolled-up Cap_ Overhead Cost");

                entity.Property(e => e.RolledUpCapacityCost)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Rolled-up Capacity Cost");

                entity.Property(e => e.RolledUpMaterialCost)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Rolled-up Material Cost");

                entity.Property(e => e.RolledUpMfgOvhdCost)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Rolled-up Mfg_ Ovhd Cost");

                entity.Property(e => e.RolledUpSubcontractedCost)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Rolled-up Subcontracted Cost");

                entity.Property(e => e.RoundingPrecision)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Rounding Precision");

                entity.Property(e => e.RoutingNo)
                    .HasMaxLength(20)
                    .HasColumnName("Routing No_");

                entity.Property(e => e.SafetyLeadTime)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("Safety Lead Time");

                entity.Property(e => e.SafetyStockQuantity)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Safety Stock Quantity");

                entity.Property(e => e.SalesUnitOfMeasure)
                    .HasMaxLength(10)
                    .HasColumnName("Sales Unit of Measure");

                entity.Property(e => e.SalesVolumeCode)
                    .HasMaxLength(10)
                    .HasColumnName("Sales Volume Code");

                entity.Property(e => e.Scrap)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Scrap _");

                entity.Property(e => e.SearchDescription)
                    .HasMaxLength(50)
                    .HasColumnName("Search Description");

                entity.Property(e => e.SerialNos)
                    .HasMaxLength(20)
                    .HasColumnName("Serial Nos_");

                entity.Property(e => e.SerialNumberRegistration).HasColumnName("Serial Number Registration");

                entity.Property(e => e.ServiceItemGroup)
                    .HasMaxLength(10)
                    .HasColumnName("Service Item Group");

                entity.Property(e => e.ShelfNo)
                    .HasMaxLength(10)
                    .HasColumnName("Shelf No_");

                entity.Property(e => e.SingleLevelCapOvhdCost)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Single-Level Cap_ Ovhd Cost");

                entity.Property(e => e.SingleLevelCapacityCost)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Single-Level Capacity Cost");

                entity.Property(e => e.SingleLevelMaterialCost)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Single-Level Material Cost");

                entity.Property(e => e.SingleLevelMfgOvhdCost)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Single-Level Mfg_ Ovhd Cost");

                entity.Property(e => e.SingleLevelSubcontrdCost)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Single-Level Subcontrd_ Cost");

                entity.Property(e => e.SpecialEquipmentCode)
                    .HasMaxLength(10)
                    .HasColumnName("Special Equipment Code");

                entity.Property(e => e.StandardCost)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Standard Cost");

                entity.Property(e => e.StatisticsGroup).HasColumnName("Statistics Group");

                entity.Property(e => e.StockoutWarning).HasColumnName("Stockout Warning");

                entity.Property(e => e.TariffNo)
                    .HasMaxLength(20)
                    .HasColumnName("Tariff No_");

                entity.Property(e => e.TaxGroupCode)
                    .HasMaxLength(20)
                    .HasColumnName("Tax Group Code");

                entity.Property(e => e.TaxGroupId).HasColumnName("Tax Group Id");

                entity.Property(e => e.TimeBucket)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("Time Bucket");

                entity.Property(e => e.Timestamp)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("timestamp");

                entity.Property(e => e.UnitCost)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Unit Cost");

                entity.Property(e => e.UnitListPrice)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Unit List Price");

                entity.Property(e => e.UnitOfMeasureId).HasColumnName("Unit of Measure Id");

                entity.Property(e => e.UnitPrice)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Unit Price");

                entity.Property(e => e.UnitVolume)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Unit Volume");

                entity.Property(e => e.UnitsPerParcel)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Units per Parcel");

                entity.Property(e => e.UnspscCode)
                    .HasMaxLength(10)
                    .HasColumnName("UNSPSC Code");

                entity.Property(e => e.UseCrossDocking).HasColumnName("Use Cross-Docking");

                entity.Property(e => e.VatBusPostingGrPrice)
                    .HasMaxLength(20)
                    .HasColumnName("VAT Bus_ Posting Gr_ (Price)");

                entity.Property(e => e.VatProdPostingGroup)
                    .HasMaxLength(20)
                    .HasColumnName("VAT Prod_ Posting Group");

                entity.Property(e => e.VendorItemNo)
                    .HasMaxLength(30)
                    .HasColumnName("Vendor Item No_");

                entity.Property(e => e.VendorNo)
                    .HasMaxLength(20)
                    .HasColumnName("Vendor No_");

                entity.Property(e => e.WarehouseClassCode)
                    .HasMaxLength(10)
                    .HasColumnName("Warehouse Class Code");

                entity.Property(e => e.WeeeDirective).HasColumnName("Weee Directive");

                entity.Property(e => e.WipExternalId1)
                    .HasMaxLength(250)
                    .HasColumnName("Wip External ID 1");

                entity.Property(e => e.WipExternalId2)
                    .HasMaxLength(250)
                    .HasColumnName("Wip External ID 2");

                entity.Property(e => e.WipExternalId3)
                    .HasMaxLength(250)
                    .HasColumnName("Wip External ID 3");
            });

            modelBuilder.Entity<TiNavItemCategory>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("TI NAV$Item Category$0");

                entity.ToTable("TI NAV$Item Category");

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.EeNo)
                    .HasMaxLength(30)
                    .HasColumnName("EE No_");

                entity.Property(e => e.HasChildren).HasColumnName("Has Children");

                entity.Property(e => e.LastModifiedDateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Last Modified Date Time");

                entity.Property(e => e.ParentCategory)
                    .HasMaxLength(20)
                    .HasColumnName("Parent Category");

                entity.Property(e => e.PresentationOrder).HasColumnName("Presentation Order");

                entity.Property(e => e.Timestamp)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("timestamp");
            });

            modelBuilder.Entity<TiNavItemCrossReference>(entity =>
            {
                entity.HasKey(e => new { e.ItemNo, e.VariantCode, e.UnitOfMeasure, e.CrossReferenceType, e.CrossReferenceTypeNo, e.CrossReferenceNo })
                    .HasName("TI NAV$Item Cross Reference$0");

                entity.ToTable("TI NAV$Item Cross Reference");

                entity.Property(e => e.ItemNo)
                    .HasMaxLength(20)
                    .HasColumnName("Item No_");

                entity.Property(e => e.VariantCode)
                    .HasMaxLength(10)
                    .HasColumnName("Variant Code");

                entity.Property(e => e.UnitOfMeasure)
                    .HasMaxLength(10)
                    .HasColumnName("Unit of Measure");

                entity.Property(e => e.CrossReferenceType).HasColumnName("Cross-Reference Type");

                entity.Property(e => e.CrossReferenceTypeNo)
                    .HasMaxLength(30)
                    .HasColumnName("Cross-Reference Type No_");

                entity.Property(e => e.CrossReferenceNo)
                    .HasMaxLength(30)
                    .HasColumnName("Cross-Reference No_");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.DiscontinueBarCode).HasColumnName("Discontinue Bar Code");

                entity.Property(e => e.Timestamp)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("timestamp");
            });

            modelBuilder.Entity<TiNavItemEnvironmentalReporting>(entity =>
            {
                entity.HasKey(e => e.ItemNo)
                    .HasName("TI NAV$ItemEnvironmentalReporting$0");

                entity.ToTable("TI NAV$ItemEnvironmentalReporting");

                entity.Property(e => e.ItemNo)
                    .HasMaxLength(20)
                    .HasColumnName("Item No_");

                entity.Property(e => e.BatteryQty).HasColumnName("BATTERY_QTY");

                entity.Property(e => e.BatteryType)
                    .HasMaxLength(10)
                    .HasColumnName("BATTERY_TYPE");

                entity.Property(e => e.BatteryWeight)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("BATTERY_WEIGHT");

                entity.Property(e => e.Ce).HasColumnName("CE");

                entity.Property(e => e.DangerousGodsNumber)
                    .HasMaxLength(30)
                    .HasColumnName("DANGEROUS_GODS_NUMBER");

                entity.Property(e => e.DangerousGodsWeight)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("DANGEROUS_GODS_WEIGHT");

                entity.Property(e => e.EnergyLabel)
                    .HasMaxLength(30)
                    .HasColumnName("ENERGY_LABEL");

                entity.Property(e => e.Gruenerpunkt).HasColumnName("GRUENERPUNKT");

                entity.Property(e => e.PackagingWeightCarton)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("PACKAGING_WEIGHT_CARTON");

                entity.Property(e => e.PackagingWeightDiverse)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("PACKAGING_WEIGHT_DIVERSE");

                entity.Property(e => e.PackagingWeightPlastic)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("PACKAGING_WEIGHT_PLASTIC");

                entity.Property(e => e.Timestamp)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("timestamp");

                entity.Property(e => e.WeeeId)
                    .HasMaxLength(10)
                    .HasColumnName("WEEE_ID");

                entity.Property(e => e.WeeeIdDk)
                    .HasMaxLength(10)
                    .HasColumnName("WEEE_ID DK");

                entity.Property(e => e.WeeeIdFi)
                    .HasMaxLength(10)
                    .HasColumnName("WEEE_ID FI");

                entity.Property(e => e.WeeeWeight)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("WEEE_WEIGHT");
            });

            modelBuilder.Entity<TiNavItemFee>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("TI NAV$Item Fee$0");

                entity.ToTable("TI NAV$Item Fee");

                entity.Property(e => e.Code).HasMaxLength(30);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Discount)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Discount _");

                entity.Property(e => e.ResourceNo)
                    .HasMaxLength(10)
                    .HasColumnName("Resource No_");

                entity.Property(e => e.Timestamp)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("timestamp");
            });

            modelBuilder.Entity<TiNavItemFee1>(entity =>
            {
                entity.HasKey(e => new { e.ItemNo, e.FeeCode })
                    .HasName("Tura Scandinavia AB$Item Fees$0");

                entity.ToTable("TI NAV$Item Fees");

                entity.Property(e => e.ItemNo)
                    .HasMaxLength(20)
                    .HasColumnName("Item No_");

                entity.Property(e => e.FeeCode)
                    .HasMaxLength(30)
                    .HasColumnName("Fee Code");

                entity.Property(e => e.Timestamp)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("timestamp");
            });

            modelBuilder.Entity<TiNavItemFeePrice>(entity =>
            {
                entity.HasKey(e => new { e.FeeType, e.FeeCode, e.FeeCustomerGroup, e.StartingDate, e.CurrencyCode })
                    .HasName("TI NAV$Item Fee Price$0");

                entity.ToTable("TI NAV$Item Fee Price");

                entity.Property(e => e.FeeType).HasColumnName("Fee Type");

                entity.Property(e => e.FeeCode)
                    .HasMaxLength(20)
                    .HasColumnName("Fee Code");

                entity.Property(e => e.FeeCustomerGroup)
                    .HasMaxLength(10)
                    .HasColumnName("Fee Customer Group");

                entity.Property(e => e.StartingDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Starting Date");

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(10)
                    .HasColumnName("Currency Code");

                entity.Property(e => e.EndingDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Ending Date");

                entity.Property(e => e.Timestamp)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("timestamp");

                entity.Property(e => e.UnitPrice)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Unit Price");
            });

            modelBuilder.Entity<TiNavItemFeeTranslation>(entity =>
            {
                entity.HasKey(e => new { e.ItemFee, e.LanguageCode })
                    .HasName("TI NAV$Item Fee Translation$0");

                entity.ToTable("TI NAV$Item Fee Translation");

                entity.Property(e => e.ItemFee)
                    .HasMaxLength(20)
                    .HasColumnName("Item Fee");

                entity.Property(e => e.LanguageCode)
                    .HasMaxLength(10)
                    .HasColumnName("Language Code");

                entity.Property(e => e.Description).HasMaxLength(30);

                entity.Property(e => e.Description2)
                    .HasMaxLength(30)
                    .HasColumnName("Description 2");

                entity.Property(e => e.Timestamp)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("timestamp");
            });

            modelBuilder.Entity<TiNavItemLedgerEntry>(entity =>
            {
                entity.HasKey(e => e.EntryNo)
                    .HasName("TI NAV$Item Ledger Entry$0");

                entity.ToTable("TI NAV$Item Ledger Entry");

                entity.Property(e => e.EntryNo)
                    .ValueGeneratedNever()
                    .HasColumnName("Entry No_");

                entity.Property(e => e.AppliedEntryToAdjust).HasColumnName("Applied Entry to Adjust");

                entity.Property(e => e.AppliesToEntry).HasColumnName("Applies-to Entry");

                entity.Property(e => e.Area).HasMaxLength(10);

                entity.Property(e => e.AssembleToOrder).HasColumnName("Assemble to Order");

                entity.Property(e => e.BenefitCode)
                    .HasMaxLength(10)
                    .HasColumnName("Benefit Code");

                entity.Property(e => e.CertificateCode)
                    .HasMaxLength(10)
                    .HasColumnName("Certificate Code");

                entity.Property(e => e.CertificateNo)
                    .HasMaxLength(30)
                    .HasColumnName("Certificate No_");

                entity.Property(e => e.CompletelyInvoiced).HasColumnName("Completely Invoiced");

                entity.Property(e => e.CountryRegionCode)
                    .HasMaxLength(10)
                    .HasColumnName("Country_Region Code");

                entity.Property(e => e.CrossReferenceNo)
                    .HasMaxLength(30)
                    .HasColumnName("Cross-Reference No_");

                entity.Property(e => e.DerivedFromBlanketOrder).HasColumnName("Derived from Blanket Order");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.DimensionSetId).HasColumnName("Dimension Set ID");

                entity.Property(e => e.DocumentDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Document Date");

                entity.Property(e => e.DocumentLineNo).HasColumnName("Document Line No_");

                entity.Property(e => e.DocumentNo)
                    .HasMaxLength(20)
                    .HasColumnName("Document No_");

                entity.Property(e => e.DocumentType).HasColumnName("Document Type");

                entity.Property(e => e.DropShipment).HasColumnName("Drop Shipment");

                entity.Property(e => e.EntryExitPoint)
                    .HasMaxLength(10)
                    .HasColumnName("Entry_Exit Point");

                entity.Property(e => e.EntryType).HasColumnName("Entry Type");

                entity.Property(e => e.EuGoods).HasColumnName("EU Goods");

                entity.Property(e => e.ExpirationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Expiration Date");

                entity.Property(e => e.ExternalDocumentNo)
                    .HasMaxLength(35)
                    .HasColumnName("External Document No_");

                entity.Property(e => e.FreightDirectUnitCost)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Freight Direct Unit Cost");

                entity.Property(e => e.GlobalDimension1Code)
                    .HasMaxLength(20)
                    .HasColumnName("Global Dimension 1 Code");

                entity.Property(e => e.GlobalDimension2Code)
                    .HasMaxLength(20)
                    .HasColumnName("Global Dimension 2 Code");

                entity.Property(e => e.InvoicedQuantity)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Invoiced Quantity");

                entity.Property(e => e.ItemCategoryCode)
                    .HasMaxLength(20)
                    .HasColumnName("Item Category Code");

                entity.Property(e => e.ItemNo)
                    .HasMaxLength(20)
                    .HasColumnName("Item No_");

                entity.Property(e => e.ItemTracking).HasColumnName("Item Tracking");

                entity.Property(e => e.JobNo)
                    .HasMaxLength(20)
                    .HasColumnName("Job No_");

                entity.Property(e => e.JobPurchase).HasColumnName("Job Purchase");

                entity.Property(e => e.JobTaskNo)
                    .HasMaxLength(20)
                    .HasColumnName("Job Task No_");

                entity.Property(e => e.LastInvoiceDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Last Invoice Date");

                entity.Property(e => e.LocationCode)
                    .HasMaxLength(10)
                    .HasColumnName("Location Code");

                entity.Property(e => e.LotNo)
                    .HasMaxLength(20)
                    .HasColumnName("Lot No_");

                entity.Property(e => e.NoSeries)
                    .HasMaxLength(20)
                    .HasColumnName("No_ Series");

                entity.Property(e => e.OrderLineNo).HasColumnName("Order Line No_");

                entity.Property(e => e.OrderNo)
                    .HasMaxLength(20)
                    .HasColumnName("Order No_");

                entity.Property(e => e.OrderType).HasColumnName("Order Type");

                entity.Property(e => e.OriginallyOrderedNo)
                    .HasMaxLength(20)
                    .HasColumnName("Originally Ordered No_");

                entity.Property(e => e.OriginallyOrderedVarCode)
                    .HasMaxLength(10)
                    .HasColumnName("Originally Ordered Var_ Code");

                entity.Property(e => e.OutOfStockSubstitution).HasColumnName("Out-of-Stock Substitution");

                entity.Property(e => e.PostingDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Posting Date");

                entity.Property(e => e.ProdOrderCompLineNo).HasColumnName("Prod_ Order Comp_ Line No_");

                entity.Property(e => e.ProductGroupCode)
                    .HasMaxLength(10)
                    .HasColumnName("Product Group Code");

                entity.Property(e => e.PurchasingCode)
                    .HasMaxLength(10)
                    .HasColumnName("Purchasing Code");

                entity.Property(e => e.QtyPerUnitOfMeasure)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Qty_ per Unit of Measure");

                entity.Property(e => e.Quantity).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.RemainingQuantity)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Remaining Quantity");

                entity.Property(e => e.ReturnReasonCode)
                    .HasMaxLength(10)
                    .HasColumnName("Return Reason Code");

                entity.Property(e => e.SerialNo)
                    .HasMaxLength(20)
                    .HasColumnName("Serial No_");

                entity.Property(e => e.ShippedQtyNotReturned)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Shipped Qty_ Not Returned");

                entity.Property(e => e.SourceNo)
                    .HasMaxLength(20)
                    .HasColumnName("Source No_");

                entity.Property(e => e.SourceType).HasColumnName("Source Type");

                entity.Property(e => e.Timestamp)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("timestamp");

                entity.Property(e => e.TransactionSpecification)
                    .HasMaxLength(10)
                    .HasColumnName("Transaction Specification");

                entity.Property(e => e.TransactionType)
                    .HasMaxLength(10)
                    .HasColumnName("Transaction Type");

                entity.Property(e => e.TransportMethod)
                    .HasMaxLength(10)
                    .HasColumnName("Transport Method");

                entity.Property(e => e.UnitOfMeasureCode)
                    .HasMaxLength(10)
                    .HasColumnName("Unit of Measure Code");

                entity.Property(e => e.VariantCode)
                    .HasMaxLength(10)
                    .HasColumnName("Variant Code");

                entity.Property(e => e.WarrantyDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Warranty Date");
            });

            modelBuilder.Entity<TiNavItemSubstitution>(entity =>
            {
                entity.HasKey(e => new { e.Type, e.No, e.VariantCode, e.SubstituteType, e.SubstituteNo, e.SubstituteVariantCode })
                    .HasName("TI NAV$Item Substitution$0");

                entity.ToTable("TI NAV$Item Substitution");

                entity.Property(e => e.No)
                    .HasMaxLength(20)
                    .HasColumnName("No_");

                entity.Property(e => e.VariantCode)
                    .HasMaxLength(10)
                    .HasColumnName("Variant Code");

                entity.Property(e => e.SubstituteType).HasColumnName("Substitute Type");

                entity.Property(e => e.SubstituteNo)
                    .HasMaxLength(20)
                    .HasColumnName("Substitute No_");

                entity.Property(e => e.SubstituteVariantCode)
                    .HasMaxLength(10)
                    .HasColumnName("Substitute Variant Code");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Inventory).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.QuantityAvailOnShptDate)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Quantity Avail_ on Shpt_ Date");

                entity.Property(e => e.RelationsLevel).HasColumnName("Relations Level");

                entity.Property(e => e.ShipmentDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Shipment Date");

                entity.Property(e => e.Timestamp)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("timestamp");
            });

            modelBuilder.Entity<TiNavItemTranslation>(entity =>
            {
                entity.HasKey(e => new { e.ItemNo, e.VariantCode, e.LanguageCode })
                    .HasName("TI NAV$Item Translation$0");

                entity.ToTable("TI NAV$Item Translation");

                entity.Property(e => e.ItemNo)
                    .HasMaxLength(20)
                    .HasColumnName("Item No_");

                entity.Property(e => e.VariantCode)
                    .HasMaxLength(10)
                    .HasColumnName("Variant Code");

                entity.Property(e => e.LanguageCode)
                    .HasMaxLength(10)
                    .HasColumnName("Language Code");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Description2)
                    .HasMaxLength(50)
                    .HasColumnName("Description 2");

                entity.Property(e => e.Timestamp)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("timestamp");
            });

            modelBuilder.Entity<TiNavItemUnitOfMeasure>(entity =>
            {
                entity.HasKey(e => new { e.ItemNo, e.Code })
                    .HasName("TI NAV$Item Unit of Measure$0");

                entity.ToTable("TI NAV$Item Unit of Measure");

                entity.Property(e => e.ItemNo)
                    .HasMaxLength(20)
                    .HasColumnName("Item No_");

                entity.Property(e => e.Code).HasMaxLength(10);

                entity.Property(e => e.Cubage).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.Height).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.Length).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.QtyPerUnitOfMeasure)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Qty_ per Unit of Measure");

                entity.Property(e => e.Timestamp)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("timestamp");

                entity.Property(e => e.Weight).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.Width).HasColumnType("decimal(38, 20)");
            });

            modelBuilder.Entity<TiNavManufacturer>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("TI NAV$Manufacturer$0");

                entity.ToTable("TI NAV$Manufacturer");

                entity.Property(e => e.Code).HasMaxLength(10);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Timestamp)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("timestamp");
            });

            modelBuilder.Entity<TiNavPrisexportSetup>(entity =>
            {
                entity.HasKey(e => e.PrimaryKey)
                    .HasName("TI NAV$Prisexport Setup$0");

                entity.ToTable("TI NAV$Prisexport Setup");

                entity.Property(e => e.PrimaryKey)
                    .HasMaxLength(10)
                    .HasColumnName("Primary Key");

                entity.Property(e => e.ActivityFilter)
                    .HasMaxLength(30)
                    .HasColumnName("Activity Filter");

                entity.Property(e => e.CustomerPricegroupEndcustome)
                    .HasMaxLength(20)
                    .HasColumnName("Customer Pricegroup Endcustome");

                entity.Property(e => e.ItemAvailReCalcMinutes).HasColumnName("Item Avail_ ReCalc (minutes)");

                entity.Property(e => e.LeadTimeCalculation)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("Lead Time Calculation");

                entity.Property(e => e.LocationFilter)
                    .HasMaxLength(10)
                    .HasColumnName("Location filter");

                entity.Property(e => e.OutgoingFilesFolder)
                    .HasMaxLength(250)
                    .HasColumnName("Outgoing Files Folder");

                entity.Property(e => e.Timestamp)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("timestamp");
            });

            modelBuilder.Entity<TiNavProductGroup>(entity =>
            {
                entity.HasKey(e => new { e.ItemCategoryCode, e.Code })
                    .HasName("TI NAV$Product Group$0");

                entity.ToTable("TI NAV$Product Group");

                entity.Property(e => e.ItemCategoryCode)
                    .HasMaxLength(20)
                    .HasColumnName("Item Category Code");

                entity.Property(e => e.Code).HasMaxLength(10);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Timestamp)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("timestamp");

                entity.Property(e => e.WarehouseClassCode)
                    .HasMaxLength(10)
                    .HasColumnName("Warehouse Class Code");
            });

            modelBuilder.Entity<TiNavPurchaseLine>(entity =>
            {
                entity.HasKey(e => new { e.DocumentType, e.DocumentNo, e.LineNo })
                    .HasName("TI NAV$Purchase Line$0");

                entity.ToTable("TI NAV$Purchase Line");

                entity.Property(e => e.DocumentType).HasColumnName("Document Type");

                entity.Property(e => e.DocumentNo)
                    .HasMaxLength(20)
                    .HasColumnName("Document No_");

                entity.Property(e => e.LineNo).HasColumnName("Line No_");

                entity.Property(e => e.ARcdNotInvExVatLcy)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("A_ Rcd_ Not Inv_ Ex_ VAT (LCY)");

                entity.Property(e => e.AllowInvoiceDisc).HasColumnName("Allow Invoice Disc_");

                entity.Property(e => e.AllowItemChargeAssignment).HasColumnName("Allow Item Charge Assignment");

                entity.Property(e => e.Amount).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.AmountIncludingVat)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Amount Including VAT");

                entity.Property(e => e.AmtRcdNotInvoiced)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Amt_ Rcd_ Not Invoiced");

                entity.Property(e => e.AmtRcdNotInvoicedLcy)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Amt_ Rcd_ Not Invoiced (LCY)");

                entity.Property(e => e.ApplToItemEntry).HasColumnName("Appl_-to Item Entry");

                entity.Property(e => e.Area).HasMaxLength(10);

                entity.Property(e => e.AttachedToLineNo).HasColumnName("Attached to Line No_");

                entity.Property(e => e.AutoAccGroup)
                    .HasMaxLength(10)
                    .HasColumnName("Auto_ Acc_ Group");

                entity.Property(e => e.BenefitCode)
                    .HasMaxLength(10)
                    .HasColumnName("Benefit Code");

                entity.Property(e => e.BinCode)
                    .HasMaxLength(20)
                    .HasColumnName("Bin Code");

                entity.Property(e => e.BlanketOrderLineNo).HasColumnName("Blanket Order Line No_");

                entity.Property(e => e.BlanketOrderNo)
                    .HasMaxLength(20)
                    .HasColumnName("Blanket Order No_");

                entity.Property(e => e.BudgetedFaNo)
                    .HasMaxLength(20)
                    .HasColumnName("Budgeted FA No_");

                entity.Property(e => e.BuyFromVendorNo)
                    .HasMaxLength(20)
                    .HasColumnName("Buy-from Vendor No_");

                entity.Property(e => e.CertificateCode)
                    .HasMaxLength(10)
                    .HasColumnName("Certificate Code");

                entity.Property(e => e.CertificateNo)
                    .HasMaxLength(30)
                    .HasColumnName("Certificate No_");

                entity.Property(e => e.CompletelyReceived).HasColumnName("Completely Received");

                entity.Property(e => e.ConfirmationStatus).HasColumnName("Confirmation Status");

                entity.Property(e => e.CrossReferenceNo)
                    .HasMaxLength(30)
                    .HasColumnName("Cross-Reference No_");

                entity.Property(e => e.CrossReferenceType).HasColumnName("Cross-Reference Type");

                entity.Property(e => e.CrossReferenceTypeNo)
                    .HasMaxLength(30)
                    .HasColumnName("Cross-Reference Type No_");

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(10)
                    .HasColumnName("Currency Code");

                entity.Property(e => e.DeferralCode)
                    .HasMaxLength(10)
                    .HasColumnName("Deferral Code");

                entity.Property(e => e.DeprAcquisitionCost).HasColumnName("Depr_ Acquisition Cost");

                entity.Property(e => e.DeprUntilFaPostingDate).HasColumnName("Depr_ until FA Posting Date");

                entity.Property(e => e.DepreciationBookCode)
                    .HasMaxLength(10)
                    .HasColumnName("Depreciation Book Code");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Description2)
                    .HasMaxLength(50)
                    .HasColumnName("Description 2");

                entity.Property(e => e.DimensionSetId).HasColumnName("Dimension Set ID");

                entity.Property(e => e.DirectUnitCost)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Direct Unit Cost");

                entity.Property(e => e.DropShipment).HasColumnName("Drop Shipment");

                entity.Property(e => e.DuplicateInDepreciationBook)
                    .HasMaxLength(10)
                    .HasColumnName("Duplicate in Depreciation Book");

                entity.Property(e => e.EntryPoint)
                    .HasMaxLength(10)
                    .HasColumnName("Entry Point");

                entity.Property(e => e.EuGoods).HasColumnName("EU Goods");

                entity.Property(e => e.ExpectedReceiptDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Expected Receipt Date");

                entity.Property(e => e.ExportedToAstro).HasColumnName("Exported to ASTRO");

                entity.Property(e => e.FaPostingDate)
                    .HasColumnType("datetime")
                    .HasColumnName("FA Posting Date");

                entity.Property(e => e.FaPostingType).HasColumnName("FA Posting Type");

                entity.Property(e => e.FreightDirectUnitCost)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Freight Direct Unit Cost");

                entity.Property(e => e.GenBusPostingGroup)
                    .HasMaxLength(20)
                    .HasColumnName("Gen_ Bus_ Posting Group");

                entity.Property(e => e.GenProdPostingGroup)
                    .HasMaxLength(20)
                    .HasColumnName("Gen_ Prod_ Posting Group");

                entity.Property(e => e.GrossWeight)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Gross Weight");

                entity.Property(e => e.IcPartnerCode)
                    .HasMaxLength(20)
                    .HasColumnName("IC Partner Code");

                entity.Property(e => e.IcPartnerRefType).HasColumnName("IC Partner Ref_ Type");

                entity.Property(e => e.IcPartnerReference)
                    .HasMaxLength(20)
                    .HasColumnName("IC Partner Reference");

                entity.Property(e => e.InboundWhseHandlingTime)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("Inbound Whse_ Handling Time");

                entity.Property(e => e.IndirectCost)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Indirect Cost _");

                entity.Property(e => e.InsuranceNo)
                    .HasMaxLength(20)
                    .HasColumnName("Insurance No_");

                entity.Property(e => e.InvDiscAmountToInvoice)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Inv_ Disc_ Amount to Invoice");

                entity.Property(e => e.InvDiscountAmount)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Inv_ Discount Amount");

                entity.Property(e => e.ItemCategoryCode)
                    .HasMaxLength(20)
                    .HasColumnName("Item Category Code");

                entity.Property(e => e.JobCurrencyCode)
                    .HasMaxLength(20)
                    .HasColumnName("Job Currency Code");

                entity.Property(e => e.JobCurrencyFactor)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Job Currency Factor");

                entity.Property(e => e.JobLineAmount)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Job Line Amount");

                entity.Property(e => e.JobLineAmountLcy)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Job Line Amount (LCY)");

                entity.Property(e => e.JobLineDiscAmountLcy)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Job Line Disc_ Amount (LCY)");

                entity.Property(e => e.JobLineDiscount)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Job Line Discount _");

                entity.Property(e => e.JobLineDiscountAmount)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Job Line Discount Amount");

                entity.Property(e => e.JobLineType).HasColumnName("Job Line Type");

                entity.Property(e => e.JobNo)
                    .HasMaxLength(20)
                    .HasColumnName("Job No_");

                entity.Property(e => e.JobPlanningLineNo).HasColumnName("Job Planning Line No_");

                entity.Property(e => e.JobRemainingQty)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Job Remaining Qty_");

                entity.Property(e => e.JobRemainingQtyBase)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Job Remaining Qty_ (Base)");

                entity.Property(e => e.JobTaskNo)
                    .HasMaxLength(20)
                    .HasColumnName("Job Task No_");

                entity.Property(e => e.JobTotalPrice)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Job Total Price");

                entity.Property(e => e.JobTotalPriceLcy)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Job Total Price (LCY)");

                entity.Property(e => e.JobUnitPrice)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Job Unit Price");

                entity.Property(e => e.JobUnitPriceLcy)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Job Unit Price (LCY)");

                entity.Property(e => e.LeadTimeCalculation)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("Lead Time Calculation");

                entity.Property(e => e.LineAmount)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Line Amount");

                entity.Property(e => e.LineDiscount)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Line Discount _");

                entity.Property(e => e.LineDiscountAmount)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Line Discount Amount");

                entity.Property(e => e.LocationCode)
                    .HasMaxLength(10)
                    .HasColumnName("Location Code");

                entity.Property(e => e.MaintenanceCode)
                    .HasMaxLength(10)
                    .HasColumnName("Maintenance Code");

                entity.Property(e => e.MpsOrder).HasColumnName("MPS Order");

                entity.Property(e => e.NetWeight)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Net Weight");

                entity.Property(e => e.No)
                    .HasMaxLength(20)
                    .HasColumnName("No_");

                entity.Property(e => e.NoteOfGoods)
                    .HasMaxLength(30)
                    .HasColumnName("Note of Goods");

                entity.Property(e => e.OperationNo)
                    .HasMaxLength(10)
                    .HasColumnName("Operation No_");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Order Date");

                entity.Property(e => e.OutstandingAmount)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Outstanding Amount");

                entity.Property(e => e.OutstandingAmountLcy)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Outstanding Amount (LCY)");

                entity.Property(e => e.OutstandingAmtExVatLcy)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Outstanding Amt_ Ex_ VAT (LCY)");

                entity.Property(e => e.OutstandingQtyBase)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Outstanding Qty_ (Base)");

                entity.Property(e => e.OutstandingQuantity)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Outstanding Quantity");

                entity.Property(e => e.OverheadRate)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Overhead Rate");

                entity.Property(e => e.PayToVendorNo)
                    .HasMaxLength(20)
                    .HasColumnName("Pay-to Vendor No_");

                entity.Property(e => e.PebChargeType).HasColumnName("PEB Charge Type");

                entity.Property(e => e.PlannedReceiptDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Planned Receipt Date");

                entity.Property(e => e.PlanningFlexibility).HasColumnName("Planning Flexibility");

                entity.Property(e => e.PostingGroup)
                    .HasMaxLength(20)
                    .HasColumnName("Posting Group");

                entity.Property(e => e.Prepayment)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Prepayment _");

                entity.Property(e => e.PrepaymentAmount)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Prepayment Amount");

                entity.Property(e => e.PrepaymentLine).HasColumnName("Prepayment Line");

                entity.Property(e => e.PrepaymentTaxAreaCode)
                    .HasMaxLength(20)
                    .HasColumnName("Prepayment Tax Area Code");

                entity.Property(e => e.PrepaymentTaxGroupCode)
                    .HasMaxLength(20)
                    .HasColumnName("Prepayment Tax Group Code");

                entity.Property(e => e.PrepaymentTaxLiable).HasColumnName("Prepayment Tax Liable");

                entity.Property(e => e.PrepaymentVat)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Prepayment VAT _");

                entity.Property(e => e.PrepaymentVatDifference)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Prepayment VAT Difference");

                entity.Property(e => e.PrepaymentVatIdentifier)
                    .HasMaxLength(20)
                    .HasColumnName("Prepayment VAT Identifier");

                entity.Property(e => e.PrepmtAmountInvInclVat)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Prepmt_ Amount Inv_ Incl_ VAT");

                entity.Property(e => e.PrepmtAmountInvLcy)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Prepmt_ Amount Inv_ (LCY)");

                entity.Property(e => e.PrepmtAmtDeducted)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Prepmt Amt Deducted");

                entity.Property(e => e.PrepmtAmtInclVat)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Prepmt_ Amt_ Incl_ VAT");

                entity.Property(e => e.PrepmtAmtInv)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Prepmt_ Amt_ Inv_");

                entity.Property(e => e.PrepmtAmtToDeduct)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Prepmt Amt to Deduct");

                entity.Property(e => e.PrepmtLineAmount)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Prepmt_ Line Amount");

                entity.Property(e => e.PrepmtVatAmountInvLcy)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Prepmt_ VAT Amount Inv_ (LCY)");

                entity.Property(e => e.PrepmtVatBaseAmt)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Prepmt_ VAT Base Amt_");

                entity.Property(e => e.PrepmtVatCalcType).HasColumnName("Prepmt_ VAT Calc_ Type");

                entity.Property(e => e.PrepmtVatDiffDeducted)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Prepmt VAT Diff_ Deducted");

                entity.Property(e => e.PrepmtVatDiffToDeduct)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Prepmt VAT Diff_ to Deduct");

                entity.Property(e => e.ProdOrderLineNo).HasColumnName("Prod_ Order Line No_");

                entity.Property(e => e.ProdOrderNo)
                    .HasMaxLength(20)
                    .HasColumnName("Prod_ Order No_");

                entity.Property(e => e.ProductGroupCode)
                    .HasMaxLength(10)
                    .HasColumnName("Product Group Code");

                entity.Property(e => e.Profit)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Profit _");

                entity.Property(e => e.PromisedReceiptDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Promised Receipt Date");

                entity.Property(e => e.PurchasingCode)
                    .HasMaxLength(10)
                    .HasColumnName("Purchasing Code");

                entity.Property(e => e.QtyInvoicedBase)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Qty_ Invoiced (Base)");

                entity.Property(e => e.QtyPerUnitOfMeasure)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Qty_ per Unit of Measure");

                entity.Property(e => e.QtyRcdNotInvoiced)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Qty_ Rcd_ Not Invoiced");

                entity.Property(e => e.QtyRcdNotInvoicedBase)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Qty_ Rcd_ Not Invoiced (Base)");

                entity.Property(e => e.QtyReceivedBase)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Qty_ Received (Base)");

                entity.Property(e => e.QtyToInvoice)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Qty_ to Invoice");

                entity.Property(e => e.QtyToInvoiceBase)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Qty_ to Invoice (Base)");

                entity.Property(e => e.QtyToReceive)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Qty_ to Receive");

                entity.Property(e => e.QtyToReceiveBase)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Qty_ to Receive (Base)");

                entity.Property(e => e.Quantity).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.QuantityBase)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Quantity (Base)");

                entity.Property(e => e.QuantityInvoiced)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Quantity Invoiced");

                entity.Property(e => e.QuantityReceived)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Quantity Received");

                entity.Property(e => e.RecalculateInvoiceDisc).HasColumnName("Recalculate Invoice Disc_");

                entity.Property(e => e.ReceiptLineNo).HasColumnName("Receipt Line No_");

                entity.Property(e => e.ReceiptNo)
                    .HasMaxLength(20)
                    .HasColumnName("Receipt No_");

                entity.Property(e => e.RequestedReceiptDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Requested Receipt Date");

                entity.Property(e => e.ResponsibilityCenter)
                    .HasMaxLength(10)
                    .HasColumnName("Responsibility Center");

                entity.Property(e => e.RetQtyShpdNotInvdBase)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Ret_ Qty_ Shpd Not Invd_(Base)");

                entity.Property(e => e.ReturnQtyShipped)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Return Qty_ Shipped");

                entity.Property(e => e.ReturnQtyShippedBase)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Return Qty_ Shipped (Base)");

                entity.Property(e => e.ReturnQtyShippedNotInvd)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Return Qty_ Shipped Not Invd_");

                entity.Property(e => e.ReturnQtyToShip)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Return Qty_ to Ship");

                entity.Property(e => e.ReturnQtyToShipBase)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Return Qty_ to Ship (Base)");

                entity.Property(e => e.ReturnReasonCode)
                    .HasMaxLength(10)
                    .HasColumnName("Return Reason Code");

                entity.Property(e => e.ReturnShipmentLineNo).HasColumnName("Return Shipment Line No_");

                entity.Property(e => e.ReturnShipmentNo)
                    .HasMaxLength(20)
                    .HasColumnName("Return Shipment No_");

                entity.Property(e => e.ReturnShpdNotInvd)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Return Shpd_ Not Invd_");

                entity.Property(e => e.ReturnShpdNotInvdLcy)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Return Shpd_ Not Invd_ (LCY)");

                entity.Property(e => e.ReturnsDeferralStartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Returns Deferral Start Date");

                entity.Property(e => e.RoutingNo)
                    .HasMaxLength(20)
                    .HasColumnName("Routing No_");

                entity.Property(e => e.RoutingReferenceNo).HasColumnName("Routing Reference No_");

                entity.Property(e => e.SafetyLeadTime)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("Safety Lead Time");

                entity.Property(e => e.SalesOrderLineNo).HasColumnName("Sales Order Line No_");

                entity.Property(e => e.SalesOrderNo)
                    .HasMaxLength(20)
                    .HasColumnName("Sales Order No_");

                entity.Property(e => e.SalvageValue)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Salvage Value");

                entity.Property(e => e.ShortcutDimension1Code)
                    .HasMaxLength(20)
                    .HasColumnName("Shortcut Dimension 1 Code");

                entity.Property(e => e.ShortcutDimension2Code)
                    .HasMaxLength(20)
                    .HasColumnName("Shortcut Dimension 2 Code");

                entity.Property(e => e.SoloLineNo).HasColumnName("SOLO Line No_");

                entity.Property(e => e.SpecialOrder).HasColumnName("Special Order");

                entity.Property(e => e.SpecialOrderSalesLineNo).HasColumnName("Special Order Sales Line No_");

                entity.Property(e => e.SpecialOrderSalesNo)
                    .HasMaxLength(20)
                    .HasColumnName("Special Order Sales No_");

                entity.Property(e => e.SystemCreatedEntry).HasColumnName("System-Created Entry");

                entity.Property(e => e.TaxAreaCode)
                    .HasMaxLength(20)
                    .HasColumnName("Tax Area Code");

                entity.Property(e => e.TaxGroupCode)
                    .HasMaxLength(20)
                    .HasColumnName("Tax Group Code");

                entity.Property(e => e.TaxLiable).HasColumnName("Tax Liable");

                entity.Property(e => e.Timestamp)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("timestamp");

                entity.Property(e => e.TransactionSpecification)
                    .HasMaxLength(10)
                    .HasColumnName("Transaction Specification");

                entity.Property(e => e.TransactionType)
                    .HasMaxLength(10)
                    .HasColumnName("Transaction Type");

                entity.Property(e => e.TransportMethod)
                    .HasMaxLength(10)
                    .HasColumnName("Transport Method");

                entity.Property(e => e.UnitCost)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Unit Cost");

                entity.Property(e => e.UnitCostLcy)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Unit Cost (LCY)");

                entity.Property(e => e.UnitOfMeasure)
                    .HasMaxLength(10)
                    .HasColumnName("Unit of Measure");

                entity.Property(e => e.UnitOfMeasureCode)
                    .HasMaxLength(10)
                    .HasColumnName("Unit of Measure Code");

                entity.Property(e => e.UnitOfMeasureCrossRef)
                    .HasMaxLength(10)
                    .HasColumnName("Unit of Measure (Cross Ref_)");

                entity.Property(e => e.UnitPriceLcy)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Unit Price (LCY)");

                entity.Property(e => e.UnitVolume)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Unit Volume");

                entity.Property(e => e.UnitsPerParcel)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Units per Parcel");

                entity.Property(e => e.UseDuplicationList).HasColumnName("Use Duplication List");

                entity.Property(e => e.UseTax).HasColumnName("Use Tax");

                entity.Property(e => e.VariantCode)
                    .HasMaxLength(10)
                    .HasColumnName("Variant Code");

                entity.Property(e => e.Vat)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("VAT _");

                entity.Property(e => e.VatBaseAmount)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("VAT Base Amount");

                entity.Property(e => e.VatBusPostingGroup)
                    .HasMaxLength(20)
                    .HasColumnName("VAT Bus_ Posting Group");

                entity.Property(e => e.VatCalculationType).HasColumnName("VAT Calculation Type");

                entity.Property(e => e.VatDifference)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("VAT Difference");

                entity.Property(e => e.VatIdentifier)
                    .HasMaxLength(20)
                    .HasColumnName("VAT Identifier");

                entity.Property(e => e.VatProdPostingGroup)
                    .HasMaxLength(20)
                    .HasColumnName("VAT Prod_ Posting Group");

                entity.Property(e => e.VendorItemNo)
                    .HasMaxLength(30)
                    .HasColumnName("Vendor Item No_");

                entity.Property(e => e.WorkCenterNo)
                    .HasMaxLength(20)
                    .HasColumnName("Work Center No_");
            });

            modelBuilder.Entity<TiNavQtyTmp>(entity =>
            {
                entity.HasKey(e => e.Item);

                entity.ToTable("TI NAV$QtyTmp");

                entity.Property(e => e.Item).HasMaxLength(20);

                entity.Property(e => e.AvailableQty).HasColumnType("decimal(38, 2)");

                entity.Property(e => e.AvailableQtyNoDate).HasColumnType("decimal(38, 2)");

                entity.Property(e => e.PlanedDate).HasColumnType("datetime");

                entity.Property(e => e.QtyOnInventory).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.QtyOnPurch).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.QtyOnSalesOrder).HasColumnType("decimal(38, 2)");

                entity.Property(e => e.QtyOnSalesOrderNoDate).HasColumnType("decimal(38, 2)");

                entity.Property(e => e.ResQty).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<TiNavReservationEntry>(entity =>
            {
                entity.HasKey(e => new { e.EntryNo, e.Positive })
                    .HasName("TI NAV$Reservation Entry$0");

                entity.ToTable("TI NAV$Reservation Entry");

                entity.Property(e => e.EntryNo)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Entry No_");

                entity.Property(e => e.ApplFromItemEntry).HasColumnName("Appl_-from Item Entry");

                entity.Property(e => e.ApplToItemEntry).HasColumnName("Appl_-to Item Entry");

                entity.Property(e => e.ChangedBy)
                    .HasMaxLength(50)
                    .HasColumnName("Changed By");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("Created By");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Creation Date");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.DisallowCancellation).HasColumnName("Disallow Cancellation");

                entity.Property(e => e.ExpectedReceiptDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Expected Receipt Date");

                entity.Property(e => e.ExpirationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Expiration Date");

                entity.Property(e => e.ItemLedgerEntryNo).HasColumnName("Item Ledger Entry No_");

                entity.Property(e => e.ItemNo)
                    .HasMaxLength(20)
                    .HasColumnName("Item No_");

                entity.Property(e => e.ItemTracking).HasColumnName("Item Tracking");

                entity.Property(e => e.LocationCode)
                    .HasMaxLength(10)
                    .HasColumnName("Location Code");

                entity.Property(e => e.LotNo)
                    .HasMaxLength(20)
                    .HasColumnName("Lot No_");

                entity.Property(e => e.NewExpirationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("New Expiration Date");

                entity.Property(e => e.NewLotNo)
                    .HasMaxLength(20)
                    .HasColumnName("New Lot No_");

                entity.Property(e => e.NewSerialNo)
                    .HasMaxLength(20)
                    .HasColumnName("New Serial No_");

                entity.Property(e => e.PlanningFlexibility).HasColumnName("Planning Flexibility");

                entity.Property(e => e.QtyPerUnitOfMeasure)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Qty_ per Unit of Measure");

                entity.Property(e => e.QtyToHandleBase)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Qty_ to Handle (Base)");

                entity.Property(e => e.QtyToInvoiceBase)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Qty_ to Invoice (Base)");

                entity.Property(e => e.Quantity).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.QuantityBase)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Quantity (Base)");

                entity.Property(e => e.QuantityInvoicedBase)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Quantity Invoiced (Base)");

                entity.Property(e => e.ReservationStatus).HasColumnName("Reservation Status");

                entity.Property(e => e.SerialNo)
                    .HasMaxLength(20)
                    .HasColumnName("Serial No_");

                entity.Property(e => e.ShipmentDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Shipment Date");

                entity.Property(e => e.SourceBatchName)
                    .HasMaxLength(10)
                    .HasColumnName("Source Batch Name");

                entity.Property(e => e.SourceId)
                    .HasMaxLength(20)
                    .HasColumnName("Source ID");

                entity.Property(e => e.SourceProdOrderLine).HasColumnName("Source Prod_ Order Line");

                entity.Property(e => e.SourceRefNo).HasColumnName("Source Ref_ No_");

                entity.Property(e => e.SourceSubtype).HasColumnName("Source Subtype");

                entity.Property(e => e.SourceType).HasColumnName("Source Type");

                entity.Property(e => e.SuppressedActionMsg).HasColumnName("Suppressed Action Msg_");

                entity.Property(e => e.Timestamp)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("timestamp");

                entity.Property(e => e.TransferredFromEntryNo).HasColumnName("Transferred from Entry No_");

                entity.Property(e => e.VariantCode)
                    .HasMaxLength(10)
                    .HasColumnName("Variant Code");

                entity.Property(e => e.WarrantyDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Warranty Date");
            });

            modelBuilder.Entity<TiNavSalesLine>(entity =>
            {
                entity.HasKey(e => new { e.DocumentType, e.DocumentNo, e.LineNo })
                    .HasName("TI NAV$Sales Line$0");

                entity.ToTable("TI NAV$Sales Line");

                entity.Property(e => e.DocumentType).HasColumnName("Document Type");

                entity.Property(e => e.DocumentNo)
                    .HasMaxLength(20)
                    .HasColumnName("Document No_");

                entity.Property(e => e.LineNo).HasColumnName("Line No_");

                entity.Property(e => e.ActivityStatus)
                    .HasMaxLength(30)
                    .HasColumnName("Activity status");

                entity.Property(e => e.AllowInvoiceDisc).HasColumnName("Allow Invoice Disc_");

                entity.Property(e => e.AllowItemChargeAssignment).HasColumnName("Allow Item Charge Assignment");

                entity.Property(e => e.AllowLineDisc).HasColumnName("Allow Line Disc_");

                entity.Property(e => e.Amount).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.AmountIncludingVat)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Amount Including VAT");

                entity.Property(e => e.ApplFromItemEntry).HasColumnName("Appl_-from Item Entry");

                entity.Property(e => e.ApplToItemEntry).HasColumnName("Appl_-to Item Entry");

                entity.Property(e => e.Area).HasMaxLength(10);

                entity.Property(e => e.AttachedToLineNo).HasColumnName("Attached to Line No_");

                entity.Property(e => e.AutoAccGroup)
                    .HasMaxLength(10)
                    .HasColumnName("Auto_ Acc_ Group");

                entity.Property(e => e.BenefitCode)
                    .HasMaxLength(10)
                    .HasColumnName("Benefit Code");

                entity.Property(e => e.BillToCustomerNo)
                    .HasMaxLength(20)
                    .HasColumnName("Bill-to Customer No_");

                entity.Property(e => e.BinCode)
                    .HasMaxLength(20)
                    .HasColumnName("Bin Code");

                entity.Property(e => e.BlanketOrderLineNo).HasColumnName("Blanket Order Line No_");

                entity.Property(e => e.BlanketOrderNo)
                    .HasMaxLength(20)
                    .HasColumnName("Blanket Order No_");

                entity.Property(e => e.BomItemNo)
                    .HasMaxLength(20)
                    .HasColumnName("BOM Item No_");

                entity.Property(e => e.CertificateCode)
                    .HasMaxLength(10)
                    .HasColumnName("Certificate Code");

                entity.Property(e => e.CertificateNo)
                    .HasMaxLength(30)
                    .HasColumnName("Certificate No_");

                entity.Property(e => e.CompletelyShipped).HasColumnName("Completely Shipped");

                entity.Property(e => e.CrossReferenceNo)
                    .HasMaxLength(20)
                    .HasColumnName("Cross-Reference No_");

                entity.Property(e => e.CrossReferenceType).HasColumnName("Cross-Reference Type");

                entity.Property(e => e.CrossReferenceTypeNo)
                    .HasMaxLength(30)
                    .HasColumnName("Cross-Reference Type No_");

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(10)
                    .HasColumnName("Currency Code");

                entity.Property(e => e.CustomerDeliveryDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Customer Delivery Date");

                entity.Property(e => e.CustomerDiscGroup)
                    .HasMaxLength(20)
                    .HasColumnName("Customer Disc_ Group");

                entity.Property(e => e.CustomerPriceGroup)
                    .HasMaxLength(10)
                    .HasColumnName("Customer Price Group");

                entity.Property(e => e.DeferralCode)
                    .HasMaxLength(10)
                    .HasColumnName("Deferral Code");

                entity.Property(e => e.DeprUntilFaPostingDate).HasColumnName("Depr_ until FA Posting Date");

                entity.Property(e => e.DepreciationBookCode)
                    .HasMaxLength(10)
                    .HasColumnName("Depreciation Book Code");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Description2)
                    .HasMaxLength(50)
                    .HasColumnName("Description 2");

                entity.Property(e => e.DimensionSetId).HasColumnName("Dimension Set ID");

                entity.Property(e => e.DropShipment).HasColumnName("Drop Shipment");

                entity.Property(e => e.DuplicateInDepreciationBook)
                    .HasMaxLength(10)
                    .HasColumnName("Duplicate in Depreciation Book");

                entity.Property(e => e.EdieanNo)
                    .HasMaxLength(35)
                    .HasColumnName("EDIEanNo");

                entity.Property(e => e.EdilineNo).HasColumnName("EDILineNo");

                entity.Property(e => e.Ediprice)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("EDIPrice");

                entity.Property(e => e.Ediqty)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("EDIQty");

                entity.Property(e => e.EuGoods).HasColumnName("EU Goods");

                entity.Property(e => e.ExitPoint)
                    .HasMaxLength(10)
                    .HasColumnName("Exit Point");

                entity.Property(e => e.ExternalLineNo).HasColumnName("External Line No_");

                entity.Property(e => e.ExternalOrderLineNo)
                    .HasMaxLength(20)
                    .HasColumnName("External Order Line No_");

                entity.Property(e => e.ExternalOrderNo)
                    .HasMaxLength(20)
                    .HasColumnName("External Order No_");

                entity.Property(e => e.FaPostingDate)
                    .HasColumnType("datetime")
                    .HasColumnName("FA Posting Date");

                entity.Property(e => e.FeeItemLineNo).HasColumnName("Fee Item Line No_");

                entity.Property(e => e.FeeLine).HasColumnName("Fee Line");

                entity.Property(e => e.GenBusPostingGroup)
                    .HasMaxLength(20)
                    .HasColumnName("Gen_ Bus_ Posting Group");

                entity.Property(e => e.GenProdPostingGroup)
                    .HasMaxLength(20)
                    .HasColumnName("Gen_ Prod_ Posting Group");

                entity.Property(e => e.GrossWeight)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Gross Weight");

                entity.Property(e => e.IcPartnerCode)
                    .HasMaxLength(20)
                    .HasColumnName("IC Partner Code");

                entity.Property(e => e.IcPartnerRefType).HasColumnName("IC Partner Ref_ Type");

                entity.Property(e => e.IcPartnerReference)
                    .HasMaxLength(20)
                    .HasColumnName("IC Partner Reference");

                entity.Property(e => e.InvDiscAmountToInvoice)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Inv_ Disc_ Amount to Invoice");

                entity.Property(e => e.InvDiscountAmount)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Inv_ Discount Amount");

                entity.Property(e => e.ItemCategoryCode)
                    .HasMaxLength(20)
                    .HasColumnName("Item Category Code");

                entity.Property(e => e.JobContractEntryNo).HasColumnName("Job Contract Entry No_");

                entity.Property(e => e.JobNo)
                    .HasMaxLength(20)
                    .HasColumnName("Job No_");

                entity.Property(e => e.JobTaskNo)
                    .HasMaxLength(20)
                    .HasColumnName("Job Task No_");

                entity.Property(e => e.LineAmount)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Line Amount");

                entity.Property(e => e.LineDiscount)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Line Discount _");

                entity.Property(e => e.LineDiscountAmount)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Line Discount Amount");

                entity.Property(e => e.LineDiscountCalculation).HasColumnName("Line Discount Calculation");

                entity.Property(e => e.LocationCode)
                    .HasMaxLength(10)
                    .HasColumnName("Location Code");

                entity.Property(e => e.NetWeight)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Net Weight");

                entity.Property(e => e.No)
                    .HasMaxLength(20)
                    .HasColumnName("No_");

                entity.Property(e => e.OrderQuantity)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Order Quantity");

                entity.Property(e => e.Ordertype).HasMaxLength(10);

                entity.Property(e => e.OriginallyOrderedNo)
                    .HasMaxLength(20)
                    .HasColumnName("Originally Ordered No_");

                entity.Property(e => e.OriginallyOrderedVarCode)
                    .HasMaxLength(10)
                    .HasColumnName("Originally Ordered Var_ Code");

                entity.Property(e => e.OutOfStockSubstitution).HasColumnName("Out-of-Stock Substitution");

                entity.Property(e => e.OutboundWhseHandlingTime)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("Outbound Whse_ Handling Time");

                entity.Property(e => e.OutstandingAmount)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Outstanding Amount");

                entity.Property(e => e.OutstandingAmountLcy)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Outstanding Amount (LCY)");

                entity.Property(e => e.OutstandingQty)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Outstanding Qty_");

                entity.Property(e => e.OutstandingQtyBase)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Outstanding Qty_ (Base)");

                entity.Property(e => e.OutstandingQuantity)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Outstanding Quantity");

                entity.Property(e => e.PebChargeType).HasColumnName("PEB Charge Type");

                entity.Property(e => e.PebConnectedToItemLine).HasColumnName("PEB Connected to Item Line");

                entity.Property(e => e.PebTextConnectedToLineNo).HasColumnName("PEB Text connected to Line No_");

                entity.Property(e => e.PlannedDeliveryDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Planned Delivery Date");

                entity.Property(e => e.PlannedShipmentDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Planned Shipment Date");

                entity.Property(e => e.PostingGroup)
                    .HasMaxLength(20)
                    .HasColumnName("Posting Group");

                entity.Property(e => e.Prepayment)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Prepayment _");

                entity.Property(e => e.PrepaymentAmount)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Prepayment Amount");

                entity.Property(e => e.PrepaymentLine).HasColumnName("Prepayment Line");

                entity.Property(e => e.PrepaymentTaxAreaCode)
                    .HasMaxLength(20)
                    .HasColumnName("Prepayment Tax Area Code");

                entity.Property(e => e.PrepaymentTaxGroupCode)
                    .HasMaxLength(20)
                    .HasColumnName("Prepayment Tax Group Code");

                entity.Property(e => e.PrepaymentTaxLiable).HasColumnName("Prepayment Tax Liable");

                entity.Property(e => e.PrepaymentVat)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Prepayment VAT _");

                entity.Property(e => e.PrepaymentVatDifference)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Prepayment VAT Difference");

                entity.Property(e => e.PrepaymentVatIdentifier)
                    .HasMaxLength(20)
                    .HasColumnName("Prepayment VAT Identifier");

                entity.Property(e => e.PrepmtAmountInvInclVat)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Prepmt_ Amount Inv_ Incl_ VAT");

                entity.Property(e => e.PrepmtAmountInvLcy)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Prepmt_ Amount Inv_ (LCY)");

                entity.Property(e => e.PrepmtAmtDeducted)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Prepmt Amt Deducted");

                entity.Property(e => e.PrepmtAmtInclVat)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Prepmt_ Amt_ Incl_ VAT");

                entity.Property(e => e.PrepmtAmtInv)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Prepmt_ Amt_ Inv_");

                entity.Property(e => e.PrepmtAmtToDeduct)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Prepmt Amt to Deduct");

                entity.Property(e => e.PrepmtLineAmount)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Prepmt_ Line Amount");

                entity.Property(e => e.PrepmtVatAmountInvLcy)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Prepmt_ VAT Amount Inv_ (LCY)");

                entity.Property(e => e.PrepmtVatBaseAmt)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Prepmt_ VAT Base Amt_");

                entity.Property(e => e.PrepmtVatCalcType).HasColumnName("Prepmt_ VAT Calc_ Type");

                entity.Property(e => e.PrepmtVatDiffDeducted)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Prepmt VAT Diff_ Deducted");

                entity.Property(e => e.PrepmtVatDiffToDeduct)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Prepmt VAT Diff_ to Deduct");

                entity.Property(e => e.PriceDescription)
                    .HasMaxLength(80)
                    .HasColumnName("Price description");

                entity.Property(e => e.ProductGroupCode)
                    .HasMaxLength(10)
                    .HasColumnName("Product Group Code");

                entity.Property(e => e.Profit)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Profit _");

                entity.Property(e => e.PromisedDeliveryDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Promised Delivery Date");

                entity.Property(e => e.PurchOrderLineNo).HasColumnName("Purch_ Order Line No_");

                entity.Property(e => e.PurchaseOrderNo)
                    .HasMaxLength(20)
                    .HasColumnName("Purchase Order No_");

                entity.Property(e => e.PurchasingCode)
                    .HasMaxLength(10)
                    .HasColumnName("Purchasing Code");

                entity.Property(e => e.QtyInvoicedBase)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Qty_ Invoiced (Base)");

                entity.Property(e => e.QtyPerUnitOfMeasure)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Qty_ per Unit of Measure");

                entity.Property(e => e.QtyShippedBase)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Qty_ Shipped (Base)");

                entity.Property(e => e.QtyShippedNotInvdBase)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Qty_ Shipped Not Invd_ (Base)");

                entity.Property(e => e.QtyShippedNotInvoiced)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Qty_ Shipped Not Invoiced");

                entity.Property(e => e.QtyToAsmToOrderBase)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Qty_ to Asm_ to Order (Base)");

                entity.Property(e => e.QtyToAssembleToOrder)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Qty_ to Assemble to Order");

                entity.Property(e => e.QtyToInvoice)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Qty_ to Invoice");

                entity.Property(e => e.QtyToInvoiceBase)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Qty_ to Invoice (Base)");

                entity.Property(e => e.QtyToShip)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Qty_ to Ship");

                entity.Property(e => e.QtyToShipBase)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Qty_ to Ship (Base)");

                entity.Property(e => e.Quantity).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.QuantityBase)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Quantity (Base)");

                entity.Property(e => e.QuantityInvoiced)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Quantity Invoiced");

                entity.Property(e => e.QuantityShipped)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Quantity Shipped");

                entity.Property(e => e.RecalculateInvoiceDisc).HasColumnName("Recalculate Invoice Disc_");

                entity.Property(e => e.RequestedDeliveryDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Requested Delivery Date");

                entity.Property(e => e.ResponsibilityCenter)
                    .HasMaxLength(10)
                    .HasColumnName("Responsibility Center");

                entity.Property(e => e.RetQtyRcdNotInvdBase)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Ret_ Qty_ Rcd_ Not Invd_(Base)");

                entity.Property(e => e.ReturnQtyRcdNotInvd)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Return Qty_ Rcd_ Not Invd_");

                entity.Property(e => e.ReturnQtyReceived)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Return Qty_ Received");

                entity.Property(e => e.ReturnQtyReceivedBase)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Return Qty_ Received (Base)");

                entity.Property(e => e.ReturnQtyToReceive)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Return Qty_ to Receive");

                entity.Property(e => e.ReturnQtyToReceiveBase)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Return Qty_ to Receive (Base)");

                entity.Property(e => e.ReturnRcdNotInvd)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Return Rcd_ Not Invd_");

                entity.Property(e => e.ReturnRcdNotInvdLcy)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Return Rcd_ Not Invd_ (LCY)");

                entity.Property(e => e.ReturnReasonCode)
                    .HasMaxLength(10)
                    .HasColumnName("Return Reason Code");

                entity.Property(e => e.ReturnReceiptLineNo).HasColumnName("Return Receipt Line No_");

                entity.Property(e => e.ReturnReceiptNo)
                    .HasMaxLength(20)
                    .HasColumnName("Return Receipt No_");

                entity.Property(e => e.ReturnsDeferralStartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Returns Deferral Start Date");

                entity.Property(e => e.SalespersonCode)
                    .HasMaxLength(10)
                    .HasColumnName("Salesperson Code");

                entity.Property(e => e.SellToCustomerNo)
                    .HasMaxLength(20)
                    .HasColumnName("Sell-to Customer No_");

                entity.Property(e => e.ShipmentDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Shipment Date");

                entity.Property(e => e.ShipmentLineNo).HasColumnName("Shipment Line No_");

                entity.Property(e => e.ShipmentNo)
                    .HasMaxLength(20)
                    .HasColumnName("Shipment No_");

                entity.Property(e => e.ShippedNotInvLcyNoVat)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Shipped Not Inv_ (LCY) No VAT");

                entity.Property(e => e.ShippedNotInvoiced)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Shipped Not Invoiced");

                entity.Property(e => e.ShippedNotInvoicedLcy)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Shipped Not Invoiced (LCY)");

                entity.Property(e => e.ShippingAgentCode)
                    .HasMaxLength(10)
                    .HasColumnName("Shipping Agent Code");

                entity.Property(e => e.ShippingAgentServiceCode)
                    .HasMaxLength(10)
                    .HasColumnName("Shipping Agent Service Code");

                entity.Property(e => e.ShippingTime)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("Shipping Time");

                entity.Property(e => e.ShortcutDimension1Code)
                    .HasMaxLength(20)
                    .HasColumnName("Shortcut Dimension 1 Code");

                entity.Property(e => e.ShortcutDimension2Code)
                    .HasMaxLength(20)
                    .HasColumnName("Shortcut Dimension 2 Code");

                entity.Property(e => e.SpecialOrder).HasColumnName("Special Order");

                entity.Property(e => e.SpecialOrderPurchLineNo).HasColumnName("Special Order Purch_ Line No_");

                entity.Property(e => e.SpecialOrderPurchaseNo)
                    .HasMaxLength(20)
                    .HasColumnName("Special Order Purchase No_");

                entity.Property(e => e.SystemCreatedEntry).HasColumnName("System-Created Entry");

                entity.Property(e => e.TaxAreaCode)
                    .HasMaxLength(20)
                    .HasColumnName("Tax Area Code");

                entity.Property(e => e.TaxCategory)
                    .HasMaxLength(10)
                    .HasColumnName("Tax Category");

                entity.Property(e => e.TaxGroupCode)
                    .HasMaxLength(20)
                    .HasColumnName("Tax Group Code");

                entity.Property(e => e.TaxLiable).HasColumnName("Tax Liable");

                entity.Property(e => e.Timestamp)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("timestamp");

                entity.Property(e => e.TransactionSpecification)
                    .HasMaxLength(10)
                    .HasColumnName("Transaction Specification");

                entity.Property(e => e.TransactionType)
                    .HasMaxLength(10)
                    .HasColumnName("Transaction Type");

                entity.Property(e => e.TransportMethod)
                    .HasMaxLength(10)
                    .HasColumnName("Transport Method");

                entity.Property(e => e.UnitCost)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Unit Cost");

                entity.Property(e => e.UnitCostLcy)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Unit Cost (LCY)");

                entity.Property(e => e.UnitOfMeasure)
                    .HasMaxLength(10)
                    .HasColumnName("Unit of Measure");

                entity.Property(e => e.UnitOfMeasureCode)
                    .HasMaxLength(10)
                    .HasColumnName("Unit of Measure Code");

                entity.Property(e => e.UnitOfMeasureCrossRef)
                    .HasMaxLength(10)
                    .HasColumnName("Unit of Measure (Cross Ref_)");

                entity.Property(e => e.UnitPrice)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Unit Price");

                entity.Property(e => e.UnitVolume)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Unit Volume");

                entity.Property(e => e.UnitsPerParcel)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Units per Parcel");

                entity.Property(e => e.UseDuplicationList).HasColumnName("Use Duplication List");

                entity.Property(e => e.VariantCode)
                    .HasMaxLength(10)
                    .HasColumnName("Variant Code");

                entity.Property(e => e.Vat)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("VAT _");

                entity.Property(e => e.VatBaseAmount)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("VAT Base Amount");

                entity.Property(e => e.VatBusPostingGroup)
                    .HasMaxLength(20)
                    .HasColumnName("VAT Bus_ Posting Group");

                entity.Property(e => e.VatCalculationType).HasColumnName("VAT Calculation Type");

                entity.Property(e => e.VatClauseCode)
                    .HasMaxLength(20)
                    .HasColumnName("VAT Clause Code");

                entity.Property(e => e.VatDifference)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("VAT Difference");

                entity.Property(e => e.VatIdentifier)
                    .HasMaxLength(20)
                    .HasColumnName("VAT Identifier");

                entity.Property(e => e.VatProdPostingGroup)
                    .HasMaxLength(20)
                    .HasColumnName("VAT Prod_ Posting Group");

                entity.Property(e => e.WhseShipLineCreated).HasColumnName("Whse Ship Line Created");

                entity.Property(e => e.WorkTypeCode)
                    .HasMaxLength(10)
                    .HasColumnName("Work Type Code");

                entity.Property(e => e.YourOrderNo)
                    .HasMaxLength(35)
                    .HasColumnName("Your Order No_");
            });

            modelBuilder.Entity<TiNavSalesLineDiscount>(entity =>
            {
                entity.HasKey(e => new { e.Type, e.Code, e.SalesType, e.SalesCode, e.StartingDate, e.CurrencyCode, e.VariantCode, e.UnitOfMeasureCode, e.MinimumQuantity })
                    .HasName("TI NAV$Sales Line Discount$0");

                entity.ToTable("TI NAV$Sales Line Discount");

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.SalesType).HasColumnName("Sales Type");

                entity.Property(e => e.SalesCode)
                    .HasMaxLength(20)
                    .HasColumnName("Sales Code");

                entity.Property(e => e.StartingDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Starting Date");

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(10)
                    .HasColumnName("Currency Code");

                entity.Property(e => e.VariantCode)
                    .HasMaxLength(10)
                    .HasColumnName("Variant Code");

                entity.Property(e => e.UnitOfMeasureCode)
                    .HasMaxLength(10)
                    .HasColumnName("Unit of Measure Code");

                entity.Property(e => e.MinimumQuantity)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Minimum Quantity");

                entity.Property(e => e.EndingDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Ending Date");

                entity.Property(e => e.LineDiscount)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Line Discount _");

                entity.Property(e => e.Timestamp)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("timestamp");
            });

            modelBuilder.Entity<TiNavSalesPrice>(entity =>
            {
                entity.HasKey(e => new { e.ItemNo, e.SalesType, e.SalesCode, e.StartingDate, e.CurrencyCode, e.VariantCode, e.UnitOfMeasureCode, e.MinimumQuantity })
                    .HasName("TI NAV$Sales Price$0");

                entity.ToTable("TI NAV$Sales Price");

                entity.Property(e => e.ItemNo)
                    .HasMaxLength(20)
                    .HasColumnName("Item No_");

                entity.Property(e => e.SalesType).HasColumnName("Sales Type");

                entity.Property(e => e.SalesCode)
                    .HasMaxLength(20)
                    .HasColumnName("Sales Code");

                entity.Property(e => e.StartingDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Starting Date");

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(10)
                    .HasColumnName("Currency Code");

                entity.Property(e => e.VariantCode)
                    .HasMaxLength(10)
                    .HasColumnName("Variant Code");

                entity.Property(e => e.UnitOfMeasureCode)
                    .HasMaxLength(10)
                    .HasColumnName("Unit of Measure Code");

                entity.Property(e => e.MinimumQuantity)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Minimum Quantity");

                entity.Property(e => e.AllowInvoiceDisc).HasColumnName("Allow Invoice Disc_");

                entity.Property(e => e.AllowLineDisc).HasColumnName("Allow Line Disc_");

                entity.Property(e => e.EndingDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Ending Date");

                entity.Property(e => e.PriceIncludesVat).HasColumnName("Price Includes VAT");

                entity.Property(e => e.Timestamp)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("timestamp");

                entity.Property(e => e.UnitPrice)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Unit Price");

                entity.Property(e => e.VatBusPostingGrPrice)
                    .HasMaxLength(20)
                    .HasColumnName("VAT Bus_ Posting Gr_ (Price)");
            });

            modelBuilder.Entity<TiNavVatPostingSetup>(entity =>
            {
                entity.HasKey(e => new { e.VatBusPostingGroup, e.VatProdPostingGroup })
                    .HasName("TI NAV$VAT Posting Setup$0");

                entity.ToTable("TI NAV$VAT Posting Setup");

                entity.Property(e => e.VatBusPostingGroup)
                    .HasMaxLength(20)
                    .HasColumnName("VAT Bus_ Posting Group");

                entity.Property(e => e.VatProdPostingGroup)
                    .HasMaxLength(20)
                    .HasColumnName("VAT Prod_ Posting Group");

                entity.Property(e => e.AdjustForPaymentDiscount).HasColumnName("Adjust for Payment Discount");

                entity.Property(e => e.CertificateOfSupplyRequired).HasColumnName("Certificate of Supply Required");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.EuService).HasColumnName("EU Service");

                entity.Property(e => e.PurchVatUnrealAccount)
                    .HasMaxLength(20)
                    .HasColumnName("Purch_ VAT Unreal_ Account");

                entity.Property(e => e.PurchaseVatAccount)
                    .HasMaxLength(20)
                    .HasColumnName("Purchase VAT Account");

                entity.Property(e => e.ReverseChrgVatAcc)
                    .HasMaxLength(20)
                    .HasColumnName("Reverse Chrg_ VAT Acc_");

                entity.Property(e => e.ReverseChrgVatUnrealAcc)
                    .HasMaxLength(20)
                    .HasColumnName("Reverse Chrg_ VAT Unreal_ Acc_");

                entity.Property(e => e.SalesVatAccount)
                    .HasMaxLength(20)
                    .HasColumnName("Sales VAT Account");

                entity.Property(e => e.SalesVatUnrealAccount)
                    .HasMaxLength(20)
                    .HasColumnName("Sales VAT Unreal_ Account");

                entity.Property(e => e.TaxCategory)
                    .HasMaxLength(10)
                    .HasColumnName("Tax Category");

                entity.Property(e => e.Timestamp)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("timestamp");

                entity.Property(e => e.UnrealizedVatType).HasColumnName("Unrealized VAT Type");

                entity.Property(e => e.Vat)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("VAT _");

                entity.Property(e => e.VatCalculationType).HasColumnName("VAT Calculation Type");

                entity.Property(e => e.VatClauseCode)
                    .HasMaxLength(20)
                    .HasColumnName("VAT Clause Code");

                entity.Property(e => e.VatIdentifier)
                    .HasMaxLength(20)
                    .HasColumnName("VAT Identifier");
            });

            modelBuilder.Entity<TiNavVendor>(entity =>
            {
                entity.HasKey(e => e.No)
                    .HasName("TI NAV$Vendor$0");

                entity.ToTable("TI NAV$Vendor");

                entity.Property(e => e.No)
                    .HasMaxLength(20)
                    .HasColumnName("No_");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Address2)
                    .HasMaxLength(50)
                    .HasColumnName("Address 2");

                entity.Property(e => e.ApplicationMethod).HasColumnName("Application Method");

                entity.Property(e => e.BaseCalendarCode)
                    .HasMaxLength(10)
                    .HasColumnName("Base Calendar Code");

                entity.Property(e => e.BlockPaymentTolerance).HasColumnName("Block Payment Tolerance");

                entity.Property(e => e.BudgetedAmount)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Budgeted Amount");

                entity.Property(e => e.CashFlowPaymentTermsCode)
                    .HasMaxLength(10)
                    .HasColumnName("Cash Flow Payment Terms Code");

                entity.Property(e => e.City).HasMaxLength(30);

                entity.Property(e => e.Contact).HasMaxLength(50);

                entity.Property(e => e.CountryRegionCode)
                    .HasMaxLength(10)
                    .HasColumnName("Country_Region Code");

                entity.Property(e => e.County).HasMaxLength(30);

                entity.Property(e => e.CreditorNo)
                    .HasMaxLength(20)
                    .HasColumnName("Creditor No_");

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(10)
                    .HasColumnName("Currency Code");

                entity.Property(e => e.CurrencyId).HasColumnName("Currency Id");

                entity.Property(e => e.DoNotExportToSolo).HasColumnName("Do not export to SOLO");

                entity.Property(e => e.DocumentSendingProfile)
                    .HasMaxLength(20)
                    .HasColumnName("Document Sending Profile");

                entity.Property(e => e.EMail)
                    .HasMaxLength(80)
                    .HasColumnName("E-Mail");

                entity.Property(e => e.FaxNo)
                    .HasMaxLength(30)
                    .HasColumnName("Fax No_");

                entity.Property(e => e.FinChargeTermsCode)
                    .HasMaxLength(10)
                    .HasColumnName("Fin_ Charge Terms Code");

                entity.Property(e => e.GenBusPostingGroup)
                    .HasMaxLength(20)
                    .HasColumnName("Gen_ Bus_ Posting Group");

                entity.Property(e => e.Gln)
                    .HasMaxLength(13)
                    .HasColumnName("GLN");

                entity.Property(e => e.GlobalDimension1Code)
                    .HasMaxLength(20)
                    .HasColumnName("Global Dimension 1 Code");

                entity.Property(e => e.GlobalDimension2Code)
                    .HasMaxLength(20)
                    .HasColumnName("Global Dimension 2 Code");

                entity.Property(e => e.HomePage)
                    .HasMaxLength(80)
                    .HasColumnName("Home Page");

                entity.Property(e => e.IcPartnerCode)
                    .HasMaxLength(20)
                    .HasColumnName("IC Partner Code");

                entity.Property(e => e.InvoiceDiscCode)
                    .HasMaxLength(20)
                    .HasColumnName("Invoice Disc_ Code");

                entity.Property(e => e.LanguageCode)
                    .HasMaxLength(10)
                    .HasColumnName("Language Code");

                entity.Property(e => e.LastDateModified)
                    .HasColumnType("datetime")
                    .HasColumnName("Last Date Modified");

                entity.Property(e => e.LastModifiedDateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Last Modified Date Time");

                entity.Property(e => e.LeadTimeCalculation)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("Lead Time Calculation");

                entity.Property(e => e.LocationCode)
                    .HasMaxLength(10)
                    .HasColumnName("Location Code");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Name2)
                    .HasMaxLength(50)
                    .HasColumnName("Name 2");

                entity.Property(e => e.NameExternal)
                    .HasMaxLength(50)
                    .HasColumnName("Name External");

                entity.Property(e => e.NoSeries)
                    .HasMaxLength(20)
                    .HasColumnName("No_ Series");

                entity.Property(e => e.OurAccountNo)
                    .HasMaxLength(20)
                    .HasColumnName("Our Account No_");

                entity.Property(e => e.PartnerType).HasColumnName("Partner Type");

                entity.Property(e => e.PayToVendorNo)
                    .HasMaxLength(20)
                    .HasColumnName("Pay-to Vendor No_");

                entity.Property(e => e.PaymentMethodCode)
                    .HasMaxLength(10)
                    .HasColumnName("Payment Method Code");

                entity.Property(e => e.PaymentMethodId).HasColumnName("Payment Method Id");

                entity.Property(e => e.PaymentTermsCode)
                    .HasMaxLength(10)
                    .HasColumnName("Payment Terms Code");

                entity.Property(e => e.PaymentTermsId).HasColumnName("Payment Terms Id");

                entity.Property(e => e.PebDocumentCode)
                    .HasMaxLength(10)
                    .HasColumnName("PEB Document Code");

                entity.Property(e => e.PebExternalDocumentNo)
                    .HasMaxLength(20)
                    .HasColumnName("PEB External Document No_");

                entity.Property(e => e.PebNoContOfExtDocNo).HasColumnName("PEB No cont_ of Ext_ Doc_ No_");

                entity.Property(e => e.PebRegistrationNo)
                    .HasMaxLength(20)
                    .HasColumnName("PEB Registration No_");

                entity.Property(e => e.PhoneNo)
                    .HasMaxLength(30)
                    .HasColumnName("Phone No_");

                entity.Property(e => e.PhysicalAddress)
                    .HasMaxLength(50)
                    .HasColumnName("Physical Address");

                entity.Property(e => e.Picture).HasColumnType("image");

                entity.Property(e => e.PostCode)
                    .HasMaxLength(20)
                    .HasColumnName("Post Code");

                entity.Property(e => e.PreferredBankAccountCode)
                    .HasMaxLength(20)
                    .HasColumnName("Preferred Bank Account Code");

                entity.Property(e => e.Prepayment)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Prepayment _");

                entity.Property(e => e.PricesIncludingVat).HasColumnName("Prices Including VAT");

                entity.Property(e => e.PrimaryContactNo)
                    .HasMaxLength(20)
                    .HasColumnName("Primary Contact No_");

                entity.Property(e => e.PrivacyBlocked).HasColumnName("Privacy Blocked");

                entity.Property(e => e.PurchaseMethodCode)
                    .HasMaxLength(10)
                    .HasColumnName("Purchase Method Code");

                entity.Property(e => e.PurchaserCode)
                    .HasMaxLength(20)
                    .HasColumnName("Purchaser Code");

                entity.Property(e => e.ResponsibilityCenter)
                    .HasMaxLength(10)
                    .HasColumnName("Responsibility Center");

                entity.Property(e => e.SearchName)
                    .HasMaxLength(50)
                    .HasColumnName("Search Name");

                entity.Property(e => e.ShipmentMethodCode)
                    .HasMaxLength(10)
                    .HasColumnName("Shipment Method Code");

                entity.Property(e => e.ShippingAgentCode)
                    .HasMaxLength(10)
                    .HasColumnName("Shipping Agent Code");

                entity.Property(e => e.StatisticsGroup).HasColumnName("Statistics Group");

                entity.Property(e => e.TaxAreaCode)
                    .HasMaxLength(20)
                    .HasColumnName("Tax Area Code");

                entity.Property(e => e.TaxLiable).HasColumnName("Tax Liable");

                entity.Property(e => e.TelexAnswerBack)
                    .HasMaxLength(20)
                    .HasColumnName("Telex Answer Back");

                entity.Property(e => e.TelexNo)
                    .HasMaxLength(20)
                    .HasColumnName("Telex No_");

                entity.Property(e => e.TerritoryCode)
                    .HasMaxLength(10)
                    .HasColumnName("Territory Code");

                entity.Property(e => e.Timestamp)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("timestamp");

                entity.Property(e => e.ValidateEuVatRegNo).HasColumnName("Validate EU Vat Reg_ No_");

                entity.Property(e => e.VatBusPostingGroup)
                    .HasMaxLength(20)
                    .HasColumnName("VAT Bus_ Posting Group");

                entity.Property(e => e.VatRegistrationNo)
                    .HasMaxLength(20)
                    .HasColumnName("VAT Registration No_");

                entity.Property(e => e.VendorPostingGroup)
                    .HasMaxLength(20)
                    .HasColumnName("Vendor Posting Group");
            });

            modelBuilder.Entity<TiNavWipProductCategory>(entity =>
            {
                entity.HasKey(e => e.ExternalIdentifier)
                    .HasName("TI NAV$WipProductCategory$0");

                entity.ToTable("TI NAV$WipProductCategory");

                entity.Property(e => e.ExternalIdentifier).HasMaxLength(250);

                entity.Property(e => e.Identifier).HasMaxLength(250);

                entity.Property(e => e.Modified).HasColumnType("datetime");

                entity.Property(e => e.NameDk)
                    .HasMaxLength(250)
                    .HasColumnName("NameDK");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(250)
                    .HasColumnName("NameEN");

                entity.Property(e => e.NameFi)
                    .HasMaxLength(250)
                    .HasColumnName("NameFI");

                entity.Property(e => e.NameNo)
                    .HasMaxLength(250)
                    .HasColumnName("NameNO");

                entity.Property(e => e.NameSv)
                    .HasMaxLength(250)
                    .HasColumnName("NameSV");

                entity.Property(e => e.Timestamp)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("timestamp");

                entity.Property(e => e.Tsnumber).HasColumnName("TSNumber");
            });

            modelBuilder.Entity<ViewTempPrisListExport>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Temp_PrisListExport");

                entity.Property(e => e.ActivityCode)
                    .HasMaxLength(10)
                    .HasColumnName("Activity Code");

                entity.Property(e => e.CountryRegionOfOriginCode)
                    .HasMaxLength(10)
                    .HasColumnName("Country_Region of Origin Code");

                entity.Property(e => e.Cubage).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Currency Code");

                entity.Property(e => e.Customer).HasMaxLength(20);

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Description 2");

                entity.Property(e => e.Eeno)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("EENo");

                entity.Property(e => e.Fee).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.GrossWeight)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Gross Weight");

                entity.Property(e => e.Height).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.Item).HasMaxLength(20);

                entity.Property(e => e.ItemCategoryCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Item Category Code");

                entity.Property(e => e.ItemCategoryDescrip)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ItemCrossRef)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ItemDateCreated).HasColumnType("datetime");

                entity.Property(e => e.ItemDiscountGroup).HasMaxLength(20);

                entity.Property(e => e.ItemLastDateModified).HasColumnType("datetime");

                entity.Property(e => e.ItemSub)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Length).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.LineDiscountPerc).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.ManufactureName).HasMaxLength(50);

                entity.Property(e => e.NoTariffNo)
                    .HasMaxLength(10)
                    .HasColumnName("NO_TariffNo");

                entity.Property(e => e.PackageType)
                    .HasMaxLength(10)
                    .HasColumnName("Package Type");

                entity.Property(e => e.Packaging).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.PackagingMaster).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.PackagingPallet).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.PriceGroupRek)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("PriceGroupREK");

                entity.Property(e => e.PrimaryEanCode)
                    .HasMaxLength(13)
                    .HasColumnName("Primary EAN Code");

                entity.Property(e => e.ProdGroupCodeDescrip)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductGroupCode)
                    .HasMaxLength(10)
                    .HasColumnName("Product Group Code");

                entity.Property(e => e.QtyOnPurch).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.QtyOnSalesOrder).HasColumnType("decimal(38, 2)");

                entity.Property(e => e.ResQty).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.SalesPrice).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.SalesVolumeCode)
                    .HasMaxLength(10)
                    .HasColumnName("Sales Volume Code");

                entity.Property(e => e.TariffNo).HasMaxLength(20);

                entity.Property(e => e.VatRate)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("VAT_rate");

                entity.Property(e => e.VendorItemNo).HasMaxLength(30);

                entity.Property(e => e.VendorName).HasMaxLength(50);

                entity.Property(e => e.VendorNo).HasMaxLength(20);

                entity.Property(e => e.Width).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.WipCat1)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.WipCat2)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.WipCat3)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ViewTempPrisListExportCdon>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Temp_PrisListExport_CDON");

                entity.Property(e => e.ActivityCode)
                    .HasMaxLength(10)
                    .HasColumnName("Activity Code");

                entity.Property(e => e.CountryRegionOfOriginCode)
                    .HasMaxLength(10)
                    .HasColumnName("Country_Region of Origin Code");

                entity.Property(e => e.Cubage).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Currency Code");

                entity.Property(e => e.Customer).HasMaxLength(20);

                entity.Property(e => e.DanDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DanDescription2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DkWebText)
                    .IsUnicode(false)
                    .HasColumnName("DK WebText");

                entity.Property(e => e.EnWebText)
                    .IsUnicode(false)
                    .HasColumnName("EN WebText");

                entity.Property(e => e.EngDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EngDescription2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EuTariffNo)
                    .HasMaxLength(20)
                    .HasColumnName("EU-TariffNo");

                entity.Property(e => e.Fee).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.FiWebText)
                    .IsUnicode(false)
                    .HasColumnName("FI WebText");

                entity.Property(e => e.FinDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FinDescription2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GrossWeight)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Gross Weight");

                entity.Property(e => e.Height).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.Item).HasMaxLength(20);

                entity.Property(e => e.ItemCategoryCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Item Category Code");

                entity.Property(e => e.ItemCrossRef)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ItemDateCreated).HasColumnType("datetime");

                entity.Property(e => e.ItemDiscountGroup).HasMaxLength(20);

                entity.Property(e => e.ItemGroup)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ItemLastDateModified).HasColumnType("datetime");

                entity.Property(e => e.ItemSub)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Length).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.LineDiscountPerc).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.ManufactureName).HasMaxLength(50);

                entity.Property(e => e.NoTariffNo)
                    .HasMaxLength(10)
                    .HasColumnName("NO-TariffNo");

                entity.Property(e => e.NoWebText)
                    .IsUnicode(false)
                    .HasColumnName("NO WebText");

                entity.Property(e => e.NorDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NorDescription2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Packaging).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.PackagingMaster).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.PackagingPallet).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.PriceGroupRek)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("PriceGroupREK");

                entity.Property(e => e.PrimaryEanCode)
                    .HasMaxLength(13)
                    .HasColumnName("Primary EAN Code");

                entity.Property(e => e.ProductGroupCode)
                    .HasMaxLength(10)
                    .HasColumnName("Product Group Code");

                entity.Property(e => e.SalesPrice).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.SeWebText)
                    .IsUnicode(false)
                    .HasColumnName("SE WebText");

                entity.Property(e => e.SweDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SweDescription2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VatDk).HasColumnType("decimal(24, 6)");

                entity.Property(e => e.VatFi).HasColumnType("decimal(24, 6)");

                entity.Property(e => e.VatNo).HasColumnType("decimal(24, 6)");

                entity.Property(e => e.VatSe).HasColumnType("decimal(24, 6)");

                entity.Property(e => e.VendorItemNo).HasMaxLength(30);

                entity.Property(e => e.VendorName).HasMaxLength(50);

                entity.Property(e => e.VendorNo).HasMaxLength(20);

                entity.Property(e => e.Width).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.WipCat1)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.WipCat2)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.WipCat3)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ViewTempPrisListExportElk>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Temp_PrisListExport_ELK");

                entity.Property(e => e.ActivityCode)
                    .HasMaxLength(10)
                    .HasColumnName("Activity Code");

                entity.Property(e => e.CountryRegionOfOriginCode)
                    .HasMaxLength(10)
                    .HasColumnName("Country_Region of Origin Code");

                entity.Property(e => e.Cubage).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Currency Code");

                entity.Property(e => e.Customer).HasMaxLength(20);

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Description 2");

                entity.Property(e => e.Eeno)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("EENo");

                entity.Property(e => e.Elgdanprice)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("ELGDANPrice");

                entity.Property(e => e.Elgigatenprice)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("ELGIGATENPrice");

                entity.Property(e => e.Elkjopfiprice)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("ELKJOPFIPrice");

                entity.Property(e => e.Elkjopnoprice)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("ELKJOPNOPrice");

                entity.Property(e => e.Fee).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.Item).HasMaxLength(20);

                entity.Property(e => e.ItemCategoryCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Item Category Code");

                entity.Property(e => e.ItemCategoryDescrip)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ItemCrossRef)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ItemSub)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LineDiscountPerc).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.ManufactureName).HasMaxLength(10);

                entity.Property(e => e.NoTariffNo)
                    .HasMaxLength(10)
                    .HasColumnName("NO_TariffNo");

                entity.Property(e => e.PackageType)
                    .HasMaxLength(10)
                    .HasColumnName("Package Type");

                entity.Property(e => e.Packaging).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.PackagingMaster).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.PackagingPallet).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.PriceGroupRek)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("PriceGroupREK");

                entity.Property(e => e.PrimaryEanCode)
                    .HasMaxLength(13)
                    .HasColumnName("Primary EAN Code");

                entity.Property(e => e.ProdGroupCodeDescrip)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductGroupCode)
                    .HasMaxLength(10)
                    .HasColumnName("Product Group Code");

                entity.Property(e => e.QtyOnPurch).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.QtyOnSalesOrder).HasColumnType("decimal(38, 2)");

                entity.Property(e => e.ResQty).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.SalesPrice).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.SalesVolumeCode)
                    .HasMaxLength(10)
                    .HasColumnName("Sales Volume Code");

                entity.Property(e => e.TariffNo).HasMaxLength(20);

                entity.Property(e => e.VendorItemNo).HasMaxLength(30);

                entity.Property(e => e.VendorName).HasMaxLength(50);

                entity.Property(e => e.VendorNo).HasMaxLength(20);
            });

            modelBuilder.Entity<ViewTempPrisListExportElkFeed>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Temp_PrisListExport_ELK_Feed");

                entity.Property(e => e.ActivityCode).HasMaxLength(10);

                entity.Property(e => e.ActivityCodeDescription).HasMaxLength(30);

                entity.Property(e => e.ActivityCodeStatus).HasMaxLength(30);

                entity.Property(e => e.CountryOfOrigin).HasMaxLength(10);

                entity.Property(e => e.Cubage).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Currency Code");

                entity.Property(e => e.CustomerNo).HasMaxLength(20);

                entity.Property(e => e.DanDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DanDescription2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DanWipCat1)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DanWipCat2)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DanWipCat3)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.EngDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EngDescription2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EngWipCat1)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.EngWipCat2)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.EngWipCat3)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.EuCommodityCode).HasMaxLength(20);

                entity.Property(e => e.Fee).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.FeeResourceDk)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("FeeResourceDK");

                entity.Property(e => e.FeeResourceFi)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("FeeResourceFI");

                entity.Property(e => e.FeeResourceNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("FeeResourceNO");

                entity.Property(e => e.FeeResourceSe)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("FeeResourceSE");

                entity.Property(e => e.FeeTypDk).HasColumnName("FeeTypDK");

                entity.Property(e => e.FeeTypFi).HasColumnName("FeeTypFI");

                entity.Property(e => e.FeeTypNo).HasColumnName("FeeTypNO");

                entity.Property(e => e.FeeTypSe).HasColumnName("FeeTypSE");

                entity.Property(e => e.FinDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FinDescription2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FinWipCat1)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FinWipCat2)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FinWipCat3)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.GrossWeight).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.Gtin)
                    .HasMaxLength(13)
                    .HasColumnName("GTIN");

                entity.Property(e => e.Height).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.ItemCategoryCode).HasMaxLength(20);

                entity.Property(e => e.ItemCrossRef)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ItemDateCreated).HasColumnType("datetime");

                entity.Property(e => e.ItemFeeCode).HasMaxLength(10);

                entity.Property(e => e.ItemFeeDescription).HasMaxLength(50);

                entity.Property(e => e.ItemFeeResource).HasMaxLength(10);

                entity.Property(e => e.ItemLastDateModified).HasColumnType("datetime");

                entity.Property(e => e.ItemNo).HasMaxLength(20);

                entity.Property(e => e.ItemProductGroupCode).HasMaxLength(10);

                entity.Property(e => e.ItemSub)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Length).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.ManufactureCode).HasMaxLength(10);

                entity.Property(e => e.ManufactureName).HasMaxLength(50);

                entity.Property(e => e.NetWeight).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.NoCommodityCode).HasMaxLength(10);

                entity.Property(e => e.NorDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NorDescription2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NorWipCat1)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NorWipCat2)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NorWipCat3)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Packaging).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.PackagingMaster).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.PackagingPallet).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.ReplacesItemNo).HasMaxLength(20);

                entity.Property(e => e.SweDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SweDescription2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SweWipCat1)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SweWipCat2)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SweWipCat3)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Unspsc)
                    .HasMaxLength(10)
                    .HasColumnName("UNSPSC");

                entity.Property(e => e.VendorItemNo).HasMaxLength(30);

                entity.Property(e => e.WebTextDan).IsUnicode(false);

                entity.Property(e => e.WebTextEng).IsUnicode(false);

                entity.Property(e => e.WebTextFin).IsUnicode(false);

                entity.Property(e => e.WebTextNor).IsUnicode(false);

                entity.Property(e => e.WebTextSwe).IsUnicode(false);

                entity.Property(e => e.Width).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.WipExternalId3)
                    .HasMaxLength(250)
                    .HasColumnName("Wip External ID 3");
            });

            modelBuilder.Entity<ViewTempPrisListExportElkPlife>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Temp_PrisListExport_ELK_Plife");

                entity.Property(e => e.ActivityCode)
                    .HasMaxLength(10)
                    .HasColumnName("Activity Code");

                entity.Property(e => e.AvailableQty).HasColumnType("decimal(38, 2)");

                entity.Property(e => e.Description).HasMaxLength(101);

                entity.Property(e => e.ExcludeInPriceFile).HasColumnName("Exclude in PriceFile");

                entity.Property(e => e.ItemCategoryCode)
                    .HasMaxLength(20)
                    .HasColumnName("Item Category Code");

                entity.Property(e => e.ItemSub)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ItemType).HasColumnName("Item Type");

                entity.Property(e => e.LastDateTimeModified)
                    .HasColumnType("datetime")
                    .HasColumnName("Last DateTime Modified");

                entity.Property(e => e.ManufacturerCode)
                    .HasMaxLength(10)
                    .HasColumnName("Manufacturer Code");

                entity.Property(e => e.No)
                    .HasMaxLength(20)
                    .HasColumnName("No_");

                entity.Property(e => e.PrimaryEanCode)
                    .HasMaxLength(13)
                    .HasColumnName("Primary EAN Code");

                entity.Property(e => e.StatusPriceFile).HasMaxLength(30);

                entity.Property(e => e.VendorItemNo)
                    .HasMaxLength(30)
                    .HasColumnName("Vendor ItemNo_");

                entity.Property(e => e.VendorNo)
                    .HasMaxLength(20)
                    .HasColumnName("Vendor No_");
            });

            modelBuilder.Entity<ViewTempPrisListExportElkPrice>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Temp_PrisListExport_ELK_Price");

                entity.Property(e => e.ActivityCode)
                    .HasMaxLength(10)
                    .HasColumnName("Activity Code");

                entity.Property(e => e.Customer).HasMaxLength(20);

                entity.Property(e => e.Item).HasMaxLength(20);

                entity.Property(e => e.ItemCrossRef)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ItemSub)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NetPriceDkk)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("NetPriceDKK");

                entity.Property(e => e.NetPriceEur)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("NetPriceEUR");

                entity.Property(e => e.NetPriceNok)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("NetPriceNOK");

                entity.Property(e => e.NetPriceSek)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("NetPriceSEK");

                entity.Property(e => e.PrimaryEanCode)
                    .HasMaxLength(13)
                    .HasColumnName("Primary EAN Code");

                entity.Property(e => e.RecommendedPriceDkk)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("RecommendedPriceDKK");

                entity.Property(e => e.RecommendedPriceEur)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("RecommendedPriceEUR");

                entity.Property(e => e.RecommendedPriceNok)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("RecommendedPriceNOK");

                entity.Property(e => e.RecommendedPriceSek)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("RecommendedPriceSEK");

                entity.Property(e => e.StatusPriceFile).HasMaxLength(30);

                entity.Property(e => e.VendorItemNo).HasMaxLength(20);
            });

            modelBuilder.Entity<ViewTempPrisListExportFilter>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Temp_PrisListExport_Filter");

                entity.Property(e => e.ActivityCode)
                    .HasMaxLength(10)
                    .HasColumnName("Activity Code");

                entity.Property(e => e.CountryRegionOfOriginCode)
                    .HasMaxLength(10)
                    .HasColumnName("Country_Region of Origin Code");

                entity.Property(e => e.Cubage).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Currency Code");

                entity.Property(e => e.Customer).HasMaxLength(20);

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Description 2");

                entity.Property(e => e.Eeno)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("EENo");

                entity.Property(e => e.Fee).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.GrossWeight)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Gross Weight");

                entity.Property(e => e.Height).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.Item).HasMaxLength(20);

                entity.Property(e => e.ItemCategoryCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Item Category Code");

                entity.Property(e => e.ItemCategoryDescrip)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ItemCrossRef)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ItemDateCreated).HasColumnType("datetime");

                entity.Property(e => e.ItemDiscountGroup).HasMaxLength(20);

                entity.Property(e => e.ItemLastDateModified).HasColumnType("datetime");

                entity.Property(e => e.ItemSub)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Length).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.LineDiscountPerc).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.ManufactureName).HasMaxLength(50);

                entity.Property(e => e.NoTariffNo)
                    .HasMaxLength(10)
                    .HasColumnName("NO_TariffNo");

                entity.Property(e => e.PackageType)
                    .HasMaxLength(10)
                    .HasColumnName("Package Type");

                entity.Property(e => e.Packaging).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.PackagingMaster).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.PackagingPallet).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.PriceGroupRek)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("PriceGroupREK");

                entity.Property(e => e.PrimaryEanCode)
                    .HasMaxLength(13)
                    .HasColumnName("Primary EAN Code");

                entity.Property(e => e.ProdGroupCodeDescrip)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductGroupCode)
                    .HasMaxLength(10)
                    .HasColumnName("Product Group Code");

                entity.Property(e => e.QtyOnPurch).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.QtyOnSalesOrder).HasColumnType("decimal(38, 2)");

                entity.Property(e => e.ResQty).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.SalesPrice).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.SalesVolumeCode)
                    .HasMaxLength(10)
                    .HasColumnName("Sales Volume Code");

                entity.Property(e => e.TariffNo).HasMaxLength(20);

                entity.Property(e => e.VatRate)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("VAT_rate");

                entity.Property(e => e.VendorItemNo).HasMaxLength(30);

                entity.Property(e => e.VendorName).HasMaxLength(50);

                entity.Property(e => e.VendorNo).HasMaxLength(20);

                entity.Property(e => e.Width).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.WipCat1)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.WipCat2)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.WipCat3)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ViewTempPrisListExportHr>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Temp_PrisListExport_Hrs");

                entity.Property(e => e.ActivityCode)
                    .HasMaxLength(10)
                    .HasColumnName("Activity Code");

                entity.Property(e => e.CountryRegionOfOriginCode)
                    .HasMaxLength(10)
                    .HasColumnName("Country_Region of Origin Code");

                entity.Property(e => e.Cubage).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Currency Code");

                entity.Property(e => e.Customer).HasMaxLength(20);

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Description 2");

                entity.Property(e => e.Eeno)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("EENo");

                entity.Property(e => e.Fee).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.GrossWeight)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Gross Weight");

                entity.Property(e => e.Height).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.Item).HasMaxLength(20);

                entity.Property(e => e.ItemCategoryCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Item Category Code");

                entity.Property(e => e.ItemCategoryDescrip)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ItemCrossRef)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ItemDateCreated).HasColumnType("datetime");

                entity.Property(e => e.ItemDiscountGroup).HasMaxLength(20);

                entity.Property(e => e.ItemLastDateModified).HasColumnType("datetime");

                entity.Property(e => e.ItemSub)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Length).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.LineDiscountPerc).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.ManufactureName).HasMaxLength(50);

                entity.Property(e => e.NoTariffNo)
                    .HasMaxLength(10)
                    .HasColumnName("NO_TariffNo");

                entity.Property(e => e.PackageType)
                    .HasMaxLength(10)
                    .HasColumnName("Package Type");

                entity.Property(e => e.Packaging).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.PackagingMaster).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.PackagingPallet).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.PriceGroupRek)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("PriceGroupREK");

                entity.Property(e => e.PrimaryEanCode)
                    .HasMaxLength(13)
                    .HasColumnName("Primary EAN Code");

                entity.Property(e => e.ProdGroupCodeDescrip)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductGroupCode)
                    .HasMaxLength(10)
                    .HasColumnName("Product Group Code");

                entity.Property(e => e.QtyOnPurch).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.QtyOnSalesOrder).HasColumnType("decimal(38, 2)");

                entity.Property(e => e.ResQty).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.SalesPrice).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.SalesVolumeCode)
                    .HasMaxLength(10)
                    .HasColumnName("Sales Volume Code");

                entity.Property(e => e.TariffNo).HasMaxLength(20);

                entity.Property(e => e.VatRate)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("VAT_rate");

                entity.Property(e => e.VendorItemNo).HasMaxLength(30);

                entity.Property(e => e.VendorName).HasMaxLength(50);

                entity.Property(e => e.VendorNo).HasMaxLength(20);

                entity.Property(e => e.Width).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.WipCat1)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.WipCat2)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.WipCat3)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ViewTempPrisListExportHrsFilter>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Temp_PrisListExport_Hrs_Filter");

                entity.Property(e => e.ActivityCode)
                    .HasMaxLength(10)
                    .HasColumnName("Activity Code");

                entity.Property(e => e.CountryRegionOfOriginCode)
                    .HasMaxLength(10)
                    .HasColumnName("Country_Region of Origin Code");

                entity.Property(e => e.Cubage).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Currency Code");

                entity.Property(e => e.Customer).HasMaxLength(20);

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Description 2");

                entity.Property(e => e.Eeno)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("EENo");

                entity.Property(e => e.Fee).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.GrossWeight)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Gross Weight");

                entity.Property(e => e.Height).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.Item).HasMaxLength(20);

                entity.Property(e => e.ItemCategoryCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Item Category Code");

                entity.Property(e => e.ItemCategoryDescrip)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ItemCrossRef)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ItemDateCreated).HasColumnType("datetime");

                entity.Property(e => e.ItemDiscountGroup).HasMaxLength(20);

                entity.Property(e => e.ItemLastDateModified).HasColumnType("datetime");

                entity.Property(e => e.ItemSub)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Length).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.LineDiscountPerc).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.ManufactureName).HasMaxLength(50);

                entity.Property(e => e.NoTariffNo)
                    .HasMaxLength(10)
                    .HasColumnName("NO_TariffNo");

                entity.Property(e => e.PackageType)
                    .HasMaxLength(10)
                    .HasColumnName("Package Type");

                entity.Property(e => e.Packaging).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.PackagingMaster).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.PackagingPallet).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.PriceGroupRek)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("PriceGroupREK");

                entity.Property(e => e.PrimaryEanCode)
                    .HasMaxLength(13)
                    .HasColumnName("Primary EAN Code");

                entity.Property(e => e.ProdGroupCodeDescrip)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductGroupCode)
                    .HasMaxLength(10)
                    .HasColumnName("Product Group Code");

                entity.Property(e => e.QtyOnPurch).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.QtyOnSalesOrder).HasColumnType("decimal(38, 2)");

                entity.Property(e => e.ResQty).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.SalesPrice).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.SalesVolumeCode)
                    .HasMaxLength(10)
                    .HasColumnName("Sales Volume Code");

                entity.Property(e => e.TariffNo).HasMaxLength(20);

                entity.Property(e => e.VatRate)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("VAT_rate");

                entity.Property(e => e.VendorItemNo).HasMaxLength(30);

                entity.Property(e => e.VendorName).HasMaxLength(50);

                entity.Property(e => e.VendorNo).HasMaxLength(20);

                entity.Property(e => e.Width).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.WipCat1)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.WipCat2)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.WipCat3)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ViewTempPrisListExportQty>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Temp_PrisListExport_Qty");

                entity.Property(e => e.AvailableQty).HasColumnType("decimal(38, 2)");

                entity.Property(e => e.Item).HasMaxLength(20);

                entity.Property(e => e.PlanedDate).HasColumnType("datetime");

                entity.Property(e => e.QtyOnPurch).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.QtyOnSalesOrder).HasColumnType("decimal(38, 2)");

                entity.Property(e => e.ResQty).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<ViewTempPrisListExportSingle>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Temp_PrisListExport_Single");

                entity.Property(e => e.ActivityCode)
                    .HasMaxLength(10)
                    .HasColumnName("Activity Code");

                entity.Property(e => e.CountryRegionOfOriginCode)
                    .HasMaxLength(10)
                    .HasColumnName("Country_Region of Origin Code");

                entity.Property(e => e.Cubage).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Currency Code");

                entity.Property(e => e.Customer).HasMaxLength(20);

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Description 2");

                entity.Property(e => e.Eeno)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("EENo");

                entity.Property(e => e.Fee).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.GrossWeight)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("Gross Weight");

                entity.Property(e => e.Height).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.Item).HasMaxLength(20);

                entity.Property(e => e.ItemCategoryCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Item Category Code");

                entity.Property(e => e.ItemCategoryDescrip)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ItemCrossRef)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ItemDateCreated).HasColumnType("datetime");

                entity.Property(e => e.ItemDiscountGroup).HasMaxLength(20);

                entity.Property(e => e.ItemLastDateModified).HasColumnType("datetime");

                entity.Property(e => e.ItemSub)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Length).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.LineDiscountPerc).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.ManufactureName).HasMaxLength(50);

                entity.Property(e => e.NoTariffNo)
                    .HasMaxLength(10)
                    .HasColumnName("NO_TariffNo");

                entity.Property(e => e.PackageType)
                    .HasMaxLength(10)
                    .HasColumnName("Package Type");

                entity.Property(e => e.Packaging).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.PackagingMaster).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.PackagingPallet).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.PriceGroupRek)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("PriceGroupREK");

                entity.Property(e => e.PrimaryEanCode)
                    .HasMaxLength(13)
                    .HasColumnName("Primary EAN Code");

                entity.Property(e => e.ProdGroupCodeDescrip)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductGroupCode)
                    .HasMaxLength(10)
                    .HasColumnName("Product Group Code");

                entity.Property(e => e.QtyOnPurch).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.QtyOnSalesOrder).HasColumnType("decimal(38, 2)");

                entity.Property(e => e.ResQty).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.SalesPrice).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.SalesVolumeCode)
                    .HasMaxLength(10)
                    .HasColumnName("Sales Volume Code");

                entity.Property(e => e.TariffNo).HasMaxLength(20);

                entity.Property(e => e.VatRate)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("VAT_rate");

                entity.Property(e => e.VendorItemNo).HasMaxLength(30);

                entity.Property(e => e.VendorName).HasMaxLength(50);

                entity.Property(e => e.VendorNo).HasMaxLength(20);

                entity.Property(e => e.Width).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.WipCat1)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.WipCat2)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.WipCat3)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ViewTempPrisListExportSsr>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Temp_PrisListExport_SSRS");

                entity.Property(e => e.ActivityCode).HasMaxLength(10);

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Customer).HasMaxLength(20);

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Description 2");

                entity.Property(e => e.FeeSum).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.Gtin)
                    .HasMaxLength(13)
                    .HasColumnName("GTIN");

                entity.Property(e => e.Item).HasMaxLength(20);

                entity.Property(e => e.ItemCategoryCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ItemCategoryDescrip)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ItemDiscountGroup).HasMaxLength(20);

                entity.Property(e => e.LineDiscountPerc).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.ManufactureName).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.PriceGroupRek)
                    .HasColumnType("decimal(38, 20)")
                    .HasColumnName("PriceGroupREK");

                entity.Property(e => e.ProdGroupCode).HasMaxLength(10);

                entity.Property(e => e.ProdGroupCodeDescrip)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SalesPrice).HasColumnType("decimal(38, 20)");

                entity.Property(e => e.VendorItemNo).HasMaxLength(30);

                entity.Property(e => e.VendorName).HasMaxLength(50);

                entity.Property(e => e.VendorNo).HasMaxLength(20);

                entity.Property(e => e.WipCat1)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.WipCat2)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.WipCat3)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
