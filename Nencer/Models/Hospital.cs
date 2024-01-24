using System;
using System.Collections.Generic;

namespace Nencer.Models;

/// <summary>
/// Danh mục cơ sở khám chữa bệnh
/// </summary>
public partial class Hospital
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Code { get; set; }

    /// <summary>
    /// Hạng
    /// </summary>
    public string? Rank { get; set; }

    /// <summary>
    /// tuyến
    /// </summary>
    public string? Type { get; set; }

    public string? Description { get; set; }

    public string? Image { get; set; }

    public string? Director { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public int? CityId { get; set; }

    public string? CountryCode { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
