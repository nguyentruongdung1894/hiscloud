using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nencer.Modules.Product.Model;
[Table("products")]
public partial class Product
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public string Name { get; set; }

    [Column("code_ins")]
    public string? CodeIns { get; set; }

    [Column("name_ins")]
    public string? NameIns { get; set; }

    [Column("sku")]
    public string? Sku { get; set; }

    [Column("barcode")]
    public string? Barcode { get; set; }

    [Column("cat_id")]
    public int? CatId { get; set; }

    [Column("area")]
    public string? Area { get; set; }

    [Column("type")]
    public string? Type { get; set; }

    [Column("is_private")]
    public int? IsPrivate { get; set; }

    [Column("manufacturer")]
    public string? Manufacturer { get; set; }

    [Column("currency_code")]
    public string? CurrencyCode { get; set; }

    [Column("price_input")]
    public decimal? PriceInput { get; set; }

    [Column("price")]
    public decimal? Price { get; set; }

    [Column("price_request")]
    public decimal? PriceRequest { get; set; }

    [Column("price_ins")]
    public decimal? PriceIns { get; set; }

    [Column("unit")]
    public string? Unit { get; set; }

    [Column("image")]
    public string? Image { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("specifications")]
    public string? Specifications { get; set; }

    [Column("concentration")]
    public string? Concentration { get; set; }

    [Column("volume")]
    public string? Volume { get; set; }

    [Column("active_ingredient")]
    public string? ActiveIngredient { get; set; }

    [Column("content")]
    public string? Content { get; set; }

    [Column("country_code")]
    public string? CountryCode { get; set; }

    [Column("group_id")]
    public string? GroupId { get; set; }

    [Column("usage")]
    public string? Usage { get; set; }

    [Column("usage_ins")]
    public int? UsageIns { get; set; }

    [Column("packing")]
    public string? Packing { get; set; }

    [Column("antibiotic")]
    public int? Antibiotic { get; set; }

    [Column("eastern_med")]
    public int? EasternMed { get; set; }

    [Column("functional_food")]
    public int? FunctionalFood { get; set; }

    [Column("featured")]
    public int? Featured { get; set; }

    [Column("registration_number")]
    public string? RegistrationNumber { get; set; }

    [Column("sort")]
    public int? Sort { get; set; }

    [Column("status")]
    public int? Status { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }
}
