using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JapaneseBook.Model.Entities
{
    [Table("OrderDetails")]
    public class OrderDetail
    {
        [Key]
        [Column(Order = 1)]
        public int OrderID { set; get; }

        [Key]
        [Column(Order = 2)]
        public int BookID { set; get; }

        public int Quantity { set; get; }

        public decimal Price { set; get; }

        [ForeignKey("OrderID")]
        public virtual Order Order { set; get; }

        [ForeignKey("BookID")]
        public virtual Book Book { set; get; }
    }
}