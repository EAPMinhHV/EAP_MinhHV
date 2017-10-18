using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PaymentASM_Client.Models
{
    public class Payment
    {
        [Required]
        [Display(Name = "Tên GD")]
        public string TenGD { get; set; }
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
        [Display(Name = "Phí")]
        public decimal Phi { get; set; }
        [Required]
        [Display(Name = "Ngày")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime Ngay { get; set; }
    }
}