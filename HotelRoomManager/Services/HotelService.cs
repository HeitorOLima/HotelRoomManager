using AutoMapper;
using HotelRoomManager.Dtos;
using HotelRoomManager.Interfaces;
using HotelRoomManager.Models;

namespace HotelRoomManager.Services
{
	public class HotelService : IHotelService
	{

		private readonly IHotelRepository _hotelRepository;
        private readonly IMapper _mapper;

        public HotelService(IHotelRepository hotelRepository, IMapper mapper)
		{
			_hotelRepository = hotelRepository;
			_mapper = mapper;
		}

		public async Task CreateHotelAsync(HotelDto model)
		{
			var hotel = _mapper.Map<Hotel>(model);
			await _hotelRepository.CreateAsync(hotel);
        }

		public async Task DeleteHotelAsync(int id)
		{
			var hotel = await _hotelRepository.GetByIdAsync(id);
			await _hotelRepository.DeleteAsync(hotel);
		}

		public async Task<Hotel> GetHotelById(int id)
		{
			return await _hotelRepository.GetByIdAsync(id);
		}

		public async Task<List<Hotel>> GetHotelListByName(string name)
		{
			var hotelList = await _hotelRepository.GetAllAsync();
			
			if(!string.IsNullOrEmpty(name))
				hotelList = hotelList.Where(x=> x.Name.ToUpper().Replace(" ","").Contains(name.ToUpper().Replace(" ",""))).ToList();

			return hotelList;
		}

		public async Task<List<Hotel>> GetHotelList()
		{
			return await _hotelRepository.GetAllAsync();
		}

		public async Task UpdateHotelAsync(int id, HotelDto model)
		{
			var hotel = await _hotelRepository.GetByIdAsync(id);
			_mapper.Map(model, hotel);
			
			await _hotelRepository.UpdateAsync(hotel);
		}
	}
}
