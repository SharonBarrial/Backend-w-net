using System.ComponentModel.DataAnnotations;

namespace _3_Data;

public class Section :ModelBase
{
   
    //Equivale lo mismo a los properties en la base de datos de la carpeta contex
    [MaxLength(25)] 
    [Required]
    public string Name { get; set; }

}