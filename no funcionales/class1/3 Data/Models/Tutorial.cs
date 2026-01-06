namespace _3_Data;

//Modelo de datos
public class Tutorial
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    public int CreatedUser { get; set; }
    
    public bool IsActive { get; set; }
    
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }

}