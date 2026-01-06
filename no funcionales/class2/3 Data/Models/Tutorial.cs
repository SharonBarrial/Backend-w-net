using System.ComponentModel.DataAnnotations;

namespace _3_Data;

//Modelo de datos
public class Tutorial :ModelBase
{
    
    //Equivale lo mismo a los properties en la base de datos de la carpeta contex
    [MaxLength(25)] 
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
}