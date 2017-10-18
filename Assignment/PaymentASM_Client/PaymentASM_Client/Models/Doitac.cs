using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PaymentASM_Client.Models
{
    public class Doitac
    {
        [Required]
        [Display(Name = "Mã đối tác")]
        public string MaDT { get; set; }
        [Required]
        [Display(Name = "Mật khẩu đối tác")]
        public string MKDT { get; set; }
        [Required]
        [Display(Name = "Mã tài khoản")]
        public string MaTK { get; set; }

        public virtual ICollection<TaiKhoan> TaiKhoans { get; set; }
    }
}