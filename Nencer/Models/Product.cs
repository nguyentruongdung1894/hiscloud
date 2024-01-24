using System;
using System.Collections.Generic;

namespace Nencer.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? NameIns { get; set; }

    public string? Sku { get; set; }

    public string? Barcode { get; set; }

    /// <summary>
    /// Danh mục
    /// </summary>
    public int? CatId { get; set; }

    /// <summary>
    /// Loại sp (Thuốc/Vật tư y tế)
    /// </summary>
    public string? Area { get; set; }

    /// <summary>
    /// Loại tiêu hao và ko tiêu hao
    /// </summary>
    public string? Type { get; set; }

    /// <summary>
    /// Chỉ dành cho cơ sở bán trực tiếp
    /// </summary>
    public int? IsPrivate { get; set; }

    public int? Manufacturer { get; set; }

    public string? CurrencyCode { get; set; }

    /// <summary>
    /// Giá nhập
    /// </summary>
    public decimal? PriceInput { get; set; }

    /// <summary>
    /// Giá bán thường
    /// </summary>
    public decimal? Price { get; set; }

    /// <summary>
    /// Giá yêu cầu
    /// </summary>
    public decimal? PriceRequest { get; set; }

    /// <summary>
    /// Giá discout, giá bhyt
    /// </summary>
    public decimal? PriceIns { get; set; }

    public string? Unit { get; set; }

    public string? Image { get; set; }

    public string? Description { get; set; }

    /// <summary>
    /// Các thông số kỹ thuật
    /// </summary>
    public string? Specifications { get; set; }

    /// <summary>
    /// nồng độ
    /// </summary>
    public string? Concentration { get; set; }

    /// <summary>
    /// thể tích
    /// </summary>
    public string? Volume { get; set; }

    public string? CountryCode { get; set; }

    /// <summary>
    /// Array
    /// </summary>
    public string? GroupId { get; set; }

    /// <summary>
    /// cách sử dụng
    /// </summary>
    public string? Usage { get; set; }

    /// <summary>
    /// mã đường dùng BHYT
    /// </summary>
    public int? UsageIns { get; set; }

    /// <summary>
    /// quy cach
    /// </summary>
    public string? Packing { get; set; }

    /// <summary>
    /// Kháng sinh
    /// </summary>
    public int? Antibiotic { get; set; }

    /// <summary>
    /// Đông y
    /// </summary>
    public int? EasternMed { get; set; }

    /// <summary>
    /// Thực phẩm chức năng
    /// </summary>
    public int? FunctionalFood { get; set; }

    public int? Featured { get; set; }

    public int? Sort { get; set; }

    public int? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ProductCat? Cat { get; set; }

    public virtual ICollection<PrescriptionOrderItem> PrescriptionOrderItems { get; set; } = new List<PrescriptionOrderItem>();

    public virtual ICollection<ProductBid> ProductBids { get; set; } = new List<ProductBid>();

    public virtual ICollection<ProductInventory> ProductInventories { get; set; } = new List<ProductInventory>();
}
