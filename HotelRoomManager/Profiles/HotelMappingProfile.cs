using AutoMapper;
using HotelRoomManager.Dtos;
using HotelRoomManager.Models;

namespace HotelRoomManager.Profiles
{
    public class HotelMappingProfile : Profile
    {
        public HotelMappingProfile()
        {
            CreateMap<HotelDto, Hotel>()
                .ForMember(dest => dest.ImageFiles, opt => opt.MapFrom(src => ConvertIFormFileToBase64(src.ImageFiles)));
        }

        private List<HotelImage> ConvertIFormFileToBase64(List<IFormFile> images)
        {
            var hotelImages = new List<HotelImage>();

            if (images != null)
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    foreach (var img in images)
                    {
                        memoryStream.SetLength(0);
                        memoryStream.Seek(0, SeekOrigin.Begin);

                        img.CopyTo(memoryStream);
                        byte[] bytes = memoryStream.ToArray();
                        var base64String = Convert.ToBase64String(bytes);

                        hotelImages.Add(new HotelImage
                        {
                            ImageBase64 = base64String,
                        });
                    }
                }
            }

            return hotelImages;
        }
    }
}
