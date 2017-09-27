using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class BookAuthor
    {
        public int ID { get; set; }
        public string BookName { get; set; }
        public int? Prices { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string AuthorName { get; set; }

    }
}
