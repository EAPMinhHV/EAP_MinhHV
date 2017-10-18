using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PaymentServiceASM
{
    public class LichSuGD
    {
        [Required]
        [Display(Name = "Mã giao dịch: ")]
        public int MGD { get; set; }

        [Required]
        [Display(Name = "Tên giao dịch: ")]
        public string tenGD { get; set; }

        [Required]
        [Display(Name = "Số tiền giao dịch: ")]
        public decimal sotien { get; set; }

        [Required]
        [Display(Name = "Phí giao dịch: ")]
        public decimal phi { get; set; }

        [Required]
        [Display(Name = "Ngày giao dịch: ")]
        public DateTime ngay { get; set; }
    }
}