using System;
using System.Collections.Generic;

namespace Nencer.Models;

/// <summary>
/// Nhà sản xuất, nhà cung cấp
/// </summary>
public partial class DrugVendor
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string Code { get; set; } = null!;

    public string? Image { get; set; }

    public string? Description { get; set; }

    public int? Status { get; set; }

    public string? CountryCode { get; set; }

    public int? CityId { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? CompanyName { get; set; }

    public string? TaxNumber { get; set; }

    public string? CompanyAddress { get; set; }

    public string? Certificate { get; set; }

    public string? Director { get; set; }

    public int? Featured { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
