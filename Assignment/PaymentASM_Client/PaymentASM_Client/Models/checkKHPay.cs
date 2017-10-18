using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PaymentASM_Client.Models
{
    public class checkKHPay
    {
        [Required]
        [Display(Name = "Mã đơn hàng:")]
        public string MaDH { get; set; }
        [Required]
        [Display(Name = "Mã khách hàng:")]
        public string MaKH { get; set; }
        [Required]
        [Display(Name = "Mã Pin:")]
        public int MaPin { get; set; }
    }
}