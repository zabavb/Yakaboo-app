using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yakaboo.Models;

namespace Yakaboo.CRUD
{
    public class PublisherAdapter : ICRUD
    {
        public void Add(Context context, AddOrEdit addOrEditForm)
        {
            context.Publishers.Add(addOrEditForm._Publisher);
            context.SaveChanges();
        }

        public object Select(Context context, string text)
        {
            List<Publisher> publishers = new List<Publisher>();
            if (!string.IsNullOrEmpty(text))
            {
                float number = 0;
                if (float.TryParse(text, out number))
                    publishers = context.Publishers.AsQueryable().Where(item => item.ID == number).AsParallel().ToList();
                else
                    publishers = context.Publishers.AsQueryable().Where(item => item.Name == text || item.Address == text).AsParallel().ToList();
            }

            return publishers;
        }

        public void Update(Context context, AddOrEdit addOrEditForm)
        {
            Publisher publisher = context.Publishers.AsQueryable().AsParallel().FirstOrDefault(item => item.ID == Extension.SelectedItemID);
            
            publisher.Name = addOrEditForm._Publisher.Name;
            publisher.Address = addOrEditForm._Publisher.Address;
            
            context.SaveChanges();
        }

        public void Delete(Context context)
        {
            context.Publishers.Remove(context.Publishers.AsQueryable().AsParallel().FirstOrDefault(item => item.ID == Extension.SelectedItemID));
            context.SaveChanges();
        }
    }
}