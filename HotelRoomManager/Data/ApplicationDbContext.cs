using HotelRoomManager.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelRoomManager.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<HotelImage> HotelImage { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<RoomImage> RoomImage { get; set; }

    }
}