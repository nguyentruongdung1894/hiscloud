using System;
using System.Collections.Generic;

namespace Nencer.Models;

/// <summary>
/// Báo cáo
/// </summary>
public partial class Report
{
    public int Id { get; set; }

    public int? ParentId { get; set; }

    public string? Name { get; set; }

    public string? Code { get; set; }

    public string? Description { get; set; }

    /// <summary>
    /// Phòng khám
    /// </summary>
    public int? RoomTypeId { get; set; }

    public int? Status { get; set; }

    public int? Sort { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? TemplateName { get; set; }

    public string? FieldXml { get; set; }

    public string? StoreName { get; set; }

    public string? QuerySql { get; set; }
}
