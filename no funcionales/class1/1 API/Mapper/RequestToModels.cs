using _1_API.Request;
using _3_Data;
using AutoMapper;

namespace _1_API.Mapper;

public class RequestToModels :Profile
{
    public RequestToModels()
    {
        
        //Conversión de datos de TurorialRequest a Tutorial
        CreateMap<TutorialRequest, Tutorial>();
    }
}