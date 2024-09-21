using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yakaboo.Models;

namespace Yakaboo.CRUD
{
    public class BookAdapter : ICRUD
    {
        public void Add(Context context, AddOrEdit addOrEditForm)
        {
            context.Books.Add(addOrEditForm._Book);
            context.SaveChanges();
        }

        public object Select(Context context, string text)
        {
            List<Book> books = new List<Book>();
            if (!string.IsNullOrEmpty(text))
            {
                float number = 0;
                if (float.TryParse(text, out number))
                    books = context.Books.AsQueryable().Where(item => item.ID == number || item.Price == number || item.Size == number).AsParallel().ToList();
                else
                {
                    Author author = context.Authors.AsQueryable().AsParallel().FirstOrDefault(a => a.Name == text || a.Surname == text || text == a.Name + " " + a.Surname);
                    Publisher publisher = context.Publishers.AsQueryable().AsParallel().FirstOrDefault(p => p.Name == text || p.Address == text);

                    if (author == null && publisher == null)
                        books = context.Books.AsQueryable().Where(item => item.Title == text).AsParallel().ToList();
                    else if (author != null)
                        books = context.Books.AsQueryable().Where(item => item.AuthorID == author.ID).AsParallel().ToList();
                    else if (publisher != null)
                        books = context.Books.AsQueryable().Where(item => item.PublisherID == publisher.ID).AsParallel().ToList();
                }
            }

            return books;
        }

        public void Update(Context context, AddOrEdit addOrEditForm)
        {
            Book book = context.Books.AsQueryable().AsParallel().FirstOrDefault(item => item.ID == Extension.SelectedItemID);

            book.Title = addOrEditForm._Book.Title;
            book.Size = addOrEditForm._Book.Size;
            book.Price = addOrEditForm._Book.Price;
            book.PublisherID = addOrEditForm._Book.PublisherID;
            book.AuthorID = addOrEditForm._Book.AuthorID;

            context.SaveChanges();
        }

        public void Delete(Context context)
        {
            context.Books.Remove(context.Books.AsQueryable().AsParallel().FirstOrDefault(item => item.ID == Extension.SelectedItemID));
            context.SaveChanges();
        }
    }
}