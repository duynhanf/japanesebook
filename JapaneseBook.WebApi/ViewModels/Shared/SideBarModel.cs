using JapaneseBook.Model.Entities;
using System.Collections.Generic;

namespace JapaneseBook.WebApi.ViewModels.Shared
{
    public class SideBarModel
    {
        public List<Menu> listMenu1 { get; set; }

        public SideBarModel()
        {
            listMenu1 = new List<Menu>();
        }
    }
}