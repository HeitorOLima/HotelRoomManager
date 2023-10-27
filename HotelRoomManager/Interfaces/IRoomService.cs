using HotelRoomManager.Dtos;
using HotelRoomManager.Models;

namespace HotelRoomManager.Interfaces
{
	public interface IRoomService
	{
		Task CreateRoomAsync(RoomDto model);
		Task DeleteRoomAsync(Room model);
		Task UpdateRoomAsync(int id, RoomDto model);
		Task<List<Room>> GetAllRoomsByHotelIdAsync(int id);
        Task<List<Room>> GetRoomList();
		Task<Room> GetRoomById(int id, bool isRoomDtoRequired = false);
		RoomDto ConvertToRoomDto(Room model);

    }
}
