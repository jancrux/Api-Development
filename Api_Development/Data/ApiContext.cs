using Microsoft.EntityFrameworkCore;
using Api_Development.Models;


namespace Api_Development.Data
{
    public class ApiContext : DbContext
    {

        public DbSet<HotelBooking> Bookings { get; set; }

        public ApiContext(DbContextOptions<ApiContext> options)
            :base(options) { 
        
        
        }
    }
}
