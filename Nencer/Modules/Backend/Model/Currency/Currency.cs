

using System.ComponentModel.DataAnnotations.Schema;

namespace Nencer.Modules.Backend.Model.Currency;
[Table("Currencies")]
public partial class Currency
{
    public long Id { set; get; }

    public string Name { get; set; } = null!;

    /// <summary>
    /// Mã tiền tệ
    /// </summary>
    public string Code { get; set; } = null!;

    /// <summary>
    /// 1 USD bằng bao nhiêu tiền này
    /// </summary>
    public double Value { get; set; }
  
    [Column("symbol_left")]
    public string? SymbolLeft { get; set; }
    [Column("symbol_right")]
    public string? SymbolRight { get; set; }

    public string Seperator { get; set; } = null!;

    public short Decimal { get; set; }

    public short Status { get; set; }
    
    public short Default { get; set; }

    public short Sort { get; set; }
    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }
    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }
}