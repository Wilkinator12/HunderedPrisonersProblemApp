using AutoMapper;
using HunderedPrisonersProblemLibrary.Models;
using WpfUI.Models;

namespace WpfUI.Profiles
{
    public class SimulationProfile : Profile
    {
        public SimulationProfile()
        {
            CreateMap<Simulation, SimulationModel>();
            CreateMap<SimulationModel, Simulation>();
        }
    }
}
