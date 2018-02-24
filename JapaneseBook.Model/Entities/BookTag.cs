using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JapaneseBook.Model.Entities
{
    [Table("BookTags")]
    public class BookTag
    {
        [Key]
        [Column(Order = 1)]
        public int BookID { set; get; }

        [Key]
        [Column(TypeName = "varchar", Order = 2)]
        [MaxLength(50)]
        public string TagID { set; get; }

        [ForeignKey("BookID")]
        public virtual Book Book { set; get; }

        [ForeignKey("TagID")]
        public virtual Tag Tag { set; get; }
    }
}