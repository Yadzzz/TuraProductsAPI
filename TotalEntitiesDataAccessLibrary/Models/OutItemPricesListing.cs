using System;
using System.Collections.Generic;

namespace TotalEntitiesDataAccessLibrary.Models;

public partial class OutItemPricesListing
{
    public string? Icin { get; set; }

    public string ItemDescription { get; set; } = null!;

    public string SalesItemNo { get; set; } = null!;

    public string EanGtin { get; set; } = null!;

    public string? Brand { get; set; }

    public string ItemGroupId { get; set; } = null!;

    public string? ItemGroup { get; set; }

    public string MainItemGroupId { get; set; } = null!;

    public string? MainItemGroup { get; set; }

    public string? StatusDesc { get; set; }

    public string? StatusId { get; set; }

    public string MinOrderQty { get; set; } = null!;

    public string? Supplier { get; set; }

    public string SupplierId { get; set; } = null!;

    public string CountryOfOrigin { get; set; } = null!;

    public string BuyingNoSource { get; set; } = null!;

    public decimal? Length { get; set; }

    public decimal? Width { get; set; }

    public decimal? Height { get; set; }

    public decimal Grossweight { get; set; }

    public decimal? McLength { get; set; }

    public decimal? McWidth { get; set; }

    public decimal? McHeight { get; set; }

    public decimal? McWeight { get; set; }

    public decimal? McQuantity { get; set; }

    public decimal? PalletQuantity { get; set; }

    public string? ReplacementItemNo { get; set; }

    public string LockedForWeb { get; set; } = null!;
}
