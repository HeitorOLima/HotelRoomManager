using System.ComponentModel.DataAnnotations;

namespace HotelRoomManager.Dtos
{
    public class HotelDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^\d{2}\.\d{3}\.\d{3}\/\d{4}-\d{2}$", ErrorMessage = "CNPJ inválido")]
        public string CNPJ { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Description { get; set; }
        public List<IFormFile> ImageFiles { get; set; }
    }
}
