using AutoMapper;
using casetravelers.Infrastructure.Entities;
using casetravelers.Presentation.Publishing.Request;
using Microsoft.AspNetCore.Http.HttpResults;

namespace pc2casetravelers.Presentation.Mapper;

public class RequestToModels: Profile
{
    public RequestToModels()
    {
        CreateMap<DestinationRequest, Destination>(); 
    }
}