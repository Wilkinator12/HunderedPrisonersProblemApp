using AutoMapper;
using HunderedPrisonersProblemLibrary.Models;
using WpfUI.Models;

namespace WpfUI.Profiles
{
    public class BoxSelectionProfile : Profile
    {
        public BoxSelectionProfile()
        {
            CreateMap<BoxSelection, BoxSelectionModel>();
            CreateMap<BoxSelectionModel, BoxSelection>();
        }
    }
}
