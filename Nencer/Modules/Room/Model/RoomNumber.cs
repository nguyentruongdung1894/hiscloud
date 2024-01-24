//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace Nencer.Modules.Room.Model;

//[Table("room_numbers")]
//public partial class RoomNumber
//{
//    public int Id { get; set; }

//    public string? Name { get; set; }

//    public string Number { get; set; } = null!;

//    [Column("room_id")] public int RoomId { get; set; }

//    [Column("room_type_id")] public int RoomTypeId { get; set; }

//    [Column("room_type_code")] public string? RoomTypeCode { get; set; }

//    public string? Note { get; set; }

//    [Column("allow_users")] public string? AllowUsers { get; set; }

//    public int? Status { get; set; }

//    [Column("created_at")] public DateTime? CreatedAt { get; set; }

//    [Column("updated_at")] public DateTime? UpdatedAt { get; set; }
//}
