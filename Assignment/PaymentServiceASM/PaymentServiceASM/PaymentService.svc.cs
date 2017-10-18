using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PaymentServiceASM
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PaymentService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PaymentService.svc or PaymentService.svc.cs at the Solution Explorer and start debugging.
    public class PaymentService : IPaymentService
    {
        PaymentDataASMDataContext data = new PaymentDataASMDataContext();

        public void dangkyDoitac(DoiTac dt)
        {
            data.DoiTacs.InsertOnSubmit(dt);
            data.SubmitChanges();
        }
        public void dangkytaikhoan(TaiKhoan tk)
        {
            data.TaiKhoans.InsertOnSubmit(tk);
            data.SubmitChanges();
        }
        public void dangkyKH(KhachHang kh)
        {
            data.KhachHangs.InsertOnSubmit(kh);
            data.SubmitChanges();
        }

        public void dangkyDonHang(DonHang dh)
        {
            data.DonHangs.InsertOnSubmit(dh);
            data.SubmitChanges();
        }
        
        public LichSuGD getLichSuGd(int MGD)
        {
            try
            {
                LichSuGD lsgd = new LichSuGD();
                if (data.Payments.Where(a => a.MaGD == MGD).Count() != 0)
                {
                    DateTime date = new DateTime();
                    Payment pm = data.Payments.Where(a => a.MaGD == MGD).Single();
                    DonHang dh = data.DonHangs.Where(a => a.MaDH == pm.MaDH).Single();
                    lsgd.MGD = MGD;
                    lsgd.ngay = date;
                    lsgd.phi = pm.Phi;
                    lsgd.sotien = dh.SoTien;
                    return lsgd;
                } else { return null; }
            }
            catch { return null; }
        }

        public List<LichSuGD> getVanTinLichSuDT(DateTime dt1,DateTime dt2,string MDT)
        {
            try
            {
                LichSuGD lsgd = new LichSuGD();
                List<LichSuGD> listLSGD = new List<LichSuGD>();
                var dh = (from a in data.Payments join b in data.DonHangs on a.MaDH equals b.MaDH where b.MaDT == MDT select new {a,b});
                if (dh.Count() != 0)
                {
                    var filter = dh.Where(a => a.a.Ngay > dt1 && a.a.Ngay < dt2);
                    foreach(var i in filter)
                    {
                        lsgd.MGD = i.a.MaGD;
                        lsgd.ngay = i.a.Ngay;
                        lsgd.phi = i.a.Phi;
                        lsgd.sotien = i.b.SoTien;
                        listLSGD.Add(lsgd);
                    }
                    return listLSGD;
                }
                else { return null; }
            }
            catch { return null; }
        }
        public List<LichSuGD> getVanTinLichSuKH(DateTime dt1, DateTime dt2, string KH)
        {
            try
            {
                LichSuGD lsgd = new LichSuGD();
                List<LichSuGD> listLSGD = new List<LichSuGD>();
                var dh = (from a in data.Payments join b in data.DonHangs on a.MaDH equals b.MaDH where b.MaKH == KH select new { a, b });
                if (dh.Count() != 0)
                {
                    var filter = dh.Where(a => a.a.Ngay > dt1 && a.a.Ngay < dt2);
                    foreach (var i in filter)
                    {
                        lsgd.MGD = i.a.MaGD;
                        lsgd.ngay = i.a.Ngay;
                        lsgd.phi = i.a.Phi;
                        lsgd.sotien = i.b.SoTien;
                        listLSGD.Add(lsgd);
                    }
                    return listLSGD;
                }
                else { return null; }
            }
            catch { return null; }
        }

        public void thanhtoanKH(Payment pm)
        {
            data.Payments.InsertOnSubmit(pm);
            var a = (from k in data.KhachHangs
                     join d in data.DonHangs on k.MaKH equals d.MaKH
                     where d.MaDH == pm.MaDH
                     select new
                     {
                         k,d.SoTien
                     }
                   ).Single();
            a.k.SoTienTK = a.k.SoTienTK - pm.Phi - a.SoTien;
            var b = (from dt in data.DoiTacs
                     join dh in data.DonHangs on dt.MaDT equals dh.MaDT
                     join tk in data.TaiKhoans on dt.MaTK equals tk.MaTK
                     where dh.MaDH == pm.MaDH
                     select tk
                   ).Single();
            b.SoTien = b.SoTien - pm.Phi;
            var c = (from d in data.DonHangs
                     where d.MaDH == pm.MaDH
                     select d
                    ).Single();
            c.statusDH = "thành công";
            data.SubmitChanges();
        }
        public bool checkDT(string madt,string mkdt)
        {
            var dtac = (from a in data.DoiTacs where a.MaDT == madt select a);
            if (dtac != null)
            {
                foreach (var i in dtac)
                {
                    if (i.MKDT == mkdt)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool checkKH(string makh,int mapin)
        {
            var khang = (from a in data.KhachHangs where a.MaKH == makh select a);
            if (khang != null)
            {
                foreach (var i in khang)
                {
                    if (i.MaPin == mapin)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public List<DoiTac> getAllDoiTac()
        {
            try
            {
                List<DoiTac> dt = new List<DoiTac>();
                foreach(var i in data.DoiTacs)
                {
                    dt.Add(i);
                }
                return dt;
            }
            catch { return null; }
        }

        public List<TaiKhoan> getAllTK()
        {
            try
            {
                List<TaiKhoan> dt = new List<TaiKhoan>();
                foreach (var i in data.TaiKhoans)
                {
                    dt.Add(i);
                }
                return dt;
            }
            catch { return null; }
        }

        public List<KhachHang> getAllKH()
        {
            try
            {
                List<KhachHang> dt = new List<KhachHang>();
                foreach (var i in data.KhachHangs)
                {
                    dt.Add(i);
                }
                return dt;
            }
            catch { return null; }
        }

        public List<DonHang> getAllDH()
        {
            try
            {
                List<DonHang> dt = new List<DonHang>();
                foreach (var i in data.DonHangs)
                {
                    dt.Add(i);
                }
                return dt;
            }
            catch { return null; }
        }

        public List<Payment> getAllPay()
        {
            try
            {
                List<Payment> dt = new List<Payment>();
                foreach (var i in data.Payments)
                {
                    dt.Add(i);
                }
                return dt;
            }
            catch { return null; }
        }
    }
}
