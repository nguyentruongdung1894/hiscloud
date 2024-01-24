using System;
using System.Collections.Generic;

namespace Nencer.Models;

public partial class DynamicReport
{
    /// <summary>
    /// Tên cột
    /// </summary>
    public string? ReportColumn { get; set; }

    /// <summary>
    /// Mẫu báo cáo
    /// </summary>
    public string? ReportCode { get; set; }

    /// <summary>
    /// Giá trị cột
    /// </summary>
    public string? ReportDataField { get; set; }

    /// <summary>
    /// Định nghĩa sql
    /// </summary>
    public string? ReportSql { get; set; }

    public int Id { get; set; }

    public string? ReportName { get; set; }
}
