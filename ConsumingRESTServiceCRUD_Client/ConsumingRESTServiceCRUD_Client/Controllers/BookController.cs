using ConsumingRESTServiceCRUD_Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConsumingRESTServiceCRUD_Client.Controllers
{
    public class BookController : Controller
    {
        BookServiceClient bsc = new BookServiceClient();
        // GET: Book
        public ActionResult Index()
        {
            ViewBag.listBooks = bsc.getAllBook();
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Book book)
        {
            bsc.AddBook(book);
            return RedirectToAction("Index","Book");
        }
        public ActionResult Delete(int id)
        {
            bsc.DeleteBook(id);
            return RedirectToAction("Index", "Book");
        }
        public ActionResult Edit(int id)
        {
            var book =bsc.getAllBook().Where(b => b.BookId==id).FirstOrDefault();
            return View(book);
        }
        [HttpPost]
        public ActionResult Edit(Book book)
        {
            bsc.Edit(book);
            return RedirectToAction("Index", "Book");
        }
    }
}