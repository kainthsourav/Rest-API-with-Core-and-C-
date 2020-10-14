using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using CoffeeShopApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CoffeeShopApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MenusController : ControllerBase
    {
        private ExpressoDbContext expressoDb;
        public MenusController(ExpressoDbContext expresso)
        {
            expressoDb = expresso;
        }

        [HttpGet]
        public IActionResult GetMenus()
        {
            var menus = expressoDb.Menus.Include("SubMenus");
            return Ok(menus);
        } 
        
        [HttpGet("{id}")]
        public IActionResult GetMenu(int id)
        {
            var menus = expressoDb.Menus.Include("SubMenus").FirstOrDefault(m => m.id == id);
            if(menus==null)
            {
                return NotFound();
            }
            return Ok(menus);
        }
    }
}
