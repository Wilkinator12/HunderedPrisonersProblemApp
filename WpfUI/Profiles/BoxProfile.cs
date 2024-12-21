using AutoMapper;
using HunderedPrisonersProblemLibrary.Models;
using WpfUI.Models;

namespace WpfUI.Profiles
{
    public class BoxProfile : Profile
    {
        public BoxProfile()
        {
            CreateMap<BoxModel, BoxWpfModel>();
            CreateMap<BoxWpfModel, BoxModel>();
        }
    }
}
