using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelRoomManager.Models
{
    public class Room
	{

        [Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

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
        
        public List<RoomImage> ImageFiles { get; set; }

    }
}
