using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab2_Lab3.Models;

namespace Lab2_Lab3.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public string HelloTeacher(string university)
        {
            return "Hello !" + university;
        }

        public ActionResult ListBook()
        {
            var books = new List<string>();
            books.Add("từ điển tiếng việt -Nhà xuất bản Hà Nội");
            books.Add("Từ điển pháp luật -Nhà xuất bản TPHCM");
            books.Add("Từ điển việt pháp- Nhà xuất bản Đà Nẵng");
            ViewBag.Books = books;
            return View();
        }

        public ActionResult ListBookModel()
        {
            var books = new List<Book>();
            books.Add(new Book(1, " từ điển tiếng việt ", "Nhà xuất bản Hà Nội", "Content/Images/a.png"));
            books.Add(new Book(2, "Từ điển pháp luật", "Nhà xuất bản TPHCM", "Content/Images/c.png"));
            books.Add(new Book(3, "Từ điển việt pháp", "Nhà xuất bản Đà Nẵng", "Content/Images/d.png"));
            return View(books);
        }

        public ActionResult EditBook(int id)
        {
            var books = new List<Book>();
            books.Add(new Book(1, " từ điển tiếng việt ", "Nhà xuất bản Hà Nội", "Content/Images/a.png"));
            books.Add(new Book(2, "Từ điển pháp luật", "Nhà xuất bản TPHCM", "Content/Images/c.png"));
            books.Add(new Book(3, "Từ điển việt pháp", "Nhà xuất bản Đà Nẵng", "Content/Images/d.png"));

            Book book = new Book();
            foreach (Book b in books)
            {
                if (b.Id == id)
                {
                    book = b;
                    break;
                }
            }
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        [HttpPost, ActionName("EditBook")]
        [ValidateAntiForgeryToken]
        public ActionResult EditBook(int id, string Title, string Author, string ImageCover )
        {
            var books = new List<Book>();
            books.Add(new Book(1, " từ điển tiếng việt ", "Nhà xuất bản Hà Nội", "Content/Images/a.png"));
            books.Add(new Book(2, "Từ điển pháp luật", "Nhà xuất bản TPHCM", "Content/Images/c.png"));
            books.Add(new Book(3, "Từ điển việt pháp", "Nhà xuất bản Đà Nẵng", "Content/Images/d.png"));
            if (id == null)
            {
                return HttpNotFound();
            }
            foreach (Book b in books)
            {
                if (b.Id == id)
                {
                    b.Title = Title;
                    b.Author = Author;
                    b.ImageCover = ImageCover;
                    break;
                }
            }
            return View("ListBookModel", books);
        }

        public ActionResult CreateBook()
        {
            return View();
        }

        [HttpPost, ActionName("CreateBook")]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include = "id , Title ,Author , ImageCover")] Book book)
        {
            var books = new List<Book>();
            books.Add(new Book(1, " từ điển tiếng việt ", "Nhà xuất bản Hà Nội", "Content/Images/a.png"));
            books.Add(new Book(2, "Từ điển pháp luật", "Nhà xuất bản TPHCM", "Content/Images/c.png"));
            books.Add(new Book(3, "Từ điển việt pháp", "Nhà xuất bản Đà Nẵng", "Content/Images/d.png"));
            try
            {
                if (ModelState.IsValid)
                {
                    
                    books.Add(book);
                }
            }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("", "Error Save Data");
            }
            
            return View("ListBookModel", books);
        }
    }
}
