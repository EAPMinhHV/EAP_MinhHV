using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PaymentASM_Client.ServiceReference1;
using PaymentASM_Client.Models;

namespace PaymentASM_Client.Controllers
{
    public class PaymentController : Controller
    {
        PaymentServiceClient client = new PaymentServiceClient();
        public ActionResult IndexDT(string MaDT,string MKDT,string fromDate,string toDate)
        {
           var a= getLSGD();
            ViewBag.products = new List<LichSuGD>();
            if (client.checkDT(MaDT, MKDT))
            {
                var filter = a.Where(b => b.pay.Ngay >= Convert.ToDateTime(fromDate) && b.pay.Ngay <= Convert.ToDateTime(toDate) && b.donhang.statusDH.Equals("thành công")).ToList();
                ViewBag.products = filter;
            }
             return View();
        }
        public ActionResult IndexKH(string MaKH, string MaPin, string fromDate, string toDate)
        {
            var a = getLSGD();
            ViewBag.products = new List<LichSuGD>();
            if(!string.IsNullOrEmpty(MaPin))
            {
                if (client.checkKH(MaKH, int.Parse(MaPin)))
                {
                    var filter = a.Where(b => b.pay.Ngay >= Convert.ToDateTime(fromDate) && b.pay.Ngay <= Convert.ToDateTime(toDate) && b.donhang.statusDH.Equals("thành công")).ToList();
                    ViewBag.products = filter;
                }
            }
            
            return View();
        }

        // GET: Tai khoan
        public ActionResult viewTK()
        {
            var a = client.getAllTK();
            List<Models.TaiKhoan> tk = new List<Models.TaiKhoan>();
            foreach (var i in a)
            {
                tk.Add(convertTKService(i));
            }
            
            return View(tk);
        }
        public ActionResult createTK()
        {
            return View();
        }
        [HttpPost]
        public ActionResult createTK(Models.TaiKhoan tk)
        {
            if(ModelState.IsValid)
            {
                var tks = convertTKClient(tk);
                client.dangkytaikhoanAsync(tks);
                return RedirectToAction("viewTK");
            }
            return View();
        }

        //Get Doi tac
        public ActionResult viewDT()
        {
            var a = client.getAllDoiTac();
            List<Models.Doitac> dt = new List<Models.Doitac>();
            foreach (var i in a)
            {
                dt.Add(convertDTService(i));
            }

            return View(dt);
        }
        public ActionResult createDT()
        {
            var listMaTK = new List<string>();
            var a = (from i in client.getAllTK()
                     orderby i.MaTK
                     select i.MaTK
                     );
            listMaTK.AddRange(a);
            ViewBag.MaTK = new SelectList(listMaTK);
            return View();
        }
        [HttpPost]
        public ActionResult createDT(Models.Doitac dt)
        {
            if (ModelState.IsValid)
            {
                var dts = convertDTClient(dt);
                client.dangkyDoitacAsync(dts);
                return RedirectToAction("viewDT");
            }
            return View();
        }
        //Get Khach Hang
        public ActionResult viewKH()
        {
            var a = client.getAllKH();
            List<Models.KhachHang> tk = new List<Models.KhachHang>();
            foreach (var i in a)
            {
                tk.Add(convertKHService(i));
            }

            return View(tk);
        }
        public ActionResult createKH()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult createKH(Models.KhachHang tk)
        {
            if (ModelState.IsValid)
            {
                var tks = convertKHClient(tk);
                client.dangkyKH(tks);
                return RedirectToAction("ViewKH");
            }
            return View();
        }

        //Get Don Hang
        public ActionResult viewDH()
        {
            var a = client.getAllDH();
            List<Models.DonHang> tk = new List<Models.DonHang>();
            foreach (var i in a)
            {
                tk.Add(convertDHService(i));
            }

            return View(tk);
        }
        public ActionResult createDH()
        {
            var listMaKH = new List<string>();
            var a = (from i in client.getAllKH()
                     orderby i.MaKH
                     select i.MaKH
                     );
            listMaKH.AddRange(a);
            ViewBag.MaKH = new SelectList(listMaKH);

            var listMaDT = new List<string>();
            var b = (from i in client.getAllDoiTac()
                     orderby i.MaDT
                     select i.MaDT
                     );
            listMaDT.AddRange(b);
            ViewBag.MaDT = new SelectList(listMaDT);

            return View();
        }
        [HttpPost]
        public ActionResult createDH(Models.DonHang dh)
        {
            if (ModelState.IsValid)
            {
                dh.statusDH = "đang chờ";
                var tks = convertDHClient(dh);
                client.dangkyDonHang(tks);
                return RedirectToAction("ViewDH");
            }
            return View();
        }
        // Payment
        public ActionResult viewPay()
        {
            return View();
        }
        public ActionResult createPay(bool? a)
        {
            if(a==true)
            {
                ViewBag.check = false;
            }
            else
            {
                ViewBag.check = true;
            }
            return View();
        }
        [HttpPost]
        public ActionResult createPay(Models.checkKHPay p)
        {
            if (ModelState.IsValid)
            {
                var a=client.checkKH(p.MaKH, p.MaPin);
                if(a)
                {
                    var b = client.getAllDH().Where(o => o.MaDH == p.MaDH && o.MaKH==p.MaKH);
                    var c = b.Single();
                    var e = client.getAllKH().Where(o => o.MaKH == p.MaKH).Single();
                    var f = e.SoTienTK - c.SoTien;
                    if (b.Count()>0&&c.statusDH.Equals("đang chờ")&& f>0)
                    {
                        ServiceReference1.Payment pm = new ServiceReference1.Payment();
                        pm.MaDH = c.MaDH;
                        pm.Ngay = DateTime.Now;
                        pm.Phi = autoPhi(c.SoTien);
                        pm.TenGD = "Thanh toán thành công";
                        client.thanhtoanKH(pm);
                        var d = convertPayService(pm);
                        d.MaKH = c.MaKH;
                        d.MaDT = c.MaDT;
                        Session["payment"] = d;
                        return RedirectToAction("viewPay");
                    }
                    else
                    {
                        return RedirectToAction("createPay", new { a = true });
                    }

                }
                else
                {
                    return RedirectToAction("createPay",new { a=true });
                }
            }
            return View();
        }


        //Convert Client to Service and Service to Client
        public ServiceReference1.TaiKhoan convertTKClient(Models.TaiKhoan tk)
        {
            ServiceReference1.TaiKhoan tkhoan = new ServiceReference1.TaiKhoan();
            tkhoan.MaTK = tk.MaTK;
            tkhoan.SoTien = tk.SoTien;
            return tkhoan;
        }
        public ServiceReference1.DoiTac convertDTClient(Models.Doitac dt)
        {
            ServiceReference1.DoiTac dtac = new ServiceReference1.DoiTac();
            dtac.MaTK = dt.MaTK;
            dtac.MaDT = dt.MaDT;
            dtac.MKDT = dt.MKDT;
            return dtac;
        }
        public ServiceReference1.KhachHang convertKHClient(Models.KhachHang kh)
        {
            ServiceReference1.KhachHang khang = new ServiceReference1.KhachHang();
            khang.MaKH = kh.MaKH;
            khang.SoTienTK = kh.SoTienTK;
            khang.MaPin = kh.MaPin;
            return khang;
        }
        public ServiceReference1.DonHang convertDHClient(Models.DonHang dh)
        {
            ServiceReference1.DonHang dhang = new ServiceReference1.DonHang();
            dhang.MaDH = dh.MaDH;
            dhang.MaDT = dh.MaDT;
            dhang.MaKH = dh.MaKH;
            dhang.SoTien = dh.SoTien;
            dhang.statusDH = dh.statusDH;
            return dhang;
        }
        public ServiceReference1.Payment convertPayClient(Models.Payment py)
        {
            ServiceReference1.Payment pay = new ServiceReference1.Payment();
            pay.MaDH = py.MaDH;
            pay.Ngay = py.Ngay;
            pay.Phi = py.Phi;
            pay.TenGD=py.TenGD;
            return pay;
        }

        public Models.TaiKhoan convertTKService(ServiceReference1.TaiKhoan tk)
        {
            Models.TaiKhoan tkhoan = new Models.TaiKhoan();
            tkhoan.MaTK = tk.MaTK;
            tkhoan.SoTien = tk.SoTien;
            return tkhoan;
        }
        public Models.Doitac convertDTService(ServiceReference1.DoiTac dt)
        {
            Models.Doitac dtac = new Models.Doitac();
            dtac.MaTK = dt.MaTK;
            dtac.MaDT = dt.MaDT;
            dtac.MKDT = dt.MKDT;
            return dtac;
        }
        public Models.KhachHang convertKHService(ServiceReference1.KhachHang kh)
        {
            Models.KhachHang khang = new Models.KhachHang();
            khang.MaKH = kh.MaKH;
            khang.SoTienTK = kh.SoTienTK;
            khang.MaPin = kh.MaPin;
            return khang;
        }
        public Models.DonHang convertDHService(ServiceReference1.DonHang dh)
        {
            Models.DonHang dhang = new Models.DonHang();
            dhang.MaDH = dh.MaDH;
            dhang.MaDT = dh.MaDT;
            dhang.MaKH = dh.MaKH;
            dhang.SoTien = dh.SoTien;
            dhang.statusDH = dh.statusDH;
            return dhang;
        }
        public Models.Payment convertPayService(ServiceReference1.Payment py)
        {
            Models.Payment pay = new Models.Payment();
            pay.MaDH = py.MaDH;
            pay.Ngay = py.Ngay;
            pay.Phi = py.Phi;
            pay.TenGD = py.TenGD;
            return pay;
        }

        //xxxx
        public decimal autoPhi(decimal tien)
        {
            if(tien <= 100000)
            {
                return 10000;
            }
            if(tien > 100000 && tien <= 500000)
            {
                return tien*2/100;
            }
            if(tien > 500000 && tien <= 1000000)
            {
                return tien * 15 / 1000;
            }
            if (tien > 1000000 && tien <= 5000000)
            {
                return tien /100;
            }
                return tien*5/1000;
        }
        public IEnumerable<LichSuGD> getLSGD () {
            List<Models.Payment> pm = new List<Models.Payment>();
            List<Models.DonHang> dh = new List<Models.DonHang>();
            List<Models.KhachHang> kh = new List<Models.KhachHang>();
            List<Models.Doitac> dt = new List<Models.Doitac>();

            foreach (var i in client.getAllPay()) { pm.Add(convertPayService(i)); }
            foreach (var i in client.getAllDH()) { dh.Add(convertDHService(i)); }
            foreach (var i in client.getAllKH()) { kh.Add(convertKHService(i)); }
            foreach (var i in client.getAllDoiTac()) { dt.Add(convertDTService(i)); }
            var product = (from p in pm
                           join d in dh on p.MaDH equals d.MaDH
                           join k in kh on d.MaKH equals k.MaKH
                           join dta in dt on d.MaDT equals dta.MaDT
                           select new LichSuGD { pay = p, khachhang = k, doitac = dta, donhang = d }
                           );
            return product;
        }
    }
}