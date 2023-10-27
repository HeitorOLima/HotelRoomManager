using HotelRoomManager.Models;

namespace HotelRoomManager.Interfaces
{
	public interface IHotelRepository
	{
		Task CreateAsync(Hotel model);
		Task UpdateAsync(Hotel model);
		Task DeleteAsync(Hotel model);
		Task<Hotel> GetByIdAsync(int id);
		Task<List<Hotel>> GetAllAsync();
	}
}
