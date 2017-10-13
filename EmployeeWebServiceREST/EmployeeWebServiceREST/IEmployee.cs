using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EmployeeWebServiceREST
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEmployeeNew" in both code and config file together.
    [ServiceContract]
    public interface IEmployee
    {
        [OperationContract]
        [WebInvoke(Method ="GET",
            ResponseFormat =WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate ="GetProductList/")]
        List<Employee> GetProductList();

        [OperationContract]
        [WebInvoke(Method ="POST",
            ResponseFormat =WebMessageFormat.Json,
            BodyStyle =WebMessageBodyStyle.Bare,
            UriTemplate ="PostEmployee")]
        bool AddEmployee(Employee eml);

        [OperationContract]
        [WebInvoke(Method ="PUT",
            ResponseFormat =WebMessageFormat.Json,
            BodyStyle =WebMessageBodyStyle.Bare,
            UriTemplate ="PutEmployee")]
        bool UpdateEmployee(Employee eml);

        [OperationContract]
        [WebInvoke(Method ="DELETE",
            RequestFormat =WebMessageFormat.Json,
            BodyStyle =WebMessageBodyStyle.Bare,
            UriTemplate ="DeleteEmployee")]
        bool DeleteEmployee(int idE);
    }
}
