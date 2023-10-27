using HotelRoomManager.Data;
using HotelRoomManager.Interfaces;
using HotelRoomManager.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelRoomManager.Repositories
{
    public class RoomRepository : IRoomRepository
	{
		private readonly ApplicationDbContext _dbContext;

		public RoomRepository(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task CreateAsync(Room model)
		{
			await _dbContext.AddAsync(model);
			await _dbContext.SaveChangesAsync();
		}

		public async Task DeleteAsync(Room model)
		{
			_dbContext.Remove(model);
			await _dbContext.SaveChangesAsync();
		}
		public async Task UpdateAsync(Room model)
		{	
			_dbContext.Entry(model).State = EntityState.Modified;
			_dbContext.Update(model);

			await _dbContext.SaveChangesAsync();
		}

		public async Task<List<Room>> GetAllAsync()
		{
			return await _dbContext.Room.Include(x=> x.ImageFiles)
										.AsNoTracking()
										.ToListAsync();
		}

		public async Task<List<Room>> GetAllByHotelIdAsync(int id)
		{
			return  await _dbContext.Room.Where(a=> a.HotelId == id)
										 .Include(a => a.ImageFiles)
										 .ToListAsync();
		}

        public async Task<Room> GetByIdAsync(int id)
        {
			return await _dbContext.Room.Include(x=> x.ImageFiles)
										.FirstOrDefaultAsync(x=> x.Id == id);
        }
    }
}
