using CoffeeShopApi.Models;
using System;
using System.Collections.Generic;

namespace CoffeeShopApi
{
    public class Menus
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        public ICollection<SubMenu> SubMenus {get;set;}
    }
}
