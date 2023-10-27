using HotelRoomManager.Dtos;
using HotelRoomManager.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelRoomManager.Controllers
{
    public class HotelsController : Controller
    {
        private readonly IHotelService _hotelService;
        private readonly IRoomService _roomService;

        public HotelsController(IHotelService hotelService, IRoomService roomService)
        {
            _hotelService = hotelService;
            _roomService = roomService; 
        }

        public async Task<IActionResult> Index()
        {
            return await _hotelService.GetHotelList() != null ? 
                        View(await _hotelService.GetHotelList()) :
                        Problem("Entity set 'ApplicationDbContext.Hotel'  is null.");
        }


        public async Task<IActionResult> Details(int id)
        {
            if (await _hotelService.GetHotelList() == null)
                return NotFound();

            try
            {
                var rooms = await _roomService.GetAllRoomsByHotelIdAsync(id);
                var hotel = await _hotelService.GetHotelById(id);

                if (hotel == null)
                    return NotFound();

                return View(new HotelDetailsDto{ Hotel = hotel, Rooms = rooms });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error","Home");
            }
        }
        
        [Authorize("LoggedIn")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize("LoggedIn")]
        public async Task<IActionResult> Create([Bind("Id,Name,CNPJ,Address,Description,ImageFiles")] HotelDto hotel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _hotelService.CreateHotelAsync(hotel);
                    return RedirectToAction(nameof(Index));
                }
            
                return View();
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [Authorize("LoggedIn")]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var hotel = await _hotelService.GetHotelById(id);
                if (hotel == null)
                    return NotFound();
            
                return View(hotel);
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize("LoggedIn")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CNPJ,Address,Description,ImageFiles")] HotelDto hotel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _hotelService.UpdateHotelAsync(id, hotel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }

            return View(hotel);
        }

        [Authorize("LoggedIn")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var hotel = await _hotelService.GetHotelById(id);

                if (hotel == null)
                    return NotFound();

                return View(hotel);
            }
            catch 
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize("LoggedIn")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                if (await  _hotelService.GetHotelList() == null)
                    return Problem("Entity set 'ApplicationDbContext.Hotel'  is null.");
            
                await _hotelService.DeleteHotelAsync(id);
            }
            catch 
            {
                RedirectToAction("Error", "Home"); 
            }
            
            return RedirectToAction(nameof(Index));
        }
    }
}
