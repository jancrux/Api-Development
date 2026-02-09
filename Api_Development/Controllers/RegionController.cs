using Microsoft.AspNetCore.Mvc;
using Api_Development.Models;
using Api_Development.Models.Entities;
using Api_Development.Models.Domain;

namespace Api_Development.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RegionController(AppDbContext context)
        {
            _context = context;
        }

        //[HttpPost]
        //public IActionResult CreateRegion(Region region)
        //{
        //    if (booking.Id == 0)
        //    {
        //        // Inserção
        //        _context..Add(booking);
        //    }
        //    else
        //    {
        //        // Edição
        //        var bookingInDb = _context.Bookings.Find(booking.Id);

        //        if (bookingInDb == null)
        //            return NotFound(new { message = "Reserva não encontrada" });

        //        // Esta é a forma correta de atualizar no EF Core sem mapear campo a campo
        //        _context.Entry(bookingInDb).CurrentValues.SetValues(booking);
        //    }

        //    _context.SaveChanges();

        //    return Ok(booking);
        //}


        //[HttpGet]
        //public IActionResult GetEdit(int Id)
        //{
        //    var result = _context.Bookings.Find(Id);

        //    if (result == null)
        //        return NotFound(new { message = "Reserva não encontrada" });

        //    return new JsonResult(Ok(result));

        //}

        //[HttpDelete]

        //public IActionResult DeleteBooking(int Id)
        //{
        //    var result = _context.Bookings.Find(Id);

        //    if (result == null)
        //        return NotFound(new { message = "Reserva não encontrada" });

        //    _context.Bookings.Remove(result);
        //    _context.SaveChanges();

        //    return new JsonResult();
        //}

    }
}
