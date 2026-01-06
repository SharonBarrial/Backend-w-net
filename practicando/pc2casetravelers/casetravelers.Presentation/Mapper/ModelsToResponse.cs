using AutoMapper;
using casetravelers.Infrastructure.Entities;
using casetravelers.Presentation.Publishing.Response;

namespace pc2casetravelers.Presentation.Mapper;

public class ModelsToResponse: Profile
{
    public ModelsToResponse()
    {
        CreateMap<Destination, DestinationResponse>();
    }
}