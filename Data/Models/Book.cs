using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Book
    {
        //[Key] alternatif primary key yolu
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string BookShelf { get; set; }
        public int WriterId { get; set; }
        public virtual Writer Writer { get; set; }
    }
}
