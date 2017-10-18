using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PaymentASM_Client.Models
{
    public class DonHang
    {
        [Required]
        [Display(Name = "Mã đơn hàng")]
        public string MaDH { get; set; }
        [Required]
        [Display(Name = "Mã khách hàng")]
        public string MaKH { get; set; }
        [Required]
        [Display(Name = "Mã đối tác")]
        public string MaDT { get; set; }
        [Required]
        [Display(Name = "Số tiền đơn hàng")]
        public decimal SoTien { get; set; }
        public string statusDH { get; set; }
    }
}