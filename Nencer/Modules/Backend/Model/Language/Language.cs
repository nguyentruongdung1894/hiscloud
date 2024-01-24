using System.ComponentModel.DataAnnotations.Schema;

namespace Nencer.Modules.Backend.Model.Language;
[Table("languages")]
public class Language
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string Code { get; set; }
    
    public string? Flag { get; set; }
    
    public string? Hreflang { get; set; }
    
    public string? Charset { get; set; }
    
    public long Default { get; set; }
    
    public long Status { get; set; }
    
    public long Installed { get; set; }
    
    public long Sort { get; set; }
    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }
    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }
}