using System.ComponentModel.DataAnnotations;

namespace HotelRoomManager.Dtos
{
    public class RoomDto
	{

        [Required]
        public int HotelId { get; set; }

        [Required]
        public string Name{ get; set; }

        [Required]
        public int NumberOfOccupants { get; set; }

        [Required]
        public int NumberOfAdults { get; set; }

        [Required]
        public int NumberOfChildrem { get;set; }

        [Required]
        public decimal Price {  get; set; }
        
        public List<IFormFile> ImageFiles { get; set; }

    }
}
