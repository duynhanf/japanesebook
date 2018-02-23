using JapaneseBook.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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