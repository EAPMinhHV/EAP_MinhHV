using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PaymentASM_Client.Models
{
    public class TaiKhoan
    {
        [Required]
        [Display(Name = "Mã tài khoản")]
        public string MaTK { get; set; }

        [Required]
        [Display(Name = "Số tiền")]
        public decimal SoTien { get; set; }

        public virtual Doitac doitacs { get; set; }
    }
}