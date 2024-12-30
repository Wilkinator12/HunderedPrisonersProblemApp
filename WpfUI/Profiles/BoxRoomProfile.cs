using AutoMapper;
using HunderedPrisonersProblemLibrary.Models;
using WpfUI.Models;

namespace WpfUI.Profiles
{
    public class BoxRoomProfile : Profile
    {
        public BoxRoomProfile()
        {
            CreateMap<BoxRoom, BoxRoomModel>();
            CreateMap<BoxRoomModel, BoxRoom>();
        }
    }
}
