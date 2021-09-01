using System;
using Data.Models;
using Data.Context;
using DataAccess.Repository;
using DataAccess.UnitOfWork;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Business
{
    public class BookBus
    {
        WriterBus writerBus = new WriterBus();
        public List<Book> GetAll()
        {
           using(UnitOfWork unitOfWork = new UnitOfWork())
            {
                var result = from p in unitOfWork.GetRepository<Book>().GetAll()
                             join c in unitOfWork.GetRepository<Writer>().GetAll()
                             on p.WriterId equals c.WriterId
                             select new Book()
                             {
                                 BookId = p.BookId,
                                 BookName = p.BookName,
                                 BookShelf = p.BookShelf,
                                 WriterId = p.WriterId,
                                 Writer = new Writer
                                 {
                                     WriterId = c.WriterId,
                                     WriterName = c.WriterName,
                                 }
                             };
                return result.ToList();
                //return unitOfWork.BookAndWriterJoin();

                //var GetBooks = unitOfWork.GetRepository<Book>().GetAll().ToList();
                //foreach (var item in GetBooks)
                //{
                //    item.Writer = writerBus.Get(item.WriterId);
                //}
                //return GetBooks;
            }
        }

        public List<Book> GetAllWithCondiction(string text)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var result = from p in unitOfWork.GetRepository<Book>().GetAll(x => x.BookName.Contains(text)).OrderBy(x => x.BookId)
                             join c in unitOfWork.GetRepository<Writer>().GetAll()
                             on p.WriterId equals c.WriterId
                             select new Book()
                             {
                                 BookId = p.BookId,
                                 BookName = p.BookName,
                                 BookShelf = p.BookShelf,
                                 WriterId = p.WriterId,
                                 Writer = new Writer
                                 {
                                     WriterId = c.WriterId,
                                     WriterName = c.WriterName,
                                 }
                             };
                return result.ToList();

                //List<Book> BookList = new List<Book>();
                //BookList = GetRepository<Book>().GetAll(x => x.BookName.Contains(text)).OrderBy(x => x.BookId).ToList();
                //foreach (var book in BookList)
                //{
                //    book.Writer = GetRepository<Writer>().Get(book.WriterId);
                //}
                //return BookList;
                //return unitOfWork.BookAndWriterJoin(text);
            }
        }

        public Book Get(int id)
        {
            using(UnitOfWork unitOfWork = new UnitOfWork())
            {
                Book book = new Book();
                book = unitOfWork.GetRepository<Book>().Get(id);
                book.Writer = unitOfWork.GetRepository<Writer>().Get(book.WriterId);
                return book;

                //MasterContext master = new MasterContext();  //Kenan abi böyle istiyor

                //var temp = master.Book.Include("Writer").Select(x => new Book()
                //{
                //    BookId = x.BookId,
                //    BookName = x.BookName,
                //    BookShelf = x.BookShelf,
                //    WriterId = x.WriterId,
                //    Writer = new Writer()
                //    {
                //        WriterId = x.Writer.WriterId,
                //        WriterName = x.Writer.WriterName
                //    }
                //}).SingleOrDefault(y => y.BookId == id);

                //return temp;


                //var product = context.Products.Include("Category").Select(b =>   //çalışmıyor
                //    new Book()
                //        {
                //          ProductName = b.ProductName,
                //             CategoryName = b.Category.CategoryName,
                //                 UnitInStock = b.UnitInStock,
                //                 UnitPrice = b.UnitPrice
                //            }).SingleOrDefault(b => b == name);


                //return product;



                //var result = from p in GetRepository<Book>().Get(id)
                //             join c in GetRepository<Writer>().Get(book.WriterId)
                //             on p.WriterId equals c.WriterId

                //             select
                //             new Book()
                //             {
                //                 BookId = p.BookId,
                //                 BookName = p.BookName,
                //                 BookShelf = p.BookShelf,
                //                 WriterId = p.WriterId,
                //                 Writer = new Writer
                //                 {
                //                     WriterId = c.WriterId,
                //                     WriterName = c.WriterName,
                //                 }
                //             };
                //return result;

                //return unitOfWork.GetRepository<Book>().Get(id);
            }
        }

        public string Add(Book book)
        {
            using(UnitOfWork unitOfWork = new UnitOfWork())
            {
                unitOfWork.GetRepository<Book>().Add(book);
                int save = unitOfWork.SaveChanges();
                if (save > 0)
                    return "Basariyla Eklendi";
                else
                    return "Eklenemedi";
            }
        }
        public string Delete(int id)
        {
            using(UnitOfWork unitOfWork = new UnitOfWork())
            {
                unitOfWork.GetRepository<Book>()
                    .Delete(unitOfWork.GetRepository<Book>().Get(id));
                int save = unitOfWork.SaveChanges();
                if (save > 0)
                    return "Basariyla Silindi";
                else
                    return "Silinemedi";
            }
        }

        public string Update(Book book)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                unitOfWork.GetRepository<Book>().Update(book);
                int save = unitOfWork.SaveChanges();
                if (save > 0)
                    return "Basariyla Guncellendi";
                else
                    return "Guncellenemedi";
            }
        }

    }
}
