using AutoMapper;
using HunderedPrisonersProblemLibrary.Models;
using WpfUI.Models;

namespace WpfUI.Profiles
{
    public class AttemptProfile : Profile
    {
        public AttemptProfile()
        {
            CreateMap<Attempt, AttemptModel>();
            CreateMap<AttemptModel, Attempt>();
        }
    }
}
