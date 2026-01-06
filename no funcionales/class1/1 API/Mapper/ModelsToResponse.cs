using _1_API.Response;
using _3_Data;
using AutoMapper;

namespace _1_API.Mapper;

public class ModelsToResponse : Profile
{
    public ModelsToResponse ()
    {
        //Conversión de datos de Tutorial a TutorialResponse
        CreateMap<Tutorial, TutorialResponse>();
        
        //Conversión de datos de la lista Tutorial a la lista TutorialResponse
        //Sirve para el get de todos los tutoriales (gETaLL) 
        CreateMap<List<Tutorial>, List<TutorialResponse>>();
    }
}