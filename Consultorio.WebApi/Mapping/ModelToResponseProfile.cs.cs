using AutoMapper;
using Consultorio.WebApi.DTOs.Responses;
using Consultorio.WebApi.Models;

namespace Consultorio.WebApi.Mapping
{
    public class ModelToResponseProfile : Profile
    {
        public ModelToResponseProfile()
        {
            CreateMap<Patient, PatientDTO>();
        }
    }
}
