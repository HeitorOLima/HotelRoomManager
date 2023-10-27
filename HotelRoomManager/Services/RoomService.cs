using AutoMapper;
using HotelRoomManager.Dtos;
using HotelRoomManager.Interfaces;
using HotelRoomManager.Models;

namespace HotelRoomManager.Services
{
	public class RoomService : IRoomService
	{

		private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;

        public RoomService(IRoomRepository roomRepository, IMapper mapper)
		{
            _roomRepository = roomRepository;
			_mapper = mapper;
		}

		public async Task CreateRoomAsync(RoomDto model)
		{
			var room = _mapper.Map<Room>(model);
			await _roomRepository.CreateAsync(room);
        }

		public async Task DeleteRoomAsync(Room model)
		{
			await _roomRepository.DeleteAsync(model);
		}

		public async Task<Room> GetRoomById(int id, bool isRoomDtoRequired = false)
		{
			return await _roomRepository.GetByIdAsync(id);
		}

		public async Task<List<Room>> GetRoomList()
		{
			return await _roomRepository.GetAllAsync();
		}
		public async Task<List<Room>> GetAllRoomsByHotelIdAsync(int id)
		{
			return await _roomRepository.GetAllByHotelIdAsync(id);
		}

        public async Task UpdateRoomAsync(int id, RoomDto model)
		{
			var room = await _roomRepository.GetByIdAsync(id);
			_mapper.Map(model, room);
			
			await _roomRepository.UpdateAsync(room);
		}

		public RoomDto ConvertToRoomDto(Room model)
		{
			return _mapper.Map<RoomDto>(model);
		}
    }
}
