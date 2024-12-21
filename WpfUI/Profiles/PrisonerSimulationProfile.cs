using AutoMapper;
using HunderedPrisonersProblemLibrary.Models;
using WpfUI.Models;

namespace WpfUI.Profiles
{
    public class PrisonerSimulationProfile : Profile
    {
        public PrisonerSimulationProfile()
        {
            CreateMap<PrisonerSimulationModel, PrisonerSimulationWpfModel>();
            CreateMap<PrisonerSimulationWpfModel, PrisonerSimulationModel>();
        }
    }
}
