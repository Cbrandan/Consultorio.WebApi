using AutoMapper;
using Consultorio.WebApi.DTOs.Requests;
using Consultorio.WebApi.Models;

namespace Consultorio.WebApi.Mapping
{
    public class RequestToModelProfile : Profile
    {
        public RequestToModelProfile()
        {
            CreateMap<PatientAddDTO, Patient>();
            CreateMap<PatientUpdateDTO, Patient>();
        }
    }
}
}
