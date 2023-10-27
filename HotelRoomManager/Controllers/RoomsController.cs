using HotelRoomManager.Dtos;
using HotelRoomManager.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelRoomManager.Controllers
{
    public class RoomsController : Controller
    {
        private readonly IRoomService _roomService;

        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var room = await _roomService.GetRoomById(id);

                if (room == null)
                    return NotFound();

                return View(room);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
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
        public async Task<IActionResult> Create(int id, [Bind("Name,NumberOfOccupants,NumberOfAdults,NumberOfChildrem,Price,ImageFiles")] RoomDto room)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    room.HotelId = id;
                    await _roomService.CreateRoomAsync(room);
                    return RedirectToAction($"Details", "Hotels", new { id = id });
                }
                catch
                {
                    return RedirectToAction("Error", "Home");
                }
            }
            return View(room);
        }


        [Authorize("LoggedIn")]
        public async Task<IActionResult> Edit(int id, int hotelId)
        {
            try
            {
                var room = await _roomService.GetRoomById(id, true);
            
                if (room == null)
                    return NotFound();
            
                return View(room);
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize("LoggedIn")]
        public async Task<IActionResult> Edit(int id, [Bind("HotelId,Name,NumberOfOccupants,NumberOfAdults,NumberOfChildrem,Price,ImageFiles")] RoomDto room)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    await _roomService.UpdateRoomAsync(id, room);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction("Details", "Rooms", new { Id = id});
            }
            return View(room);
        }


        [Authorize("LoggedIn")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var room = await _roomService.GetRoomById(id);
            
                if (room == null)
                    return NotFound();

                return View(room);
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
                var room = await _roomService.GetRoomById(id);
                var hotelId = room.HotelId;
                if (room != null)
                    await _roomService.DeleteRoomAsync(room);
            
                return RedirectToAction("Details", "Hotels", new { id = hotelId });
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
        }
    }
}
