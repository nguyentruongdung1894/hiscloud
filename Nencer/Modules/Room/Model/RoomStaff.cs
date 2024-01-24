//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace Nencer.Modules.Room.Model;

///// <summary>
///// Danh sách bác sỹ và nhân viên phục vụ
///// </summary>
//[Table("room_staffs")]
//public partial class RoomStaff
//{
//    public int Id { get; set; }

//    [Column("job_type")] public string? JobType { get; set; }

//    public string? Name { get; set; }

//    /// <summary>
//    /// bác sỹ hoặc nhân viên
//    /// </summary>
//    [Column("user_id")] public int? UserId { get; set; }

//    [Column("room_id")] public int? RoomId { get; set; }

//    public string? Status { get; set; }

//    [Column("checkin_at")] public DateTime? CheckinAt { get; set; }

//    [Column("checkout_at")] public DateTime? CheckoutAt { get; set; }

//    [Column("created_at")] public DateTime? CreatedAt { get; set; }

//    [Column("updated_at")] public DateTime? UpdatedAt { get; set; }
//}
