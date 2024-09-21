using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yakaboo.Models;

namespace Yakaboo.CRUD
{
    public class AuthorAdapter : ICRUD
    {
        public void Add(Context context, AddOrEdit addOrEditForm)
        {
            context.Authors.Add(addOrEditForm._Author);
            context.SaveChanges();
        }

        public object Select(Context context, string text)
        {
            List<Author> authors = new List<Author>();
            if (!string.IsNullOrEmpty(text))
            {
                int id = 0;
                if (int.TryParse(text, out id))
                    authors = context.Authors.AsQueryable().Where(item => item.ID == id).AsParallel().ToList();
                else
                    authors = context.Authors.AsQueryable().Where(item => item.Name == text || item.Surname == text || text == item.Name + " " + item.Surname ).AsParallel().ToList();
            }

            return authors;
        }

        public void Update(Context context, AddOrEdit addOrEditForm)
        {
            Author author = context.Authors.AsQueryable().AsParallel().FirstOrDefault(item => item.ID == Extension.SelectedItemID);
            
            author.Name = addOrEditForm._Author.Name;
            author.Surname = addOrEditForm._Author.Surname;
            
            context.SaveChanges();
        }

        public void Delete(Context context)
        {
            context.Authors.Remove(context.Authors.AsQueryable().AsParallel().FirstOrDefault(item => item.ID == Extension.SelectedItemID));
            context.SaveChanges();
        }
    }
}