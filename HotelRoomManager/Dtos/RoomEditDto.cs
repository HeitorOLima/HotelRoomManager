using HotelRoomManager.Models;

namespace HotelRoomManager.Dtos
{
    public class RoomEditDto
    {
        public Room Room { get; set; }
        public int HotelId { get; set; }
    }
}
