using System;
using System.Collections.Generic;

namespace StreamServiceDataAccessLibrary.Models;

public partial class MetaEdiLev
{
    public Guid PartPartId { get; set; }

    public DateTime? BlobInfoCreationDateTime { get; set; }

    public int? DocumentControlFlags { get; set; }

    public byte[]? DocumentData { get; set; }

    public int? DeviceIndependentControlFlags { get; set; }

    public byte[]? DeviceIndependentData { get; set; }

    public string? FixedMetaDataExternalId { get; set; }

    public string? FixedMetaDataReceiver { get; set; }

    public string? FixedMetaDataSender { get; set; }

    public string? BlobInfoContentType { get; set; }

    public DateTime? BlobInfoExpiringDateTime { get; set; }

    public decimal? BlobInfoTotalBlobSize { get; set; }

    public string? PartTrackerId { get; set; }

    public string? PartApplicationDomainId { get; set; }

    public string? EdiOrder { get; set; }

    public string? EdiCustomer { get; set; }

    public string? EdiCustomerOrder { get; set; }

    public DateTime? EdiDate { get; set; }
}
