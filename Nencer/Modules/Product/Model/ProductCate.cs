using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nencer.Modules.Product.Model;
[Table("product_cats")]
public partial class ProductCate
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("slug")]
    public string Slug { get; set; }

    [Column("area")]
    public string? Area { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("sort")]
    public int? Sort { get; set; }

    [Column("image")]
    public string? Image { get; set; }

    [Column("status")]
    public int? Status { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

}
