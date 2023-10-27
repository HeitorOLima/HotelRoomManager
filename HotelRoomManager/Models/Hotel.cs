using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelRoomManager.Models
{
    public class Hotel
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id{ get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        public string CNPJ { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Description { get; set; }
        
        public List<HotelImage> ImageFiles{ get; set; }
    }
}
