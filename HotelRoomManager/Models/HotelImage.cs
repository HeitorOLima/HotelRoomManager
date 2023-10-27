using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelRoomManager.Models
{
	public class HotelImage
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string ImageBase64 { get; set; }
		[JsonIgnore]
        public Hotel Hotel{ get; set; }
		
	}
}
