using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StreamServiceDataAccessLibrary.Models;

namespace StreamServiceDataAccessLibrary.Context;

public partial class StrsTuraArchiveNewContext : DbContext
{
    public StrsTuraArchiveNewContext()
    {
    }

    public StrsTuraArchiveNewContext(DbContextOptions<StrsTuraArchiveNewContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Annotation> Annotations { get; set; }

    public virtual DbSet<ArchiveDdlScript> ArchiveDdlScripts { get; set; }

    public virtual DbSet<ArchiveFieldMapping> ArchiveFieldMappings { get; set; }

    public virtual DbSet<DocumentType> DocumentTypes { get; set; }

    public virtual DbSet<ErrorMessage> ErrorMessages { get; set; }

    public virtual DbSet<MetaDataName> MetaDataNames { get; set; }

    public virtual DbSet<MetaDataType> MetaDataTypes { get; set; }

    public virtual DbSet<MetaEdiLev> MetaEdiLevs { get; set; }

    public virtual DbSet<MetaFinanceChrg> MetaFinanceChrgs { get; set; }

    public virtual DbSet<MetaInvoice> MetaInvoices { get; set; }

    public virtual DbSet<MetaLeveransbek> MetaLeveransbeks { get; set; }

    public virtual DbSet<MetaOrderbek> MetaOrderbeks { get; set; }

    public virtual DbSet<MetaReturorder> MetaReturorders { get; set; }

    public virtual DbSet<RelDocumentTypeMetaDataName> RelDocumentTypeMetaDataNames { get; set; }

    public virtual DbSet<SchemaVersion> SchemaVersions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {        
        IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();

        if (!optionsBuilder.IsConfigured)
        {
            //optionsBuilder.UseSqlServer("Data Source=LAPTOP-V6EKNDRG\\SQLEXPRESS;Initial Catalog=TI;Integrated Security=True;");
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("StreamSrv"));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_SwedishStd_Pref_CP1_CI_AS");

        modelBuilder.Entity<Annotation>(entity =>
        {
            entity.HasKey(e => e.AnnotationId).HasName("PK__Annotati__FC2AC5A3173876EA");

            entity.ToTable(tb => tb.HasComment("Holds the annotations made on a document by a user"));

            entity.HasIndex(e => e.PrincipalObjectId, "ixAPrincipalObjectID").HasFillFactor(80);

            entity.Property(e => e.AnnotationId)
                .ValueGeneratedNever()
                .HasComment("Synthetic key")
                .HasColumnName("AnnotationID");
            entity.Property(e => e.Annotation1)
                .HasMaxLength(500)
                .HasColumnName("Annotation");
            entity.Property(e => e.CreationDateTime)
                .HasComment("When the annotation was made")
                .HasColumnType("datetime");
            entity.Property(e => e.ExpiringDateTime)
                .HasComment("Can be used as time for when a deletion script should clean up")
                .HasColumnType("datetime");
            entity.Property(e => e.PartId)
                .HasComment("PartID is the reference to the document in question")
                .HasColumnName("PartID");
            entity.Property(e => e.PrincipalObjectId)
                .HasMaxLength(255)
                .HasComment("The user or role that wrote the annotation")
                .HasColumnName("PrincipalObjectID");
        });

        modelBuilder.Entity<ArchiveDdlScript>(entity =>
        {
            entity.HasKey(e => new { e.JobNo, e.SeqNo }).HasName("Archive_DDL_Scripts_pk");

            entity.ToTable("Archive_DDL_Scripts", tb => tb.HasComment("Maps the fields in the archive META_% tables to metadata in METADATANAME"));

            entity.Property(e => e.JobNo).HasComment("Job Number");
            entity.Property(e => e.SeqNo).HasComment("Sequence number for the sql statement in the job");
            entity.Property(e => e.ArchiveTable)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Archive_Table");
            entity.Property(e => e.CreationDate)
                .HasComment("Creation timestamp for the job")
                .HasColumnType("datetime")
                .HasColumnName("Creation_Date");
            entity.Property(e => e.SqlStatement)
                .HasComment("SQL statement")
                .HasColumnName("SQL_Statement");
            entity.Property(e => e.TypeId)
                .HasComment("Document type in DOCUMENTTYPE")
                .HasColumnName("TypeID");

            entity.HasOne(d => d.Type).WithMany(p => p.ArchiveDdlScripts)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Archive_DDL_Scripts_fk1");
        });

        modelBuilder.Entity<ArchiveFieldMapping>(entity =>
        {
            entity.HasKey(e => new { e.ArchiveTable, e.ArchiveColumnNo }).HasName("Archive_Field_Mapping_PK");

            entity.ToTable("Archive_Field_Mapping", tb => tb.HasComment("Maps the fields in the archive META_% tables to metadata in METADATANAME"));

            entity.HasIndex(e => new { e.ArchiveTable, e.ArchiveColumnNo }, "Archive_Field_Mapping_UK1").IsUnique();

            entity.HasIndex(e => e.MetaDataNameId, "IX_ServiceCreationDateTime").HasFillFactor(80);

            entity.Property(e => e.ArchiveTable)
                .HasMaxLength(200)
                .HasComment("Archive table name for the collector data")
                .HasColumnName("Archive_Table");
            entity.Property(e => e.ArchiveColumnNo)
                .HasComment("Archive column order (Field ID is not included)")
                .HasColumnName("Archive_Column_No");
            entity.Property(e => e.ArchiveColumnName)
                .HasMaxLength(200)
                .HasComment("Archive column name for the collector data")
                .HasColumnName("Archive_Column_Name");
            entity.Property(e => e.MetaDataNameId)
                .HasComment("Foreign key to column METADATANAME.METADATANAMEID")
                .HasColumnName("MetaDataNameID");
            entity.Property(e => e.Searchable).HasComment("Set to 1 if the field should be searchable from Streamstudio, else set to 0 (e.g. BLOB fields)");
            entity.Property(e => e.TypeId)
                .HasComment("Foreign key to column DOCUMENTTYPE.TYPEID")
                .HasColumnName("TypeID");

            entity.HasOne(d => d.MetaDataName).WithMany(p => p.ArchiveFieldMappings)
                .HasForeignKey(d => d.MetaDataNameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Archive_Field_Mapping_FK1");

            entity.HasOne(d => d.Type).WithMany(p => p.ArchiveFieldMappings)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Archive_Field_Mapping_FK2");
        });

        modelBuilder.Entity<DocumentType>(entity =>
        {
            entity.HasKey(e => e.TypeId)
                .HasName("PK_Type")
                .IsClustered(false);

            entity.ToTable("DocumentType");

            entity.HasIndex(e => new { e.TypeName, e.TypeOfType, e.TypeId }, "ixDTTypeNameN").HasFillFactor(80);

            entity.Property(e => e.TypeId)
                .ValueGeneratedNever()
                .HasColumnName("TypeID");
            entity.Property(e => e.ExpiringDateTime).HasColumnType("datetime");
            entity.Property(e => e.PermissionsId).HasColumnName("PermissionsID");
            entity.Property(e => e.PrincipalObjectId)
                .HasMaxLength(255)
                .HasColumnName("PrincipalObjectID");
            entity.Property(e => e.SearchId).HasColumnName("SearchID");
            entity.Property(e => e.TypeName).HasMaxLength(255);
        });

        modelBuilder.Entity<ErrorMessage>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Error_Messages");

            entity.Property(e => e.ErrLang)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.ErrMsg).HasMaxLength(255);
        });

        modelBuilder.Entity<MetaDataName>(entity =>
        {
            entity.HasKey(e => e.MetaDataNameId).IsClustered(false);

            entity.ToTable("MetaDataName");

            entity.Property(e => e.MetaDataNameId)
                .ValueGeneratedNever()
                .HasColumnName("MetaDataNameID");
            entity.Property(e => e.MetaDataName1)
                .HasMaxLength(255)
                .HasColumnName("MetaDataName");
            entity.Property(e => e.Source).HasMaxLength(511);
            entity.Property(e => e.SourceColumn).HasMaxLength(255);
            entity.Property(e => e.SourceTable).HasMaxLength(255);
            entity.Property(e => e.TypeId).HasColumnName("TypeID");
        });

        modelBuilder.Entity<MetaDataType>(entity =>
        {
            entity.ToTable("MetaDataType");

            entity.Property(e => e.MetaDataTypeId).HasColumnName("MetaDataTypeID");
            entity.Property(e => e.ArchiveDataType)
                .HasMaxLength(50)
                .HasColumnName("Archive_DataType");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.SqldataType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SQLDataType");
        });

        modelBuilder.Entity<MetaEdiLev>(entity =>
        {
            entity.HasKey(e => e.PartPartId)
                .HasName("META_EdiLev_PK")
                .IsClustered(false);

            entity.ToTable("META_EdiLev");

            entity.HasIndex(e => e.BlobInfoCreationDateTime, "ix_META_EdiLev_creationdatetime")
                .IsClustered()
                .HasFillFactor(80);

            entity.Property(e => e.PartPartId)
                .ValueGeneratedNever()
                .HasColumnName("Part.PartID");
            entity.Property(e => e.BlobInfoContentType)
                .HasMaxLength(400)
                .HasColumnName("BlobInfo.ContentType");
            entity.Property(e => e.BlobInfoCreationDateTime)
                .HasColumnType("datetime")
                .HasColumnName("BlobInfo.CreationDateTime");
            entity.Property(e => e.BlobInfoExpiringDateTime)
                .HasColumnType("datetime")
                .HasColumnName("BlobInfo.ExpiringDateTime");
            entity.Property(e => e.BlobInfoTotalBlobSize)
                .HasColumnType("decimal(28, 8)")
                .HasColumnName("BlobInfo.TotalBlobSize");
            entity.Property(e => e.DeviceIndependentData).HasColumnType("image");
            entity.Property(e => e.DocumentData).HasColumnType("image");
            entity.Property(e => e.EdiCustomer).HasMaxLength(400);
            entity.Property(e => e.EdiCustomerOrder).HasMaxLength(400);
            entity.Property(e => e.EdiDate).HasColumnType("datetime");
            entity.Property(e => e.EdiOrder).HasMaxLength(400);
            entity.Property(e => e.FixedMetaDataExternalId)
                .HasMaxLength(400)
                .HasColumnName("FixedMetaData.ExternalID");
            entity.Property(e => e.FixedMetaDataReceiver)
                .HasMaxLength(400)
                .HasColumnName("FixedMetaData.Receiver");
            entity.Property(e => e.FixedMetaDataSender)
                .HasMaxLength(400)
                .HasColumnName("FixedMetaData.Sender");
            entity.Property(e => e.PartApplicationDomainId)
                .HasMaxLength(400)
                .HasColumnName("Part.ApplicationDomainID");
            entity.Property(e => e.PartTrackerId)
                .HasMaxLength(400)
                .HasColumnName("Part.TrackerID");
        });

        modelBuilder.Entity<MetaFinanceChrg>(entity =>
        {
            entity.HasKey(e => e.PartPartId)
                .HasName("META_FinanceChrg_PK")
                .IsClustered(false);

            entity.ToTable("META_FinanceChrg");

            entity.HasIndex(e => e.BlobInfoCreationDateTime, "ix_META_FinanceChrg_creationdatetime")
                .IsClustered()
                .HasFillFactor(90);

            entity.Property(e => e.PartPartId)
                .ValueGeneratedNever()
                .HasColumnName("Part.PartID");
            entity.Property(e => e.BlobInfoContentType)
                .HasMaxLength(400)
                .HasColumnName("BlobInfo.ContentType");
            entity.Property(e => e.BlobInfoCreationDateTime)
                .HasColumnType("datetime")
                .HasColumnName("BlobInfo.CreationDateTime");
            entity.Property(e => e.BlobInfoExpiringDateTime)
                .HasColumnType("datetime")
                .HasColumnName("BlobInfo.ExpiringDateTime");
            entity.Property(e => e.BlobInfoTotalBlobSize)
                .HasColumnType("decimal(28, 8)")
                .HasColumnName("BlobInfo.TotalBlobSize");
            entity.Property(e => e.CustomerName).HasMaxLength(400);
            entity.Property(e => e.CustomerNumber).HasMaxLength(400);
            entity.Property(e => e.DeviceIndependentData).HasColumnType("image");
            entity.Property(e => e.DocumentData).HasColumnType("image");
            entity.Property(e => e.FixedMetaDataExternalId)
                .HasMaxLength(400)
                .HasColumnName("FixedMetaData.ExternalID");
            entity.Property(e => e.FixedMetaDataReceiver)
                .HasMaxLength(400)
                .HasColumnName("FixedMetaData.Receiver");
            entity.Property(e => e.FixedMetaDataSender)
                .HasMaxLength(400)
                .HasColumnName("FixedMetaData.Sender");
            entity.Property(e => e.InvoiceDate).HasColumnType("datetime");
            entity.Property(e => e.InvoiceNumber).HasMaxLength(400);
            entity.Property(e => e.PartApplicationDomainId)
                .HasMaxLength(400)
                .HasColumnName("Part.ApplicationDomainID");
            entity.Property(e => e.PartTrackerId)
                .HasMaxLength(400)
                .HasColumnName("Part.TrackerID");
        });

        modelBuilder.Entity<MetaInvoice>(entity =>
        {
            entity.HasKey(e => e.PartPartId)
                .HasName("META_Invoice_PK")
                .IsClustered(false);

            entity.ToTable("META_Invoice");

            entity.HasIndex(e => e.BlobInfoCreationDateTime, "ix_META_Invoice_creationdatetime")
                .IsClustered()
                .HasFillFactor(90);

            entity.Property(e => e.PartPartId)
                .ValueGeneratedNever()
                .HasColumnName("Part.PartID");
            entity.Property(e => e.BlobInfoContentType)
                .HasMaxLength(400)
                .HasColumnName("BlobInfo.ContentType");
            entity.Property(e => e.BlobInfoCreationDateTime)
                .HasColumnType("datetime")
                .HasColumnName("BlobInfo.CreationDateTime");
            entity.Property(e => e.BlobInfoExpiringDateTime)
                .HasColumnType("datetime")
                .HasColumnName("BlobInfo.ExpiringDateTime");
            entity.Property(e => e.BlobInfoTotalBlobSize)
                .HasColumnType("decimal(28, 8)")
                .HasColumnName("BlobInfo.TotalBlobSize");
            entity.Property(e => e.CustomerName).HasMaxLength(400);
            entity.Property(e => e.CustomerNumber).HasMaxLength(400);
            entity.Property(e => e.DeviceIndependentData).HasColumnType("image");
            entity.Property(e => e.DocumentData).HasColumnType("image");
            entity.Property(e => e.FixedMetaDataExternalId)
                .HasMaxLength(400)
                .HasColumnName("FixedMetaData.ExternalID");
            entity.Property(e => e.FixedMetaDataReceiver)
                .HasMaxLength(400)
                .HasColumnName("FixedMetaData.Receiver");
            entity.Property(e => e.FixedMetaDataSender)
                .HasMaxLength(400)
                .HasColumnName("FixedMetaData.Sender");
            entity.Property(e => e.InvoiceDate).HasColumnType("datetime");
            entity.Property(e => e.InvoiceNumber).HasMaxLength(400);
            entity.Property(e => e.PartApplicationDomainId)
                .HasMaxLength(400)
                .HasColumnName("Part.ApplicationDomainID");
            entity.Property(e => e.PartTrackerId)
                .HasMaxLength(400)
                .HasColumnName("Part.TrackerID");
        });

        modelBuilder.Entity<MetaLeveransbek>(entity =>
        {
            entity.HasKey(e => e.PartPartId)
                .HasName("META_Leveransbek_PK")
                .IsClustered(false);

            entity.ToTable("META_Leveransbek");

            entity.HasIndex(e => e.BlobInfoCreationDateTime, "ix_META_Leveransbek_creationdatetime")
                .IsClustered()
                .HasFillFactor(90);

            entity.Property(e => e.PartPartId)
                .ValueGeneratedNever()
                .HasColumnName("Part.PartID");
            entity.Property(e => e.BlobInfoContentType)
                .HasMaxLength(400)
                .HasColumnName("BlobInfo.ContentType");
            entity.Property(e => e.BlobInfoCreationDateTime)
                .HasColumnType("datetime")
                .HasColumnName("BlobInfo.CreationDateTime");
            entity.Property(e => e.BlobInfoExpiringDateTime)
                .HasColumnType("datetime")
                .HasColumnName("BlobInfo.ExpiringDateTime");
            entity.Property(e => e.BlobInfoTotalBlobSize)
                .HasColumnType("decimal(28, 8)")
                .HasColumnName("BlobInfo.TotalBlobSize");
            entity.Property(e => e.CustomerEmail).HasMaxLength(400);
            entity.Property(e => e.CustomerName).HasMaxLength(400);
            entity.Property(e => e.CustomerNumber).HasMaxLength(400);
            entity.Property(e => e.DeviceIndependentData).HasColumnType("image");
            entity.Property(e => e.DocumentData).HasColumnType("image");
            entity.Property(e => e.FixedMetaDataExternalId)
                .HasMaxLength(400)
                .HasColumnName("FixedMetaData.ExternalID");
            entity.Property(e => e.FixedMetaDataReceiver)
                .HasMaxLength(400)
                .HasColumnName("FixedMetaData.Receiver");
            entity.Property(e => e.FixedMetaDataSender)
                .HasMaxLength(400)
                .HasColumnName("FixedMetaData.Sender");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.OrderNumber).HasMaxLength(400);
            entity.Property(e => e.PartApplicationDomainId)
                .HasMaxLength(400)
                .HasColumnName("Part.ApplicationDomainID");
            entity.Property(e => e.PartTrackerId)
                .HasMaxLength(400)
                .HasColumnName("Part.TrackerID");
        });

        modelBuilder.Entity<MetaOrderbek>(entity =>
        {
            entity.HasKey(e => e.PartPartId)
                .HasName("META_Orderbek_PK")
                .IsClustered(false);

            entity.ToTable("META_Orderbek");

            entity.HasIndex(e => e.BlobInfoCreationDateTime, "ix_META_Orderbek_creationdatetime")
                .IsClustered()
                .HasFillFactor(90);

            entity.Property(e => e.PartPartId)
                .ValueGeneratedNever()
                .HasColumnName("Part.PartID");
            entity.Property(e => e.BlobInfoContentType)
                .HasMaxLength(400)
                .HasColumnName("BlobInfo.ContentType");
            entity.Property(e => e.BlobInfoCreationDateTime)
                .HasColumnType("datetime")
                .HasColumnName("BlobInfo.CreationDateTime");
            entity.Property(e => e.BlobInfoExpiringDateTime)
                .HasColumnType("datetime")
                .HasColumnName("BlobInfo.ExpiringDateTime");
            entity.Property(e => e.BlobInfoTotalBlobSize)
                .HasColumnType("decimal(28, 8)")
                .HasColumnName("BlobInfo.TotalBlobSize");
            entity.Property(e => e.CustomerEmail).HasMaxLength(400);
            entity.Property(e => e.CustomerName).HasMaxLength(400);
            entity.Property(e => e.CustomerNumber).HasMaxLength(400);
            entity.Property(e => e.DeviceIndependentData).HasColumnType("image");
            entity.Property(e => e.DocumentData).HasColumnType("image");
            entity.Property(e => e.FixedMetaDataExternalId)
                .HasMaxLength(400)
                .HasColumnName("FixedMetaData.ExternalID");
            entity.Property(e => e.FixedMetaDataReceiver)
                .HasMaxLength(400)
                .HasColumnName("FixedMetaData.Receiver");
            entity.Property(e => e.FixedMetaDataSender)
                .HasMaxLength(400)
                .HasColumnName("FixedMetaData.Sender");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.OrderNumber).HasMaxLength(400);
            entity.Property(e => e.PartApplicationDomainId)
                .HasMaxLength(400)
                .HasColumnName("Part.ApplicationDomainID");
            entity.Property(e => e.PartTrackerId)
                .HasMaxLength(400)
                .HasColumnName("Part.TrackerID");
        });

        modelBuilder.Entity<MetaReturorder>(entity =>
        {
            entity.HasKey(e => e.PartPartId)
                .HasName("META_Returorder_PK")
                .IsClustered(false);

            entity.ToTable("META_Returorder");

            entity.HasIndex(e => e.BlobInfoCreationDateTime, "ix_META_Returorder_creationdatetime")
                .IsClustered()
                .HasFillFactor(90);

            entity.Property(e => e.PartPartId)
                .ValueGeneratedNever()
                .HasColumnName("Part.PartID");
            entity.Property(e => e.BlobInfoContentType)
                .HasMaxLength(400)
                .HasColumnName("BlobInfo.ContentType");
            entity.Property(e => e.BlobInfoCreationDateTime)
                .HasColumnType("datetime")
                .HasColumnName("BlobInfo.CreationDateTime");
            entity.Property(e => e.BlobInfoExpiringDateTime)
                .HasColumnType("datetime")
                .HasColumnName("BlobInfo.ExpiringDateTime");
            entity.Property(e => e.BlobInfoTotalBlobSize)
                .HasColumnType("decimal(28, 8)")
                .HasColumnName("BlobInfo.TotalBlobSize");
            entity.Property(e => e.CustomerEmail).HasMaxLength(400);
            entity.Property(e => e.CustomerName).HasMaxLength(400);
            entity.Property(e => e.CustomerNumber).HasMaxLength(400);
            entity.Property(e => e.DeviceIndependentData).HasColumnType("image");
            entity.Property(e => e.DocumentData).HasColumnType("image");
            entity.Property(e => e.FixedMetaDataExternalId)
                .HasMaxLength(400)
                .HasColumnName("FixedMetaData.ExternalID");
            entity.Property(e => e.FixedMetaDataReceiver)
                .HasMaxLength(400)
                .HasColumnName("FixedMetaData.Receiver");
            entity.Property(e => e.FixedMetaDataSender)
                .HasMaxLength(400)
                .HasColumnName("FixedMetaData.Sender");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.OrderNumber).HasMaxLength(400);
            entity.Property(e => e.PartApplicationDomainId)
                .HasMaxLength(400)
                .HasColumnName("Part.ApplicationDomainID");
            entity.Property(e => e.PartTrackerId)
                .HasMaxLength(400)
                .HasColumnName("Part.TrackerID");
        });

        modelBuilder.Entity<RelDocumentTypeMetaDataName>(entity =>
        {
            entity.HasKey(e => new { e.DocumentTypeId, e.MetaDataNameId });

            entity.ToTable("relDocumentTypeMetaDataName");

            entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");
            entity.Property(e => e.MetaDataNameId).HasColumnName("MetaDataNameID");
            entity.Property(e => e.FlatColumnName).HasMaxLength(255);
            entity.Property(e => e.FlatTableName).HasMaxLength(255);

            entity.HasOne(d => d.DocumentType).WithMany(p => p.RelDocumentTypeMetaDataNames)
                .HasForeignKey(d => d.DocumentTypeId)
                .HasConstraintName("FK_relDocumentTypeMetaDataName_DocumentType");

            entity.HasOne(d => d.MetaDataName).WithMany(p => p.RelDocumentTypeMetaDataNames)
                .HasForeignKey(d => d.MetaDataNameId)
                .HasConstraintName("FK_relDocumentTypeMetaDataName_MetaDataName");
        });

        modelBuilder.Entity<SchemaVersion>(entity =>
        {
            entity.HasKey(e => e.SchemaVersionId).IsClustered(false);

            entity.ToTable("SchemaVersion", tb => tb.HasComment("The version of the database schema"));

            entity.Property(e => e.SchemaVersionId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("primary key, the name of the schema")
                .HasColumnName("SchemaVersionID");
            entity.Property(e => e.Build)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Build is the build where this schema was sent out with");
            entity.Property(e => e.CreationDate)
                .HasComment("When this row was inserted")
                .HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("An informative text");
            entity.Property(e => e.Major).HasComment("The major version of the schema, follows the service pack, clients check this before they start");
            entity.Property(e => e.Revision).HasComment("The revision of the schema, on any change this is stepped up, clients do not check this before start ");
            entity.Property(e => e.Version).HasComment("The version of the schema, connected to the platform version, clients check this before they start");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
