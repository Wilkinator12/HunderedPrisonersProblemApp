using AutoMapper;
using HunderedPrisonersProblemLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfUI.Models;

namespace WpfUI.Profiles
{
    public class PrisonerProfile : Profile
    {
        public PrisonerProfile()
        {
            CreateMap<PrisonerModel, PrisonerWpfModel>();
            CreateMap<PrisonerWpfModel, PrisonerModel>();
        }
    }
}
