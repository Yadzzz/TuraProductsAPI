using System;
using System.Collections.Generic;
using IntranetDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace IntranetDataAccessLibrary.Context;

public partial class ItturaContext : DbContext
{
    public ItturaContext()
    {
    }

    public ItturaContext(DbContextOptions<ItturaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<Categorytemp> Categorytemps { get; set; }

    public virtual DbSet<ChangeLog> ChangeLogs { get; set; }

    public virtual DbSet<Claim> Claims { get; set; }

    public virtual DbSet<Dmz> Dmzs { get; set; }

    public virtual DbSet<Dn> Dns { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmplyeeBroadband> EmplyeeBroadbands { get; set; }

    public virtual DbSet<HardWare> HardWares { get; set; }

    public virtual DbSet<HardWareComputer> HardWareComputers { get; set; }

    public virtual DbSet<InfoMessage> InfoMessages { get; set; }

    public virtual DbSet<Ipnassjo> Ipnassjos { get; set; }

    public virtual DbSet<KossHeadphoneModel> KossHeadphoneModels { get; set; }

    public virtual DbSet<KossRma> KossRmas { get; set; }

    public virtual DbSet<KossRmaMessage> KossRmaMessages { get; set; }

    public virtual DbSet<Lan> Lans { get; set; }

    public virtual DbSet<MigrationHistory> MigrationHistories { get; set; }

    public virtual DbSet<Network> Networks { get; set; }

    public virtual DbSet<NetworkIp> NetworkIps { get; set; }

    public virtual DbSet<NetworkLocation> NetworkLocations { get; set; }

    public virtual DbSet<NetworkSwitch> NetworkSwitches { get; set; }

    public virtual DbSet<NfsNet> NfsNets { get; set; }

    public virtual DbSet<Passwd> Passwds { get; set; }

    public virtual DbSet<RmaInformation> RmaInformations { get; set; }

    public virtual DbSet<San> Sans { get; set; }

    public virtual DbSet<SanNet> SanNets { get; set; }

    public virtual DbSet<Shipment> Shipments { get; set; }

    public virtual DbSet<ShipmentDeviation> ShipmentDeviations { get; set; }

    public virtual DbSet<ShipmentEmployee> ShipmentEmployees { get; set; }

    public virtual DbSet<ShipmentReceivingCompany> ShipmentReceivingCompanies { get; set; }

    public virtual DbSet<ShipmentStatus> ShipmentStatuses { get; set; }

    public virtual DbSet<ShipmentUpdate> ShipmentUpdates { get; set; }

    public virtual DbSet<SoftwareLicense> SoftwareLicenses { get; set; }

    public virtual DbSet<SpecialCustomer> SpecialCustomers { get; set; }

    public virtual DbSet<SwitchPort> SwitchPorts { get; set; }

    public virtual DbSet<Telium> Telia { get; set; }

    public virtual DbSet<VmotionNet> VmotionNets { get; set; }

    public virtual DbSet<Wan> Wans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=YAD;Initial Catalog=ITTura;Integrated Security=SSPI;Trusted_Connection=Yes;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Finnish_Swedish_CI_AS");

        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.AspNetRoles");

            entity.Property(e => e.Id).HasMaxLength(128);
            entity.Property(e => e.Name).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.AspNetUsers");

            entity.Property(e => e.Id).HasMaxLength(128);
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany()
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId").HasName("PK_dbo.AspNetUserRoles");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.AspNetUserClaims");

            entity.Property(e => e.UserId).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId");
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId }).HasName("PK_dbo.AspNetUserLogins");

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.ProviderKey).HasMaxLength(128);
            entity.Property(e => e.UserId).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId");
        });

        modelBuilder.Entity<Categorytemp>(entity =>
        {
            entity.HasKey(e => e.Enovaid);

            entity.ToTable("categorytemp");

            entity.Property(e => e.Enovaid)
                .ValueGeneratedNever()
                .HasColumnName("enovaid");
            entity.Property(e => e.NameDa)
                .HasMaxLength(300)
                .HasColumnName("name_da");
            entity.Property(e => e.NameEn)
                .HasMaxLength(300)
                .HasColumnName("name_en");
            entity.Property(e => e.NameFi)
                .HasMaxLength(300)
                .HasColumnName("name_fi");
            entity.Property(e => e.NameNo)
                .HasMaxLength(300)
                .HasColumnName("name_no");
            entity.Property(e => e.NameSv)
                .HasMaxLength(300)
                .HasColumnName("name_sv");
            entity.Property(e => e.Turaid).HasColumnName("turaid");
            entity.Property(e => e.UrlDa)
                .HasMaxLength(300)
                .HasColumnName("url_da");
            entity.Property(e => e.UrlEn)
                .HasMaxLength(300)
                .HasColumnName("url_en");
            entity.Property(e => e.UrlFi)
                .HasMaxLength(300)
                .HasColumnName("url_fi");
            entity.Property(e => e.UrlNo)
                .HasMaxLength(300)
                .HasColumnName("url_no");
            entity.Property(e => e.UrlSv)
                .HasMaxLength(300)
                .HasColumnName("url_sv");
        });

        modelBuilder.Entity<ChangeLog>(entity =>
        {
            entity.ToTable("ChangeLog");

            entity.Property(e => e.Employee).HasMaxLength(100);
            entity.Property(e => e.LoggedAt).HasColumnType("datetime");
            entity.Property(e => e.LoggedInUser).HasMaxLength(100);
            entity.Property(e => e.Message).HasMaxLength(500);
            entity.Property(e => e.Type).HasMaxLength(200);
        });

        modelBuilder.Entity<Claim>(entity =>
        {
            entity.ToTable("Claim");

            entity.Property(e => e.AmountIn).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.AmountOut).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.CreditFromSupplierReference).HasMaxLength(200);
            entity.Property(e => e.CreditToCustomerReference).HasMaxLength(200);
            entity.Property(e => e.Customer).HasMaxLength(200);
            entity.Property(e => e.CustomerContactPerson).HasMaxLength(200);
            entity.Property(e => e.CustomerNumber).HasMaxLength(50);
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.InvoiceFromCustomerReference).HasMaxLength(200);
            entity.Property(e => e.InvoiceToSupplierReference).HasMaxLength(200);
            entity.Property(e => e.Supplier).HasMaxLength(200);
            entity.Property(e => e.TuraContactPerson).HasMaxLength(200);
        });

        modelBuilder.Entity<Dmz>(entity =>
        {
            entity.HasKey(e => e.Ipaddress).HasName("PK_DMZ$");

            entity.ToTable("DMZ");

            entity.Property(e => e.Ipaddress)
                .HasMaxLength(20)
                .HasColumnName("IPAddress");
            entity.Property(e => e.Service)
                .HasMaxLength(255)
                .HasColumnName("SERVICE");
            entity.Property(e => e.SubnetMask)
                .HasMaxLength(20)
                .HasColumnName("SUBNET_MASK");
        });

        modelBuilder.Entity<Dn>(entity =>
        {
            entity.ToTable("DNS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Host)
                .HasMaxLength(255)
                .HasColumnName("HOST");
            entity.Property(e => e.TdcDestination)
                .HasMaxLength(255)
                .HasColumnName("TDC DESTINATION");
            entity.Property(e => e.TeliaDestination)
                .HasMaxLength(255)
                .HasColumnName("TELIA DESTINATION");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasColumnName("TYPE");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Antal).HasName("PK_Personallista");

            entity.ToTable("Employee");

            entity.Property(e => e.AnstForm).HasMaxLength(100);
            entity.Property(e => e.Anställd).HasColumnType("datetime");
            entity.Property(e => e.Arbetsställe).HasMaxLength(50);
            entity.Property(e => e.Arbetsuppgift).HasMaxLength(100);
            entity.Property(e => e.Attest).HasMaxLength(100);
            entity.Property(e => e.Avtal).HasMaxLength(100);
            entity.Property(e => e.Efternamn).HasMaxLength(100);
            entity.Property(e => e.Förnamn).HasMaxLength(100);
            entity.Property(e => e.Kön).HasMaxLength(10);
            entity.Property(e => e.Land).HasMaxLength(100);
        });

        modelBuilder.Entity<EmplyeeBroadband>(entity =>
        {
            entity.HasKey(e => e.Antal);

            entity.ToTable("EmplyeeBroadband");

            entity.Property(e => e.Antal).ValueGeneratedNever();
            entity.Property(e => e.HardwareSn)
                .HasMaxLength(50)
                .HasColumnName("HardwareSN");
            entity.Property(e => e.HardwareType).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            entity.Property(e => e.Pin)
                .HasMaxLength(10)
                .HasColumnName("PIN");
            entity.Property(e => e.Puk)
                .HasMaxLength(50)
                .HasColumnName("PUK");
            entity.Property(e => e.SubscriptionType).HasMaxLength(50);
            entity.Property(e => e.Supplier)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.AntalNavigation).WithOne(p => p.EmplyeeBroadband)
                .HasForeignKey<EmplyeeBroadband>(d => d.Antal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmplyeeBroadband_Employee");
        });

        modelBuilder.Entity<HardWare>(entity =>
        {
            entity.ToTable("HardWare");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(20);
            entity.Property(e => e.Type).HasMaxLength(50);
        });

        modelBuilder.Entity<HardWareComputer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_datorer");

            entity.ToTable("HardWareComputer");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ComputerModel).HasMaxLength(100);
            entity.Property(e => e.ComputerName).HasMaxLength(50);
            entity.Property(e => e.ComputerType).HasMaxLength(50);
            entity.Property(e => e.Delivered).HasColumnType("datetime");
            entity.Property(e => e.Misc).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Profile).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        modelBuilder.Entity<InfoMessage>(entity =>
        {
            entity.ToTable("InfoMessage");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.BackgroundColor)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.FontColor)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Header).HasMaxLength(200);
            entity.Property(e => e.Message)
                .HasMaxLength(500)
                .IsFixedLength();
            entity.Property(e => e.Updated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Ipnassjo>(entity =>
        {
            entity.HasKey(e => e.Ipaddress).HasName("PK_IP_Nassjo");

            entity.ToTable("IPNassjo");

            entity.HasIndex(e => e.Ipaddress, "IP").IsUnique();

            entity.Property(e => e.Ipaddress)
                .HasMaxLength(15)
                .HasColumnName("IPAddress");
            entity.Property(e => e.Info)
                .HasMaxLength(255)
                .HasColumnName("INFO");
            entity.Property(e => e.Service)
                .HasMaxLength(255)
                .HasColumnName("SERVICE");
        });

        modelBuilder.Entity<KossHeadphoneModel>(entity =>
        {
            entity.ToTable("KossHeadphoneModel");

            entity.Property(e => e.Name).HasMaxLength(150);
        });

        modelBuilder.Entity<KossRma>(entity =>
        {
            entity.ToTable("KossRma");

            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.CoAddress).HasMaxLength(100);
            entity.Property(e => e.Country).HasMaxLength(4);
            entity.Property(e => e.CustomReply).HasMaxLength(1000);
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(128);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(25);
            entity.Property(e => e.ProblemDescription).HasMaxLength(500);
            entity.Property(e => e.Receipt).HasMaxLength(50);
            entity.Property(e => e.ReplyDate).HasColumnType("datetime");
            entity.Property(e => e.StreetAddress).HasMaxLength(100);
            entity.Property(e => e.Vendor).HasMaxLength(160);
            entity.Property(e => e.Zipcode).HasMaxLength(10);

            entity.HasOne(d => d.KossModel).WithMany(p => p.KossRmas)
                .HasForeignKey(d => d.KossModelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KossRma_KossHeadphoneModel");

            entity.HasOne(d => d.ReplyMessage).WithMany(p => p.KossRmas)
                .HasForeignKey(d => d.ReplyMessageId)
                .HasConstraintName("FK_KossRma_KossRmaMessage");
        });

        modelBuilder.Entity<KossRmaMessage>(entity =>
        {
            entity.ToTable("KossRmaMessage");

            entity.Property(e => e.Country).HasMaxLength(3);
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.Message).HasMaxLength(1000);
        });

        modelBuilder.Entity<Lan>(entity =>
        {
            entity.HasKey(e => e.Ipaddress);

            entity.ToTable("LAN");

            entity.HasIndex(e => e.Ipaddress, "IX_LAN");

            entity.Property(e => e.Ipaddress)
                .HasMaxLength(15)
                .HasColumnName("IPAddress");
            entity.Property(e => e.Info)
                .HasMaxLength(50)
                .HasColumnName("INFO");
            entity.Property(e => e.Service)
                .HasMaxLength(50)
                .HasColumnName("SERVICE");
        });

        modelBuilder.Entity<MigrationHistory>(entity =>
        {
            entity.HasKey(e => new { e.MigrationId, e.ContextKey }).HasName("PK_dbo.__MigrationHistory");

            entity.ToTable("__MigrationHistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ContextKey).HasMaxLength(300);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

        modelBuilder.Entity<Network>(entity =>
        {
            entity.ToTable("Network");

            entity.Property(e => e.Address).HasMaxLength(20);
            entity.Property(e => e.NetworkName).HasMaxLength(50);
            entity.Property(e => e.SubnetAddress).HasMaxLength(20);
            entity.Property(e => e.VlanId).HasMaxLength(50);
        });

        modelBuilder.Entity<NetworkIp>(entity =>
        {
            entity.ToTable("NetworkIP");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AssignedTo).HasMaxLength(100);
            entity.Property(e => e.Info).HasMaxLength(100);
            entity.Property(e => e.Ip1).HasColumnName("ip_1");
            entity.Property(e => e.Ip2).HasColumnName("ip_2");
            entity.Property(e => e.Ip3).HasColumnName("ip_3");
            entity.Property(e => e.Ip4).HasColumnName("ip_4");

            entity.HasOne(d => d.Network).WithMany(p => p.NetworkIps)
                .HasForeignKey(d => d.NetworkId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NetworkIP_Network");
        });

        modelBuilder.Entity<NetworkLocation>(entity =>
        {
            entity.ToTable("NetworkLocation");

            entity.Property(e => e.Location).HasMaxLength(50);
        });

        modelBuilder.Entity<NetworkSwitch>(entity =>
        {
            entity.ToTable("NetworkSwitch");

            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Placement).HasMaxLength(50);

            entity.HasOne(d => d.Location).WithMany(p => p.NetworkSwitches)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NetworkSwitch_NetworkLocation");
        });

        modelBuilder.Entity<NfsNet>(entity =>
        {
            entity.HasKey(e => e.Ipaddress);

            entity.ToTable("NFS_NET");

            entity.Property(e => e.Ipaddress)
                .HasMaxLength(15)
                .HasColumnName("IPAddress");
            entity.Property(e => e.Appliance).HasMaxLength(255);
            entity.Property(e => e.Interface).HasMaxLength(255);
        });

        modelBuilder.Entity<Passwd>(entity =>
        {
            entity.ToTable("Passwd");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Appliance).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<RmaInformation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_RMA_information_1");

            entity.ToTable("RMA_information");

            entity.Property(e => e.ItemNumber).HasMaxLength(50);
            entity.Property(e => e.Rmainfo).HasColumnName("RMAInfo");
        });

        modelBuilder.Entity<San>(entity =>
        {
            entity.ToTable("SAN");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Bmc)
                .HasMaxLength(50)
                .HasColumnName("BMC");
            entity.Property(e => e.HardwareType)
                .HasMaxLength(50)
                .HasColumnName("Hardware type");
            entity.Property(e => e.IfE0a)
                .HasMaxLength(50)
                .HasColumnName("if_e0a");
            entity.Property(e => e.IfE0b)
                .HasMaxLength(50)
                .HasColumnName("if_e0b");
            entity.Property(e => e.Product).HasMaxLength(50);
            entity.Property(e => e.Sn)
                .HasMaxLength(50)
                .HasColumnName("SN");
        });

        modelBuilder.Entity<SanNet>(entity =>
        {
            entity.HasKey(e => e.Ipaddress);

            entity.ToTable("SAN_NET");

            entity.Property(e => e.Ipaddress)
                .HasMaxLength(255)
                .HasColumnName("IPAddress");
            entity.Property(e => e.Service)
                .HasMaxLength(255)
                .HasColumnName("SERVICE");
            entity.Property(e => e.SubnetMask)
                .HasMaxLength(255)
                .HasColumnName("SUBNET_MASK");
        });

        modelBuilder.Entity<Shipment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_RecievedShipments");

            entity.Property(e => e.OrderNumbers).HasMaxLength(1000);
            entity.Property(e => e.Placement).HasMaxLength(300);
            entity.Property(e => e.ReceivedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Supplier).HasMaxLength(200);

            entity.HasOne(d => d.InitatedByNavigation).WithMany(p => p.ShipmentInitatedByNavigations)
                .HasForeignKey(d => d.InitatedBy)
                .HasConstraintName("FK_RecievedShipments_ShipmentReceivingStaff1");

            entity.HasOne(d => d.ReceivedByNavigation).WithMany(p => p.ShipmentReceivedByNavigations)
                .HasForeignKey(d => d.ReceivedBy)
                .HasConstraintName("FK_RecievedShipments_ShipmentReceivingStaff");

            entity.HasOne(d => d.ReceivingCompanyNavigation).WithMany(p => p.Shipments)
                .HasForeignKey(d => d.ReceivingCompany)
                .HasConstraintName("FK_RecievedShipments_ShipmentReceivers");
        });

        modelBuilder.Entity<ShipmentDeviation>(entity =>
        {
            entity.HasKey(e => e.ShipmentId).HasName("PK_ShipmentDeviation_1");

            entity.ToTable("ShipmentDeviation");

            entity.Property(e => e.ShipmentId).ValueGeneratedNever();
            entity.Property(e => e.Note).HasMaxLength(500);

            entity.HasOne(d => d.Shipment).WithOne(p => p.ShipmentDeviation)
                .HasForeignKey<ShipmentDeviation>(d => d.ShipmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ShipmentDeviation_Shipments");
        });

        modelBuilder.Entity<ShipmentEmployee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_OrderReceivers");

            entity.ToTable("ShipmentEmployee");

            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
        });

        modelBuilder.Entity<ShipmentReceivingCompany>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ShipmentReceivers");

            entity.ToTable("ShipmentReceivingCompany");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<ShipmentStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ReceivedShipmnetStatus");

            entity.ToTable("ShipmentStatus");

            entity.Property(e => e.StatusName).HasMaxLength(100);
        });

        modelBuilder.Entity<ShipmentUpdate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Table_1");

            entity.ToTable("ShipmentUpdate");

            entity.Property(e => e.Note).HasMaxLength(300);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Shipment).WithMany(p => p.ShipmentUpdates)
                .HasForeignKey(d => d.ShipmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReceivedShipmentUpdate_RecievedShipments");

            entity.HasOne(d => d.Status).WithMany(p => p.ShipmentUpdates)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReceivedShipmentUpdate_ReceivedShipmnetStatus");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.ShipmentUpdates)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("FK_ReceivedShipmentUpdate_ShipmentReceivingStaff");
        });

        modelBuilder.Entity<SoftwareLicense>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Företag).HasMaxLength(255);
            entity.Property(e => e.Leverantör).HasMaxLength(255);
            entity.Property(e => e.Media).HasMaxLength(255);
            entity.Property(e => e.Mjukvara).HasMaxLength(255);
            entity.Property(e => e.Plattform).HasMaxLength(255);
            entity.Property(e => e.Språk).HasMaxLength(255);
            entity.Property(e => e.SrNr).HasMaxLength(255);
            entity.Property(e => e.Version).HasMaxLength(255);
        });

        modelBuilder.Entity<SpecialCustomer>(entity =>
        {
            entity.ToTable("SpecialCustomer");

            entity.Property(e => e.CustomerNumber).HasMaxLength(20);
            entity.Property(e => e.ResponsibleSalesPerson).HasMaxLength(20);
            entity.Property(e => e.SalesPersonPhone).HasMaxLength(50);
        });

        modelBuilder.Entity<SwitchPort>(entity =>
        {
            entity.ToTable("SwitchPort");

            entity.Property(e => e.AssignedTo).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.NetworkSwitch).WithMany(p => p.SwitchPorts)
                .HasForeignKey(d => d.NetworkSwitchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SwitchPort_NetworkSwitch");
        });

        modelBuilder.Entity<Telium>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CiscoInt)
                .HasMaxLength(255)
                .HasColumnName("CISCO INT");
            entity.Property(e => e.Interface)
                .HasMaxLength(255)
                .HasColumnName("INTERFACE");
            entity.Property(e => e.Telia)
                .HasMaxLength(255)
                .HasColumnName("TELIA");
        });

        modelBuilder.Entity<VmotionNet>(entity =>
        {
            entity.HasKey(e => e.Ipaddress);

            entity.ToTable("VMotion_net");

            entity.Property(e => e.Ipaddress)
                .HasMaxLength(15)
                .HasColumnName("IPAddress");
            entity.Property(e => e.Appliance).HasMaxLength(255);
            entity.Property(e => e.Interface).HasMaxLength(255);
        });

        modelBuilder.Entity<Wan>(entity =>
        {
            entity.ToTable("WAN");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(20)
                .HasColumnName("IPAddress");
            entity.Property(e => e.Misc)
                .HasMaxLength(255)
                .HasColumnName("MISC");
            entity.Property(e => e.Service)
                .HasMaxLength(255)
                .HasColumnName("SERVICE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
