using HotelRoomManager.Dtos;
using HotelRoomManager.Models;

namespace HotelRoomManager.Interfaces
{
	public interface IHotelService
	{
		Task CreateHotelAsync(HotelDto model);
		Task DeleteHotelAsync(int id);
		Task UpdateHotelAsync(int id, HotelDto model);
		Task<List<Hotel>> GetHotelList();
		Task<Hotel> GetHotelById(int id);
		Task<List<Hotel>> GetHotelListByName(string name);


    }
}
