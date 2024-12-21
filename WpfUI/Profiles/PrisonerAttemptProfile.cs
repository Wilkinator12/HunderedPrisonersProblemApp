using AutoMapper;
using HunderedPrisonersProblemLibrary.Models;
using WpfUI.Models;

namespace WpfUI.Profiles
{
    public class PrisonerAttemptProfile : Profile
    {
        public PrisonerAttemptProfile()
        {
            CreateMap<PrisonerAttemptModel, PrisonerAttemptWpfModel>();
            CreateMap<PrisonerAttemptWpfModel, PrisonerAttemptModel>();
        }
    }
}
