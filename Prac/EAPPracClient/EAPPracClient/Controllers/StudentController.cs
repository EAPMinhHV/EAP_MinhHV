using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EAPPracClient.ServiceReference1;

namespace EAPPracClient.Controllers
{
    public class StudentController : Controller
    {
        PracticeServicesClient client = new PracticeServicesClient();
        // GET: Student
        public ActionResult Index()
        {
            List<Models.Student> lst = convertClient(client.getAllStudent().ToList());
            return View(lst);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(Models.Student st)
        {
            try
            {
                // TODO: Add insert logic here
                Student sst = new Student();
                sst.StudentID = st.StudentID;
                sst.FirstName = st.FirstName;
                sst.LastName = st.LastName;
                sst.PhoneNumber = st.Phone;
                sst.Email = st.Email;
                client.setStudent(sst);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        private List<Models.Student> convertClient(List<Student> st)
        {
            List<Models.Student> lst = new List<Models.Student>();
            
            foreach (var i in st)
            {
                Models.Student mst = new Models.Student();
                mst.StudentID = i.StudentID;
                mst.FirstName = i.FirstName;
                mst.LastName = i.LastName;
                mst.Phone = i.PhoneNumber;
                mst.Email = i.Email;
                lst.Add(mst);
            }
            return lst;
        }
    }
}
