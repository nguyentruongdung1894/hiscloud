using System.ComponentModel.DataAnnotations.Schema;

namespace Nencer.Modules.Backend.Model.Menu;

[Table("menu")]
  public partial class Menu
  {
    public long Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Url { get; set; }
    [Column("menu_type")]
    public string? MenuType { get; set; }
    [Column("parent_id")]
    public int? ParentId { get; set; } = 0;
    public int? Level { get; set; } = 1;
    [Column("children_count")]
    public int? ChildrenCount { get; set; } = 0;
    [Column("sort_order")]
    public int? SortOrder { get; set; }
    public int? Status { get; set; } = 1;
    public string Language { get; set; } = "vi";
    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }
    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    public static implicit operator string(Menu v)
    {
        throw new NotImplementedException();
    }
}

