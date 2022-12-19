using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TotalEntitiesDataAccessLibrary.DatabaseModels;

public partial class TuraTotalContext : DbContext
{
    public TuraTotalContext()
    {
    }

    public TuraTotalContext(DbContextOptions<TuraTotalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ActivityCode> ActivityCodes { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerPrice> CustomerPrices { get; set; }

    public virtual DbSet<GetItemDatum> GetItemData { get; set; }

    public virtual DbSet<GetItemDescDanWeb> GetItemDescDanWebs { get; set; }

    public virtual DbSet<GetItemDescEngWeb> GetItemDescEngWebs { get; set; }

    public virtual DbSet<GetItemDescFinWeb> GetItemDescFinWebs { get; set; }

    public virtual DbSet<GetItemDescNorWeb> GetItemDescNorWebs { get; set; }

    public virtual DbSet<GetItemDescSweWeb> GetItemDescSweWebs { get; set; }

    public virtual DbSet<GetItemDescSweWebLitium> GetItemDescSweWebLitia { get; set; }

    public virtual DbSet<HamaCurrencyCrossRef> HamaCurrencyCrossRefs { get; set; }

    public virtual DbSet<HamaDeliveryaddress> HamaDeliveryaddresses { get; set; }

    public virtual DbSet<HamaFeeCrossRef> HamaFeeCrossRefs { get; set; }

    public virtual DbSet<HamaItemDescription> HamaItemDescriptions { get; set; }

    public virtual DbSet<HamaOrderitem> HamaOrderitems { get; set; }

    public virtual DbSet<HamaPurchaseorder> HamaPurchaseorders { get; set; }

    public virtual DbSet<HamaUnspsc> HamaUnspscs { get; set; }

    public virtual DbSet<HamaVatCrossRef> HamaVatCrossRefs { get; set; }

    public virtual DbSet<InBackorder> InBackorders { get; set; }

    public virtual DbSet<InCustomer> InCustomers { get; set; }

    public virtual DbSet<InCustomeraddress> InCustomeraddresses { get; set; }

    public virtual DbSet<InCustomerspecificPrice> InCustomerspecificPrices { get; set; }

    public virtual DbSet<InFee> InFees { get; set; }

    public virtual DbSet<InItem> InItems { get; set; }

    public virtual DbSet<InPrice> InPrices { get; set; }

    public virtual DbSet<InSalesLineOrderhistory> InSalesLineOrderhistories { get; set; }

    public virtual DbSet<InSalesstatus> InSalesstatuses { get; set; }

    public virtual DbSet<InStockdatum> InStockdata { get; set; }

    public virtual DbSet<InVat> InVats { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<ItemCategory> ItemCategories { get; set; }

    public virtual DbSet<ItemFeePrice> ItemFeePrices { get; set; }

    public virtual DbSet<ItemStockDatum> ItemStockData { get; set; }

    public virtual DbSet<ItemTranslation> ItemTranslations { get; set; }

    public virtual DbSet<ItemUnitOfMeasure> ItemUnitOfMeasures { get; set; }

    public virtual DbSet<LitiumProductsDescription> LitiumProductsDescriptions { get; set; }

    public virtual DbSet<OutBackorder> OutBackorders { get; set; }

    public virtual DbSet<OutCustomer> OutCustomers { get; set; }

    public virtual DbSet<OutCustomeradress> OutCustomeradresses { get; set; }

    public virtual DbSet<OutCustomerspecificPrice> OutCustomerspecificPrices { get; set; }

    public virtual DbSet<OutItemPricesListing> OutItemPricesListings { get; set; }

    public virtual DbSet<OutPrice> OutPrices { get; set; }

    public virtual DbSet<OutSalesLineOrderhistory> OutSalesLineOrderhistories { get; set; }

    public virtual DbSet<OutSalesstatus> OutSalesstatuses { get; set; }

    public virtual DbSet<OutStockdatum> OutStockdata { get; set; }

    public virtual DbSet<ProductGroup> ProductGroups { get; set; }

    public virtual DbSet<SalesCrMemoHeader> SalesCrMemoHeaders { get; set; }

    public virtual DbSet<SalesCrMemoLine> SalesCrMemoLines { get; set; }

    public virtual DbSet<SalesHeader> SalesHeaders { get; set; }

    public virtual DbSet<SalesInvoiceHeader> SalesInvoiceHeaders { get; set; }

    public virtual DbSet<SalesInvoiceLine> SalesInvoiceLines { get; set; }

    public virtual DbSet<SalesLine> SalesLines { get; set; }

    public virtual DbSet<SalesLineDiscount> SalesLineDiscounts { get; set; }

    public virtual DbSet<SalesPrice> SalesPrices { get; set; }

    public virtual DbSet<ShipToAddress> ShipToAddresses { get; set; }

    public virtual DbSet<Specialkunder> Specialkunders { get; set; }

    public virtual DbSet<Specialkunder1> Specialkunders1 { get; set; }

    public virtual DbSet<TestHamaItemDescription> TestHamaItemDescriptions { get; set; }

    public virtual DbSet<TmpCustomerPrice> TmpCustomerPrices { get; set; }

    public virtual DbSet<TuraProductDescription> TuraProductDescriptions { get; set; }

    public virtual DbSet<VatPostingSetup> VatPostingSetups { get; set; }

    public virtual DbSet<WipProductCategory> WipProductCategories { get; set; }

    public virtual DbSet<WipProductCategoryLink> WipProductCategoryLinks { get; set; }

    public virtual DbSet<WipWebOrder> WipWebOrders { get; set; }

    public virtual DbSet<WipWebOrderRow> WipWebOrderRows { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=192.168.1.94;Initial Catalog=TuraTotal;User ID=ttreader;Password=rocco12!;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Finnish_Swedish_100_CS_AS");

        modelBuilder.Entity<ActivityCode>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("Activity Code$0");

            entity.ToTable("Activity Code");

            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Timestamp)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("timestamp");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.No).HasName("Customer$0");

            entity.ToTable("Customer");

            entity.Property(e => e.No)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("No_");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Address2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Address 2");
            entity.Property(e => e.AllowLineDisc).HasColumnName("Allow Line Disc_");
            entity.Property(e => e.BillToCustomerNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Bill-to Customer No_");
            entity.Property(e => e.ChainCoded)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Chain Coded");
            entity.Property(e => e.ChainName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Chain Name");
            entity.Property(e => e.City)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Contact)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CountryRegionCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Country_Region Code");
            entity.Property(e => e.CreditLimitLcy)
                .HasColumnType("decimal(38, 20)")
                .HasColumnName("Credit Limit (LCY)");
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Currency Code");
            entity.Property(e => e.CustomerDiscGroup)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Customer Disc_ Group");
            entity.Property(e => e.CustomerPriceGroup)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Customer Price Group");
            entity.Property(e => e.EMail)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("E-Mail");
            entity.Property(e => e.Eancode)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("EANCode");
            entity.Property(e => e.FaxNo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Fax No_");
            entity.Property(e => e.FeeCustomerGroupCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Fee Customer Group Code");
            entity.Property(e => e.HomePage)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("Home Page");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Name 2");
            entity.Property(e => e.Ordertype)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.PaymentTermsCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Payment Terms Code");
            entity.Property(e => e.PhoneNo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Phone No_");
            entity.Property(e => e.PostCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Post Code");
            entity.Property(e => e.PricelistInterval).HasColumnName("Pricelist Interval");
            entity.Property(e => e.PricesIncludingVat).HasColumnName("Prices Including VAT");
            entity.Property(e => e.SearchName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Search Name");
            entity.Property(e => e.ShipToCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Ship-to Code");
            entity.Property(e => e.ShipmentMethodCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Shipment Method Code");
            entity.Property(e => e.TelexNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Telex No_");
            entity.Property(e => e.TerritoryCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Territory Code");
            entity.Property(e => e.Timestamp)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("timestamp");
            entity.Property(e => e.VatRegistrationNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("VAT Registration No_");
            entity.Property(e => e.WebShop).HasColumnName("Web Shop");
        });

        modelBuilder.Entity<CustomerPrice>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Customer Prices");

            entity.Property(e => e.AllowLineDisc).HasColumnName("Allow Line Disc_");
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Currency Code");
            entity.Property(e => e.CustomerNo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Customer No_");
            entity.Property(e => e.CustomerPrice1)
                .HasColumnType("decimal(38, 20)")
                .HasColumnName("Customer Price");
            entity.Property(e => e.Discount)
                .HasColumnType("decimal(38, 20)")
                .HasColumnName("Discount %");
            entity.Property(e => e.EndingDate)
                .HasColumnType("datetime")
                .HasColumnName("Ending Date");
            entity.Property(e => e.ItemFee)
                .HasColumnType("decimal(38, 20)")
                .HasColumnName("Item Fee");
            entity.Property(e => e.ItemNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Item No_");
            entity.Property(e => e.MinimumQuantity)
                .HasColumnType("decimal(38, 20)")
                .HasColumnName("Minimum Quantity");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("Modified Date");
            entity.Property(e => e.NotDivisibleUnit).HasColumnName("Not Divisible Unit");
            entity.Property(e => e.RecPrice)
                .HasColumnType("decimal(38, 20)")
                .HasColumnName("Rec Price");
            entity.Property(e => e.SalesCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Sales Code");
            entity.Property(e => e.StartingDate)
                .HasColumnType("datetime")
                .HasColumnName("Starting Date");
            entity.Property(e => e.Timestamp)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("timestamp");
            entity.Property(e => e.UnitPrice)
                .HasColumnType("decimal(38, 20)")
                .HasColumnName("Unit Price");
        });

        modelBuilder.Entity<GetItemDatum>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Get_ItemData");

            entity.Property(e => e.ActivityCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Activity Code");
            entity.Property(e => e.Description)
                .HasMaxLength(101)
                .IsUnicode(false);
            entity.Property(e => e.ItemDescriptionSw)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasColumnName("item_description_sw");
            entity.Property(e => e.ManufacturerCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Manufacturer Code");
            entity.Property(e => e.No)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("No_");
            entity.Property(e => e.PrimaryEanCode)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("Primary EAN Code");
            entity.Property(e => e.UnspscId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("unspsc_id");
            entity.Property(e => e.UnspscName)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasColumnName("unspsc_name");
            entity.Property(e => e.VendorItemNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Vendor Item No_");
        });

        modelBuilder.Entity<GetItemDescDanWeb>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GetItemDescDanWeb");

            entity.Property(e => e.Eancode)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("EANCode");
            entity.Property(e => e.ManufacturerCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ProductDescriptionDan).HasColumnName("ProductDescriptionDAN");
            entity.Property(e => e.ProductName)
                .HasMaxLength(101)
                .IsUnicode(false);
            entity.Property(e => e.TuraItemNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.VendorItemNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.WebCat1)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.WebCat2)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.WebCat3)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<GetItemDescEngWeb>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GetItemDescEngWeb");

            entity.Property(e => e.Eancode)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("EANCode");
            entity.Property(e => e.ManufacturerCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ProductDescriptionEng).HasColumnName("ProductDescriptionENG");
            entity.Property(e => e.ProductName)
                .HasMaxLength(101)
                .IsUnicode(false);
            entity.Property(e => e.TuraItemNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.VendorItemNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.WebCat1)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.WebCat2)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.WebCat3)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<GetItemDescFinWeb>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GetItemDescFinWeb");

            entity.Property(e => e.Eancode)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("EANCode");
            entity.Property(e => e.ManufacturerCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ProductDescriptionFin).HasColumnName("ProductDescriptionFIN");
            entity.Property(e => e.ProductName)
                .HasMaxLength(101)
                .IsUnicode(false);
            entity.Property(e => e.TuraItemNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.VendorItemNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.WebCat1)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.WebCat2)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.WebCat3)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<GetItemDescNorWeb>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GetItemDescNorWeb");

            entity.Property(e => e.Eancode)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("EANCode");
            entity.Property(e => e.ManufacturerCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ProductDescriptionNor).HasColumnName("ProductDescriptionNOR");
            entity.Property(e => e.ProductName)
                .HasMaxLength(101)
                .IsUnicode(false);
            entity.Property(e => e.TuraItemNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.VendorItemNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.WebCat1)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.WebCat2)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.WebCat3)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<GetItemDescSweWeb>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GetItemDescSweWeb");

            entity.Property(e => e.Eancode)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("EANCode");
            entity.Property(e => e.ManufacturerCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ProductDescriptionSwe).HasColumnName("ProductDescriptionSWE");
            entity.Property(e => e.ProductName)
                .HasMaxLength(101)
                .IsUnicode(false);
            entity.Property(e => e.TuraItemNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.VendorItemNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.WebCat1)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.WebCat2)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.WebCat3)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<GetItemDescSweWebLitium>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GetItemDescSweWebLitium");

            entity.Property(e => e.Eancode)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("EANCode");
            entity.Property(e => e.ManufacturerCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ProductDescriptionSwe).HasColumnName("ProductDescriptionSWE");
            entity.Property(e => e.ProductName)
                .HasMaxLength(101)
                .IsUnicode(false);
            entity.Property(e => e.TuraItemNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.VendorItemNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.WebCat1)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.WebCat2)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.WebCat3)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HamaCurrencyCrossRef>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("HAMA_Currency_CrossRef");

            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(50)
                .HasColumnName("CURRENCY_CODE");
            entity.Property(e => e.CurrencyId)
                .HasMaxLength(50)
                .HasColumnName("CURRENCY_ID");
        });

        modelBuilder.Entity<HamaDeliveryaddress>(entity =>
        {
            entity.HasKey(e => e.PurchaseorderId);

            entity.ToTable("HAMA_DELIVERYADDRESS");

            entity.Property(e => e.PurchaseorderId)
                .ValueGeneratedNever()
                .HasColumnName("PURCHASEORDER_ID");
            entity.Property(e => e.AdditonToCustomeraddress)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("additon_to_customeraddress");
            entity.Property(e => e.City)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("CITY");
            entity.Property(e => e.Country)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("COUNTRY");
            entity.Property(e => e.CountryId).HasColumnName("COUNTRY_ID");
            entity.Property(e => e.CustomerId).HasColumnName("CUSTOMER_ID");
            entity.Property(e => e.LastModified)
                .HasColumnType("datetime")
                .HasColumnName("LAST_MODIFIED");
            entity.Property(e => e.MobilePhoneNo)
                .HasMaxLength(50)
                .HasColumnName("MOBILE_PHONE_NO");
            entity.Property(e => e.Name1)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("NAME1");
            entity.Property(e => e.Name2)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("NAME2");
            entity.Property(e => e.RecordstatusId).HasColumnName("RECORDSTATUS_ID");
            entity.Property(e => e.Sortvalue).HasColumnName("SORTVALUE");
            entity.Property(e => e.Street)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("STREET");
            entity.Property(e => e.StreetNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("STREET_NUMBER");
            entity.Property(e => e.TempDeliveryaddressId).HasColumnName("TEMP_DELIVERYADDRESS_ID");
            entity.Property(e => e.Zipcode)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("ZIPCODE");
        });

        modelBuilder.Entity<HamaFeeCrossRef>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("HAMA_Fee_CrossRef");

            entity.Property(e => e.CountryCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Country_Code");
            entity.Property(e => e.HamaCode).HasColumnName("HAMA_Code");
            entity.Property(e => e.NavCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAV_Code");
        });

        modelBuilder.Entity<HamaItemDescription>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("HAMA_Item_Description");

            entity.Property(e => e.ItemDescriptionDk)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasColumnName("item_description_dk");
            entity.Property(e => e.ItemDescriptionEn)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasColumnName("item_description_en");
            entity.Property(e => e.ItemDescriptionFi)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasColumnName("item_description_fi");
            entity.Property(e => e.ItemDescriptionNo)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasColumnName("item_description_no");
            entity.Property(e => e.ItemDescriptionSw)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasColumnName("item_description_sw");
            entity.Property(e => e.ItemTechDk)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasColumnName("item_tech_dk");
            entity.Property(e => e.ItemTechEn)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasColumnName("item_tech_en");
            entity.Property(e => e.ItemTechFi)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasColumnName("item_tech_fi");
            entity.Property(e => e.ItemTechNo)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasColumnName("item_tech_no");
            entity.Property(e => e.ItemTechSw)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasColumnName("item_tech_sw");
            entity.Property(e => e.SalesItemNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("sales_item_no");
            entity.Property(e => e.UnspscId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("unspsc_id");
            entity.Property(e => e.UnspscName)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasColumnName("unspsc_name");
        });

        modelBuilder.Entity<HamaOrderitem>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("HAMA_ORDERITEM");

            entity.Property(e => e.CurrencyId).HasColumnName("CURRENCY_ID");
            entity.Property(e => e.ItemId).HasColumnName("ITEM_ID");
            entity.Property(e => e.Itemnumber)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("ITEMNUMBER");
            entity.Property(e => e.LastModified)
                .HasColumnType("datetime")
                .HasColumnName("LAST_MODIFIED");
            entity.Property(e => e.Note)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasColumnName("NOTE");
            entity.Property(e => e.OrderitemId).HasColumnName("ORDERITEM_ID");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("PRICE");
            entity.Property(e => e.PurchaseorderId).HasColumnName("PURCHASEORDER_ID");
            entity.Property(e => e.Quantity).HasColumnName("QUANTITY");
            entity.Property(e => e.RecordstatusId).HasColumnName("RECORDSTATUS_ID");
        });

        modelBuilder.Entity<HamaPurchaseorder>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("HAMA_PURCHASEORDER");

            entity.Property(e => e.AccountId).HasColumnName("ACCOUNT_ID");
            entity.Property(e => e.AusgelesenAm)
                .HasColumnType("datetime")
                .HasColumnName("AUSGELESEN_AM");
            entity.Property(e => e.CurrencyId).HasColumnName("CURRENCY_ID");
            entity.Property(e => e.Customernumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CUSTOMERNUMBER");
            entity.Property(e => e.DeliveryDate)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("DELIVERY_DATE");
            entity.Property(e => e.DeliveryaddressId).HasColumnName("DELIVERYADDRESS_ID");
            entity.Property(e => e.ExternalAddressId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("EXTERNAL_ADDRESS_ID");
            entity.Property(e => e.ExternalId)
                .HasMaxLength(19)
                .HasColumnName("EXTERNAL_ID");
            entity.Property(e => e.InternalNote)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("INTERNAL_NOTE");
            entity.Property(e => e.LastModified)
                .HasColumnType("datetime")
                .HasColumnName("LAST_MODIFIED");
            entity.Property(e => e.Note)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("NOTE");
            entity.Property(e => e.Ordertype).HasColumnName("ORDERTYPE");
            entity.Property(e => e.PurchaseorderId).HasColumnName("PURCHASEORDER_ID");
            entity.Property(e => e.RecordstatusId).HasColumnName("RECORDSTATUS_ID");
            entity.Property(e => e.Status).HasColumnName("STATUS");
            entity.Property(e => e.TempDeliveryaddressId).HasColumnName("TEMP_DELIVERYADDRESS_ID");
            entity.Property(e => e.TotalSum)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("TOTAL_SUM");
            entity.Property(e => e.UsersessionId).HasColumnName("USERSESSION_ID");
        });

        modelBuilder.Entity<HamaUnspsc>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("HAMA_UNSPSC");

            entity.Property(e => e.UnspscId).HasColumnName("UNSPSC_ID");
            entity.Property(e => e.UnspscName)
                .HasMaxLength(255)
                .HasColumnName("UNSPSC_NAME");
        });

        modelBuilder.Entity<HamaVatCrossRef>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("HAMA_VAT_CrossRef");

            entity.Property(e => e.VatCode)
                .HasMaxLength(50)
                .HasColumnName("VAT_CODE");
            entity.Property(e => e.VatCountryCode)
                .HasMaxLength(50)
                .HasColumnName("VAT_COUNTRY_CODE");
            entity.Property(e => e.VatTypeId)
                .HasMaxLength(50)
                .HasColumnName("VAT_TYPE_ID");
        });

        modelBuilder.Entity<InBackorder>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("IN_BACKORDERS");

            entity.Property(e => e.CustomerBuyingPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("customer_buying_price");
            entity.Property(e => e.CustomerNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("customer_no");
            entity.Property(e => e.LastModified).HasColumnName("last_modified");
            entity.Property(e => e.OrderDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("order_date");
            entity.Property(e => e.OrderLine).HasColumnName("order_line");
            entity.Property(e => e.OrderNumberInternal)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("order_number_internal");
            entity.Property(e => e.OrderQty).HasColumnName("order_qty");
            entity.Property(e => e.OrderQtyBackorder).HasColumnName("order_qty_backorder");
            entity.Property(e => e.OrderText).HasColumnName("order_text");
            entity.Property(e => e.OwnerId).HasColumnName("owner_id");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.PriceSrp).HasColumnName("price_srp");
            entity.Property(e => e.PriceTypeId).HasColumnName("price_type_id");
            entity.Property(e => e.SalesItemNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("sales_item_no");
            entity.Property(e => e.TransmissionDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("transmission_date");
            entity.Property(e => e.WeekDelivery).HasColumnName("week_delivery");
            entity.Property(e => e.YearDelivery).HasColumnName("year_delivery");
        });

        modelBuilder.Entity<InCustomer>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("IN_CUSTOMER");

            entity.Property(e => e.CurrencyId)
                .HasMaxLength(50)
                .HasColumnName("CURRENCY_ID");
            entity.Property(e => e.CustomerAccountManager).HasColumnName("customer_account_manager");
            entity.Property(e => e.CustomerActive).HasColumnName("customer_active");
            entity.Property(e => e.CustomerAgent).HasColumnName("customer_agent");
            entity.Property(e => e.CustomerAssociationNo).HasColumnName("customer_association_no");
            entity.Property(e => e.CustomerBank).HasColumnName("customer_bank");
            entity.Property(e => e.CustomerBankAccountNo).HasColumnName("customer_bank_account_no");
            entity.Property(e => e.CustomerBankCollectionFlag).HasColumnName("customer_bank_collection_flag");
            entity.Property(e => e.CustomerBankIban).HasColumnName("customer_bank_iban");
            entity.Property(e => e.CustomerBankNo).HasColumnName("customer_bank_no");
            entity.Property(e => e.CustomerBranch).HasColumnName("customer_branch");
            entity.Property(e => e.CustomerCashDiscount).HasColumnName("customer_cash_discount");
            entity.Property(e => e.CustomerCode).HasColumnName("customer_code");
            entity.Property(e => e.CustomerCompanyGroup).HasColumnName("customer_company_group");
            entity.Property(e => e.CustomerCorporationNo).HasColumnName("customer_corporation_no");
            entity.Property(e => e.CustomerCreditCheckFlag).HasColumnName("customer_credit_check_flag");
            entity.Property(e => e.CustomerCreditLimit)
                .HasColumnType("decimal(38, 20)")
                .HasColumnName("customer_credit_limit");
            entity.Property(e => e.CustomerCreditPeriod).HasColumnName("customer_credit_period");
            entity.Property(e => e.CustomerCreditRating).HasColumnName("customer_credit_rating");
            entity.Property(e => e.CustomerCreditRatingId).HasColumnName("customer_credit_rating_id");
            entity.Property(e => e.CustomerDebtClaim).HasColumnName("customer_debt_claim");
            entity.Property(e => e.CustomerDefaultInterest).HasColumnName("customer_default_interest");
            entity.Property(e => e.CustomerEmail)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("customer_email");
            entity.Property(e => e.CustomerFax)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("customer_fax");
            entity.Property(e => e.CustomerFreeDeliveryMinQty).HasColumnName("customer_free_delivery_min_qty");
            entity.Property(e => e.CustomerGln)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("customer_GLN");
            entity.Property(e => e.CustomerHolding).HasColumnName("customer_holding");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.CustomerInternalCreditorId).HasColumnName("customer_internal_creditor_id");
            entity.Property(e => e.CustomerInternalDiscountId).HasColumnName("customer_internal_discount_id");
            entity.Property(e => e.CustomerName1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("customer_name1");
            entity.Property(e => e.CustomerName2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("customer_name2");
            entity.Property(e => e.CustomerNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("customer_no");
            entity.Property(e => e.CustomerPaymentCorrectionId).HasColumnName("customer_payment_correction_id");
            entity.Property(e => e.CustomerPhone)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("customer_phone");
            entity.Property(e => e.CustomerPricelistId).HasColumnName("customer_pricelist_id");
            entity.Property(e => e.CustomerReminder).HasColumnName("customer_reminder");
            entity.Property(e => e.CustomerReminderFrequency).HasColumnName("customer_reminder_frequency");
            entity.Property(e => e.CustomerVisitFrequency).HasColumnName("customer_visit_frequency");
            entity.Property(e => e.CustomerWeb)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("customer_web");
            entity.Property(e => e.OwnerId).HasColumnName("owner_id");
            entity.Property(e => e.SuitableBacklogsFlag).HasColumnName("suitable_backlogs_flag");
            entity.Property(e => e.TransmissionDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("transmission_date");
        });

        modelBuilder.Entity<InCustomeraddress>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("IN_CUSTOMERADDRESS");

            entity.Property(e => e.AdditionToAdress)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("addition_to_adress");
            entity.Property(e => e.CustomerAddressDefault).HasColumnName("customer_address_default");
            entity.Property(e => e.CustomerAdressId).HasColumnName("customer_adress_id");
            entity.Property(e => e.CustomerAdressTypeId).HasColumnName("customer_adress_type_id");
            entity.Property(e => e.CustomerCity)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("customer_city");
            entity.Property(e => e.CustomerCountry)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("customer_country");
            entity.Property(e => e.CustomerId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("customer_id");
            entity.Property(e => e.CustomerName1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("customer_name1");
            entity.Property(e => e.CustomerName2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("customer_name2");
            entity.Property(e => e.CustomerNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("customer_no");
            entity.Property(e => e.CustomerStreet)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("customer_street");
            entity.Property(e => e.CustomerZipcode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("customer_zipcode");
            entity.Property(e => e.Default).HasColumnName("DEFAULT");
            entity.Property(e => e.OwnerId).HasColumnName("owner_id");
            entity.Property(e => e.TransmissionDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("transmission_date");
        });

        modelBuilder.Entity<InCustomerspecificPrice>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("IN_CUSTOMERSPECIFIC_PRICES");

            entity.Property(e => e.BlockCurrencyId)
                .HasMaxLength(50)
                .HasColumnName("block_currency_id");
            entity.Property(e => e.BlockPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("block_price");
            entity.Property(e => e.CustomerCommodityGroup).HasColumnName("customer_commodity_group");
            entity.Property(e => e.CustomerCommodityGroupId).HasColumnName("customer_commodity_group_id");
            entity.Property(e => e.CustomerCurrency).HasColumnName("customer_currency");
            entity.Property(e => e.CustomerGtin).HasColumnName("customer_GTIN");
            entity.Property(e => e.CustomerNo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("customer_no");
            entity.Property(e => e.CustomerSalesPart).HasColumnName("customer_sales_part");
            entity.Property(e => e.CustomerSrp).HasColumnName("customer_srp");
            entity.Property(e => e.OwnerId).HasColumnName("owner_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.SalesItemNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("sales_item_no");
            entity.Property(e => e.TransmissionDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("transmission_date");
        });

        modelBuilder.Entity<InFee>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("IN_FEES");

            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Currency Code");
            entity.Property(e => e.FeeTypeId).HasColumnName("fee_type_id");
            entity.Property(e => e.FeeValue)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("fee_value");
            entity.Property(e => e.OwnerId).HasColumnName("owner_id");
            entity.Property(e => e.SalesItemNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("sales_item_no");
            entity.Property(e => e.TransmissionDate)
                .HasColumnType("datetime")
                .HasColumnName("transmission_date");
        });

        modelBuilder.Entity<InItem>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("IN_ITEM");

            entity.Property(e => e.CommodityDescription)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("commodity_description");
            entity.Property(e => e.CommodityId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("commodity_id");
            entity.Property(e => e.CommodityMainDescription)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("commodity_main_description");
            entity.Property(e => e.CommodityMainId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("commodity_main_id");
            entity.Property(e => e.Container20ftQty).HasColumnName("container_20ft_qty");
            entity.Property(e => e.Container40ftQty).HasColumnName("container_40ft_qty");
            entity.Property(e => e.CountryOfOrigin)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("country_of_origin");
            entity.Property(e => e.CurrencyLastPurchaseId).HasColumnName("currency_last_purchase_id");
            entity.Property(e => e.CustomerAvailabilityDate).HasColumnName("customer_availability_date");
            entity.Property(e => e.DeliveryTime).HasColumnName("delivery_time");
            entity.Property(e => e.EndAvailabilityDate).HasColumnName("end_availability_date");
            entity.Property(e => e.Gtin)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("GTIN");
            entity.Property(e => e.Icin)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ICIN");
            entity.Property(e => e.ImportClassificationNo).HasColumnName("import_classification_no");
            entity.Property(e => e.InnerPackGrossweight).HasColumnName("inner_pack_grossweight");
            entity.Property(e => e.InnerPackGtin).HasColumnName("inner_pack_gtin");
            entity.Property(e => e.InnerPackHeight).HasColumnName("inner_pack_height");
            entity.Property(e => e.InnerPackLenght).HasColumnName("inner_pack_lenght");
            entity.Property(e => e.InnerPackQty).HasColumnName("inner_pack_qty");
            entity.Property(e => e.InnerPackWidth).HasColumnName("inner_pack_width");
            entity.Property(e => e.IntrastatCode).HasColumnName("intrastat_code");
            entity.Property(e => e.ItemBonusFlag).HasColumnName("item_bonus_flag");
            entity.Property(e => e.ItemCreationDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("item_creation_date");
            entity.Property(e => e.ItemDescription).HasColumnName("item_description");
            entity.Property(e => e.ItemDescriptionDk)
                .HasMaxLength(101)
                .IsUnicode(false)
                .HasColumnName("item_description_dk");
            entity.Property(e => e.ItemDescriptionFi)
                .HasMaxLength(101)
                .IsUnicode(false)
                .HasColumnName("item_description_fi");
            entity.Property(e => e.ItemDescriptionNo)
                .HasMaxLength(101)
                .IsUnicode(false)
                .HasColumnName("item_description_no");
            entity.Property(e => e.ItemDescriptionSw)
                .HasMaxLength(101)
                .IsUnicode(false)
                .HasColumnName("item_description_sw");
            entity.Property(e => e.ItemGrossweight)
                .HasColumnType("decimal(9, 3)")
                .HasColumnName("Item_grossweight");
            entity.Property(e => e.ItemHeight)
                .HasColumnType("decimal(9, 3)")
                .HasColumnName("Item_height");
            entity.Property(e => e.ItemLength)
                .HasColumnType("decimal(9, 3)")
                .HasColumnName("item_length");
            entity.Property(e => e.ItemMoq).HasColumnName("item_moq");
            entity.Property(e => e.ItemName).HasColumnName("item_name");
            entity.Property(e => e.ItemPackBrand)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("item_pack_brand");
            entity.Property(e => e.ItemWidth)
                .HasColumnType("decimal(9, 3)")
                .HasColumnName("Item_width");
            entity.Property(e => e.McGrossweight)
                .HasColumnType("decimal(15, 3)")
                .HasColumnName("mc_grossweight");
            entity.Property(e => e.McGtin).HasColumnName("mc_gtin");
            entity.Property(e => e.McHeight)
                .HasColumnType("decimal(12, 3)")
                .HasColumnName("mc_height");
            entity.Property(e => e.McLength)
                .HasColumnType("decimal(12, 3)")
                .HasColumnName("mc_length");
            entity.Property(e => e.McQty).HasColumnName("mc_qty");
            entity.Property(e => e.McWidth)
                .HasColumnType("decimal(12, 3)")
                .HasColumnName("mc_width");
            entity.Property(e => e.OwnerId).HasColumnName("owner_id");
            entity.Property(e => e.PackagingPaperShare).HasColumnName("packaging_paper_share");
            entity.Property(e => e.PackagingPlasticShare).HasColumnName("packaging_plastic_share");
            entity.Property(e => e.PackagingStrechfoilShare).HasColumnName("packaging_strechfoil_share");
            entity.Property(e => e.PackagingUnit).HasColumnName("packaging_unit");
            entity.Property(e => e.PalletQty).HasColumnName("pallet_qty");
            entity.Property(e => e.PartStatusDescription)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("part_status_description");
            entity.Property(e => e.PartStatusId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("part_status_id");
            entity.Property(e => e.PriceCurrencyId).HasColumnName("price_currency_id");
            entity.Property(e => e.PriceLastPurchase).HasColumnName("price_last_purchase");
            entity.Property(e => e.PriceSrp).HasColumnName("price_srp");
            entity.Property(e => e.PriceTypeId).HasColumnName("price_type_id");
            entity.Property(e => e.PurchaseItemNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("purchase_item_no");
            entity.Property(e => e.RecycleableFlag).HasColumnName("recycleable_flag");
            entity.Property(e => e.RecycleablePackagingFlag).HasColumnName("recycleable_packaging_flag");
            entity.Property(e => e.ReplacementItemNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("replacement_item_no");
            entity.Property(e => e.ReplacementItemNo2).HasColumnName("replacement_item_no_2");
            entity.Property(e => e.RohsFlag).HasColumnName("rohs_flag");
            entity.Property(e => e.SalesItemNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("sales_item_no");
            entity.Property(e => e.StandardPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("standard_price");
            entity.Property(e => e.StartAvailabilityDate).HasColumnName("start_availability_date");
            entity.Property(e => e.SupplierDescriptionPrimary)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("supplier_description_primary");
            entity.Property(e => e.SupplierGln).HasColumnName("supplier_GLN");
            entity.Property(e => e.SupplierNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("supplier_no");
            entity.Property(e => e.TransmissionDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("transmission_date");
            entity.Property(e => e.TypeOfPackaging).HasColumnName("type_of_packaging");
            entity.Property(e => e.TypeOfPackagingId).HasColumnName("type_of_packaging_id");
            entity.Property(e => e.Warranty).HasColumnName("warranty");
            entity.Property(e => e.WebEndDate).HasColumnName("web_end_date");
            entity.Property(e => e.WebFlag).HasColumnName("web_flag");
            entity.Property(e => e.WebStartDate).HasColumnName("web_start_date");
        });

        modelBuilder.Entity<InPrice>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("IN_PRICES");

            entity.Property(e => e.InvoiceCurrencyId)
                .HasMaxLength(50)
                .HasColumnName("invoice_currency_ID");
            entity.Property(e => e.OwnerId).HasColumnName("owner_id");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.PriceEndDate)
                .HasColumnType("datetime")
                .HasColumnName("price_end_date");
            entity.Property(e => e.PriceStartDate)
                .HasColumnType("datetime")
                .HasColumnName("price_start_date");
            entity.Property(e => e.PriceTypeId).HasColumnName("price_type_id");
            entity.Property(e => e.SalesItemNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("sales_item_no");
            entity.Property(e => e.TransmissionDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("transmission_date");
        });

        modelBuilder.Entity<InSalesLineOrderhistory>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("IN_SALES_LINE_ORDERHISTORY");

            entity.Property(e => e.CommodityId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("commodity_id");
            entity.Property(e => e.CustomerBuyingPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("customer_buying_price");
            entity.Property(e => e.CustomerLevel3).HasColumnName("customer_level3");
            entity.Property(e => e.CustomerNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("customer_no");
            entity.Property(e => e.InvoiceCostOfSalesPcs).HasColumnName("invoice_cost_of_sales_pcs");
            entity.Property(e => e.InvoiceDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("invoice_date");
            entity.Property(e => e.InvoiceLine).HasColumnName("invoice_line");
            entity.Property(e => e.InvoiceNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("invoice_number");
            entity.Property(e => e.InvoiceTypeId).HasColumnName("invoice_type_id");
            entity.Property(e => e.OrderDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("order_date");
            entity.Property(e => e.OrderNumberInternal)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("order_number_internal");
            entity.Property(e => e.OrderQty).HasColumnName("order_qty");
            entity.Property(e => e.OrderQtyDelivered).HasColumnName("order_qty_delivered");
            entity.Property(e => e.OwnerId).HasColumnName("owner_id");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.PriceSrp).HasColumnName("price_srp");
            entity.Property(e => e.PriceTypeId).HasColumnName("price_type_id");
            entity.Property(e => e.SalesItemNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("sales_item_no");
            entity.Property(e => e.TransmissionDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("transmission_date");
        });

        modelBuilder.Entity<InSalesstatus>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("IN_SALESSTATUS");

            entity.Property(e => e.OwnerId).HasColumnName("owner_id");
            entity.Property(e => e.SalesItemNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("sales_item_no");
            entity.Property(e => e.SalesStatusDescription)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("sales_status_description");
            entity.Property(e => e.SalesStatusId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("sales_status_id");
            entity.Property(e => e.TransmissionDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("transmission_date");
        });

        modelBuilder.Entity<InStockdatum>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("IN_STOCKDATA");

            entity.Property(e => e.ConfirmedReceiptDate).HasColumnName("confirmed_receipt_date");
            entity.Property(e => e.EstimatedReceiptDate).HasColumnName("estimated_receipt_date");
            entity.Property(e => e.FirstEntryDate).HasColumnName("first_entry_date");
            entity.Property(e => e.FirstEntryQty).HasColumnName("first_entry_qty");
            entity.Property(e => e.Forecast3months).HasColumnName("forecast_3months");
            entity.Property(e => e.Forecast6months).HasColumnName("forecast_6months");
            entity.Property(e => e.ForecastTotal).HasColumnName("forecast_total");
            entity.Property(e => e.LastEntryDate).HasColumnName("last_entry_date");
            entity.Property(e => e.LastEntryQty).HasColumnName("last_entry_qty");
            entity.Property(e => e.OpenPurchaseOrderQty).HasColumnName("open_purchase_order_qty");
            entity.Property(e => e.OpenPurchaseOrders).HasColumnName("open_purchase_orders");
            entity.Property(e => e.OpenSalesOrderQty).HasColumnName("open_sales_order_qty");
            entity.Property(e => e.OpenSalesOrders).HasColumnName("open_sales_orders");
            entity.Property(e => e.OrderQtyBackorder).HasColumnName("order_qty_backorder");
            entity.Property(e => e.OwnerId).HasColumnName("owner_id");
            entity.Property(e => e.PriceStockCost).HasColumnName("price_stock_cost");
            entity.Property(e => e.PriceStockCostCurrencyId).HasColumnName("price_stock_cost_currency_id");
            entity.Property(e => e.ProductionFinishingDate).HasColumnName("production_finishing_date");
            entity.Property(e => e.ProductionQty).HasColumnName("production_qty");
            entity.Property(e => e.ReservationsTotal).HasColumnName("reservations_total");
            entity.Property(e => e.SalesItemNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("sales_item_no");
            entity.Property(e => e.StockAvailableQty).HasColumnName("stock_available_qty");
            entity.Property(e => e.StockLocation).HasColumnName("stock_location");
            entity.Property(e => e.StockQsQty).HasColumnName("stock_qs_qty");
            entity.Property(e => e.StockReserveStock).HasColumnName("stock_reserve_stock");
            entity.Property(e => e.StockWarehouse).HasColumnName("stock_warehouse");
            entity.Property(e => e.TransmissionDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("transmission_date");
        });

        modelBuilder.Entity<InVat>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("IN_VAT");

            entity.Property(e => e.OwnerId).HasColumnName("owner_id");
            entity.Property(e => e.SalesItemNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("sales_item_no");
            entity.Property(e => e.TransmissionDate)
                .HasColumnType("datetime")
                .HasColumnName("transmission_date");
            entity.Property(e => e.VatTypeId)
                .HasMaxLength(50)
                .HasColumnName("vat_type_id");
            entity.Property(e => e.VatValue)
                .HasColumnType("decimal(38, 20)")
                .HasColumnName("vat_value");
        });

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

        modelBuilder.Entity<ItemCategory>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("Item Category$0");

            entity.ToTable("Item Category");

            entity.Property(e => e.Code).HasMaxLength(20);
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.Timestamp)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("timestamp");
        });

        modelBuilder.Entity<ItemFeePrice>(entity =>
        {
            entity.HasKey(e => new { e.FeeType, e.FeeCode, e.FeeCustomerGroup, e.StartingDate, e.CurrencyCode }).HasName("Item Fee Price$0");

            entity.ToTable("Item Fee Price");

            entity.Property(e => e.FeeType).HasColumnName("Fee Type");
            entity.Property(e => e.FeeCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Fee Code");
            entity.Property(e => e.FeeCustomerGroup)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Fee Customer Group");
            entity.Property(e => e.StartingDate)
                .HasColumnType("datetime")
                .HasColumnName("Starting Date");
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(10)
                .IsUnicode(false)
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

        modelBuilder.Entity<ItemStockDatum>(entity =>
        {
            entity.HasKey(e => e.ItemNo).HasName("Item Stock Data$0");

            entity.ToTable("Item Stock Data");

            entity.Property(e => e.ItemNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Item No_");
            entity.Property(e => e.AvailableQantity)
                .HasColumnType("decimal(38, 20)")
                .HasColumnName("Available Qantity");
            entity.Property(e => e.QuantityOnInventory)
                .HasColumnType("decimal(38, 20)")
                .HasColumnName("Quantity on Inventory");
            entity.Property(e => e.QuantityOnPurchaseOrder)
                .HasColumnType("decimal(38, 20)")
                .HasColumnName("Quantity on Purchase Order");
            entity.Property(e => e.QuantityOnSalesOrder)
                .HasColumnType("decimal(38, 20)")
                .HasColumnName("Quantity on Sales Order");
            entity.Property(e => e.ReservedQuantity)
                .HasColumnType("decimal(38, 20)")
                .HasColumnName("Reserved Quantity");
            entity.Property(e => e.Timestamp)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("timestamp");
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

        modelBuilder.Entity<ItemUnitOfMeasure>(entity =>
        {
            entity.HasKey(e => new { e.ItemNo, e.Code }).HasName("Item Unit of Measure$0");

            entity.ToTable("Item Unit of Measure");

            entity.Property(e => e.ItemNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Item No_");
            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .IsUnicode(false);
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

        modelBuilder.Entity<LitiumProductsDescription>(entity =>
        {
            entity.HasKey(e => e.VariantId);

            entity.ToTable("LitiumProductsDescription");

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

        modelBuilder.Entity<OutBackorder>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("OUT_BACKORDERS");

            entity.Property(e => e.BackorderQuantity)
                .HasColumnType("decimal(38, 20)")
                .HasColumnName("backorder_quantity");
            entity.Property(e => e.CustomerNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("customer_no");
            entity.Property(e => e.LastModified)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("last_modified");
            entity.Property(e => e.NetListprice)
                .HasColumnType("decimal(38, 20)")
                .HasColumnName("net_listprice");
            entity.Property(e => e.OrderDaet2)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("order_daet_2");
            entity.Property(e => e.OrderDate)
                .HasColumnType("datetime")
                .HasColumnName("order_date");
            entity.Property(e => e.OrderNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("order_no");
            entity.Property(e => e.OrderText)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("order_text");
            entity.Property(e => e.OrderedQuantity)
                .HasColumnType("decimal(38, 20)")
                .HasColumnName("ordered_quantity");
            entity.Property(e => e.PositionNo).HasColumnName("position_no");
            entity.Property(e => e.PurchasePrice)
                .HasColumnType("decimal(38, 20)")
                .HasColumnName("purchase_price");
            entity.Property(e => e.SalesItemNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("sales_item_no");
            entity.Property(e => e.SuggestedRetailPrice)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("suggested_retail_price");
            entity.Property(e => e.WeekDelivery)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("week_delivery");
            entity.Property(e => e.YearDelivery)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("year_delivery");
        });

        modelBuilder.Entity<OutCustomer>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("OUT_CUSTOMER");

            entity.Property(e => e.Active)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("ACTIVE");
            entity.Property(e => e.ClientId)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CLIENT_ID");
            entity.Property(e => e.Code)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CODE");
            entity.Property(e => e.CreditcheckId)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CREDITCHECK_ID");
            entity.Property(e => e.Creditlimit)
                .HasColumnType("decimal(38, 20)")
                .HasColumnName("CREDITLIMIT");
            entity.Property(e => e.CreditratingId)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CREDITRATING_ID");
            entity.Property(e => e.Customernumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CUSTOMERNUMBER");
            entity.Property(e => e.Email)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Fax)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("FAX");
            entity.Property(e => e.Gln)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("GLN");
            entity.Property(e => e.Importstatus).HasColumnName("IMPORTSTATUS");
            entity.Property(e => e.InsertDate)
                .HasColumnType("datetime")
                .HasColumnName("INSERT_DATE");
            entity.Property(e => e.Name1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAME1");
            entity.Property(e => e.Name2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAME2");
            entity.Property(e => e.Phone)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("PHONE");
            entity.Property(e => e.Web)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("WEB");
        });

        modelBuilder.Entity<OutCustomeradress>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("OUT_CUSTOMERADRESS");

            entity.Property(e => e.AddressId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ADDRESS_ID");
            entity.Property(e => e.AddresstypeId).HasColumnName("ADDRESSTYPE_ID");
            entity.Property(e => e.City)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("CITY");
            entity.Property(e => e.ClientId)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CLIENT_ID");
            entity.Property(e => e.Country)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("COUNTRY");
            entity.Property(e => e.Customernumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CUSTOMERNUMBER");
            entity.Property(e => e.Default).HasColumnName("DEFAULT");
            entity.Property(e => e.Importstatus).HasColumnName("IMPORTSTATUS");
            entity.Property(e => e.InsertDate)
                .HasColumnType("datetime")
                .HasColumnName("INSERT_DATE");
            entity.Property(e => e.Street)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("STREET");
            entity.Property(e => e.Zipcode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZIPCODE");
        });

        modelBuilder.Entity<OutCustomerspecificPrice>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("OUT_CUSTOMERSPECIFIC_PRICES");

            entity.Property(e => e.Amount).HasColumnType("decimal(38, 20)");
            entity.Property(e => e.CustomerNo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("customer_no");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(38, 20)")
                .HasColumnName("price");
            entity.Property(e => e.SalesItemNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("sales_item_no");
        });

        modelBuilder.Entity<OutItemPricesListing>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("OUT_ITEM_PRICES_LISTING");

            entity.Property(e => e.Brand)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("brand");
            entity.Property(e => e.BuyingNoSource)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Buying no. source");
            entity.Property(e => e.CountryOfOrigin)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("country_of_origin");
            entity.Property(e => e.EanGtin)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("EAN/GTIN");
            entity.Property(e => e.Grossweight)
                .HasColumnType("decimal(38, 20)")
                .HasColumnName("grossweight");
            entity.Property(e => e.Height)
                .HasColumnType("decimal(38, 20)")
                .HasColumnName("height");
            entity.Property(e => e.Icin)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ICIN");
            entity.Property(e => e.ItemDescription)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("item description");
            entity.Property(e => e.ItemGroup)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("item_group");
            entity.Property(e => e.ItemGroupId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("item_group_id");
            entity.Property(e => e.Length)
                .HasColumnType("decimal(38, 20)")
                .HasColumnName("length_");
            entity.Property(e => e.LockedForWeb)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Locked_for_web");
            entity.Property(e => e.MainItemGroup)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("main_item_group");
            entity.Property(e => e.MainItemGroupId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("main_item_group_id");
            entity.Property(e => e.McHeight)
                .HasColumnType("decimal(38, 20)")
                .HasColumnName("mc_height");
            entity.Property(e => e.McLength)
                .HasColumnType("decimal(38, 20)")
                .HasColumnName("mc_length");
            entity.Property(e => e.McQuantity)
                .HasColumnType("decimal(38, 20)")
                .HasColumnName("mc_quantity");
            entity.Property(e => e.McWeight)
                .HasColumnType("decimal(38, 20)")
                .HasColumnName("mc_weight");
            entity.Property(e => e.McWidth)
                .HasColumnType("decimal(38, 20)")
                .HasColumnName("mc_width");
            entity.Property(e => e.MinOrderQty)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("min_order_qty");
            entity.Property(e => e.PalletQuantity)
                .HasColumnType("decimal(38, 20)")
                .HasColumnName("pallet_quantity");
            entity.Property(e => e.ReplacementItemNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("replacement_item_no");
            entity.Property(e => e.SalesItemNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("sales_item_no");
            entity.Property(e => e.StatusDesc)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("status_desc");
            entity.Property(e => e.StatusId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("status_id");
            entity.Property(e => e.Supplier)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("supplier");
            entity.Property(e => e.SupplierId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("supplier_id");
            entity.Property(e => e.Width)
                .HasColumnType("decimal(38, 20)")
                .HasColumnName("width");
        });

        modelBuilder.Entity<OutPrice>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("OUT_PRICES");

            entity.Property(e => e.InvCurrency)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("inv_currency");
            entity.Property(e => e.Price).HasColumnType("decimal(38, 20)");
            entity.Property(e => e.Pricetype)
                .HasMaxLength(13)
                .IsUnicode(false);
            entity.Property(e => e.Quantity).HasColumnType("decimal(38, 20)");
            entity.Property(e => e.SalesItemNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Sales Item No.");
        });

        modelBuilder.Entity<OutSalesLineOrderhistory>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("OUT_SALES_LINE_ORDERHISTORY");

            entity.Property(e => e.AssociationId)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Association_id");
            entity.Property(e => e.CostOfSales)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("cost_of_sales");
            entity.Property(e => e.CustomerBuyingPrice)
                .HasColumnType("decimal(38, 20)")
                .HasColumnName("customer_buying_price");
            entity.Property(e => e.CustomerNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("customer_no");
            entity.Property(e => e.DeliveryQuantity)
                .HasColumnType("decimal(38, 20)")
                .HasColumnName("delivery_quantity");
            entity.Property(e => e.InvoiceDate)
                .HasColumnType("datetime")
                .HasColumnName("invoice_date");
            entity.Property(e => e.InvoiceId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("invoice_id");
            entity.Property(e => e.InvoiceLine).HasColumnName("invoice_line");
            entity.Property(e => e.InvoiceType)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("Invoice_Type");
            entity.Property(e => e.ItemGroupId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("item_group_id");
            entity.Property(e => e.OrderDate)
                .HasColumnType("datetime")
                .HasColumnName("order_date");
            entity.Property(e => e.OrderId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("order_id");
            entity.Property(e => e.OrderQuantity)
                .HasColumnType("decimal(38, 20)")
                .HasColumnName("order_quantity");
            entity.Property(e => e.SalesItemNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("sales_item_no");
            entity.Property(e => e.StandardBuyingPrice)
                .HasColumnType("decimal(38, 20)")
                .HasColumnName("standard_buying_price");
            entity.Property(e => e.SuggestedRetailPrice)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("suggested_retail_price");
        });

        modelBuilder.Entity<OutSalesstatus>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("OUT_SALESSTATUS");

            entity.Property(e => e.SalesItemNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Sales Item No.");
            entity.Property(e => e.SalesStatus)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Sales Status");
            entity.Property(e => e.SalesStatusId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Sales Status ID");
        });

        modelBuilder.Entity<OutStockdatum>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("OUT_STOCKDATA");

            entity.Property(e => e.Backlogs).HasColumnName("BACKLOGS");
            entity.Property(e => e.FirstEntryDate).HasColumnName("FIRST_ENTRY_DATE");
            entity.Property(e => e.FirstEntryQty).HasColumnName("FIRST_ENTRY_QTY");
            entity.Property(e => e.Forecast3months).HasColumnName("FORECAST_3months");
            entity.Property(e => e.Forecast6months).HasColumnName("FORECAST_6months");
            entity.Property(e => e.ForecastTotal).HasColumnName("FORECAST_TOTAL");
            entity.Property(e => e.LastEntryDate).HasColumnName("LAST_ENTRY_DATE");
            entity.Property(e => e.LastEntryQty).HasColumnName("LAST_ENTRY_QTY");
            entity.Property(e => e.OpenPurchaseOrderNo).HasColumnName("OPEN_PURCHASE_ORDER_NO");
            entity.Property(e => e.OpenPurchaseOrderQty)
                .HasColumnType("decimal(38, 20)")
                .HasColumnName("OPEN_PURCHASE_ORDER_QTY");
            entity.Property(e => e.OpenSalesOrderAmount).HasColumnName("OPEN_SALES_ORDER_AMOUNT");
            entity.Property(e => e.OpenSalesOrderQty)
                .HasColumnType("decimal(38, 20)")
                .HasColumnName("OPEN_SALES_ORDER_QTY");
            entity.Property(e => e.Reservations).HasColumnName("RESERVATIONS");
            entity.Property(e => e.SalesItemNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("sales_item_no");
            entity.Property(e => e.StockAvailable)
                .HasColumnType("decimal(38, 20)")
                .HasColumnName("STOCK_AVAILABLE");
            entity.Property(e => e.StockOther).HasColumnName("STOCK_OTHER");
            entity.Property(e => e.StockPricePcs).HasColumnName("STOCK_PRICE_PCS");
            entity.Property(e => e.StockPricePcsCurr).HasColumnName("STOCK_PRICE_PCS_CURR");
        });

        modelBuilder.Entity<ProductGroup>(entity =>
        {
            entity.HasKey(e => new { e.ItemCategoryCode, e.Code }).HasName("Product Group$0");

            entity.ToTable("Product Group");

            entity.Property(e => e.ItemCategoryCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Item Category Code");
            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Timestamp)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("timestamp");
            entity.Property(e => e.WarehouseClassCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Warehouse Class Code");
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

        modelBuilder.Entity<SalesHeader>(entity =>
        {
            entity.HasKey(e => new { e.DocumentType, e.No })
                .HasName("Sales Header$0")
                .IsClustered(false);

            entity.ToTable("Sales Header");

            entity.Property(e => e.DocumentType).HasColumnName("Document Type");
            entity.Property(e => e.No)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("No_");
            entity.Property(e => e.OrderDate)
                .HasColumnType("datetime")
                .HasColumnName("Order Date");
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

        modelBuilder.Entity<SalesInvoiceLine>(entity =>
        {
            entity.HasKey(e => new { e.DocumentNo, e.LineNo }).HasName("Sales Invoice Line$0");

            entity.ToTable("Sales Invoice Line");

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
            entity.Property(e => e.UnitPrice)
                .HasColumnType("decimal(38, 20)")
                .HasColumnName("Unit Price");
            entity.Property(e => e.YourOrderNo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Your Order No_");
        });

        modelBuilder.Entity<SalesLine>(entity =>
        {
            entity.HasKey(e => new { e.DocumentType, e.DocumentNo, e.LineNo })
                .HasName("Sales Line$0")
                .IsClustered(false);

            entity.ToTable("Sales Line");

            entity.Property(e => e.DocumentType).HasColumnName("Document Type");
            entity.Property(e => e.DocumentNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Document No_");
            entity.Property(e => e.LineNo).HasColumnName("Line No_");
            entity.Property(e => e.No)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("No_");
            entity.Property(e => e.OutstandingQuantity)
                .HasColumnType("decimal(38, 20)")
                .HasColumnName("Outstanding Quantity");
            entity.Property(e => e.Quantity).HasColumnType("decimal(38, 20)");
            entity.Property(e => e.SellToCustomerNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Sell-to Customer No_");
            entity.Property(e => e.UnitPrice)
                .HasColumnType("decimal(38, 20)")
                .HasColumnName("Unit Price");
        });

        modelBuilder.Entity<SalesLineDiscount>(entity =>
        {
            entity.HasKey(e => new { e.Type, e.Code, e.SalesType, e.SalesCode, e.StartingDate, e.CurrencyCode, e.MinimumQuantity }).HasName("Sales Line Discount$0");

            entity.ToTable("Sales Line Discount");

            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SalesType).HasColumnName("Sales Type");
            entity.Property(e => e.SalesCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Sales Code");
            entity.Property(e => e.StartingDate)
                .HasColumnType("datetime")
                .HasColumnName("Starting Date");
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Currency Code");
            entity.Property(e => e.MinimumQuantity)
                .HasColumnType("decimal(38, 20)")
                .HasColumnName("Minimum Quantity");
            entity.Property(e => e.EndingDate)
                .HasColumnType("datetime")
                .HasColumnName("Ending Date");
            entity.Property(e => e.LineDiscount)
                .HasColumnType("decimal(38, 20)")
                .HasColumnName("Line Discount %");
            entity.Property(e => e.Timestamp)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("timestamp");
        });

        modelBuilder.Entity<SalesPrice>(entity =>
        {
            entity.HasKey(e => new { e.ItemNo, e.SalesType, e.SalesCode, e.StartingDate, e.CurrencyCode, e.UnitOfMeasureCode, e.MinimumQuantity });

            entity.ToTable("Sales Price");

            entity.Property(e => e.ItemNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Item No_");
            entity.Property(e => e.SalesType).HasColumnName("Sales Type");
            entity.Property(e => e.SalesCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Sales Code");
            entity.Property(e => e.StartingDate)
                .HasColumnType("datetime")
                .HasColumnName("Starting Date");
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Currency Code");
            entity.Property(e => e.UnitOfMeasureCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Unit of Measure Code");
            entity.Property(e => e.MinimumQuantity)
                .HasColumnType("decimal(38, 20)")
                .HasColumnName("Minimum Quantity");
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
        });

        modelBuilder.Entity<ShipToAddress>(entity =>
        {
            entity.HasKey(e => new { e.CustomerNo, e.Code }).HasName("Ship-to Address$0");

            entity.ToTable("Ship-to Address");

            entity.Property(e => e.CustomerNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Customer No_");
            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Address2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Address 2");
            entity.Property(e => e.City)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Contact)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CountryRegionCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Country_Region Code");
            entity.Property(e => e.County)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.EMail)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("E-Mail");
            entity.Property(e => e.FaxNo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Fax No_");
            entity.Property(e => e.HomePage)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("Home Page");
            entity.Property(e => e.LastDateModified)
                .HasColumnType("datetime")
                .HasColumnName("Last Date Modified");
            entity.Property(e => e.LocationCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Location Code");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Name 2");
            entity.Property(e => e.PhoneNo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Phone No_");
            entity.Property(e => e.PostCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Post Code");
            entity.Property(e => e.TelexNo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Telex No_");
            entity.Property(e => e.Timestamp)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("timestamp");
        });

        modelBuilder.Entity<Specialkunder>(entity =>
        {
            entity.ToTable("Specialkunder");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CustomerNo).HasColumnName("customer_no");
            entity.Property(e => e.Info).HasColumnName("info");
            entity.Property(e => e.SsmaTimeStamp)
                .HasMaxLength(255)
                .HasColumnName("SSMA_TimeStamp");
        });

        modelBuilder.Entity<Specialkunder1>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Specialkunder$");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Info).HasColumnName("info");
            entity.Property(e => e.SsmaTimeStamp)
                .HasMaxLength(255)
                .HasColumnName("SSMA_TimeStamp");
        });

        modelBuilder.Entity<TestHamaItemDescription>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TEST_HAMA_Item_Description");

            entity.Property(e => e.ItemDescriptionDk)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasColumnName("item_description_dk");
            entity.Property(e => e.ItemDescriptionEn)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasColumnName("item_description_en");
            entity.Property(e => e.ItemDescriptionFi)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasColumnName("item_description_fi");
            entity.Property(e => e.ItemDescriptionNo)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasColumnName("item_description_no");
            entity.Property(e => e.ItemDescriptionSw)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasColumnName("item_description_sw");
            entity.Property(e => e.SalesItemNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("sales_item_no");
        });

        modelBuilder.Entity<TmpCustomerPrice>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Tmp_Customer Prices");

            entity.Property(e => e.AllowLineDisc).HasColumnName("Allow Line Disc_");
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Currency Code");
            entity.Property(e => e.CustomerNo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Customer No_");
            entity.Property(e => e.CustomerPrice)
                .HasColumnType("decimal(38, 20)")
                .HasColumnName("Customer Price");
            entity.Property(e => e.Discount)
                .HasColumnType("decimal(38, 20)")
                .HasColumnName("Discount %");
            entity.Property(e => e.EndingDate)
                .HasColumnType("datetime")
                .HasColumnName("Ending Date");
            entity.Property(e => e.ItemFee)
                .HasColumnType("decimal(38, 20)")
                .HasColumnName("Item Fee");
            entity.Property(e => e.ItemNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Item No_");
            entity.Property(e => e.MinimumQuantity)
                .HasColumnType("decimal(38, 20)")
                .HasColumnName("Minimum Quantity");
            entity.Property(e => e.NotDivisibleUnit).HasColumnName("Not Divisible Unit");
            entity.Property(e => e.RecPrice)
                .HasColumnType("decimal(38, 20)")
                .HasColumnName("Rec Price");
            entity.Property(e => e.SalesCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Sales Code");
            entity.Property(e => e.StartingDate)
                .HasColumnType("datetime")
                .HasColumnName("Starting Date");
            entity.Property(e => e.Timestamp)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("timestamp");
            entity.Property(e => e.UnitPrice)
                .HasColumnType("decimal(38, 20)")
                .HasColumnName("Unit Price");
        });

        modelBuilder.Entity<TuraProductDescription>(entity =>
        {
            entity.HasKey(e => e.ItemNumber);

            entity.ToTable("Tura_product_descriptions");

            entity.Property(e => e.ItemNumber).HasMaxLength(10);
            entity.Property(e => e.Ean)
                .HasMaxLength(20)
                .HasColumnName("EAN");
            entity.Property(e => e.ManufacturerCode).HasMaxLength(20);
            entity.Property(e => e.Name).HasMaxLength(500);
        });

        modelBuilder.Entity<VatPostingSetup>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("VAT Posting Setup");

            entity.Property(e => e.Timestamp)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("timestamp");
            entity.Property(e => e.Vat)
                .HasColumnType("decimal(38, 20)")
                .HasColumnName("VAT %");
            entity.Property(e => e.VatBusPostingGroup)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("VAT Bus_ Posting Group");
            entity.Property(e => e.VatCalculationType).HasColumnName("VAT Calculation Type");
            entity.Property(e => e.VatProdPostingGroup)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("VAT Prod_ Posting Group");
        });

        modelBuilder.Entity<WipProductCategory>(entity =>
        {
            entity.HasKey(e => e.EnovaId);

            entity.ToTable("WipProductCategory");

            entity.Property(e => e.EnovaId)
                .ValueGeneratedNever()
                .HasColumnName("EnovaID");
            entity.Property(e => e.ExternalIdentifier)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Identifier)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Modified).HasColumnType("datetime");
            entity.Property(e => e.NameDk)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("NameDK");
            entity.Property(e => e.NameEn)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("NameEN");
            entity.Property(e => e.NameFi)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("NameFI");
            entity.Property(e => e.NameNo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("NameNO");
            entity.Property(e => e.NameSv)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("NameSV");
            entity.Property(e => e.Ts)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("TS");
            entity.Property(e => e.Tsnumber).HasColumnName("TSNumber");
        });

        modelBuilder.Entity<WipProductCategoryLink>(entity =>
        {
            entity.HasKey(e => new { e.ParentEnovaId, e.ChildEnovaId });

            entity.ToTable("WipProductCategoryLink");

            entity.Property(e => e.ParentEnovaId).HasColumnName("ParentEnovaID");
            entity.Property(e => e.ChildEnovaId).HasColumnName("ChildEnovaID");
            entity.Property(e => e.Ts)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("TS");
            entity.Property(e => e.Tsnumber).HasColumnName("TSNumber");
        });

        modelBuilder.Entity<WipWebOrder>(entity =>
        {
            entity.HasKey(e => e.OrderNumber).HasName("PK_WebOrder");

            entity.ToTable("WipWebOrder");

            entity.Property(e => e.OrderNumber)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.AddressCode)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CoAddress)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CurrencyIsocode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CurrencyISOCode");
            entity.Property(e => e.CustomerNumber)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Email).HasMaxLength(320);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name2)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.OrderReference)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.OrderedAt).HasColumnType("datetime");
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PostalCode)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PreferredDeliveryDate).HasColumnType("datetime");
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.Ts)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("TS");
            entity.Property(e => e.Tsnumber).HasColumnName("TSNumber");
        });

        modelBuilder.Entity<WipWebOrderRow>(entity =>
        {
            entity.HasKey(e => e.RowId).HasName("PK_WebOrderRow");

            entity.ToTable("WipWebOrderRow");

            entity.Property(e => e.RowId)
                .ValueGeneratedNever()
                .HasColumnName("RowID");
            entity.Property(e => e.CurrencyIsocode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CurrencyISOCode");
            entity.Property(e => e.OrderNumber)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PiecePrice).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.ProductNumber)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.RowPrice).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.Ts)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("TS");
            entity.Property(e => e.Tsnumber).HasColumnName("TSNumber");

            entity.HasOne(d => d.OrderNumberNavigation).WithMany(p => p.WipWebOrderRows)
                .HasForeignKey(d => d.OrderNumber)
                .HasConstraintName("FK_WebOrderRow_WebOrder");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
