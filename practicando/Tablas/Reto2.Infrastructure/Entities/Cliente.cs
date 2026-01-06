namespace Reto2.Infrastructure.Entities;

public class Cliente
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Correo { get; set; }
    
    public List<Pedido> Pedidos { get; set; }
}