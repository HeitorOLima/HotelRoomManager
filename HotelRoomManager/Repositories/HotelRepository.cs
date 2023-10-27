using HotelRoomManager.Data;
using HotelRoomManager.Interfaces;
using HotelRoomManager.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelRoomManager.Repositories
{
    public class HotelRepository : IHotelRepository
	{
		private readonly ApplicationDbContext _dbContext;

		public HotelRepository(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task CreateAsync(Hotel model)
		{
			await _dbContext.AddAsync(model);
			await _dbContext.SaveChangesAsync();
		}

		public async Task DeleteAsync(Hotel model)
		{
			_dbContext.Remove(model);
			await _dbContext.SaveChangesAsync();
		}
		public async Task UpdateAsync(Hotel model)
		{	
			_dbContext.Entry(model).State = EntityState.Modified;
			_dbContext.Update(model);

			await _dbContext.SaveChangesAsync();
		}

		public async Task<List<Hotel>> GetAllAsync()
		{
			try
			{
				return await _dbContext.Hotel.Include(x=> x.ImageFiles)
											 .AsNoTracking()
											 .ToListAsync();
			}
			catch (Exception ex)
			{

				throw;
			}
		}

		public async Task<Hotel> GetByIdAsync(int id)
		{
			return await _dbContext.Hotel.Include(a=> a.ImageFiles)
										 .FirstOrDefaultAsync(a=> a.Id == id);
		}

	}
}
