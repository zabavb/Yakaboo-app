using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Yakaboo.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }

        [Range(1, 5000)]
        public int Size { get; set; }
        public float Price { get; set; }
        public int? AuthorID { get; set; }
        public int? PublisherID { get; set; }
    }
}