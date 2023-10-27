using HotelRoomManager.Models;

namespace HotelRoomManager.Dtos
{
    public class HotelDetailsDto
    {
        public Hotel Hotel { get; set; }
        public List<Room> Rooms { get; set; }
    }
}
