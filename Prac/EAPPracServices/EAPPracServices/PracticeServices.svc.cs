using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EAPPracServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PracticeServices" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PracticeServices.svc or PracticeServices.svc.cs at the Solution Explorer and start debugging.
    public class PracticeServices : IPracticeServices
    {
        EAPPracDataDataContext sv = new EAPPracDataDataContext();
        public void DoWork()
        {
        }

        public List<Student> getAllStudent()
        {
            List<Student> lst = new List<Student>();
            var i = sv.Students.Where(o=>o.Email==o.Email).ToList();
            lst = i;
            return lst;
        }

        public void setStudent(Student st)
        {
            sv.Students.InsertOnSubmit(st);
            sv.SubmitChanges();
        }
    }
}
