using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JapaneseBook.Model
{
    [Table("Menus")]
    public class Menu
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public int DisplayOrder { get; set; }

        public int GroupID { get; set; }

        public string Target { get; set; }

        public bool Status { get; set; }
    }
}
