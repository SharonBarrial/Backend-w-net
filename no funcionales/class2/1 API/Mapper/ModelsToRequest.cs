using _1_API.Request;
using _3_Data;
using AutoMapper;

namespace _1_API.Mapper;

public class ModelsToRequest :Profile
{
    public ModelsToRequest()
    {
        
        //Conversión de datos de Tutorial a TutorialRequest
        CreateMap<Tutorial, TutorialRequest>();
    }
}