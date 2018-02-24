using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace JapaneseBook.Model.Entities
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base()
        {
        }

        [StringLength(250)]
        public string Description { set; get; }
    }
}