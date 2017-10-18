using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PaymentServiceASM
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPaymentService" in both code and config file together.
    [ServiceContract]
    public interface IPaymentService
    {
      //  [OperationContract]
      // // [WebInvoke(Method = "GET",
      // //     RequestFormat = WebMessageFormat.Json,
      // //     ResponseFormat = WebMessageFormat.Json
      //  //    )]
      //  LichSuGD getLichSuGd(int MGD);

      //  [OperationContract]
      ////  [WebInvoke(Method = "GET",
      ////      ResponseFormat = WebMessageFormat.Json,
      ////      RequestFormat = WebMessageFormat.Json)]
      //  List<LichSuGD> getVanTinLichSuDT(DateTime dt1,DateTime dt2,string MDT);

      //  [OperationContract]
      //  //  [WebInvoke(Method = "GET",
      //  //      ResponseFormat = WebMessageFormat.Json,
      //  //      RequestFormat = WebMessageFormat.Json)]
      //  List<LichSuGD> getVanTinLichSuKH(DateTime dt1, DateTime dt2, string MDT);
        [OperationContract]
      //  [WebInvoke(Method = "POST",
       //     RequestFormat = WebMessageFormat.Json,
      //      ResponseFormat = WebMessageFormat.Json)]
        void dangkyDonHang(DonHang dh);

        [OperationContract]
       // [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void thanhtoanKH(Payment pm);

        [OperationContract]
        // [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<Payment> getAllPay();

        [OperationContract]
       // [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        void dangkyDoitac(DoiTac dt);

        [OperationContract]
       // [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<DoiTac> getAllDoiTac();

        [OperationContract]
       // [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void dangkytaikhoan(TaiKhoan tk);

        [OperationContract]
       // [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<TaiKhoan> getAllTK();

        [OperationContract]
       // [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void dangkyKH(KhachHang kh);

        [OperationContract]
       // [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<KhachHang> getAllKH();

        [OperationContract]
       // [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool checkDT(string madt,string mkdt);

        [OperationContract]
       // [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool checkKH(string makh,int mapin);

        [OperationContract]
        // [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<DonHang> getAllDH();
    }
}
