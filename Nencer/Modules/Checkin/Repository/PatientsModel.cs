namespace Nencer.Modules.Checkin.Repository
{
    public class PatientsModel
    {
        public int ID { get; set; }

        public long CheckInID { get; set; }

        public string MaBenhNhan { get; set; }

        public string TenBenhNhan { get; set; }

        public string SoDT { get; set; }

        public string CCCD { get; set; }

        public string DoiTuong { get; set; }

        public string GioiTinh { get; set; }

        public string DiaChi { get; set; }

        public string ngaysinh { get; set; }

        public string khoakham { get; set; }

        public string tenphong { get; set; }

        public string lydokham { get; set; }

        public int sotiepdon { get; set; }

        public string thoigiantiepdon { get; set; }

        public string trangthai { get; set; }

        public string uutien { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int TotalCount { get; set; }
    }
}
