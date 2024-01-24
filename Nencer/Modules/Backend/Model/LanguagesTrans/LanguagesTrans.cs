using System.ComponentModel.DataAnnotations.Schema;

namespace Nencer.Modules.Backend.Model.LanguagesTrans;
[Table("languages_trans")]
public class LanguagesTrans
{
    public int Id { get; set; }
    
    public string Key { get; set; }
    [Column("lang_code")]
    public string LangCode { get; set; }
    [Column("lang_key")]
    public string LangKey { get; set; }

    public string Filename { get; set; }
    
    public string Content { get; set; }
    
    public string Type { get; set; }
    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }
    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }
}