using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Writer
    {
        //[Key] alternatif primary key yolu ayrıca foreign key de yapar
        public int WriterId { get; set; }
        public string WriterName { get; set; }
    //    public virtual ICollection<Book> Book { get; set; }
    }
}
