using System;
using System.Collections.Generic;

namespace Nencer.Models;

public partial class StorehouseInven
{
    public int InvenId { get; set; }

    public int? StorehouseId { get; set; }

    public int? ProductId { get; set; }

    public double? PriceInput { get; set; }

    public double? Price { get; set; }

    public double? PriceIns { get; set; }

    public double? PriceFee { get; set; }

    public double? PriceHospital { get; set; }

    public double? PriceRequest { get; set; }

    public string? BatchNumber { get; set; }

    public double? Vat { get; set; }

    public string? BidNumber { get; set; }

    public string? BidGroup { get; set; }

    public string? BidPackage { get; set; }

    public string? BidYear { get; set; }

    public string? ExpirationDateFe { get; set; }

    public DateOnly? ProductionDate { get; set; }

    public int? Qty { get; set; }

    public int? QtyLock { get; set; }

    public DateOnly? ExpirationDate { get; set; }

    public int? OrderDetailId { get; set; }

    public double? PriceSelling { get; set; }

    public DateOnly? CreatedDate { get; set; }

    public DateOnly? UpdatedDate { get; set; }
}
