using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EAPPracServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPracticeServices" in both code and config file together.
    [ServiceContract]
    public interface IPracticeServices
    {
        [OperationContract]
        void setStudent(Student st);
        [OperationContract]
        List<Student> getAllStudent();
    }
}
