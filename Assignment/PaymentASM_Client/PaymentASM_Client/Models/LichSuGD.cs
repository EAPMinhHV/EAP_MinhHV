using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PaymentASM_Client.Models
{
    public class LichSuGD
    {
        public Payment pay { get; set; }
        public DonHang donhang { get; set; }
        public Doitac doitac { get; set; }
        public KhachHang khachhang { get; set; }
    }
}