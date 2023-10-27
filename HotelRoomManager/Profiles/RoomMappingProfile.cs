using AutoMapper;
using HotelRoomManager.Dtos;
using HotelRoomManager.Models;

namespace HotelRoomManager.Profiles
{
    public class RoomMappingProfile : Profile
    {
        public RoomMappingProfile()
        {
            CreateMap<RoomDto, Room>()
                .ForMember(dest => dest.ImageFiles, opt => opt.MapFrom(src => ConvertIFormFileToBase64(src.ImageFiles)));
        }

        private List<RoomImage> ConvertIFormFileToBase64(List<IFormFile> images)
        {
            var roomImages = new List<RoomImage>();

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

                        roomImages.Add(new RoomImage
                        {
                            ImageBase64 = base64String,
                        });
                    }
                }
            }

            return roomImages;
        }
    }
}
