using HotelRoomManager.Models;

namespace HotelRoomManager.Interfaces
{
	public interface IRoomRepository
	{
		Task CreateAsync(Room model);
		Task UpdateAsync(Room model);
		Task DeleteAsync(Room model);
		Task<Room> GetByIdAsync(int id);
		Task<List<Room>> GetAllByHotelIdAsync(int id);
        Task<List<Room>> GetAllAsync();
	}
}
