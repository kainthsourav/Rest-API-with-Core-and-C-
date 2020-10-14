using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeShopApi.Data;
using CoffeeShopApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private ExpressoDbContext expressoDb;

        public ReservationsController(ExpressoDbContext expressoDbContext)
        {
            expressoDb = expressoDbContext;
        }

        [HttpPost]
        public IActionResult Post(Reservation reservation)
        {
            
            expressoDb.Reservations.Add(reservation);
            expressoDb.SaveChanges();
            return StatusCode(201);
        }
        [HttpGet]
        public IActionResult GetReservation()
        {
            var reservations = expressoDb.Reservations;
            return Ok(reservations);
        }
    }
}
