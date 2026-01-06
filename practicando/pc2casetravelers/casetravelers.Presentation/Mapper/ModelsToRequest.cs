using AutoMapper;
using casetravelers.Infrastructure.Entities;
using casetravelers.Presentation.Publishing.Request;

namespace pc2casetravelers.Presentation.Mapper;

/// <summary>
/// 
/// </summary>

public class ModelsToRequest: Profile
{
    /// <summary>
    /// 
    /// </summary>
    public ModelsToRequest()
    {
        CreateMap<Destination, DestinationRequest>();
    }
}