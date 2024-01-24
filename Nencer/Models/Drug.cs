using System;
using System.Collections.Generic;

namespace Nencer.Models;

public partial class Drug
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public string? BarCode { get; set; }

    public int? DrugTypeId { get; set; }

    public string? RegisterNumber { get; set; }

    /// <summary>
    /// array
    /// </summary>
    public string? IngredientIds { get; set; }

    public int? DrugGroupId { get; set; }

    public int? UnitId { get; set; }

    public string? DrugContent { get; set; }

    /// <summary>
    /// Nồng độ
    /// </summary>
    public string? Concentration { get; set; }

    /// <summary>
    /// Thể tích, khối lượng
    /// </summary>
    public string? Volume { get; set; }

    public string? CountryCode { get; set; }

    public int? Vendor { get; set; }

    /// <summary>
    /// Quy cách
    /// </summary>
    public string? Packing { get; set; }

    public string? AtcCode { get; set; }

    public string? InsuranceGroupId { get; set; }

    public int? Antibiotic { get; set; }

    public int? NewDrug { get; set; }

    /// <summary>
    /// Vị y học cổ truyền
    /// </summary>
    public int? TraditionalMedicineTaste { get; set; }

    /// <summary>
    /// Chế phẩm y học cổ truyền
    /// </summary>
    public int? TraditionalMedicineProduct { get; set; }

    /// <summary>
    /// Thuốc kê đơn
    /// </summary>
    public int? DrugReceipt { get; set; }

    /// <summary>
    /// Thực phẩm chức năng
    /// </summary>
    public int? FunctionalFood { get; set; }

    public string? InputPrice { get; set; }

    public string? Price { get; set; }

    public string? PriceIns { get; set; }

    public int? Status { get; set; }

    public int? Featured { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
