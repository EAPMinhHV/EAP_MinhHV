using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PaymentASM_Client.Models
{
    public class KhachHang
    {
        [Required]
        [Display(Name = "Mã khách hàng")]
        public string MaKH { get; set; }

        [Required]
        [Display(Name = "Mã Pin")]
        public int MaPin { get; set; }

        [Required]
        [Display(Name = "Số tiền tài khoản")]
        public decimal SoTienTK { get; set; }
    }
}